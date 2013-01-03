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

namespace ParkingManagement.Forms
{
    // Form for administrators to view a overview of the parkings garage spots
    public partial class ParkingSpotOverviewForm : Form
    {
        public List<Garage.ParkingSpot> ParkingSpots { get; set; }
        public IClock OverviewClock { get; set; }
        public IMailer Mailer { get; set; }
        public ParkingDatabase Database { get; set; }

        // constructors
        public ParkingSpotOverviewForm(ParkingDatabase db, IClock clock, IMailer mailer)
        {
            Database = db;
            this.OverviewClock = clock;
            Mailer = mailer;

            // get parking spots from the database
            ParkingSpots = Database.GetParkingSpots();

            InitializeComponent();

            // set control values
            parkingSpotComboBox.DataSource = ParkingSpots;
            parkingSpotComboBox.DisplayMember = "ParkingSpotID";
            currentTimeLabel.Text = OverviewClock.Now.ToString("g");
        }

        // update the details view to reflect the parking spot that has been selected
        private void parkingSpotComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the parking spot and retrieve any relevant reservation information
            Garage.ParkingSpot selectedSpot = parkingSpotComboBox.SelectedItem as Garage.ParkingSpot;
            ParkingReservation currentReservation = Database.GetRelevantReservation(selectedSpot.ParkingSpotID);

            // set occupancy status
            if (selectedSpot.AvailabilityStatus == Garage.ParkingSpot.Availibility.OCCUPIED)
            {
                // check if customer has overstayed
                if (currentReservation != null && currentReservation.ReservationEndTime < OverviewClock.Now)
                {
                    occupancyLabel.BackColor = Color.IndianRed;
                    occupancyLabel.Text = "Overstaid";
                }
                else
                {
                    occupancyLabel.BackColor = Color.LemonChiffon;
                    occupancyLabel.Text = "Occupied";
                }
            }
            else
            {
                occupancyLabel.BackColor = Color.LightGreen;
                occupancyLabel.Text = "Vacant";
            }

            // fill details
            FillReservationDetails(currentReservation);

            // set load label
            double loadPercentage = 0;
            try
            {
                loadPercentage = Database.GetLoadPercentage();
                loadLabel.Text = loadPercentage.ToString("P1");
            }
            catch (Exception)
            {
                MessageBox.Show("Could not retrieve load percentage.");
            }

            // set load label color based on how full
            if (loadPercentage >= 0 && loadPercentage < 33)
            {
                loadLabel.BackColor = Color.LightGreen;
            }
            else if (loadPercentage < 66)
            {
                loadLabel.BackColor = Color.LemonChiffon;
            }
            else
            {
                loadLabel.BackColor = Color.IndianRed;
            }
        }

        // fill the reservation details labels
        public void FillReservationDetails(ParkingReservation res)
        {
            if (res == null)
            {
                idLabel.Text = "n/a";
                startLabel.Text = "n/a";
                endLabel.Text = "n/a";
                modelLabel.Text = "n/a";
                licenseLabel.Text = "n/a";
            }
            else
            {
                idLabel.Text = res.ReservationID.ToString();
                startLabel.Text = res.Date.ToString("g");
                endLabel.Text = res.ReservationEndTime.ToString("g");
                modelLabel.Text = res.ReservationVehicle.CarModel;
                licenseLabel.Text = res.ReservationVehicle.LicensePlateID;
            }
        }

        // return to the previous form
        private void returnLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        // modify the reservation that has been selected, if any exist
        private void modifyButton_Click(object sender, EventArgs e)
        {
            Garage.ParkingSpot selectedSpot = parkingSpotComboBox.SelectedItem as Garage.ParkingSpot;
            ParkingReservation currentReservation = Database.GetRelevantReservation(selectedSpot.ParkingSpotID);
            if (currentReservation == null)
            {
                MessageBox.Show("No reservation to modify.");
            }
            else
            {
                // show the form for modifying a reservation
                ModifyReservationForm modifyForm = new ModifyReservationForm(this, Database, currentReservation, OverviewClock, Mailer);
                this.Visible = false;
                modifyForm.ShowDialog();

                // update the details view
                currentReservation = Database.GetRelevantReservation(selectedSpot.ParkingSpotID);
                FillReservationDetails(currentReservation);
            }
        }

        // cancel the reservation that has been selected, if any exist
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Garage.ParkingSpot selectedSpot = parkingSpotComboBox.SelectedItem as Garage.ParkingSpot;
            ParkingReservation currentReservation = Database.GetRelevantReservation(selectedSpot.ParkingSpotID);
            if (currentReservation == null)
            {
                MessageBox.Show("No reservation to cancel.");
            }
            else
            {
                // delete the reservation from the database
                Database.CancelReservation(currentReservation);
                MessageBox.Show("Reservation cancelled.");

                // update the details view
                currentReservation = Database.GetRelevantReservation(selectedSpot.ParkingSpotID);
                FillReservationDetails(currentReservation);
            }
        }
    }
}
