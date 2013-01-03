using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Exceptions
{
    // Exception for issues related to reservations.
    class ReservationException : Exception
    {
        public ReservationException(string message)
            : base(message) {}
    }
}
