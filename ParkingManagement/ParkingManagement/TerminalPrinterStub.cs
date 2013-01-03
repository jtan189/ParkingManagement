using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParkingManagement.External
{
    // Stub class for testing a terminal printer component
    class TerminalPrinterStub : ITerminalPrinter
    {
        public void PrintReservation(ParkingReservation reservation)
        {
            MessageBox.Show("Printing ticket for reservation " + reservation.ReservationID + ".");
        }
    }
}
