using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkingManagement.External;
using ParkingManagement.Database;
using ParkingManagement.Exceptions;
using ParkingManagement.Test;

namespace ParkingManagement.Forms
{
    // Form for the parking garage terminal. Should be displayed at the entrance and exit to the garage,
    // in front of vehicle barriers.
    public partial class TerminalForm : Form
    {
        public IBarrier Barrier { get; set; }
        public ITerminalPrinter Printer { get; set; }
        public ParkingDatabase Database { get; set; }
        private Random rand;
        public IClock TerminalClock { get; set; }
        public IMailer TerminalMailer { get; set; }

        // constructor
        public TerminalForm(IBarrier barrier, ITerminalPrinter printer, IClock termClock, IMailer mailer)
        {
            TerminalMailer = mailer;
            rand = new Random();
            Barrier = barrier;
            Printer = printer;
            TerminalClock = termClock;
            Database = new ParkingDatabase(termClock, TerminalMailer);
            InitializeComponent();
        }

        // validate the user input
        private void ValidateInput()
        {
            try
            {
                // validate reservation number
                Convert.ToInt32(reservationNumTexBox.Text);
            }
            catch (Exception)
            {
                throw new FormatException("Reservation number is invalid.");
            }

            try
            {
                // validate ticket key
                Convert.ToInt32(ticketKeyTextBox.Text);
            }
            catch (Exception)
            {
                throw new FormatException("Ticket key number is invalid.");
            }
        }

        // display details of a parking reservation (after successful check-in)
        public void DisplayDetails(ParkingReservation reservation)
        {
            MessageBox.Show(String.Format("Check-in successful.\n\nReservation ID: {0}\nReservation Ends: {1}\nParking Spot: {2}",
                    reservation.ReservationID, reservation.ReservationEndTime, reservation.ParkingSpotID));
        }

        // allow a vehicle through the barrier
        public void AllowThroughBarrier()
        {
            Barrier.AllowVehicleThrough();
        }

