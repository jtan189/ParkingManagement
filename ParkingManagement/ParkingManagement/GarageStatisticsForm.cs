using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkingManagement.Database;

namespace ParkingManagement.Forms
{
    // Form for viewing statistics about the parking garage
    public partial class GarageStatisticsForm : Form
    {
        public Form PreviousMenu { get; set; }
        public ParkingDatabase Database { get; set; }

        public GarageStatisticsForm(Form prevMenu, ParkingDatabase database)
        {
            this.PreviousMenu = prevMenu;
            this.Database = database;
            InitializeComponent();
        }

        // Load the statistics form with statistics data
        private void GarageStatisticsForm_Load(object sender, EventArgs e)
        {
            // retrieve the transaction and reservation records from the database
            IEnumerable<Transaction> transactions = Database.GetTransactionList();
            IEnumerable<Reservation> reservations = Database.getReservationList();

            var transactionDates =
                from trans in transactions
                select trans.TransactionDate;

            // get total time values for days, months, and weeks
            TimeSpan totalTime = transactionDates.Max().Subtract(transactionDates.Min());
            double totalDays = totalTime.TotalDays;
            double totalMonths = totalDays / 30;
            double totalWeeks = totalDays / 7;

            // get total income
            // source: http://stackoverflow.com/questions/641682/linq-to-sql-sum-without-group-into
            decimal totalIncome = transactions.AsEnumerable().Sum(o => o.Amount);

            // get total reservations
            int totalReservations = transactions.Count();

            // set labels
            averageIncomePerMonthLabel.Text = GetAverageIncomePerMonth(totalIncome, totalMonths).ToString("C");
            averageIncomePerWeekLabel.Text = GetAverageIncomePerWeek(totalIncome, totalWeeks).ToString("C");
            averageResPerMonthLabel.Text = GetAverageResPerMonth(totalReservations, totalMonths).ToString("N2");
            averageResPerWeekLabel.Text = GetAverageResPerWeek(totalReservations, totalWeeks).ToString("N2");
        }

        // calculate the average income per month
        public double GetAverageIncomePerMonth(decimal totalIncome, double totalMonths)
        {
            return (double) totalIncome / totalMonths;
        }

        // calculate the average income per week
        public double GetAverageIncomePerWeek(decimal totalIncome, double totalWeeks)
        {
            return (double)totalIncome / totalWeeks;
        }

        // calculate the average reservations made per month
        public double GetAverageResPerMonth(int totalReservations, double totalMonths)
        {
            return totalReservations / totalMonths;
        }

        // calculate the average reservations made per week
        public double GetAverageResPerWeek(int totalReservations, double totalWeeks)
        {
            return totalReservations / totalWeeks;
        }

        // return to the previous form
        private void returnLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
