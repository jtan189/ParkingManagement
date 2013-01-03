namespace ParkingManagement.Forms
{
    partial class AdminForm
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
            this.statisticsButton = new System.Windows.Forms.Button();
            this.customerOverviewButton = new System.Windows.Forms.Button();
            this.garageOverviewButton = new System.Windows.Forms.Button();
            this.billButton = new System.Windows.Forms.Button();
            this.logoutLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // statisticsButton
            // 
            this.statisticsButton.Location = new System.Drawing.Point(42, 134);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(289, 55);
            this.statisticsButton.TabIndex = 5;
            this.statisticsButton.Text = "Garage Statistics";
            this.statisticsButton.UseVisualStyleBackColor = true;
            this.statisticsButton.Click += new System.EventHandler(this.statisticsButton_Click);
            // 
            // customerOverviewButton
            // 
            this.customerOverviewButton.Location = new System.Drawing.Point(42, 73);
            this.customerOverviewButton.Name = "customerOverviewButton";
            this.customerOverviewButton.Size = new System.Drawing.Size(289, 55);
            this.customerOverviewButton.TabIndex = 4;
            this.customerOverviewButton.Text = "Customer Overview";
            this.customerOverviewButton.UseVisualStyleBackColor = true;
            this.customerOverviewButton.Click += new System.EventHandler(this.customerOverviewButton_Click);
            // 
            // garageOverviewButton
            // 
            this.garageOverviewButton.Location = new System.Drawing.Point(42, 12);
            this.garageOverviewButton.Name = "garageOverviewButton";
            this.garageOverviewButton.Size = new System.Drawing.Size(289, 55);
            this.garageOverviewButton.TabIndex = 3;
            this.garageOverviewButton.Text = "Garage Overview";
            this.garageOverviewButton.UseVisualStyleBackColor = true;
            this.garageOverviewButton.Click += new System.EventHandler(this.garageOverviewButton_Click);
            // 
            // billButton
            // 
            this.billButton.Location = new System.Drawing.Point(42, 195);
            this.billButton.Name = "billButton";
            this.billButton.Size = new System.Drawing.Size(289, 55);
            this.billButton.TabIndex = 6;
            this.billButton.Text = "Mail Customer Monthly Bill";
            this.billButton.UseVisualStyleBackColor = true;
            this.billButton.Click += new System.EventHandler(this.billButton_Click);
            // 
            // logoutLabel
            // 
            this.logoutLabel.AutoSize = true;
            this.logoutLabel.Location = new System.Drawing.Point(291, 267);
            this.logoutLabel.Name = "logoutLabel";
            this.logoutLabel.Size = new System.Drawing.Size(40, 13);
            this.logoutLabel.TabIndex = 10;
            this.logoutLabel.TabStop = true;
            this.logoutLabel.Text = "Logout";
            this.logoutLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logoutLabel_LinkClicked);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 300);
            this.Controls.Add(this.logoutLabel);
            this.Controls.Add(this.billButton);
            this.Controls.Add(this.statisticsButton);
            this.Controls.Add(this.customerOverviewButton);
            this.Controls.Add(this.garageOverviewButton);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parking Management - Administrator Mode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.Button customerOverviewButton;
        private System.Windows.Forms.Button garageOverviewButton;
        private System.Windows.Forms.Button billButton;
        private System.Windows.Forms.LinkLabel logoutLabel;
    }
}