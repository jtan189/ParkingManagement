using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Billing
{
    // A customer transaction. Each transaction is related to a reservation and is
    // either normal reservation purchase or a fine for overstaying a reservation.
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int CustomerID { get; set; }
        public decimal Amount { get; set; }
        public ParkingReservation Reservation { get; set; }
        public bool IsFine { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
