using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkingManagement.Accounts;
using ParkingManagement.Exceptions;
using ParkingManagement.Billing;
using System.Text.RegularExpressions;
using ParkingManagement.Database;
using ParkingManagement.External;

namespace ParkingManagement.Forms
{
    // Form for creating a customer account
    public partial class CreateAccountForm : Form
    {
        public ParkingDatabase Database { get; set; }
        public IClock FormClock { get; set; }
        public IMailer Mailer { get; set; }

        public CreateAccountForm(ParkingDatabase db, IClock clock, IMailer mailer)
        {
            Database = db;
            FormClock = clock;
            Mailer = mailer;
            InitializeComponent();
        }

        // create a customer account
        private void createButton_Click(object sender, EventArgs e)
        {
            bool createAccountSuccess = false;
            bool createCardSuccess = false;
            CustomerAccount accountToCreate = null;

            try
            {
                // attempt to create account
                accountToCreate = new CustomerAccount(firstNameTextBox.Text, lastNameTextBox.Text, phoneNumberTextBox.Text,
                   emailTextBox.Text, passwordTextBox.Text);

                // create customer account and pass to method
                CreateAccount(accountToCreate);
                createAccountSuccess = true;
            }
            catch (CreateAccountException ex)
            {
                // if error, show the error and quit
                MessageBox.Show(ex.Message);
                return;
            }

            // automatically login user with new account
            Customer cust = Database.LoginCustomer(accountToCreate);
            accountToCreate = new CustomerAccount(cust.FirstName, cust.LastName, cust.PhoneNumber, cust.Email, cust.Password);
            accountToCreate.CustomerID = cust.CustomerID;
            accountToCreate.CreditCards = new List<Billing.CreditCard>();
            accountToCreate.RegisteredVehicles = new List<Accounts.Vehicle>();

            // create credit card
            try
            {
                CreateCreditCard(accountToCreate);
                createCardSuccess = true;
            }
            catch (CreditCardException ex)
            {
                // if error creating the customer credit card, show the error message
                MessageBox.Show(ex.Message);
            }

            // if successful, show the customer form
            if (createAccountSuccess && createCardSuccess)
            {
                CustomerForm custForm = new CustomerForm(accountToCreate, Database, FormClock, Mailer);
                this.Visible = false;
                custForm.ShowDialog();
            }

            // afterwards, close this form
            this.Close();
        }

        // create a customer account in the database
        public void CreateAccount(CustomerAccount accountToCreate)
        {
            long cardNumber;

            // validate input
            if (accountToCreate.FirstName.Equals(""))
            {
                throw new CreateAccountException("First name cannot be left empty.");
            }
            if (accountToCreate.LastName.Equals(""))
            {
                throw new CreateAccountException("Last name cannot be left empty.");
            }
            if (accountToCreate.EmailAddress.Equals(""))
            {
                throw new CreateAccountException("Email cannot be left empty.");
            }
            if (accountToCreate.Password.Equals(""))
            {
                throw new CreateAccountException("Password field cannot be left empty.");
            }
            if (cardNumberTextBox.Text.Length != 16 || !long.TryParse(cardNumberTextBox.Text, out cardNumber))
            {
                throw new CreateAccountException("Card number format is incorrect.");
            }
            if (cardTypeComboBox.SelectedIndex == -1)
            {
                throw new CreateAccountException("You must select a credit card type.");
            }
            if (!EmailIsValid(accountToCreate.EmailAddress))
            {
                throw new CreateAccountException("Email is not valid.");
            }
            if (!PhoneNumberIsValid(accountToCreate.PhoneNumber))
            {
                throw new CreateAccountException("Phone number is not valid.");
            }

            // add account to database
            try
            {
                Database.AddAccount(accountToCreate);
            }
            catch (CreateAccountException)
            {
                throw new CreateAccountException("Could not create account in database.");
            }
        }

        // create a customer credit card in the database
        public void CreateCreditCard(CustomerAccount cust)
        {
            // validate card number and create in database
            Billing.CreditCard.CreditCardType cardType = (Billing.CreditCard.CreditCardType)cardTypeComboBox.SelectedIndex;
            long cardNumber;
            if ( !long.TryParse(cardNumberTextBox.Text, out cardNumber))
            {
                throw new CreditCardException("Card number format is incorrect.");
            }
            else
            {
                // add credit card to database tables
                Billing.CreditCard creditCard = new Billing.CreditCard(cardNumber, (Billing.CreditCard.CreditCardType)cardType);
                Database.AddCreditCard(creditCard, cust.CustomerID);
                cust.CreditCards.Add(creditCard);
            }
        }

        // validate email input
        //source: http://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
        public bool EmailIsValid(string email)
        {
            return Regex.IsMatch(email, @"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$");
        }

        // validate phone number input
        // source: http://social.msdn.microsoft.com/Forums/en/csharpgeneral/thread/35a98673-1c5e-4c2b-8a87-6c7bd5742dd4
        public bool PhoneNumberIsValid(string number)
        {
            return Regex.IsMatch(number, @"^(\(?[0-9]{3}\)?)?\-?[0-9]{3}\-?[0-9]{4}$");
        }

        // return to the previous form
        private void returnLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }

}
