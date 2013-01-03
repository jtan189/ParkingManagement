using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParkingManagement.External
{
    // Stub class for a mailing component (used for testing).
    class MailerStub : IMailer
    {
        // mail the customer bills for the previous month
        // this will just show a message box, to demonstrate correct functioning
        public void MailMonthlyBills(List<Billing.Bill> bills)
        {
            MessageBox.Show(string.Format("Mailing {0} monthly bills...", bills.Count()));
        }

        // mail a receipt for a reservation to the customer who created it
        // this will just show a message box, to demonstrate correct functioning
        public void MailReservationReceipt(ParkingReservation reservation)
        {
            Console.WriteLine("Mailing reservation receipt...");
        }
    }
}
