using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Accounts
{
    // An administrator account. These will be created separately from the application by management.
    public class AdminAccount : Account
    {
        public int EmployeeID { get; set; }

        public AdminAccount(int employeeID, string email, string password) 
            : base(email, password)
            {
                EmployeeID = employeeID;
            }
    }
}
