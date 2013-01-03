using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Exceptions
{
    // Exception for creating accounts
    class CreateAccountException : Exception
    {
        public CreateAccountException(string message)
            : base(message) { }
    }
}
