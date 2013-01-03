using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParkingManagement.Forms
{
    // Administrator form for viewing an overview of registered customers
    public partial class CustomerOverviewForm : Form
    {
        public CustomerOverviewForm()
        {
            InitializeComponent();
        }

        // save the table data to the database
        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.parkingManagementDataSet);
        }

        // upon loading the form, fill it with customer data from the database
        private void CustomerOverviewForm_Load(object sender, EventArgs e)
        {
            this.customerTableAdapter.Fill(this.parkingManagementDataSet.Customer);
        }

        // return to the previous form
        private void returnLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
