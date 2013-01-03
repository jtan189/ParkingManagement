using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkingManagement.Accounts;
using ParkingManagement.Database;
using ParkingManagement.Exceptions;
using ParkingManagement.External;

namespace ParkingManagement.Forms
{
    // The main form for a customer
    public partial class CustomerForm : Form
    {
        public ParkingDatabase Database { get; set; }
        public CustomerAccount Customer { get; set; }
        public IClock CustomerClock { get; set; }
        public IMailer Mailer { get; set; }

        public CustomerForm(CustomerAccount cust, ParkingDatabase db, IClock clock, IMailer mailer)
        {
            CustomerClock = clock;
            Mailer = mailer;
            InitializeComponent();
            Customer = cust;
            Database = db;
        }

        // create a reservation
        private void createReservationButton_Click(object sender, EventArgs e)
        {
            try
            {
                // will throw exception if user has not registered any vehicles
                Database.GetVehicles(Customer.CustomerID);

                // show the form for creating a reservation
                CreateReservationForm addResForm = new CreateReservationForm(Database, Customer);
                this.Visible = false;
                addResForm.ShowDialog();
                this.Visible = true;
            }
            catch (VehicleException)
            {
                // if user has not registered a vehicle, direct them to do so before creating a reservation
                MessageBox.Show("Please register a vehicle first.");
            }
        }

        // show the form for modifying a reservation
        private void modifyReservationButton_Click(object sender, EventArgs e)
        {
            // check if user has created any reservations to modify
            List<ParkingReservation> Reservations = Database.GetCurrentAndFutureReservations(Customer.CustomerID);
            if (Reservations.Count() == 0)
            {
                MessageBox.Show("No reservation to modify.");
            }
            else
            {
                // show the form for modifying a reservation
                SelectReservationToModifyForm modifyReservationForm = new SelectReservationToModifyForm(Database, CustomerClock, Mailer, Customer);
                this.Visible = false;
                modifyReservationForm.ShowDialog();
                this.Visible = true;
            }
        }

        // show the previous form
        private void returnLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        // show the form for registering a vehicle
        private void registerVehicleButton_Click(object sender, EventArgs e)
        {
            RegisterVehicleForm vehicleForm = new RegisterVehicleForm(Database, Customer);
            this.Visible = false;
            vehicleForm.ShowDialog();
            this.Visible = true;
        }

        // show the form for adding a method of payment
        private void paymentButton_Click(object sender, EventArgs e)
        {
            AddPaymentMethodForm paymentMethodForm = new AddPaymentMethodForm(Database, Customer);
            this.Visible = false;
            paymentMethodForm.ShowDialog();
            this.Visible = true;
        }
    }
}
