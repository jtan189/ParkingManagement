namespace ParkingManagement.Forms
{
    partial class SelectReservationToModifyForm
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
            this.reservationComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.spotLabel = new System.Windows.Forms.Label();
            this.licenseLabel = new System.Windows.Forms.Label();
            this.modelLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.modifyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.returnLabel = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reservationComboBox
            // 
            this.reservationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reservationComboBox.FormattingEnabled = true;
            this.reservationComboBox.Location = new System.Drawing.Point(214, 6);
            this.reservationComboBox.Name = "reservationComboBox";
            this.reservationComboBox.Size = new System.Drawing.Size(141, 21);
            this.reservationComboBox.TabIndex = 0;
            this.reservationComboBox.SelectedIndexChanged += new System.EventHandler(this.reservationComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a reservation to modify or cancel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reservation Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Reservation Duration:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Vehicle Make and Model:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Parking Spot ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Vehicle License Number:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.spotLabel);
            this.groupBox1.Controls.Add(this.licenseLabel);
            this.groupBox1.Controls.Add(this.modelLabel);
            this.groupBox1.Controls.Add(this.durationLabel);
            this.groupBox1.Controls.Add(this.dateLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 179);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reservation Details";
            // 
            // spotLabel
            // 
            this.spotLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spotLabel.Location = new System.Drawing.Point(158, 139);
            this.spotLabel.Name = "spotLabel";
            this.spotLabel.Size = new System.Drawing.Size(185, 20);
            this.spotLabel.TabIndex = 11;
            this.spotLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // licenseLabel
            // 
            this.licenseLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.licenseLabel.Location = new System.Drawing.Point(158, 111);
            this.licenseLabel.Name = "licenseLabel";
            this.licenseLabel.Size = new System.Drawing.Size(185, 20);
            this.licenseLabel.TabIndex = 10;
            this.licenseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // modelLabel
            // 
            this.modelLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modelLabel.Location = new System.Drawing.Point(158, 85);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(185, 20);
            this.modelLabel.TabIndex = 9;
            this.modelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // durationLabel
            // 
            this.durationLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.durationLabel.Location = new System.Drawing.Point(158, 54);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(185, 20);
            this.durationLabel.TabIndex = 8;
            this.durationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateLabel
            // 
            this.dateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateLabel.Location = new System.Drawing.Point(158, 27);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(185, 20);
            this.dateLabel.TabIndex = 7;
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(15, 218);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(75, 23);
            this.modifyButton.TabIndex = 8;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(96, 218);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(126, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel Reservation";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // returnLabel
            // 
            this.returnLabel.AutoSize = true;
            this.returnLabel.Location = new System.Drawing.Point(289, 223);
            this.returnLabel.Name = "returnLabel";
            this.returnLabel.Size = new System.Drawing.Size(107, 13);
            this.returnLabel.TabIndex = 10;
            this.returnLabel.TabStop = true;
            this.returnLabel.Text = "Return to Main Menu";
            this.returnLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.returnLabel_LinkClicked);
            // 
            // SelectReservationToModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 257);
            this.Controls.Add(this.returnLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reservationComboBox);
            this.Name = "SelectReservationToModifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify or Cancel Reservation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox reservationComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label licenseLabel;
        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.LinkLabel returnLabel;
        private System.Windows.Forms.Label spotLabel;
    }
}