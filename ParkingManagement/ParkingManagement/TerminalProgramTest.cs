using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ParkingManagement.Forms;
using ParkingManagement.External;
using ParkingManagement;
using ParkingManagement.Database;
using ParkingManagement.Accounts;
using ParkingManagement.Billing;
using ParkingManagement.Exceptions;

namespace ParkingManagement.Test
{
    // Main program for testing the corrrect functioning of the Terminal program and GUI.
    static class TerminalProgramTest
    {
        /// <summary>
        /// The main entry point for the terminal application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // set up test environment
                // source: http://stackoverflow.com/questions/43711/whats-a-good-way-to-overwrite-datetime-now-during-testing
                ITerminalPrinter printer = new TerminalPrinterStub();
                IMailer mailer = new MailerStub();
                IBarrier barrier = new BarrierStub();
                DateTime testTime = new DateTime(2012, 12, 30, 13, 1, 0);
                IClock testClock = new TestClock(testTime);
                ParkingDatabase database = new ParkingDatabase(testClock, mailer);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // create reservation - 
                // case where check-in should encounter no problems
                CustomerAccount testAccount = new CustomerAccount("John", "Doe", "218-232-1243",
                    "tester@ndsu.edu", "password");
                Billing.CreditCard testCard = new Billing.CreditCard(1234123412349876, Billing.CreditCard.CreditCardType.MASTERCARD);
                Accounts.Vehicle testVehicle = new Accounts.Vehicle("Honda Civic", "VGB2342");
                DateTime testResDate = new DateTime(2012, 12, 30, 13, 0, 0); // 12-30-12 @ 1PM
                database.AddAccount(testAccount);
                database.AddCreditCard(testCard, testAccount.CustomerID);
                database.AddVehicle(testVehicle, testAccount.CustomerID);
                ParkingReservation testReservation = new ParkingReservation(testAccount, testVehicle,
                    testResDate, 15);
                database.AddReservation(testReservation, testCard.CardID, 1);

                // create reservation - 
                // case where check-in should not be allowed (too early)
                DateTime testResDate2 = new DateTime(2012, 12, 30, 14, 0, 0); // 12-30-12 @ 2PM
                ParkingReservation testReservation2 = new ParkingReservation(testAccount, testVehicle,
                    testResDate2, 15);
                database.AddReservation(testReservation2, testCard.CardID);

                // create reservation - 
                // case where check-in should not be allowed (too late)
                DateTime testResDate3 = new DateTime(2012, 12, 30, 11, 0, 0); // 12-30-12 @ 11AM
                ParkingReservation testReservation3 = new ParkingReservation(testAccount, testVehicle,
                    testResDate3, 15);
                database.AddReservation(testReservation3, testCard.CardID);

                // create reservation - 
                // case where spot still taken
                // if testReservation1 is not checked out and testReservation5 is not checked out, then will be rejected
                // if testReservation1 is not checked out and testReservation5 is checked out, then will be able to change spots
                DateTime testResDate4 = new DateTime(2012, 12, 30, 13, 0, 0); // 12-30-12 @ 1PM
                ParkingReservation testReservation4 = new ParkingReservation(testAccount, testVehicle,
                    testResDate4, 15);
                database.AddReservation(testReservation4, testCard.CardID, 1);

                // create reservation -
                // checked in a long time ago (should have a fine when check out)
                DateTime testResDate5 = new DateTime(2012, 12, 29, 13, 0, 0); // 12-30-12 @ 1PM
                ParkingReservation testReservation5 = new ParkingReservation(testAccount, testVehicle,
                    testResDate5, 15);
                try
                {
                    database.AddReservation(testReservation5, testCard.CardID, 2);
                }
                catch (ParkingSpotException) // reservation conflicts with existing one
                {
                }
                // change status of reservation (check in testReservation5)
                database.ModifyReservation(testReservation5, testReservation5.ParkingSpotID,
                    testReservation5.Date, testReservation5.DurationMinutes, true,
                    testReservation5.ReservationVehicle.CarID);

                // change status of parking spot for testReservation5 to occupied
                database.SetParkingSpotStatus(testReservation5.ParkingSpotID, 1);

                // fill other 98 spots for 1PM reservation time
                for (int i = 3; i <= 100; i++)
                {
                    DateTime testResDateFiller = new DateTime(2012, 12, 30, 13, 0, 0); // 12-30-12 @ 1PM
                    ParkingReservation testReservationFiller = new ParkingReservation(testAccount, testVehicle,
                        testResDate, 15);

                    // add reservation to database
                    database.AddReservation(testReservationFiller, testCard.CardID);

                    // mark reservation as checked in
                    database.ModifyReservation(testReservationFiller, testReservationFiller.ParkingSpotID,
                        testReservationFiller.Date, testReservationFiller.DurationMinutes, true,
                        testReservationFiller.ReservationVehicle.CarID);

                    // change status of parking spot to occupied
                    database.SetParkingSpotStatus(testReservationFiller.ParkingSpotID, 1);
                }

                // show reservation number and ticket ID of test reservations, for testing purposes
                System.Windows.Forms.MessageBox.Show(string.Format("Reservation Number 1 (No Issues): {0}\nTicket Key: {1}\n\n" +
                "Reservation Number 2 (Too Early): {2}\nTicket Key: {3}\n\n" +
                "Reservation Number 3 (Too Late): {4}\nTicket Key: {5}\n\n" +
                "Reservation Number 4 (Conflict if Reservation 1 not check out - situation changes if Reservation 5 is checked out): {6}\nTicket Key: {7}\n\n" +
                "Reservation Number 5 (Should have fine when checkout): {8}\nTicket Key: {9}",
                 testReservation.ReservationID, testReservation.TicketKey,
                 testReservation2.ReservationID, testReservation2.TicketKey,
                 testReservation3.ReservationID, testReservation3.TicketKey,
                 testReservation4.ReservationID, testReservation4.TicketKey,
                 testReservation5.ReservationID, testReservation5.TicketKey
                 ));
                Application.Run(new TerminalForm(barrier, printer, testClock, mailer));

            }
            catch (Exception)
            {
                // conflict because database has not been cleared
                MessageBox.Show("Clean project before running.");
            }
        }
    }
}
