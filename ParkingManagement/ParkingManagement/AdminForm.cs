using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkingManagement.Database;
using ParkingManagement.Billing;
using ParkingManagement.External;

namespace ParkingManagement.Forms
{
    // The main form for administrators.
    public partial class AdminForm : Form
    {
        public ParkingDatabase Database { get; set; }
        public IClock AdminClock { get; set; }
        public IMailer Mailer { get; set; }
        public int EmployeeID { get; set; }
        
        public AdminForm(IClock adminClock, IMailer mailer)
        {
            AdminClock = adminClock;
            Mailer = mailer;
            Database = new ParkingDatabase(adminClock, Mailer);
            InitializeComponent();
        }

        // open the garage overview form
        private void garageOverviewButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ParkingSpotOverviewForm parkingOverviewForm = new ParkingSpotOverviewForm(Database, AdminClock, Mailer);
            parkingOverviewForm.ShowDialog();
            this.Visible = true;
        }

        // open the customer overview form
        private void customerOverviewButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            CustomerOverviewForm customerOverviewForm = new CustomerOverviewForm();
            customerOverviewForm.ShowDialog();
            this.Visible = true;
        }

        // open the garage statistics form
        private void statisticsButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            GarageStatisticsForm statisticsForm = new GarageStatisticsForm(this, Database);
            statisticsForm.ShowDialog();
            this.Visible = true;
        }

        // bill users for transactions made in the last month
        // this can be automated, if desired by management
        private void billButton_Click(object sender, EventArgs e)
        {
            List<Bill> bills = new List<Bill>();

            // get lists of customers and transactions
            IEnumerable<Customer> customers = Database.GetCustomerList();
            IEnumerable<Transaction> transactions = Database.GetTransactionList();

            // for each customer, add those transactions made in the last month to a bill
            // add this bill to the list of bills to send out
            foreach (Customer cust in customers)
            {
                var transaction =
                    from trans in transactions
                    where cust.CustomerID == trans.CustomerID
                    where trans.TransactionDate.Month == AdminClock.Now.AddMonths(-1).Month
                    select trans;

                IEnumerable<Transaction> custTransList = transaction.AsEnumerable();

                // only send out bill if customer has transactions for last month
                if (custTransList.Count() > 0)
                {
                    Bill bill = new Bill(cust, custTransList);
                    bills.Add(bill);
                }
            }

            // send out bills to mailer
            Mailer.MailMonthlyBills(bills);
        }

        // logout and return to the previous form
        private void logoutLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

    }
}
