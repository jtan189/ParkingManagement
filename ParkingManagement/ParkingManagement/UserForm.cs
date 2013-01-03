using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParkingManagement.Database;
using ParkingManagement.Accounts;
using ParkingManagement.External;

namespace ParkingManagement.Forms
{
    /* 
     * Startup form for all users. For both customer and admins, this will allow
     * a use to transition to the form for logging in. For customers, this will
     * allow them to also create an account.
     */
    public partial class UserForm : Form
    {
        ParkingDatabase database;

        IClock UserClock { get; set; }
        IMailer Mailer { get; set; }
        bool IsAdmin { get; set; }

        public ParkingDatabase Database
        {
            get { return database; }
            set { database = value; }
        }

        // constructor
        public UserForm(IClock clock, IMailer mailer, ParkingDatabase database, bool isAdmin)
        {
            IsAdmin = isAdmin;
            Database = database;
            UserClock = clock;
            Mailer = mailer;
            InitializeComponent();

            // if user is an admin, disable the button for creating an account
            if (isAdmin)
            {
                createAccountButton.Enabled = false;
            }
        }

        // show the form for logging in
        private void loginButton_Click(object sender, EventArgs e)
        {

            LoginForm loginForm = new LoginForm(IsAdmin, Database, UserClock, Mailer);
            this.Visible = false;
            loginForm.ShowDialog();
            this.Visible = true;
        }

        // show the form for creating an account
        private void createAccountButton_Click(object sender, EventArgs e)
        {
            CreateAccountForm createAccountForm = new CreateAccountForm(Database, UserClock, Mailer);
            this.Visible = false;
            createAccountForm.ShowDialog();
            this.Visible = true;
        }
    }
}
