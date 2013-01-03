using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.External
{
    // Interface to be implemented by all ticket printing components.
    public interface ITerminalPrinter
    {
        // print a reservation ticket for the given reservation
        void PrintReservation(ParkingReservation reservation);
    }
}
