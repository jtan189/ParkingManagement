namespace ParkingManagement.Forms
{
    partial class ModifyReservationForm
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
            this.durationComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.vehicleComboBox = new System.Windows.Forms.ComboBox();
            this.returnLabel = new System.Windows.Forms.LinkLabel();
            this.modifyButton = new System.Windows.Forms.Button();
            this.desiredMonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.desiredTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // durationComboBox
            // 
            this.durationComboBox.FormattingEnabled = true;
            this.durationComboBox.Items.AddRange(new object[] {
            "30 minutes",
            "1 hour",
            "1.5 hours",
            "2 hours"});
            this.durationComboBox.Location = new System.Drawing.Point(403, 93);
            this.durationComboBox.Name = "durationComboBox";
            this.durationComboBox.Size = new System.Drawing.Size(133, 21);
            this.durationComboBox.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Select a vehicle:";
            // 
            // vehicleComboBox
            // 
            this.vehicleComboBox.FormattingEnabled = true;
            this.vehicleComboBox.Location = new System.Drawing.Point(273, 31);
            this.vehicleComboBox.Name = "vehicleComboBox";
            this.vehicleComboBox.Size = new System.Drawing.Size(263, 21);
            this.vehicleComboBox.TabIndex = 21;
            // 
            // returnLabel
            // 
            this.returnLabel.AutoSize = true;
            this.returnLabel.Location = new System.Drawing.Point(429, 161);
            this.returnLabel.Name = "returnLabel";
            this.returnLabel.Size = new System.Drawing.Size(107, 13);
            this.returnLabel.TabIndex = 20;
            this.returnLabel.TabStop = true;
            this.returnLabel.Text = "Return to Main Menu";
            this.returnLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.returnLabel_LinkClicked);
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(273, 156);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(105, 23);
            this.modifyButton.TabIndex = 19;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // desiredMonthCalendar
            // 
            this.desiredMonthCalendar.Location = new System.Drawing.Point(15, 31);
            this.desiredMonthCalendar.MaxSelectionCount = 1;
            this.desiredMonthCalendar.Name = "desiredMonthCalendar";
            this.desiredMonthCalendar.TabIndex = 18;
            // 
            // desiredTimeDateTimePicker
            // 
            this.desiredTimeDateTimePicker.CustomFormat = "h:mm tt";
            this.desiredTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.desiredTimeDateTimePicker.Location = new System.Drawing.Point(273, 94);
            this.desiredTimeDateTimePicker.Name = "desiredTimeDateTimePicker";
            this.desiredTimeDateTimePicker.ShowUpDown = true;
            this.desiredTimeDateTimePicker.Size = new System.Drawing.Size(74, 20);
            this.desiredTimeDateTimePicker.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Select the desired duration:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Select the desired time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Select the desired date:";
            // 
            // ModifyReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 216);
            this.Controls.Add(this.durationComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vehicleComboBox);
            this.Controls.Add(this.returnLabel);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.desiredMonthCalendar);
            this.Controls.Add(this.desiredTimeDateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModifyReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify Reservation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox durationComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox vehicleComboBox;
        private System.Windows.Forms.LinkLabel returnLabel;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.MonthCalendar desiredMonthCalendar;
        private System.Windows.Forms.DateTimePicker desiredTimeDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}