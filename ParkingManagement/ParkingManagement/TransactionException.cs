using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Exceptions
{
    // Exception for issues related to transactions.
    class TransactionException : Exception
    {
        public TransactionException(string message) :
            base(message) { }
    }
}
