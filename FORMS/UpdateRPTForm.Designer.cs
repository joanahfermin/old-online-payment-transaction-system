namespace SampleRPT1
{
    partial class UpdateRPTForm
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
            this.label12 = new System.Windows.Forms.Label();
            this.btnUpdateRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.textRemarks = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textRequestingParty = new System.Windows.Forms.TextBox();
            this.textTaxDec = new System.Windows.Forms.TextBox();
            this.textTPName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textAmountToBePaid = new System.Windows.Forms.TextBox();
            this.textYearQuarter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textTransferredAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtDateOfPayment = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBankUsed = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(-47, -269);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "label11";
            // 
            // btnUpdateRecord
            // 
            this.btnUpdateRecord.Location = new System.Drawing.Point(152, 464);
            this.btnUpdateRecord.Name = "btnUpdateRecord";
            this.btnUpdateRecord.Size = new System.Drawing.Size(253, 23);
            this.btnUpdateRecord.TabIndex = 11;
            this.btnUpdateRecord.Text = "Update Record";
            this.btnUpdateRecord.UseVisualStyleBackColor = true;
            this.btnUpdateRecord.Click += new System.EventHandler(this.btnUpdateRecord_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tax Declaration Number: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(86, 404);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Remarks: ";
            // 
            // cbStatus
            // 
            this.cbStatus.Enabled = false;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "FOR ASSESSMENT",
            "FOR PAYMENT VERIFICATION",
            "FOR PAYMENT VALIDATION",
            "FOR O.R UPLOAD",
            "FOR O.R PICK UP",
            "RELEASED"});
            this.cbStatus.Location = new System.Drawing.Point(152, 320);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(253, 21);
            this.cbStatus.TabIndex = 8;
            // 
            // textRemarks
            // 
            this.textRemarks.Location = new System.Drawing.Point(152, 397);
            this.textRemarks.Name = "textRemarks";
            this.textRemarks.Size = new System.Drawing.Size(253, 20);
            this.textRemarks.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Requesting Party: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(99, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Status: ";
            // 
            // textRequestingParty
            // 
            this.textRequestingParty.Location = new System.Drawing.Point(152, 359);
            this.textRequestingParty.Name = "textRequestingParty";
            this.textRequestingParty.Size = new System.Drawing.Size(253, 20);
            this.textRequestingParty.TabIndex = 9;
            // 
            // textTaxDec
            // 
            this.textTaxDec.Location = new System.Drawing.Point(152, 19);
            this.textTaxDec.Name = "textTaxDec";
            this.textTaxDec.Size = new System.Drawing.Size(253, 20);
            this.textTaxDec.TabIndex = 1;
            // 
            // textTPName
            // 
            this.textTPName.Location = new System.Drawing.Point(152, 94);
            this.textTPName.Name = "textTPName";
            this.textTPName.Size = new System.Drawing.Size(253, 20);
            this.textTPName.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Year/Quarter: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Taxpayer\'s Name: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Bank Used: ";
            // 
            // textAmountToBePaid
            // 
            this.textAmountToBePaid.Location = new System.Drawing.Point(152, 132);
            this.textAmountToBePaid.Name = "textAmountToBePaid";
            this.textAmountToBePaid.Size = new System.Drawing.Size(253, 20);
            this.textAmountToBePaid.TabIndex = 4;
            this.textAmountToBePaid.Text = "0.00";
            this.textAmountToBePaid.Leave += new System.EventHandler(this.textAmountToBePaid_Leave);
            // 
            // textYearQuarter
            // 
            this.textYearQuarter.Location = new System.Drawing.Point(152, 242);
            this.textYearQuarter.Name = "textYearQuarter";
            this.textYearQuarter.Size = new System.Drawing.Size(112, 20);
            this.textYearQuarter.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Amount To Be Paid: ";
            // 
            // textTransferredAmount
            // 
            this.textTransferredAmount.Location = new System.Drawing.Point(152, 168);
            this.textTransferredAmount.Name = "textTransferredAmount";
            this.textTransferredAmount.Size = new System.Drawing.Size(253, 20);
            this.textTransferredAmount.TabIndex = 5;
            this.textTransferredAmount.Text = "0.00";
            this.textTransferredAmount.TextChanged += new System.EventHandler(this.textTransferredAmount_TextChanged);
            this.textTransferredAmount.Leave += new System.EventHandler(this.textTransferredAmount_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Update Record";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Transferred Amount: ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboBankUsed);
            this.panel1.Controls.Add(this.dtDateOfPayment);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btnUpdateRecord);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cbStatus);
            this.panel1.Controls.Add(this.textRemarks);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textRequestingParty);
            this.panel1.Controls.Add(this.textTaxDec);
            this.panel1.Controls.Add(this.textTPName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textAmountToBePaid);
            this.panel1.Controls.Add(this.textYearQuarter);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textTransferredAmount);
            this.panel1.Location = new System.Drawing.Point(15, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 503);
            this.panel1.TabIndex = 6;
            // 
            // dtDateOfPayment
            // 
            this.dtDateOfPayment.CustomFormat = "MM/dd/yyyy";
            this.dtDateOfPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfPayment.Location = new System.Drawing.Point(147, 281);
            this.dtDateOfPayment.Name = "dtDateOfPayment";
            this.dtDateOfPayment.ShowCheckBox = true;
            this.dtDateOfPayment.Size = new System.Drawing.Size(117, 20);
            this.dtDateOfPayment.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date Of Payment: ";
            // 
            // cboBankUsed
            // 
            this.cboBankUsed.FormattingEnabled = true;
            this.cboBankUsed.Items.AddRange(new object[] {
            "LBP",
            "METROBANK",
            "UNIONBANK"});
            this.cboBankUsed.Location = new System.Drawing.Point(152, 204);
            this.cboBankUsed.Name = "cboBankUsed";
            this.cboBankUsed.Size = new System.Drawing.Size(253, 21);
            this.cboBankUsed.TabIndex = 13;
            // 
            // UpdateRPTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 531);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Name = "UpdateRPTForm";
            this.Text = "UpdateRPTForm";
            this.Load += new System.EventHandler(this.UpdateRPTForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnUpdateRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox textRemarks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textRequestingParty;
        private System.Windows.Forms.TextBox textTaxDec;
        private System.Windows.Forms.TextBox textTPName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textAmountToBePaid;
        private System.Windows.Forms.TextBox textYearQuarter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textTransferredAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDateOfPayment;
        private System.Windows.Forms.ComboBox cboBankUsed;
    }
}