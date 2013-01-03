using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Accounts
{
    // An Parking Management account.
    public class Account
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public Account(string email, string password)
        {
            this.EmailAddress = email;
            this.Password = password;
        }
    }
}
