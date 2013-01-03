using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.External
{
    // Interface to be implemented by all barrier components
    public interface IBarrier
    {
        // allow a vehicle through the barrier
        void AllowVehicleThrough();
    }
}
