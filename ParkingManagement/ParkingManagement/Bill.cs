using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParkingManagement.Accounts;

namespace ParkingManagement.Billing
{
    // A customer bill for parking garage transactions (and fines)
    public class Bill
    {
        public Customer Customer { get; set; }
        public IEnumerable<ParkingManagement.Transaction> Transactions { get; set; }
        public decimal Total { get; set; }

        public Bill(Customer account, IEnumerable<ParkingManagement.Transaction> transactions)
        {
            Customer = account;
            Transactions = transactions;
        }

        // get the total charge for the bill
        public decimal TotalCharge
        {
            get
            {
                var charges =
                    from trans in Transactions
                    select trans.Amount;

                return charges.Sum();
            }
        }
    }
}
