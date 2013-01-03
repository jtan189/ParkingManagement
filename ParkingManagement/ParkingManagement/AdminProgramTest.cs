using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkingManagement.Forms;
using ParkingManagement.External;
using ParkingManagement;
using ParkingManagement.Database;
using ParkingManagement.Accounts;
using ParkingManagement.Billing;

namespace ParkingManagement.Test
{
    // Testing class for the administrator program.
    public class AdminProgramTest
    {
        // random number generator, based on ticks in the current time
        private static Random random = new Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// The main entry point for the terminal application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // set up the print, mailer, and barrier external components to be used (stubs for now)
            ITerminalPrinter printer = new TerminalPrinterStub();
            IMailer mailer = new MailerStub();
            IBarrier barrier = new BarrierStub();

            // set up test environment
            // source: http://stackoverflow.com/questions/43711/whats-a-good-way-to-overwrite-datetime-now-during-testing
            DateTime testTime = new DateTime(2012, 12, 30, 13, 1, 0); 
            IClock testClock = new TestClock(testTime); // a static clock for testing

            ParkingDatabase database = new ParkingDatabase(testClock, mailer);

            // fill with database with fake data
            for (int i = 0; i < 80; i++)
            {
                // create a random customer (including vehicle and billing info) and reservation
                CustomerAccount testAccount = new CustomerAccount(RandomString(), RandomString(), "555-555-5555",
                    RandomString() + "@tester.com", "password");
                Billing.CreditCard.CreditCardType randomCardType = (Billing.CreditCard.CreditCardType)random.Next(3);
                Billing.CreditCard testCard = new Billing.CreditCard(1234123412349876, Billing.CreditCard.CreditCardType.MASTERCARD);
                Accounts.Vehicle testVehicle = new Accounts.Vehicle(RandomString() + " " + RandomString(),
                    RandomString());
                DateTime startDate = new DateTime(2012, 12, 30, 10, 0, 0); // date to start generating from
                DateTime testResDate = RandomTime(startDate);

                // add fake customer data to database
                database.AddAccount(testAccount);
                database.AddCreditCard(testCard, testAccount.CustomerID);
                database.AddVehicle(testVehicle, testAccount.CustomerID);
                ParkingReservation testReservation = new ParkingReservation(testAccount, testVehicle,
                    testResDate, 120);

                // generate a random transaction date in the past
                int hours = random.Next(1, 500);
                TimeSpan timeSpan = new TimeSpan(hours, 0, 0);
                DateTime transactionDate = testResDate.Subtract(timeSpan);

                try
                {
                    // add fake reservation data to the database
                    database.AddReservation(testReservation, testCard.CardID, transactionDate);

                    // check in with 50% chance
                    if (random.Next(2) == 0)
                    {
                        // change status of reservation, if reservation is not in the future
                        if (testReservation.Date < testClock.Now)
                        {
                            database.ModifyReservation(testReservation, testReservation.ParkingSpotID,
                                testReservation.Date, testReservation.DurationMinutes, true,
                                testReservation.ReservationVehicle.CarID);

                            // change status of parking garage spot
                            database.SetParkingSpotStatus(testReservation.ParkingSpotID, 1);
                        }
                    }
                }
                catch (Exception)
                { } // conflict when adding reservation (ignore)
            }

            // fill database with fake data for last month
            FillLastMonthData(database, testClock);

            // reminder of admin credentials, for testing
            System.Windows.Forms.MessageBox.Show(
                string.Format("You can login as admin with\nemail: {0}\npassword: {1}",
                "admin100@test.com", "password"));
            Application.Run(new UserForm(testClock, mailer, database, true));
        }

        // generate a random string
        // source: http://stackoverflow.com/questions/1122483/c-sharp-random-string-generator
        private static string RandomString()
        {
            int size = 5;
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        // generate a random date and time
        // source: http://stackoverflow.com/questions/1483670/whats-the-best-practice-for-getting-a-random-date-time-between-two-date-times
        public static DateTime RandomTime(DateTime startDate)
        {
            TimeSpan timeSpan = new TimeSpan(7,0,0);
            TimeSpan newSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);
            DateTime newDate = startDate + newSpan;
            return newDate;
        }

        // fill the database with fake data for last month, using a test clock
        public static void FillLastMonthData(ParkingDatabase database, IClock testClock)
        {
            try
            {
                // fill with database with fake data
                for (int i = 0; i < 80; i++)
                {
                    CustomerAccount testAccount = new CustomerAccount(RandomString(), RandomString(), "555-555-5555",
                        RandomString() + "@tester.com", "password");
                    Billing.CreditCard.CreditCardType randomCardType = (Billing.CreditCard.CreditCardType)random.Next(3);
                    Billing.CreditCard testCard = new Billing.CreditCard(1234123412349876, Billing.CreditCard.CreditCardType.MASTERCARD);
                    Accounts.Vehicle testVehicle = new Accounts.Vehicle(RandomString() + " " + RandomString(),
                        RandomString());
                    DateTime startDate = new DateTime(2012, 11, 25, 10, 0, 0); // 11-25-12 @ 10a
                    DateTime testResDate = RandomTime(startDate);
                    database.AddAccount(testAccount);
                    database.AddCreditCard(testCard, testAccount.CustomerID);
                    database.AddVehicle(testVehicle, testAccount.CustomerID);
                    ParkingReservation testReservation = new ParkingReservation(testAccount, testVehicle,
                        testResDate, 120);

                    // generate a random transaction date in the past
                    int hours = random.Next(1, 500);
                    TimeSpan timeSpan = new TimeSpan(hours, 0, 0);
                    DateTime transactionDate = testResDate.Subtract(timeSpan);

                    // add reservation (and transaction) to database
                    database.AddReservation(testReservation, testCard.CardID, transactionDate);
                }
            }
            catch (Exception)
            { } // confict when adding reservation (ignore)
        }
    }
}
