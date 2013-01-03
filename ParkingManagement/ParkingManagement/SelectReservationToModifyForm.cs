using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkingManagement.Database;
using ParkingManagement.Accounts;
using ParkingManagement.External;

namespace ParkingManagement.Forms
{
    // Form for selecting a reseration to modify.
    public partial class SelectReservationToModifyForm : Form
    {
        // use a binding list (in conjuction with a list objects that notify), in order for element
        // updates to be reflected in the display
        public BindingList<ParkingReservation> Reservations { get; set; }

        public ParkingDatabase Database { get; set; }
        public IClock CustomerClock { get; set; }
        public CustomerAccount Customer { get; set; }
        public IMailer Mailer { get; set; }

        // constructor
        public SelectReservationToModifyForm(ParkingDatabase db, IClock custClock, IMailer mailer, CustomerAccount cust)
        {
            Mailer = mailer;
            Database = db;
            this.CustomerClock = custClock;
            Customer = cust;

            // create a binding list from the database list
            Reservations = new BindingList<ParkingReservation>(Database.GetCurrentAndFutureReservations(Customer.CustomerID));

            InitializeComponent();

            // bind the bindinglist to the combobox datasource
            reservationComboBox.DataSource = Reservations;
            reservationComboBox.DisplayMember = "ReservationID";
        }

        // modify the reservation that is selected
        private void modifyButton_Click(object sender, EventArgs e)
        {
            if (reservationComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a reservation.");
            }
            else
            {
                // retrieve the reservation from the user input information
                ParkingReservation selectedReservation = reservationComboBox.SelectedItem as ParkingReservation;
                ModifyReservationForm modifyForm = new ModifyReservationForm(this, Database, selectedReservation, CustomerClock, Mailer);
                int indexOfChange = reservationComboBox.SelectedIndex;

                // show the form for modifying a reservation
                this.Visible = false;
                modifyForm.ShowDialog();

                // update the details view based on any changes made
                List<ParkingReservation> res = Database.GetCurrentAndFutureReservations(Customer.CustomerID);
                Reservations[indexOfChange].Date = res[indexOfChange].Date;
                Reservations[indexOfChange].DurationMinutes = res[indexOfChange].DurationMinutes;
                Reservations[indexOfChange].ReservationVehicle = res[indexOfChange].ReservationVehicle;
                Reservations[indexOfChange].ParkingSpotID = res[indexOfChange].ParkingSpotID;
                UpdateDetails();
            }
        }

        // cancel a reservation
        private void cancelButton_Click(object sender, EventArgs e)
        {
            // check if any reservation is selected
            if (reservationComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a reservation.");
            }
            else
            {
                ParkingReservation selectedReservation = reservationComboBox.SelectedItem as ParkingReservation;

                // check if cancel is allowed
                if (CancelAllowed(selectedReservation))
                {
                    // cancel the selected reservation    
                    Database.CancelReservation(selectedReservation);
                    MessageBox.Show("Reservation cancelled.");

                    // update list and details view
                    Reservations.Remove(selectedReservation);
                    UpdateDetails();
                }
                else
                {
                    MessageBox.Show("Cancellation not allowed within 24 hours of reservation start.");
                }
            }
        }

        // check if a reservation cancellation is allowed
        public bool CancelAllowed(ParkingReservation resToCancel)
        {
            // determine if the cancellation request is being requested within 24 hours of 
            // the reservation start date
            TimeSpan timeDiff = resToCancel.Date.Subtract(CustomerClock.Now);
            if (timeDiff.TotalHours < 24)
            {
                return false; // cannot be < 24 hours away
            }
            else
            {
                return true;
            }
        }

        // update the reservation details when the selected item changes
        private void reservationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDetails();
        }

        // return to the previous form
        private void returnLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        // update the details of the form, based on the selected reservation
        private void UpdateDetails()
        {
            ParkingReservation selectedReservation = reservationComboBox.SelectedItem as ParkingReservation;
            if (selectedReservation != null)
            {
                dateLabel.Text = selectedReservation.Date.ToString("g");
                durationLabel.Text = selectedReservation.DurationMinutes + " minutes";
                modelLabel.Text = selectedReservation.ReservationVehicle.CarModel;
                licenseLabel.Text = selectedReservation.ReservationVehicle.LicensePlateID;
                spotLabel.Text = selectedReservation.ParkingSpotID.ToString();
            }
            else
            {
                // no reservation selected
                dateLabel.Text = "n/a";
                durationLabel.Text = "n/a";
                modelLabel.Text = "n/a";
                licenseLabel.Text = "n/a";
                spotLabel.Text = "n/a";
            }
        }
    }
}
