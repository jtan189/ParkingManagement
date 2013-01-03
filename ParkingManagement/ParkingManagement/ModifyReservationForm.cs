using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkingManagement.Database;
using ParkingManagement.Exceptions;
using ParkingManagement.External;

namespace ParkingManagement.Forms
{
    // Form for modifying a reservation.
    public partial class ModifyReservationForm : Form
    {
        public Form PreviousMenu { get; set; }
        public ParkingDatabase Database { get; set; }
        public ParkingReservation OldReservation { get; set; }
        public List<Accounts.Vehicle> VehicleList { get; set; }
        public List<Billing.CreditCard> CardList { get; set; }
        public IClock ModificationClock { get; set; }
        public IMailer Mailer { get; set; }
        private Random rand;

        // constructor
        public ModifyReservationForm(Form prevMenu, ParkingDatabase database,
            ParkingReservation reservationToModify, IClock clock, IMailer mailer)
        {
            rand = new Random();
            Mailer = mailer;
            ModificationClock = clock;
            this.PreviousMenu = prevMenu;
            this.Database = database;
            OldReservation = reservationToModify;
            VehicleList = Database.GetVehicles(OldReservation.Customer.CustomerID);
            CardList = Database.GetCreditCards(OldReservation.Customer.CustomerID);

            InitializeComponent();

            // bind the vehicle combo box to the vehicle list
            vehicleComboBox.DataSource = VehicleList;
            vehicleComboBox.DisplayMember = "AsString";

            // set initial values based on current reservation details
            desiredMonthCalendar.MaxSelectionCount = 1;
            desiredMonthCalendar.SelectionStart = OldReservation.Date;
            desiredTimeDateTimePicker.Value = OldReservation.Date;
            durationComboBox.SelectedIndex = MinutesToDurationIndex(OldReservation.DurationMinutes);
            vehicleComboBox.SelectedItem = OldReservation.ReservationVehicle;
        }

        // return to the previous form
        private void returnLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        // convert the duration combobox index to an integer minute amount
        public int DurationIndexToMinutes(int index)
        {
            int minutes = 0;
            switch (index)
            {
                case 0:
                    minutes = 30;
                    break;
                case 1:
                    minutes = 60;
                    break;
                case 2:
                    minutes = 90;
                    break;
                case 3:
                    minutes = 120;
                    break;
            }
            return minutes;
        }

        // convert an integer minute amount to the appropriate combobox index
        public int MinutesToDurationIndex(int minutes)
        {
            int index = 0;
            switch (minutes)
            {
                case 30:
                    index = 0;
                    break;
                case 60:
                    index = 2;
                    break;
                case 90:
                    index = 2;
                    break;
                case 120:
                    index = 3;
                    break;
            }
            return index;
        }

        // attempt to modify the reservation
        private void modifyButton_Click(object sender, EventArgs e)
        {
            // retrieve the desired reservation date from the input
            DateTime desiredDate = new DateTime(desiredMonthCalendar.SelectionStart.Year,
                desiredMonthCalendar.SelectionStart.Month,
                desiredMonthCalendar.SelectionStart.Day,
                desiredTimeDateTimePicker.Value.Hour,
                desiredTimeDateTimePicker.Value.Minute, 0);

            // retrieve the desired vehicle from the input
            Accounts.Vehicle desiredVehicle = vehicleComboBox.SelectedItem as Accounts.Vehicle;
            ParkingReservation newReservation = null;

            try
            {
                // create the new version of the reservation
                newReservation = new ParkingReservation(OldReservation.ReservationID,
                    OldReservation.Customer, desiredVehicle, desiredDate,
                    DurationIndexToMinutes(durationComboBox.SelectedIndex),
                    OldReservation.ParkingSpotID, OldReservation.TicketKey, false);

                // check if modification is valid (does not conflict with another reservation)
                if (Database.ReservationModificationValid(OldReservation, newReservation))
                {
                    bool isAllowed = true; // by default, allowed

                    // check if modifications are being attempted by a customer
                    if (PreviousMenu is SelectReservationToModifyForm) // is customer
                    {
                        isAllowed = false;

                        // check if modification is only an extension (date, vehicle, and time must be the same)
                        // (modification only allowed before reservation start; customer extensions allowed whenever)
                        if (OldReservation.Date == desiredDate &&
                            OldReservation.ReservationVehicle.CarID == desiredVehicle.CarID &&
                            OldReservation.DurationMinutes < newReservation.DurationMinutes)
                        {
                            // just extending 
                            isAllowed = true;
                        }
                        else
                        {
                            // attempting to make non-extension modifcation (don't allow if already started)
                            // if desired is now or in the past, then do not continue
                            if (desiredDate <= DateTime.Now)
                            {
                                MessageBox.Show("Please select a reservation date and time that is in the future.");
                                
                            }
                            else if (OldReservation.Date <= ModificationClock.Now)
                            {

                                MessageBox.Show("Modifications to reservation date or vehicle not allowed after " +
                                    "start of reservation period.");
                            }
                            else
                            {
                                isAllowed = true;
                            }
                        }
                    }

                    // if the modiciation is allowed, process it
                    if (isAllowed)
                    {
                        // modify the reservation in the database
                        Database.ModifyReservation(OldReservation, newReservation.ParkingSpotID,
                            newReservation.Date, newReservation.DurationMinutes, newReservation.IsCheckedIn,
                            newReservation.ReservationVehicle.CarID);

                        // display result
                        MessageBox.Show(String.Format("Successfully modified reservation:\nReservation ID: {0}\nDate and Time: {1}\nDuration: {2} minutes\nParking Spot: {3}\nTicket Key: {4}",
                            newReservation.ReservationID, newReservation.Date, newReservation.DurationMinutes,
                            newReservation.ParkingSpotID, newReservation.TicketKey));

                        // mail receipt of the modification
                        Mailer.MailReservationReceipt(newReservation);
                    }
                }
                else
                {
                    // if reservation already started, then can't modify spot
                    if (OldReservation.Date < ModificationClock.Now)
                    {
                        MessageBox.Show("Cannot extend reservation period for your parking spot.");
                    }
                    else
                    {
                        // check if other available spots for same time and duration
                        if (!Database.IsOtherParkingSpots(newReservation))
                        {
                            MessageBox.Show("Modified reservation period is not available.");
                        }
                        else // another spot is available
                        {
                            // offer new reservation to user
                            List<Garage.ParkingSpot> otherSpots = Database.GetAvailableParkingSpots(newReservation);

                            // pick a random spot from the available spots
                            int newSpotID = otherSpots[rand.Next(0, otherSpots.Count)].ParkingSpotID;

                            // check if user wishes to make spot change
                            DialogResult agreeResult = MessageBox.Show("Your parking spot is not available for that reservation period. " +
                                "Would you like to change your reservation parking spot to " + newSpotID + "?",
                                "Parking spot not available at that time.", MessageBoxButtons.YesNo);

                            // if agree:
                            if (agreeResult == DialogResult.Yes)
                            {
                                // modifiy original reservation to have new parking spot
                                Database.ModifyReservation(newReservation, newSpotID, newReservation.Date, newReservation.DurationMinutes,
                                    false, newReservation.ReservationVehicle.CarID);
                                newReservation.ParkingSpotID = newSpotID;

                                // print ticket
                                Mailer.MailReservationReceipt(newReservation);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (ReservationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
