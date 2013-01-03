using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ParkingManagement.Forms;
using ParkingManagement.External;

namespace ParkingManagement
{
    // Main program for running the terminal GUI.
    static class TerminalProgram
    {
        /// <summary>
        /// The main entry point for the terminal application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // initialize printer, barrier, clock, and mailer components to be used in the application
            ITerminalPrinter printer = new TerminalPrinterStub();
            IBarrier barrier = new BarrierStub();
            IClock terminalClock = new SystemClock();
            IMailer mailer = new MailerStub();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TerminalForm(barrier, printer, terminalClock, mailer));
        }
    }
}
