using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParkingManagement.External
{
    // Stub class for the vehicle barrier component
    public class BarrierStub : IBarrier
    {
        // allow a vehicle through the barrier
        public void AllowVehicleThrough()
        {
            MessageBox.Show("Allowing a vehicle through barrier...");
        }
    }
}