using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParkingManagement.Billing;

namespace ParkingManagement.External
{
    // Interface to be implemented by all mailing components
    public interface IMailer
    {
        // mail the list of bills for the previous month
        void MailMonthlyBills(List<Bill> bills);
        
        // mail a reservation receipt to the customer who created it
        void MailReservationReceipt(ParkingReservation reservation);
    }
}
