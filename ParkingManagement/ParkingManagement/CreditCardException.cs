using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Exceptions
{
    // Exception for issues related to credit cards
    class CreditCardException : Exception
    {
        public CreditCardException(string message)
            : base(message) { }
    }
}
