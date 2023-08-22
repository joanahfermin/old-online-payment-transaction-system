namespace SampleRPT1.FORMS
{
    partial class AddBusinessForm
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
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboQuarter = new System.Windows.Forms.ComboBox();
            this.cboPaymentType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDateOfPayment = new System.Windows.Forms.DateTimePicker();
            this.textStatForAssessment = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textRemarks = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textRequestingParty = new System.Windows.Forms.TextBox();
            this.textMP_Num = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textAmountToBePaid = new System.Windows.Forms.TextBox();
            this.textYear = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textTotalTransferredAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboBusType = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbTaxpayersName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbBusinessName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbBillNumber = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbMisc_Fees = new System.Windows.Forms.TextBox();
            this.tbContactNumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(237, 361);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Quarter: ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboBusType);
            this.panel1.Controls.Add(this.cboQuarter);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cboPaymentType);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtDateOfPayment);
            this.panel1.Controls.Add(this.textStatForAssessment);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textRemarks);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tbContactNumber);
            this.panel1.Controls.Add(this.textRequestingParty);
            this.panel1.Controls.Add(this.tbBillNumber);
            this.panel1.Controls.Add(this.tbBusinessName);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.tbTaxpayersName);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.textMP_Num);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbMisc_Fees);
            this.panel1.Controls.Add(this.textAmountToBePaid);
            this.panel1.Controls.Add(this.textYear);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textTotalTransferredAmount);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 792);
            this.panel1.TabIndex = 16;
            // 
            // cboQuarter
            // 
            this.cboQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuarter.FormattingEnabled = true;
            this.cboQuarter.Location = new System.Drawing.Point(291, 361);
            this.cboQuarter.Name = "cboQuarter";
            this.cboQuarter.Size = new System.Drawing.Size(114, 21);
            this.cboQuarter.TabIndex = 10;
            // 
            // cboPaymentType
            // 
            this.cboPaymentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaymentType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboPaymentType.FormattingEnabled = true;
            this.cboPaymentType.Items.AddRange(new object[] {
            "Please select a bank..."});
            this.cboPaymentType.Location = new System.Drawing.Point(152, 445);
            this.cboPaymentType.Name = "cboPaymentType";
            this.cboPaymentType.Size = new System.Drawing.Size(253, 21);
            this.cboPaymentType.TabIndex = 12;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 486);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Date of Payment: ";
            // 
            // dtDateOfPayment
            // 
            this.dtDateOfPayment.CustomFormat = "MM/dd/yyyy";
            this.dtDateOfPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateOfPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfPayment.Location = new System.Drawing.Point(152, 486);
            this.dtDateOfPayment.Name = "dtDateOfPayment";
            this.dtDateOfPayment.ShowCheckBox = true;
            this.dtDateOfPayment.Size = new System.Drawing.Size(114, 23);
            this.dtDateOfPayment.TabIndex = 13;
            // 
            // textStatForAssessment
            // 
            this.textStatForAssessment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textStatForAssessment.Enabled = false;
            this.textStatForAssessment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textStatForAssessment.Location = new System.Drawing.Point(152, 404);
            this.textStatForAssessment.Name = "textStatForAssessment";
            this.textStatForAssessment.Size = new System.Drawing.Size(133, 23);
            this.textStatForAssessment.TabIndex = 11;
            this.textStatForAssessment.Text = "FOR ASSESSMENT";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(152, 745);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(253, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save Record";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Business Type: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(87, 619);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Remarks: ";
            // 
            // textRemarks
            // 
            this.textRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRemarks.Location = new System.Drawing.Point(152, 619);
            this.textRemarks.Multiline = true;
            this.textRemarks.Name = "textRemarks";
            this.textRemarks.Size = new System.Drawing.Size(253, 105);
            this.textRemarks.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 528);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Requesting Party: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(99, 404);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Status: ";
            // 
            // textRequestingParty
            // 
            this.textRequestingParty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRequestingParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRequestingParty.Location = new System.Drawing.Point(152, 528);
            this.textRequestingParty.Name = "textRequestingParty";
            this.textRequestingParty.Size = new System.Drawing.Size(253, 23);
            this.textRequestingParty.TabIndex = 14;
            // 
            // textMP_Num
            // 
            this.textMP_Num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textMP_Num.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMP_Num.Location = new System.Drawing.Point(153, 54);
            this.textMP_Num.Name = "textMP_Num";
            this.textMP_Num.Size = new System.Drawing.Size(253, 23);
            this.textMP_Num.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Year/Quarter: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "MP Number:  ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 445);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Bank Used: ";
            // 
            // textAmountToBePaid
            // 
            this.textAmountToBePaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAmountToBePaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAmountToBePaid.Location = new System.Drawing.Point(152, 229);
            this.textAmountToBePaid.Name = "textAmountToBePaid";
            this.textAmountToBePaid.Size = new System.Drawing.Size(134, 23);
            this.textAmountToBePaid.TabIndex = 6;
            this.textAmountToBePaid.Text = "0.00";
            this.textAmountToBePaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textYear
            // 
            this.textYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textYear.Location = new System.Drawing.Point(152, 361);
            this.textYear.Name = "textYear";
            this.textYear.Size = new System.Drawing.Size(68, 23);
            this.textYear.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Transferred Amount: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Amount To Be Paid: ";
            // 
            // textTotalTransferredAmount
            // 
            this.textTotalTransferredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalTransferredAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalTransferredAmount.Location = new System.Drawing.Point(152, 317);
            this.textTotalTransferredAmount.Name = "textTotalTransferredAmount";
            this.textTotalTransferredAmount.Size = new System.Drawing.Size(134, 23);
            this.textTotalTransferredAmount.TabIndex = 8;
            this.textTotalTransferredAmount.Text = "0.00";
            this.textTotalTransferredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Add New Record";
            // 
            // cboBusType
            // 
            this.cboBusType.FormattingEnabled = true;
            this.cboBusType.Location = new System.Drawing.Point(153, 17);
            this.cboBusType.Name = "cboBusType";
            this.cboBusType.Size = new System.Drawing.Size(252, 21);
            this.cboBusType.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(49, 94);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Taxpayer\'s Name: ";
            // 
            // tbTaxpayersName
            // 
            this.tbTaxpayersName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTaxpayersName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTaxpayersName.Location = new System.Drawing.Point(152, 94);
            this.tbTaxpayersName.Name = "tbTaxpayersName";
            this.tbTaxpayersName.Size = new System.Drawing.Size(253, 23);
            this.tbTaxpayersName.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(61, 137);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Business Name: ";
            // 
            // tbBusinessName
            // 
            this.tbBusinessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBusinessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusinessName.Location = new System.Drawing.Point(152, 137);
            this.tbBusinessName.Name = "tbBusinessName";
            this.tbBusinessName.Size = new System.Drawing.Size(253, 23);
            this.tbBusinessName.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(80, 181);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Bill Number: ";
            // 
            // tbBillNumber
            // 
            this.tbBillNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBillNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBillNumber.Location = new System.Drawing.Point(152, 181);
            this.tbBillNumber.Name = "tbBillNumber";
            this.tbBillNumber.Size = new System.Drawing.Size(253, 23);
            this.tbBillNumber.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(77, 271);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Misc. Fees:  ";
            // 
            // tbMisc_Fees
            // 
            this.tbMisc_Fees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMisc_Fees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMisc_Fees.Location = new System.Drawing.Point(152, 271);
            this.tbMisc_Fees.Name = "tbMisc_Fees";
            this.tbMisc_Fees.Size = new System.Drawing.Size(134, 23);
            this.tbMisc_Fees.TabIndex = 7;
            this.tbMisc_Fees.Text = "0.00";
            this.tbMisc_Fees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbContactNumber
            // 
            this.tbContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbContactNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContactNumber.Location = new System.Drawing.Point(152, 571);
            this.tbContactNumber.Name = "tbContactNumber";
            this.tbContactNumber.Size = new System.Drawing.Size(253, 23);
            this.tbContactNumber.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(52, 571);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Contact Number: ";
            // 
            // AddBusinessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 816);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Name = "AddBusinessForm";
            this.Text = "AddBusinessForm";
            this.Load += new System.EventHandler(this.AddBusinessForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboQuarter;
        private System.Windows.Forms.ComboBox cboPaymentType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDateOfPayment;
        private System.Windows.Forms.TextBox textStatForAssessment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textRemarks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textRequestingParty;
        private System.Windows.Forms.TextBox textMP_Num;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textAmountToBePaid;
        private System.Windows.Forms.TextBox textYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textTotalTransferredAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboBusType;
        private System.Windows.Forms.TextBox tbBillNumber;
        private System.Windows.Forms.TextBox tbBusinessName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbTaxpayersName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbContactNumber;
        private System.Windows.Forms.TextBox tbMisc_Fees;
        private System.Windows.Forms.Label label19;
    }
}