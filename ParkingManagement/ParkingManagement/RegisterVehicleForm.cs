using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkingManagement;
using ParkingManagement.Exceptions;
using ParkingManagement.Accounts;
using ParkingManagement.Database;

namespace ParkingManagement.Forms
{
    // From for registering a vehicle
    public partial class RegisterVehicleForm : Form
    {
        public ParkingDatabase Database { get; set; }
        public CustomerAccount Customer { get; set; }

        public RegisterVehicleForm(ParkingDatabase db, CustomerAccount cust)
        {
            Database = db;
            Customer = cust;
            InitializeComponent();
        }

        // register a vehicle, if input is valid
        private void registerButton_Click(object sender, EventArgs e)
        {

            if (InputIsValid())
            {
                // retrieve the vehicle from the input
                Accounts.Vehicle auto = new Accounts.Vehicle(modelTextBox.Text, plateTextBox.Text);

                // add vehicle to database
                try
                {
                    Database.AddVehicle(auto, Customer.CustomerID);
                }
                catch (Exception)
                {
                    throw new VehicleException("Could not create account in database.");
                }

                MessageBox.Show("Successfully registered vehicle.");
                this.Close();
            }
        }

        // return to the previous form
        private void returnLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        // validate user input
        public bool InputIsValid()
        {
            bool inputValid = true;

            // check if any fields are empty
            if (modelTextBox.Text == "")
            {
                MessageBox.Show("Vehicle make/model field cannot be left empty.");
                inputValid = false;
            }
            else if (plateTextBox.Text == "")
            {
                MessageBox.Show("Licencse plate ID field cannot be left empty.");
                inputValid = false;
            }
            return inputValid;
        }
    }
}
