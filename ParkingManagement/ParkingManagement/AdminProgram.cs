using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ParkingManagement.Forms;
using ParkingManagement.External;

namespace ParkingManagement
{
    // Main program for starting the administrator GUI.
    static class AdminProgram
    {
        /// <summary>
        /// The main entry point for the admin application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // set the clock and mailing component to be used
            IClock clock = new SystemClock();
            IMailer mailer = new MailerStub();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AdminForm(clock, mailer));
        }
    }
}
