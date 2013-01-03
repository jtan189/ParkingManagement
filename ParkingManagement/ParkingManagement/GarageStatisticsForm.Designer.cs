namespace ParkingManagement.Forms
{
    partial class GarageStatisticsForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.reservationGroupBox = new System.Windows.Forms.GroupBox();
            this.averageResPerMonthLabel = new System.Windows.Forms.Label();
            this.averageResPerWeekLabel = new System.Windows.Forms.Label();
            this.incomeGroupBox = new System.Windows.Forms.GroupBox();
            this.averageIncomePerWeekLabel = new System.Windows.Forms.Label();
            this.averageIncomePerMonthLabel = new System.Windows.Forms.Label();
            this.returnLabel = new System.Windows.Forms.LinkLabel();
            this.reservationGroupBox.SuspendLayout();
            this.incomeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Average Reservations Per Week:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Average Reservations Per Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Average Income Per Week:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Average Income Per Month:";
            // 
            // reservationGroupBox
            // 
            this.reservationGroupBox.Controls.Add(this.averageResPerMonthLabel);
            this.reservationGroupBox.Controls.Add(this.averageResPerWeekLabel);
            this.reservationGroupBox.Controls.Add(this.label1);
            this.reservationGroupBox.Controls.Add(this.label2);
            this.reservationGroupBox.Location = new System.Drawing.Point(12, 12);
            this.reservationGroupBox.Name = "reservationGroupBox";
            this.reservationGroupBox.Size = new System.Drawing.Size(204, 163);
            this.reservationGroupBox.TabIndex = 4;
            this.reservationGroupBox.TabStop = false;
            this.reservationGroupBox.Text = "Reservations";
            // 
            // averageResPerMonthLabel
            // 
            this.averageResPerMonthLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.averageResPerMonthLabel.Location = new System.Drawing.Point(17, 118);
            this.averageResPerMonthLabel.Name = "averageResPerMonthLabel";
            this.averageResPerMonthLabel.Size = new System.Drawing.Size(163, 23);
            this.averageResPerMonthLabel.TabIndex = 5;
            this.averageResPerMonthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // averageResPerWeekLabel
            // 
            this.averageResPerWeekLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.averageResPerWeekLabel.Location = new System.Drawing.Point(19, 57);
            this.averageResPerWeekLabel.Name = "averageResPerWeekLabel";
            this.averageResPerWeekLabel.Size = new System.Drawing.Size(161, 23);
            this.averageResPerWeekLabel.TabIndex = 2;
            this.averageResPerWeekLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // incomeGroupBox
            // 
            this.incomeGroupBox.Controls.Add(this.averageIncomePerWeekLabel);
            this.incomeGroupBox.Controls.Add(this.averageIncomePerMonthLabel);
            this.incomeGroupBox.Controls.Add(this.label3);
            this.incomeGroupBox.Controls.Add(this.label4);
            this.incomeGroupBox.Location = new System.Drawing.Point(12, 181);
            this.incomeGroupBox.Name = "incomeGroupBox";
            this.incomeGroupBox.Size = new System.Drawing.Size(204, 149);
            this.incomeGroupBox.TabIndex = 5;
            this.incomeGroupBox.TabStop = false;
            this.incomeGroupBox.Text = "Income";
            // 
            // averageIncomePerWeekLabel
            // 
            this.averageIncomePerWeekLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.averageIncomePerWeekLabel.Location = new System.Drawing.Point(17, 48);
            this.averageIncomePerWeekLabel.Name = "averageIncomePerWeekLabel";
            this.averageIncomePerWeekLabel.Size = new System.Drawing.Size(163, 23);
            this.averageIncomePerWeekLabel.TabIndex = 3;
            this.averageIncomePerWeekLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // averageIncomePerMonthLabel
            // 
            this.averageIncomePerMonthLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.averageIncomePerMonthLabel.Location = new System.Drawing.Point(19, 109);
            this.averageIncomePerMonthLabel.Name = "averageIncomePerMonthLabel";
            this.averageIncomePerMonthLabel.Size = new System.Drawing.Size(161, 23);
            this.averageIncomePerMonthLabel.TabIndex = 4;
            this.averageIncomePerMonthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // returnLabel
            // 
            this.returnLabel.AutoSize = true;
            this.returnLabel.Location = new System.Drawing.Point(91, 344);
            this.returnLabel.Name = "returnLabel";
            this.returnLabel.Size = new System.Drawing.Size(125, 13);
            this.returnLabel.TabIndex = 6;
            this.returnLabel.TabStop = true;
            this.returnLabel.Text = "Return to Previous Menu";
            this.returnLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.returnLabel_LinkClicked);
            // 
            // GarageStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 366);
            this.Controls.Add(this.returnLabel);
            this.Controls.Add(this.incomeGroupBox);
            this.Controls.Add(this.reservationGroupBox);
            this.Name = "GarageStatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Garage Statistics";
            this.Load += new System.EventHandler(this.GarageStatisticsForm_Load);
            this.reservationGroupBox.ResumeLayout(false);
            this.reservationGroupBox.PerformLayout();
            this.incomeGroupBox.ResumeLayout(false);
            this.incomeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox reservationGroupBox;
        private System.Windows.Forms.Label averageResPerMonthLabel;
        private System.Windows.Forms.Label averageResPerWeekLabel;
        private System.Windows.Forms.GroupBox incomeGroupBox;
        private System.Windows.Forms.Label averageIncomePerWeekLabel;
        private System.Windows.Forms.Label averageIncomePerMonthLabel;
        private System.Windows.Forms.LinkLabel returnLabel;
    }
}