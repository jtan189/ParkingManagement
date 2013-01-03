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

namespace ParkingManagement.Forms
{
    // Form for adding a method of payment.
    public partial class AddPaymentMethodForm : Form
    {
        public ParkingDatabase Database { get; set; }
        public CustomerAccount Customer { get; set; }

        public AddPaymentMethodForm(ParkingDatabase db, CustomerAccount cust)
        {
            Database = db;
            Customer = cust;
            InitializeComponent();
        }

        // Add a payment method.
        private void addButton_Click(object sender, EventArgs e)
        {
            int cardType = cardTypeComboBox.SelectedIndex;

            // validate card number
            if (InputIsValid()) {

                Billing.CreditCard creditCard = new Billing.CreditCard(long.Parse(cardNumberTextBox.Text),
                    (Billing.CreditCard.CreditCardType) cardType);

                // add payment method to database
                Database.AddCreditCard(creditCard, Customer.CustomerID);
                MessageBox.Show("Payment method successfully added.");

                this.Close();
            }
        }

        // verify that user input is valid
        public bool InputIsValid()
        {
            bool inputValid = true;
            long cardNumber;

            // validate card number and card type
            if (cardNumberTextBox.Text.Length != 16 || !long.TryParse(cardNumberTextBox.Text, out cardNumber))
            {
                MessageBox.Show("Card number format is incorrect.");
                inputValid = false;
            }
            else if (cardTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a card type.");
                inputValid = false;
            }

            return inputValid;
        }

        // return to the previous formS
        private void returnLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

    }
}
