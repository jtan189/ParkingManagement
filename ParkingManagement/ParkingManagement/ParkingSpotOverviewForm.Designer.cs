
namespace ParkingManagement.Forms
{
    partial class ParkingSpotOverviewForm
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
            this.returnLabel = new System.Windows.Forms.LinkLabel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.licenseLabel = new System.Windows.Forms.Label();
            this.modelLabel = new System.Windows.Forms.Label();
            this.endLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.parkingSpotComboBox = new System.Windows.Forms.ComboBox();
            this.occupancyLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.loadLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // returnLabel
            // 
            this.returnLabel.AutoSize = true;
            this.returnLabel.Location = new System.Drawing.Point(375, 275);
            this.returnLabel.Name = "returnLabel";
            this.returnLabel.Size = new System.Drawing.Size(107, 13);
            this.returnLabel.TabIndex = 16;
            this.returnLabel.TabStop = true;
            this.returnLabel.Text = "Return to Main Menu";
            this.returnLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.returnLabel_LinkClicked);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(353, 23);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(129, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel Reservation";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(272, 23);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(75, 23);
            this.modifyButton.TabIndex = 14;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.idLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.licenseLabel);
            this.groupBox1.Controls.Add(this.modelLabel);
            this.groupBox1.Controls.Add(this.endLabel);
            this.groupBox1.Controls.Add(this.startLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 179);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reservation Details";
            // 
            // idLabel
            // 
            this.idLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idLabel.Location = new System.Drawing.Point(185, 25);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(225, 20);
            this.idLabel.TabIndex = 12;
            this.idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Reservation ID:";
            // 
            // licenseLabel
            // 
            this.licenseLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.licenseLabel.Location = new System.Drawing.Point(185, 139);
            this.licenseLabel.Name = "licenseLabel";
            this.licenseLabel.Size = new System.Drawing.Size(225, 20);
            this.licenseLabel.TabIndex = 10;
            this.licenseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // modelLabel
            // 
            this.modelLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modelLabel.Location = new System.Drawing.Point(185, 113);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(225, 20);
            this.modelLabel.TabIndex = 9;
            this.modelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endLabel
            // 
            this.endLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.endLabel.Location = new System.Drawing.Point(185, 86);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(225, 20);
            this.endLabel.TabIndex = 8;
            this.endLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startLabel
            // 
            this.startLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startLabel.Location = new System.Drawing.Point(185, 55);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(225, 20);
            this.startLabel.TabIndex = 7;
            this.startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reservation Start:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(41, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Vehicle License Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Reservation End:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Vehicle Make and Model:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Select a parking spot:";
            // 
            // parkingSpotComboBox
            // 
            this.parkingSpotComboBox.FormattingEnabled = true;
            this.parkingSpotComboBox.Location = new System.Drawing.Point(12, 25);
            this.parkingSpotComboBox.Name = "parkingSpotComboBox";
            this.parkingSpotComboBox.Size = new System.Drawing.Size(129, 21);
            this.parkingSpotComboBox.TabIndex = 11;
            this.parkingSpotComboBox.SelectedIndexChanged += new System.EventHandler(this.parkingSpotComboBox_SelectedIndexChanged);
            // 
            // occupancyLabel
            // 
            this.occupancyLabel.BackColor = System.Drawing.Color.LightGray;
            this.occupancyLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.occupancyLabel.Location = new System.Drawing.Point(157, 23);
            this.occupancyLabel.Name = "occupancyLabel";
            this.occupancyLabel.Size = new System.Drawing.Size(98, 22);
            this.occupancyLabel.TabIndex = 17;
            this.occupancyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 250);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Current Garage Load:";
            // 
            // loadLabel
            // 
            this.loadLabel.BackColor = System.Drawing.Color.LightGray;
            this.loadLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loadLabel.Location = new System.Drawing.Point(128, 245);
            this.loadLabel.Name = "loadLabel";
            this.loadLabel.Size = new System.Drawing.Size(98, 22);
            this.loadLabel.TabIndex = 20;
            this.loadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(283, 247);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Current Time:";
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentTimeLabel.Location = new System.Drawing.Point(359, 243);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(123, 20);
            this.currentTimeLabel.TabIndex = 13;
            this.currentTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ParkingSpotOverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 299);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.loadLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.occupancyLabel);
            this.Controls.Add(this.returnLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.parkingSpotComboBox);
            this.Name = "ParkingSpotOverviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parking Garage Overview";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel returnLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label licenseLabel;
        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox parkingSpotComboBox;
        private System.Windows.Forms.Label occupancyLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label loadLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label currentTimeLabel;
    }
}