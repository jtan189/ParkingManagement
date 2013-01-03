using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Garage
{
    // A parking spot in a garage
    public class ParkingSpot
    {
        public int ParkingSpotID { get; set; }
        public Availibility AvailabilityStatus { get; set; }

        // enum for the availability of parking spot
        public enum Availibility
        {
            VACANT = 0,
            OCCUPIED = 1,
        }
    }
}
