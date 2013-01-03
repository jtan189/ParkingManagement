using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Exceptions
{
    // An exception for issues related to vehicles.
    class VehicleException : Exception
    {
        public VehicleException(string message)
            : base(message) {}
    }
}