        // check into or out of the parking garage
        private void checkInOutButton_Click(object sender, EventArgs e)
        {
            // make sure input is valid
            try
            {
                ValidateInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // check if reservation exists and retrieve it
            ParkingReservation reservation = null;
            try
            {
                reservation = Database.GetReservation(
                    Convert.ToInt32(reservationNumTexBox.Text));

                // if checked in, then check out; if not checked in, then check in
                if (reservation.IsCheckedIn)
                {
                    CheckOut(reservation);
                }
                else
                {
                    CheckIn(reservation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // check in the parking garage using a reservation
        public void CheckIn(ParkingReservation reservation)
        {

            if (reservation.Date > TerminalClock.Now)
            {
                // reservation period is not yet in effect; notify
                MessageBox.Show(string.Format("Reservation period has not started yet.\nPlease wait until {0}.",
                    reservation.Date.ToShortTimeString()));

            }
            else if (reservation.ReservationEndTime <= TerminalClock.Now)
            {
                // reservation period has passed; notify
                MessageBox.Show(string.Format("Reservation period has passed.\nReservation ended at {0}.",
                    reservation.ReservationEndTime.ToShortTimeString()));
            }
            else
            {
                // reservation period is in effect; check ticket key
                if (reservation.TicketKey != Convert.ToInt32(ticketKeyTextBox.Text))
                {
                    MessageBox.Show("Ticket key is invalid.");
                }
                else
                {
                    // check if currently occupied
                    bool isOccupied = Database.IsOccupied(reservation.ParkingSpotID);

                    if (isOccupied) // parking spot is still occupied by previous customer
                    {
                        // check if other available spots for same time and duration
                        bool cannotOrWillNot = false; // cannot or will not change spots

                        if (!Database.IsOtherParkingSpots(reservation))
                        {
                            cannotOrWillNot = true; // cannot offer another spot
                            MessageBox.Show("Your parking spot has not been vacated. Since the garage is operating at maximum capacity, we are " +
                                "currently unable to offer you a different spot.");
                        }
                        else // offer reservation with new parking spot ID to user
                        {
                            // pick a random other available spot
                            List<Garage.ParkingSpot> otherSpots = Database.GetAvailableParkingSpots(reservation);
                            int newSpotID = otherSpots[rand.Next(0, otherSpots.Count)].ParkingSpotID;

                            // check if user agrees to switch spot
                            DialogResult agreeResult = MessageBox.Show("Your parking spot has not been vacated. Would you like to change your reservation parking spot to " + newSpotID + "?",
                                "Parking spot has not been vacated.", MessageBoxButtons.YesNo);

                            // if agree:
                            if (agreeResult == DialogResult.Yes)
                            {
                                // modifiy original reservation to have new parking spot and set as checked in
                                Database.ModifyReservation(reservation, newSpotID, reservation.Date, reservation.DurationMinutes,
                                    true, reservation.ReservationVehicle.CarID);
                                reservation.ParkingSpotID = newSpotID;

                                // change status of parking spot
                                Database.SetParkingSpotStatus(reservation.ParkingSpotID, 1);

                                // print ticket
                                Printer.PrintReservation(reservation);

                                DisplayDetails(reservation);

                                // lift barrier
                                Barrier.AllowVehicleThrough();
                            }
                            // if disagree:
                            else if (agreeResult == DialogResult.No)
                            {
                                cannotOrWillNot = true;
                            }
                        }

                        // if customer reservation spot has not been vacated, and the customer cannot or will change spots,
                        // then offer the customer the chance to cancel the reservation and drop any charges
                        if (cannotOrWillNot)
                        {
                            // apologize and ask if want to cancel transaction:
                            DialogResult cancelResult = MessageBox.Show("Would you like to cancel your reservation? This will cancel also cancel " +
                                "any charges for the reservation.", "Cancel reservation?", MessageBoxButtons.YesNo);

                            // if agree:
                            if (cancelResult == DialogResult.Yes)
                            {
                                // delete the reservation (and transaction) from the database
                                Database.CancelReservation(reservation);
                                MessageBox.Show("Reservation cancelled.");
                            }
                            else
                            {
                                // if disagree to make change, then inform that they may attempt to check in later
                                MessageBox.Show("You may check back at a later time to check if parking spot has been vacated.");
                            }
                        }

                    }
                    else // parking spot is NOT occupied by previous customer
                    {
                        // display reservation details
                        DisplayDetails(reservation);
                        try
                        {
                            // change status of reservation
                            Database.ModifyReservation(reservation, reservation.ParkingSpotID, reservation.Date,
                                reservation.DurationMinutes, true, reservation.ReservationVehicle.CarID);

                            // change status of parking lot
                            Database.SetParkingSpotStatus(reservation.ParkingSpotID, 1);

                            // lift barrier
                            Barrier.AllowVehicleThrough();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }

                }
            }

            // clear input and wait for next customer
            reservationNumTexBox.Clear();
            ticketKeyTextBox.Clear();
        }

        // check a user out from the garage
        public void CheckOut(ParkingReservation reservation)
        {
            // check if have any fine, due to customer oversaying his or her reservation period
            if (TerminalClock.Now > reservation.ReservationEndTime)
            {
                // if so, create new fine
                TimeSpan diff = TerminalClock.Now.Subtract(reservation.ReservationEndTime);
                decimal fine = decimal.Round((((decimal)diff.TotalMinutes) * (Database.HourlyRate / 60)), 2);

                // insert fine as transaction
                Database.RecordFine(fine, reservation.Customer.CustomerID, reservation.ReservationID,
                    Database.GetDefaultCreditCardID(reservation.Customer.CustomerID));

                // display fine to user
                MessageBox.Show(string.Format("Your checkout is {0:N0} minute(s) overdue. You will be charged a fine of {1:C}.",
                    diff.TotalMinutes, fine));
            }

            // change status of reservation to checked out
            Database.ModifyReservation(reservation, reservation.ParkingSpotID, reservation.Date,
                reservation.DurationMinutes, false, reservation.ReservationVehicle.CarID);

            // change status of parking lot to checked out
            Database.SetParkingSpotStatus(reservation.ParkingSpotID, 0);

            // thank user and allow through barrier
            MessageBox.Show("Thank you for your business.");
            AllowThroughBarrier();

            // clear input
            reservationNumTexBox.Clear();
            ticketKeyTextBox.Clear();
        }
    }
}
