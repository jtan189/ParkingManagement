namespace ParkingManagement.Forms
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createReservationButton = new System.Windows.Forms.Button();
            this.modifyReservationButton = new System.Windows.Forms.Button();
            this.logoutLabel = new System.Windows.Forms.LinkLabel();
            this.registerVehicleButton = new System.Windows.Forms.Button();
            this.paymentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createReservationButton
            // 
            this.createReservationButton.Location = new System.Drawing.Point(12, 138);
            this.createReservationButton.Name = "createReservationButton";
            this.createReservationButton.Size = new System.Drawing.Size(300, 57);
            this.createReservationButton.TabIndex = 0;
            this.createReservationButton.Text = "Create Reservation";
            this.createReservationButton.UseVisualStyleBackColor = true;
            this.createReservationButton.Click += new System.EventHandler(this.createReservationButton_Click);
            // 
            // modifyReservationButton
            // 
            this.modifyReservationButton.Location = new System.Drawing.Point(12, 201);
            this.modifyReservationButton.Name = "modifyReservationButton";
            this.modifyReservationButton.Size = new System.Drawing.Size(300, 57);
            this.modifyReservationButton.TabIndex = 2;
            this.modifyReservationButton.Text = "Modify or Cancel Reservation";
            this.modifyReservationButton.UseVisualStyleBackColor = true;
            this.modifyReservationButton.Click += new System.EventHandler(this.modifyReservationButton_Click);
            // 
            // logoutLabel
            // 
            this.logoutLabel.AutoSize = true;
            this.logoutLabel.Location = new System.Drawing.Point(272, 271);
            this.logoutLabel.Name = "logoutLabel";
            this.logoutLabel.Size = new System.Drawing.Size(40, 13);
            this.logoutLabel.TabIndex = 9;
            this.logoutLabel.TabStop = true;
            this.logoutLabel.Text = "Logout";
            this.logoutLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.returnLabel_LinkClicked);
            // 
            // registerVehicleButton
            // 
            this.registerVehicleButton.Location = new System.Drawing.Point(12, 12);
            this.registerVehicleButton.Name = "registerVehicleButton";
            this.registerVehicleButton.Size = new System.Drawing.Size(300, 57);
            this.registerVehicleButton.TabIndex = 10;
            this.registerVehicleButton.Text = "Register Vehicle";
            this.registerVehicleButton.UseVisualStyleBackColor = true;
            this.registerVehicleButton.Click += new System.EventHandler(this.registerVehicleButton_Click);
            // 
            // paymentButton
            // 
            this.paymentButton.Location = new System.Drawing.Point(12, 75);
            this.paymentButton.Name = "paymentButton";
            this.paymentButton.Size = new System.Drawing.Size(300, 57);
            this.paymentButton.TabIndex = 11;
            this.paymentButton.Text = "Add Payment Method";
            this.paymentButton.UseVisualStyleBackColor = true;
            this.paymentButton.Click += new System.EventHandler(this.paymentButton_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 299);
            this.Controls.Add(this.paymentButton);
            this.Controls.Add(this.registerVehicleButton);
            this.Controls.Add(this.logoutLabel);
            this.Controls.Add(this.modifyReservationButton);
            this.Controls.Add(this.createReservationButton);
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parking Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createReservationButton;
        private System.Windows.Forms.Button modifyReservationButton;
        private System.Windows.Forms.LinkLabel logoutLabel;
        private System.Windows.Forms.Button registerVehicleButton;
        private System.Windows.Forms.Button paymentButton;
    }
}

