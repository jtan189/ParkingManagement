using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Exceptions
{
    // Exception for issues related to parking spots
    class ParkingSpotException : Exception
    {
        public ParkingSpotException(string message)
            : base(message) { }
    }
}
