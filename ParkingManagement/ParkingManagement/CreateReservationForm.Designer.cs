namespace ParkingManagement.Forms
{
    partial class CreateReservationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.desiredTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.desiredMonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.createButton = new System.Windows.Forms.Button();
            this.returnLabel = new System.Windows.Forms.LinkLabel();
            this.vehicleComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.paymentMethodComboBox = new System.Windows.Forms.ComboBox();
            this.durationComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the desired date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select the desired time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select the desired duration:";
            // 
            // desiredTimeDateTimePicker
            // 
            this.desiredTimeDateTimePicker.CustomFormat = "h:mm tt";
            this.desiredTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.desiredTimeDateTimePicker.Location = new System.Drawing.Point(295, 158);
            this.desiredTimeDateTimePicker.Name = "desiredTimeDateTimePicker";
            this.desiredTimeDateTimePicker.ShowUpDown = true;
            this.desiredTimeDateTimePicker.Size = new System.Drawing.Size(74, 20);
            this.desiredTimeDateTimePicker.TabIndex = 5;
            // 
            // desiredMonthCalendar
            // 
            this.desiredMonthCalendar.Location = new System.Drawing.Point(15, 31);
            this.desiredMonthCalendar.MaxSelectionCount = 1;
            this.desiredMonthCalendar.Name = "desiredMonthCalendar";
            this.desiredMonthCalendar.TabIndex = 6;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(295, 201);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(105, 23);
            this.createButton.TabIndex = 7;
            this.createButton.Text = "Create Reservation";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.checkAvailabilityButton_Click);
            // 
            // returnLabel
            // 
            this.returnLabel.AutoSize = true;
            this.returnLabel.Location = new System.Drawing.Point(480, 206);
            this.returnLabel.Name = "returnLabel";
            this.returnLabel.Size = new System.Drawing.Size(107, 13);
            this.returnLabel.TabIndex = 8;
            this.returnLabel.TabStop = true;
            this.returnLabel.Text = "Return to Main Menu";
            this.returnLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.returnLabel_LinkClicked);
            // 
            // vehicleComboBox
            // 
            this.vehicleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vehicleComboBox.FormattingEnabled = true;
            this.vehicleComboBox.Location = new System.Drawing.Point(295, 25);
            this.vehicleComboBox.Name = "vehicleComboBox";
            this.vehicleComboBox.Size = new System.Drawing.Size(292, 21);
            this.vehicleComboBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Select a Vehicle:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Select a Payment Method:";
            // 
            // paymentMethodComboBox
            // 
            this.paymentMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paymentMethodComboBox.FormattingEnabled = true;
            this.paymentMethodComboBox.Location = new System.Drawing.Point(295, 79);
            this.paymentMethodComboBox.Name = "paymentMethodComboBox";
            this.paymentMethodComboBox.Size = new System.Drawing.Size(292, 21);
            this.paymentMethodComboBox.TabIndex = 12;
            // 
            // durationComboBox
            // 
            this.durationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.durationComboBox.FormattingEnabled = true;
            this.durationComboBox.Items.AddRange(new object[] {
            "30 minutes",
            "1 hour",
            "1.5 hours",
            "2 hours"});
            this.durationComboBox.Location = new System.Drawing.Point(454, 156);
            this.durationComboBox.Name = "durationComboBox";
            this.durationComboBox.Size = new System.Drawing.Size(133, 21);
            this.durationComboBox.TabIndex = 13;
            // 
            // CreateReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 247);
            this.Controls.Add(this.durationComboBox);
            this.Controls.Add(this.paymentMethodComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vehicleComboBox);
            this.Controls.Add(this.returnLabel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.desiredMonthCalendar);
            this.Controls.Add(this.desiredTimeDateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Reservation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker desiredTimeDateTimePicker;
        private System.Windows.Forms.MonthCalendar desiredMonthCalendar;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.LinkLabel returnLabel;
        private System.Windows.Forms.ComboBox vehicleComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox paymentMethodComboBox;
        private System.Windows.Forms.ComboBox durationComboBox;
    }
}