using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement
{
    // Concrete implementation of the IClock. Use for code that will be deployed in
    // the actual business environment.
    public class SystemClock : IClock
    {
        // return the actual current date and time
        public DateTime Now { get { return DateTime.Now; } }
    }
}
