namespace ParkingManagement.Forms
{
    partial class AddPaymentMethodForm
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
            this.cardTypeComboBox = new System.Windows.Forms.ComboBox();
            this.cardNumberTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.returnLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Credit Card Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Credit Card Number:\r\n(16 digit number)";
            // 
            // cardTypeComboBox
            // 
            this.cardTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardTypeComboBox.FormattingEnabled = true;
            this.cardTypeComboBox.Items.AddRange(new object[] {
            "Visa",
            "Mastercard",
            "American Express"});
            this.cardTypeComboBox.Location = new System.Drawing.Point(125, 18);
            this.cardTypeComboBox.Name = "cardTypeComboBox";
            this.cardTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.cardTypeComboBox.TabIndex = 2;
            // 
            // cardNumberTextBox
            // 
            this.cardNumberTextBox.Location = new System.Drawing.Point(125, 59);
            this.cardNumberTextBox.Name = "cardNumberTextBox";
            this.cardNumberTextBox.Size = new System.Drawing.Size(175, 20);
            this.cardNumberTextBox.TabIndex = 3;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(44, 101);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // returnLabel
            // 
            this.returnLabel.AutoSize = true;
            this.returnLabel.Location = new System.Drawing.Point(175, 106);
            this.returnLabel.Name = "returnLabel";
            this.returnLabel.Size = new System.Drawing.Size(125, 13);
            this.returnLabel.TabIndex = 5;
            this.returnLabel.TabStop = true;
            this.returnLabel.Text = "Return to Previous Menu";
            this.returnLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.returnLabel_LinkClicked);
            // 
            // AddPaymentMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 140);
            this.Controls.Add(this.returnLabel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cardNumberTextBox);
            this.Controls.Add(this.cardTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddPaymentMethodForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Payment Method";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cardTypeComboBox;
        private System.Windows.Forms.TextBox cardNumberTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.LinkLabel returnLabel;
    }
}