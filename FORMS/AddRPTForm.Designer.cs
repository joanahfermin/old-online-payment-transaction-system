namespace SampleRPT1
{
    partial class AddRPTForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRPTForm));
            this.label11 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.textTotalTransferredAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textYear = new System.Windows.Forms.TextBox();
            this.textAmountToBePaid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textTPName = new System.Windows.Forms.TextBox();
            this.textTaxDec = new System.Windows.Forms.TextBox();
            this.textRequestingParty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textRemarks = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.textStatForAssessment = new System.Windows.Forms.TextBox();
            this.checkTaxDecRetain = new System.Windows.Forms.CheckBox();
            this.checkBankUsedRetain = new System.Windows.Forms.CheckBox();
            this.checkTaxNameRetain = new System.Windows.Forms.CheckBox();
            this.checkRequestingParty = new System.Windows.Forms.CheckBox();
            this.btnAddClearAll = new System.Windows.Forms.Button();
            this.dtDateOfPayment = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboBillingSelection = new System.Windows.Forms.ComboBox();
            this.cboPaymentType = new System.Windows.Forms.ComboBox();
            this.cboQuarter = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboBankUsed = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Add New Record";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // textTotalTransferredAmount
            // 
            this.textTotalTransferredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalTransferredAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalTransferredAmount.Location = new System.Drawing.Point(153, 128);
            this.textTotalTransferredAmount.Name = "textTotalTransferredAmount";
            this.textTotalTransferredAmount.Size = new System.Drawing.Size(253, 23);
            this.textTotalTransferredAmount.TabIndex = 4;
            this.textTotalTransferredAmount.Text = "0.00";
            this.textTotalTransferredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTotalTransferredAmount.Click += new System.EventHandler(this.textTotalTransferredAmount_Click);
            this.textTotalTransferredAmount.TextChanged += new System.EventHandler(this.textTransferredAmount_TextChanged);
            this.textTotalTransferredAmount.Enter += new System.EventHandler(this.textTotalTransferredAmount_Enter);
            this.textTotalTransferredAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTotalTransferredAmount_KeyDown);
            this.textTotalTransferredAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTotalTransferredAmount_KeyPress);
            this.textTotalTransferredAmount.Leave += new System.EventHandler(this.textTransferredAmount_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Amount To Be Paid: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Transferred Amount: ";
            // 
            // textYear
            // 
            this.textYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textYear.Location = new System.Drawing.Point(153, 202);
            this.textYear.Name = "textYear";
            this.textYear.Size = new System.Drawing.Size(68, 23);
            this.textYear.TabIndex = 6;
            this.textYear.Click += new System.EventHandler(this.textYearQuarter_Click);
            this.textYear.Enter += new System.EventHandler(this.textYearQuarter_Enter);
            this.textYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textYearQuarter_KeyDown);
            // 
            // textAmountToBePaid
            // 
            this.textAmountToBePaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAmountToBePaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAmountToBePaid.Location = new System.Drawing.Point(153, 92);
            this.textAmountToBePaid.Name = "textAmountToBePaid";
            this.textAmountToBePaid.Size = new System.Drawing.Size(253, 23);
            this.textAmountToBePaid.TabIndex = 3;
            this.textAmountToBePaid.Text = "0.00";
            this.textAmountToBePaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textAmountToBePaid.Click += new System.EventHandler(this.textAmountToBePaid_Click);
            this.textAmountToBePaid.Enter += new System.EventHandler(this.textAmountToBePaid_Enter);
            this.textAmountToBePaid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textAmountToBePaid_KeyDown);
            this.textAmountToBePaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAmountToBePaid_KeyPress);
            this.textAmountToBePaid.Leave += new System.EventHandler(this.textAmountToBePaid_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Bank Used: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Taxpayer\'s Name: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Year/Quarter: ";
            // 
            // textTPName
            // 
            this.textTPName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTPName.Location = new System.Drawing.Point(153, 54);
            this.textTPName.Name = "textTPName";
            this.textTPName.Size = new System.Drawing.Size(253, 23);
            this.textTPName.TabIndex = 2;
            this.textTPName.Click += new System.EventHandler(this.textTPName_Click);
            this.textTPName.Enter += new System.EventHandler(this.textTPName_Enter);
            this.textTPName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTPName_KeyDown);
            // 
            // textTaxDec
            // 
            this.textTaxDec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTaxDec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTaxDec.Location = new System.Drawing.Point(152, 19);
            this.textTaxDec.MaxLength = 50;
            this.textTaxDec.Name = "textTaxDec";
            this.textTaxDec.Size = new System.Drawing.Size(253, 23);
            this.textTaxDec.TabIndex = 1;
            this.textTaxDec.Click += new System.EventHandler(this.textTaxDec_Click);
            this.textTaxDec.TextChanged += new System.EventHandler(this.textTaxDec_TextChanged);
            this.textTaxDec.Enter += new System.EventHandler(this.textTaxDec_Enter);
            this.textTaxDec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTaxDec_KeyDown);
            this.textTaxDec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTaxDec_KeyPress);
            this.textTaxDec.Leave += new System.EventHandler(this.textTaxDec_Leave);
            // 
            // textRequestingParty
            // 
            this.textRequestingParty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRequestingParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRequestingParty.Location = new System.Drawing.Point(153, 359);
            this.textRequestingParty.Name = "textRequestingParty";
            this.textRequestingParty.Size = new System.Drawing.Size(253, 23);
            this.textRequestingParty.TabIndex = 11;
            this.textRequestingParty.Click += new System.EventHandler(this.textRequestingParty_Click);
            this.textRequestingParty.Enter += new System.EventHandler(this.textRequestingParty_Enter);
            this.textRequestingParty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textRequestingParty_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(100, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Status: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Requesting Party: ";
            // 
            // textRemarks
            // 
            this.textRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRemarks.Location = new System.Drawing.Point(153, 397);
            this.textRemarks.Multiline = true;
            this.textRemarks.Name = "textRemarks";
            this.textRemarks.Size = new System.Drawing.Size(253, 105);
            this.textRemarks.TabIndex = 12;
            this.textRemarks.Click += new System.EventHandler(this.textRemarks_Click);
            this.textRemarks.Enter += new System.EventHandler(this.textRemarks_Enter);
            this.textRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textRemarks_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(87, 404);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Remarks: ";
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
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(152, 521);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(253, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save Record";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textStatForAssessment
            // 
            this.textStatForAssessment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textStatForAssessment.Enabled = false;
            this.textStatForAssessment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textStatForAssessment.Location = new System.Drawing.Point(153, 325);
            this.textStatForAssessment.Name = "textStatForAssessment";
            this.textStatForAssessment.Size = new System.Drawing.Size(133, 23);
            this.textStatForAssessment.TabIndex = 110;
            this.textStatForAssessment.Text = "FOR ASSESSMENT";
            this.textStatForAssessment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textStatForAssessment_KeyDown);
            // 
            // checkTaxDecRetain
            // 
            this.checkTaxDecRetain.AutoSize = true;
            this.checkTaxDecRetain.Location = new System.Drawing.Point(426, 21);
            this.checkTaxDecRetain.Name = "checkTaxDecRetain";
            this.checkTaxDecRetain.Size = new System.Drawing.Size(57, 17);
            this.checkTaxDecRetain.TabIndex = 15;
            this.checkTaxDecRetain.Text = "Retain";
            this.checkTaxDecRetain.UseVisualStyleBackColor = true;
            this.checkTaxDecRetain.CheckedChanged += new System.EventHandler(this.checkTaxDecRetain_CheckedChanged);
            // 
            // checkBankUsedRetain
            // 
            this.checkBankUsedRetain.AutoSize = true;
            this.checkBankUsedRetain.Location = new System.Drawing.Point(439, 183);
            this.checkBankUsedRetain.Name = "checkBankUsedRetain";
            this.checkBankUsedRetain.Size = new System.Drawing.Size(57, 17);
            this.checkBankUsedRetain.TabIndex = 15;
            this.checkBankUsedRetain.Text = "Retain";
            this.checkBankUsedRetain.UseVisualStyleBackColor = true;
            this.checkBankUsedRetain.CheckedChanged += new System.EventHandler(this.checkBankUsedRetain_CheckedChanged);
            // 
            // checkTaxNameRetain
            // 
            this.checkTaxNameRetain.AutoSize = true;
            this.checkTaxNameRetain.Location = new System.Drawing.Point(427, 57);
            this.checkTaxNameRetain.Name = "checkTaxNameRetain";
            this.checkTaxNameRetain.Size = new System.Drawing.Size(57, 17);
            this.checkTaxNameRetain.TabIndex = 16;
            this.checkTaxNameRetain.Text = "Retain";
            this.checkTaxNameRetain.UseVisualStyleBackColor = true;
            this.checkTaxNameRetain.CheckedChanged += new System.EventHandler(this.checkTaxNameRetain_CheckedChanged);
            // 
            // checkRequestingParty
            // 
            this.checkRequestingParty.AutoSize = true;
            this.checkRequestingParty.Location = new System.Drawing.Point(427, 361);
            this.checkRequestingParty.Name = "checkRequestingParty";
            this.checkRequestingParty.Size = new System.Drawing.Size(57, 17);
            this.checkRequestingParty.TabIndex = 17;
            this.checkRequestingParty.Text = "Retain";
            this.checkRequestingParty.UseVisualStyleBackColor = true;
            this.checkRequestingParty.CheckedChanged += new System.EventHandler(this.checkRequestingParty_CheckedChanged);
            // 
            // btnAddClearAll
            // 
            this.btnAddClearAll.Location = new System.Drawing.Point(152, 550);
            this.btnAddClearAll.Name = "btnAddClearAll";
            this.btnAddClearAll.Size = new System.Drawing.Size(253, 23);
            this.btnAddClearAll.TabIndex = 14;
            this.btnAddClearAll.Text = "Clear";
            this.btnAddClearAll.UseVisualStyleBackColor = true;
            this.btnAddClearAll.Click += new System.EventHandler(this.btnAddClearAll_Click);
            // 
            // dtDateOfPayment
            // 
            this.dtDateOfPayment.CustomFormat = "MM/dd/yyyy";
            this.dtDateOfPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateOfPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfPayment.Location = new System.Drawing.Point(152, 288);
            this.dtDateOfPayment.Name = "dtDateOfPayment";
            this.dtDateOfPayment.ShowCheckBox = true;
            this.dtDateOfPayment.Size = new System.Drawing.Size(114, 23);
            this.dtDateOfPayment.TabIndex = 10;
            this.dtDateOfPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtDateOfPayment_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Date of Payment: ";
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboBillingSelection);
            this.panel1.Controls.Add(this.cboPaymentType);
            this.panel1.Controls.Add(this.cboQuarter);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cboBankUsed);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtDateOfPayment);
            this.panel1.Controls.Add(this.btnAddClearAll);
            this.panel1.Controls.Add(this.checkRequestingParty);
            this.panel1.Controls.Add(this.checkTaxNameRetain);
            this.panel1.Controls.Add(this.checkTaxDecRetain);
            this.panel1.Controls.Add(this.textStatForAssessment);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textRemarks);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textRequestingParty);
            this.panel1.Controls.Add(this.textTaxDec);
            this.panel1.Controls.Add(this.textTPName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textAmountToBePaid);
            this.panel1.Controls.Add(this.textYear);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textTotalTransferredAmount);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 604);
            this.panel1.TabIndex = 4;
            // 
            // cboBillingSelection
            // 
            this.cboBillingSelection.FormattingEnabled = true;
            this.cboBillingSelection.Location = new System.Drawing.Point(330, 248);
            this.cboBillingSelection.Name = "cboBillingSelection";
            this.cboBillingSelection.Size = new System.Drawing.Size(76, 21);
            this.cboBillingSelection.TabIndex = 9;
            // 
            // cboPaymentType
            // 
            this.cboPaymentType.FormattingEnabled = true;
            this.cboPaymentType.Location = new System.Drawing.Point(152, 248);
            this.cboPaymentType.Name = "cboPaymentType";
            this.cboPaymentType.Size = new System.Drawing.Size(69, 21);
            this.cboPaymentType.Sorted = true;
            this.cboPaymentType.TabIndex = 8;
            // 
            // cboQuarter
            // 
            this.cboQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuarter.FormattingEnabled = true;
            this.cboQuarter.Location = new System.Drawing.Point(291, 203);
            this.cboQuarter.Name = "cboQuarter";
            this.cboQuarter.Size = new System.Drawing.Size(114, 21);
            this.cboQuarter.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(237, 248);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Billing Selection: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(65, 248);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Payment Type: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(237, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Quarter: ";
            // 
            // cboBankUsed
            // 
            this.cboBankUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBankUsed.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboBankUsed.FormattingEnabled = true;
            this.cboBankUsed.Items.AddRange(new object[] {
            "Please select a bank..."});
            this.cboBankUsed.Location = new System.Drawing.Point(152, 166);
            this.cboBankUsed.Name = "cboBankUsed";
            this.cboBankUsed.Size = new System.Drawing.Size(253, 21);
            this.cboBankUsed.TabIndex = 5;
            this.cboBankUsed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboBankUsed_KeyDown);
            this.cboBankUsed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboBankUsed_KeyPress);
            // 
            // AddRPTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 628);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBankUsedRetain);
            this.Name = "AddRPTForm";
            this.Text = "Online Payment Transaction System - Add RPT Form";
            this.Load += new System.EventHandler(this.AddRPTForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDateOfPayment;
        private System.Windows.Forms.Button btnAddClearAll;
        private System.Windows.Forms.CheckBox checkRequestingParty;
        private System.Windows.Forms.CheckBox checkTaxNameRetain;
        private System.Windows.Forms.CheckBox checkBankUsedRetain;
        private System.Windows.Forms.CheckBox checkTaxDecRetain;
        private System.Windows.Forms.TextBox textStatForAssessment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textTotalTransferredAmount;
        private System.Windows.Forms.ComboBox cboBankUsed;
        private System.Windows.Forms.ComboBox cboQuarter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboBillingSelection;
        private System.Windows.Forms.ComboBox cboPaymentType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
    }
}