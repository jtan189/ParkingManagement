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
    // Form for logging into the application (used by both admins and customers).
    public partial class LoginForm : Form
    {
        public ParkingDatabase Database { get; set; }
        public bool IsAdmin { get; set; }
        IClock LoginClock { get; set; }
        IMailer LoginMailer { get; set; }

        // constructor
        public LoginForm(bool isAdmin, ParkingDatabase database, IClock clock, IMailer mailer)
        {
            IsAdmin = isAdmin;
            Database = database;
            LoginClock = clock;
            LoginMailer = mailer;

            InitializeComponent();

            // if user is an adminitrator, this is the first form
            if (IsAdmin)
            {
                // disable and hide info for returning to previous form
                returnLabel.Text = "";
                returnLabel.Enabled = false;
            }
        }

        // attempt to login the user
        private void loginButton_Click(object sender, EventArgs e)
        {
            bool loginSuccess = false;
            if (!IsAdmin) // is customer
            {
                CustomerAccount accountToLogin = null;
                try
                {
                    // attempt to create account
                    Account accountSent = new Account(emailTextBox.Text, passwordTextBox.Text);

                    // automatically login user with new account
                    Customer cust = Database.LoginCustomer(accountSent);

                    accountToLogin = new CustomerAccount(cust.FirstName, cust.LastName, cust.PhoneNumber, cust.Email, cust.Password);
                    accountToLogin.CustomerID = cust.CustomerID;
                    accountToLogin.RegisteredVehicles = new List<Accounts.Vehicle>();
                    accountToLogin.CreditCards = new List<Billing.CreditCard>();

                    // if not exception thrown at this point, login was successful
                    loginSuccess = true;

                }
                catch (AccountException)
                {
                    MessageBox.Show("Login unsuccessful.");
                }

                // if successful, clear all fields and show the customer form
                if (loginSuccess)
                {
                    CustomerForm custForm = new CustomerForm(accountToLogin, Database, LoginClock, LoginMailer);
                    this.Visible = false;
                    emailTextBox.Clear();
                    passwordTextBox.Clear();
                    custForm.ShowDialog();
                    this.Close();
                }
            }
            else // is admin
            {
                try
                {
                    // attempt to create account object
                    Account accountSent = new Account(emailTextBox.Text, passwordTextBox.Text);

                    // automatically login the administrator with created account object
                    loginSuccess = Database.LoginAdmin(accountSent);
                }
                catch (AccountException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // if successful, clear all fields and show the admin form 
                if (loginSuccess)
                {
                    AdminForm adminMenu = new AdminForm(LoginClock, LoginMailer);
                    this.Visible = false;
                    emailTextBox.Clear();
                    passwordTextBox.Clear();
                    adminMenu.ShowDialog();
                    this.Visible = true;
                }
                else
                {
                    MessageBox.Show("Login unsuccessful.");
                }
            }
        }

        // return to the previous form
        private void returnLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
