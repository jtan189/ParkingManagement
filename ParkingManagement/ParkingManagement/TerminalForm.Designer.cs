namespace ParkingManagement.Forms
{
    partial class TerminalForm
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
            this.reservationNumTexBox = new System.Windows.Forms.TextBox();
            this.checkInOutButton = new System.Windows.Forms.Button();
            this.ticketKeyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Ticket Reservation Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reservationNumTexBox
            // 
            this.reservationNumTexBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservationNumTexBox.Location = new System.Drawing.Point(127, 61);
            this.reservationNumTexBox.Name = "reservationNumTexBox";
            this.reservationNumTexBox.Size = new System.Drawing.Size(165, 24);
            this.reservationNumTexBox.TabIndex = 1;
            // 
            // checkInOutButton
            // 
            this.checkInOutButton.Location = new System.Drawing.Point(127, 130);
            this.checkInOutButton.Name = "checkInOutButton";
            this.checkInOutButton.Size = new System.Drawing.Size(165, 42);
            this.checkInOutButton.TabIndex = 2;
            this.checkInOutButton.Text = "Check In/Out";
            this.checkInOutButton.UseVisualStyleBackColor = true;
            this.checkInOutButton.Click += new System.EventHandler(this.checkInOutButton_Click);
            // 
            // ticketKeyTextBox
            // 
            this.ticketKeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketKeyTextBox.Location = new System.Drawing.Point(127, 91);
            this.ticketKeyTextBox.Name = "ticketKeyTextBox";
            this.ticketKeyTextBox.PasswordChar = '*';
            this.ticketKeyTextBox.Size = new System.Drawing.Size(165, 24);
            this.ticketKeyTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Reservation Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ticket Key:";
            // 
            // TerminalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 186);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ticketKeyTextBox);
            this.Controls.Add(this.checkInOutButton);
            this.Controls.Add(this.reservationNumTexBox);
            this.Controls.Add(this.label1);
            this.Name = "TerminalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parking Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox reservationNumTexBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button checkInOutButton;
        private System.Windows.Forms.TextBox ticketKeyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

    }
}