using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Exceptions
{
    // An exception related to accounts.
    class AccountException : Exception
    {
        public AccountException(string message)
            : base(message)  { }
    }
}
