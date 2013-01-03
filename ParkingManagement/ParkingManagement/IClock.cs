using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement
{
    // interface for a clock used in the application
    public interface IClock
    {
        // get the current date and time
        DateTime Now { get; } 
    }
}
