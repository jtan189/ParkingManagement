using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkingManagement.ParkingManagementDataSetTableAdapters;
using ParkingManagement;
using ParkingManagement.Exceptions;
using ParkingManagement.Database;
using ParkingManagement.Accounts;

namespace ParkingManagement.Forms
{
    // Form for creating a customer reservation
    public partial class CreateReservationForm : Form
    {
        public List<Accounts.Vehicle> VehicleList { get; set; }
        public List<Billing.CreditCard> CardList { get; set; }
        public ParkingDatabase Database { get; set; }
        public CustomerAccount Customer { get; set; }

        // Constuctor for initalizing this form
        // source: http://stackoverflow.com/questions/600869/how-to-bind-a-list-to-a-combobox-winforms
        public CreateReservationForm(ParkingDatabase db, CustomerAccount customer)
        {
            Database = db;
            Customer = customer;
            VehicleList = Database.GetVehicles(Customer.CustomerID);
            CardList = Database.GetCreditCards(Customer.CustomerID);
            InitializeComponent();
            vehicleComboBox.DataSource = VehicleList;
            vehicleComboBox.DisplayMember = "AsString";
            paymentMethodComboBox.DataSource = CardList;
            paymentMethodComboBox.DisplayMember = "AsString";
            desiredMonthCalendar.MaxSelectionCount = 1;
        }

        // return to the previous form
        private void returnLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        // check the availability of the provided reservation and add (if available)
        private void checkAvailabilityButton_Click(object sender, EventArgs e)
        {
            if (InputIsValid())
            {
                // retrieve the desired date based on the input
                DateTime desiredDate = new DateTime(
                    desiredMonthCalendar.SelectionStart.Year,
                    desiredMonthCalendar.SelectionStart.Month,
                    desiredMonthCalendar.SelectionStart.Day,
                    desiredTimeDateTimePicker.Value.Hour,
                    desiredTimeDateTimePicker.Value.Minute, 0);

                // retrieve the vehicle based on the input
                Accounts.Vehicle desiredVehicle = vehicleComboBox.SelectedItem as Accounts.Vehicle;
                
                // create the reservation, based on the input
                ParkingReservation reservation = null;
                try
                {
                    reservation = new ParkingReservation(Customer,
                        desiredVehicle, desiredDate, Convert.ToInt32(
                        DurationIndexToMinutes(durationComboBox.SelectedIndex)));

                    // add reservation to database
                    Billing.CreditCard chosenCard = paymentMethodComboBox.SelectedItem as Billing.CreditCard;
                    int cardID = chosenCard.CardID;
                    reservation = Database.AddReservation(reservation, cardID);

                    // display result
                    MessageBox.Show(String.Format("Successfully created new reservation:\nReservation ID: {0}\nDate and Time: {1}\nDuration: {2} minutes\nParking Spot: {3}\nTicket Key: {4}",
                        reservation.ReservationID, reservation.Date, reservation.DurationMinutes, reservation.ParkingSpotID, reservation.TicketKey));

                    this.Close();
                }
                catch (ReservationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // validate user input
        public bool InputIsValid()
        {
            bool inputValid = true;
            DateTime desiredDate = new DateTime(
                    desiredMonthCalendar.SelectionStart.Year,
                    desiredMonthCalendar.SelectionStart.Month,
                    desiredMonthCalendar.SelectionStart.Day,
                    desiredTimeDateTimePicker.Value.Hour,
                    desiredTimeDateTimePicker.Value.Minute, 0);

            if (vehicleComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("No vehicle selected.");
                inputValid = false;
            }
            else if (paymentMethodComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("No payment method selected.");
                inputValid = false;
            }
            else if (durationComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a reservation duration.");
                inputValid = false;
            }
            // if desired date is now or in the past, then do not continue
            else if (desiredDate <= DateTime.Now)
            {
                MessageBox.Show("Please select a reservation date and time that is in the future.");
                inputValid = false;
            }

            return inputValid;
        }
        
        // convert the duration combobox input to a integer for minutes
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
    }
}
