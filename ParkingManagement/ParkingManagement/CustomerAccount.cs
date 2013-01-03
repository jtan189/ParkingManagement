using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParkingManagement.Billing;

namespace ParkingManagement.Accounts
{
    // A customer account
    public class CustomerAccount : Account
    {
        public int CustomerID { get; set; }
        public List<Vehicle> RegisteredVehicles { get; set; }
        public List<Billing.CreditCard> CreditCards { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        // constructors
        public CustomerAccount(string firstName, string lastName, string phoneNumber,
            string email, string password) : base(email, password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
        }

        public CustomerAccount(int customerID, string firstName, string lastName, string phoneNumber,
            string email, string password) : base(email, password)
        {
            this.CustomerID = customerID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
        }
    }
}
