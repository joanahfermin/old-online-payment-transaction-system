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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateRPTForm));
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
            this.textYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textTransferredAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboQuarter = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboBankUsed = new System.Windows.Forms.ComboBox();
            this.dtDateOfPayment = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAmountToBPay = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.textTotalTransferredAmount = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.btnUpdateRecord.Location = new System.Drawing.Point(152, 519);
            this.btnUpdateRecord.Name = "btnUpdateRecord";
            this.btnUpdateRecord.Size = new System.Drawing.Size(253, 23);
            this.btnUpdateRecord.TabIndex = 12;
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
            this.label1.TabIndex = 12;
            this.label1.Text = "Tax Declaration Number: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(86, 377);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 21;
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
            this.cbStatus.Location = new System.Drawing.Point(152, 291);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(253, 21);
            this.cbStatus.TabIndex = 9;
            this.cbStatus.Click += new System.EventHandler(this.cbStatus_Click);
            this.cbStatus.Enter += new System.EventHandler(this.cbStatus_Enter);
            this.cbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbStatus_KeyDown);
            // 
            // textRemarks
            // 
            this.textRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRemarks.Location = new System.Drawing.Point(152, 370);
            this.textRemarks.Multiline = true;
            this.textRemarks.Name = "textRemarks";
            this.textRemarks.Size = new System.Drawing.Size(253, 132);
            this.textRemarks.TabIndex = 11;
            this.textRemarks.Click += new System.EventHandler(this.textRemarks_Click);
            this.textRemarks.Enter += new System.EventHandler(this.textRemarks_Enter);
            this.textRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textRemarks_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 337);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Requesting Party: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(99, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Status: ";
            // 
            // textRequestingParty
            // 
            this.textRequestingParty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRequestingParty.Location = new System.Drawing.Point(152, 330);
            this.textRequestingParty.Name = "textRequestingParty";
            this.textRequestingParty.Size = new System.Drawing.Size(253, 20);
            this.textRequestingParty.TabIndex = 10;
            this.textRequestingParty.Click += new System.EventHandler(this.textRequestingParty_Click);
            this.textRequestingParty.Enter += new System.EventHandler(this.textRequestingParty_Enter);
            this.textRequestingParty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textRequestingParty_KeyDown);
            // 
            // textTaxDec
            // 
            this.textTaxDec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTaxDec.Location = new System.Drawing.Point(152, 19);
            this.textTaxDec.Name = "textTaxDec";
            this.textTaxDec.Size = new System.Drawing.Size(253, 20);
            this.textTaxDec.TabIndex = 1;
            this.textTaxDec.Click += new System.EventHandler(this.textTaxDec_Click);
            this.textTaxDec.Enter += new System.EventHandler(this.textTaxDec_Enter);
            this.textTaxDec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTaxDec_KeyDown);
            // 
            // textTPName
            // 
            this.textTPName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTPName.Location = new System.Drawing.Point(152, 58);
            this.textTPName.Name = "textTPName";
            this.textTPName.Size = new System.Drawing.Size(253, 20);
            this.textTPName.TabIndex = 2;
            this.textTPName.Click += new System.EventHandler(this.textTPName_Click);
            this.textTPName.Enter += new System.EventHandler(this.textTPName_Enter);
            this.textTPName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTPName_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Year/Quarter: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Taxpayer\'s Name: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Bank Used: ";
            // 
            // textAmountToBePaid
            // 
            this.textAmountToBePaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAmountToBePaid.Location = new System.Drawing.Point(152, 102);
            this.textAmountToBePaid.Name = "textAmountToBePaid";
            this.textAmountToBePaid.Size = new System.Drawing.Size(112, 20);
            this.textAmountToBePaid.TabIndex = 3;
            this.textAmountToBePaid.Text = "0.00";
            this.textAmountToBePaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textAmountToBePaid.Click += new System.EventHandler(this.textAmountToBePaid_Click);
            this.textAmountToBePaid.Enter += new System.EventHandler(this.textAmountToBePaid_Enter);
            this.textAmountToBePaid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textAmountToBePaid_KeyDown);
            this.textAmountToBePaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAmountToBePaid_KeyPress);
            this.textAmountToBePaid.Leave += new System.EventHandler(this.textAmountToBePaid_Leave);
            // 
            // textYear
            // 
            this.textYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textYear.Location = new System.Drawing.Point(152, 218);
            this.textYear.Name = "textYear";
            this.textYear.Size = new System.Drawing.Size(80, 20);
            this.textYear.TabIndex = 6;
            this.textYear.Click += new System.EventHandler(this.textYear_Click);
            this.textYear.Enter += new System.EventHandler(this.textYear_Enter);
            this.textYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textYear_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(510, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Amount To Be Paid: ";
            // 
            // textTransferredAmount
            // 
            this.textTransferredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTransferredAmount.Enabled = false;
            this.textTransferredAmount.Location = new System.Drawing.Point(625, 176);
            this.textTransferredAmount.Name = "textTransferredAmount";
            this.textTransferredAmount.Size = new System.Drawing.Size(112, 20);
            this.textTransferredAmount.TabIndex = 4;
            this.textTransferredAmount.Text = "0.00";
            this.textTransferredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTransferredAmount.Click += new System.EventHandler(this.textTransferredAmount_Click);
            this.textTransferredAmount.TextChanged += new System.EventHandler(this.textTransferredAmount_TextChanged);
            this.textTransferredAmount.Enter += new System.EventHandler(this.textTransferredAmount_Enter);
            this.textTransferredAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTransferredAmount_KeyDown);
            this.textTransferredAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTransferredAmount_KeyPress);
            this.textTransferredAmount.Leave += new System.EventHandler(this.textTransferredAmount_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Update Record";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(509, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Transferred Amount: ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.textTotalTransferredAmount);
            this.panel1.Controls.Add(this.cboQuarter);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cboBankUsed);
            this.panel1.Controls.Add(this.textAmountToBePaid);
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
            this.panel1.Controls.Add(this.labelAmountToBPay);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textYear);
            this.panel1.Location = new System.Drawing.Point(15, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 563);
            this.panel1.TabIndex = 25;
            // 
            // cboQuarter
            // 
            this.cboQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuarter.FormattingEnabled = true;
            this.cboQuarter.Location = new System.Drawing.Point(291, 217);
            this.cboQuarter.Name = "cboQuarter";
            this.cboQuarter.Size = new System.Drawing.Size(114, 21);
            this.cboQuarter.TabIndex = 7;
            this.cboQuarter.Click += new System.EventHandler(this.cboQuarter_Click);
            this.cboQuarter.Enter += new System.EventHandler(this.cboQuarter_Enter);
            this.cboQuarter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboQuarter_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(238, 225);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Quarter: ";
            // 
            // cboBankUsed
            // 
            this.cboBankUsed.FormattingEnabled = true;
            this.cboBankUsed.Items.AddRange(new object[] {
            "Please select a bank..."});
            this.cboBankUsed.Location = new System.Drawing.Point(152, 180);
            this.cboBankUsed.Name = "cboBankUsed";
            this.cboBankUsed.Size = new System.Drawing.Size(253, 21);
            this.cboBankUsed.TabIndex = 5;
            this.cboBankUsed.Click += new System.EventHandler(this.cboBankUsed_Click);
            this.cboBankUsed.Enter += new System.EventHandler(this.cboBankUsed_Enter);
            this.cboBankUsed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboBankUsed_KeyDown);
            // 
            // dtDateOfPayment
            // 
            this.dtDateOfPayment.CustomFormat = "MM/dd/yyyy";
            this.dtDateOfPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfPayment.Location = new System.Drawing.Point(152, 254);
            this.dtDateOfPayment.Name = "dtDateOfPayment";
            this.dtDateOfPayment.ShowCheckBox = true;
            this.dtDateOfPayment.Size = new System.Drawing.Size(112, 20);
            this.dtDateOfPayment.TabIndex = 8;
            this.dtDateOfPayment.Enter += new System.EventHandler(this.dtDateOfPayment_Enter);
            this.dtDateOfPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtDateOfPayment_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Date Of Payment: ";
            // 
            // labelAmountToBPay
            // 
            this.labelAmountToBPay.AutoSize = true;
            this.labelAmountToBPay.Location = new System.Drawing.Point(56, 109);
            this.labelAmountToBPay.Name = "labelAmountToBPay";
            this.labelAmountToBPay.Size = new System.Drawing.Size(86, 13);
            this.labelAmountToBPay.TabIndex = 13;
            this.labelAmountToBPay.Text = "Amount To Pay: ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Total Transferred Amount: ";
            // 
            // textTotalTransferredAmount
            // 
            this.textTotalTransferredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalTransferredAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalTransferredAmount.Location = new System.Drawing.Point(152, 141);
            this.textTotalTransferredAmount.Name = "textTotalTransferredAmount";
            this.textTotalTransferredAmount.Size = new System.Drawing.Size(112, 20);
            this.textTotalTransferredAmount.TabIndex = 4;
            this.textTotalTransferredAmount.Text = "0.00";
            this.textTotalTransferredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTotalTransferredAmount.Click += new System.EventHandler(this.textTotalTransferredAmount_Click);
            this.textTotalTransferredAmount.Enter += new System.EventHandler(this.textTotalTransferredAmount_Enter);
            this.textTotalTransferredAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTotalTransferredAmount_KeyDown);
            // 
            // UpdateRPTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 595);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textTransferredAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Name = "UpdateRPTForm";
            this.Text = "UpdateRPTForm";
            this.Load += new System.EventHandler(this.UpdateRPTForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.TextBox textYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textTransferredAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDateOfPayment;
        private System.Windows.Forms.ComboBox cboBankUsed;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cboQuarter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelAmountToBPay;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textTotalTransferredAmount;
    }
}