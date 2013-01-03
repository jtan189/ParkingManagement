using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Test
{
    // Concrete implementation of the IClock. Use for code that will not be deployed in
    // the actual business environment. This implementation should be used for testing.
    public class TestClock : IClock
    {
        public DateTime StaticTime { get; set; }

        // constructor that initializes the static time to be used
        public TestClock(DateTime staticTime)
        {
            StaticTime = staticTime;
        }

        // return the static time for this test clock
        public DateTime Now { get { return StaticTime; } }
    }
}
