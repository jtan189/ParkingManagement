using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ParkingManagement.Forms;
using ParkingManagement.External;
using ParkingManagement.Database;

namespace ParkingManagement
{
    // Main program for starting the customer GUI.
    static class CustomerProgram
    {
        /// <summary>
        /// The main entry point for the customer application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // define the clock, database, and mailing component to be used
            IClock clock = new SystemClock();
            IMailer mailer = new MailerStub();
            ParkingDatabase database = new ParkingDatabase(clock, mailer);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserForm(clock, mailer, database, false));
        } 
    }
}
