namespace SampleRPT1
{
    partial class UpdateMultipleRPTForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateMultipleRPTForm));
            this.lvMultipleRecord = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taxDec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taxpayerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount2Pay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YearQuarter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qtr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paymentChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paymentDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textTotalAmountToPay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboBankUsed = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtDateOfPayment = new System.Windows.Forms.DateTimePicker();
            this.textRequestingParty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textTPName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textYearQuarter = new System.Windows.Forms.TextBox();
            this.textTDN = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.textRemarks = new System.Windows.Forms.TextBox();
            this.textAmountToBePay = new System.Windows.Forms.TextBox();
            this.labelAmountToBPay = new System.Windows.Forms.Label();
            this.cboQuarter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textTotalTransferredAmount = new System.Windows.Forms.TextBox();
            this.totalAmountTrans = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvMultipleRecord
            // 
            this.lvMultipleRecord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.taxDec,
            this.taxpayerName,
            this.Amount2Pay,
            this.totalAmountTrans,
            this.YearQuarter,
            this.qtr,
            this.paymentChannel,
            this.paymentDate,
            this.email,
            this.remarks});
            this.lvMultipleRecord.FullRowSelect = true;
            this.lvMultipleRecord.GridLines = true;
            this.lvMultipleRecord.HideSelection = false;
            this.lvMultipleRecord.Location = new System.Drawing.Point(513, 47);
            this.lvMultipleRecord.Name = "lvMultipleRecord";
            this.lvMultipleRecord.Size = new System.Drawing.Size(1346, 518);
            this.lvMultipleRecord.TabIndex = 1;
            this.lvMultipleRecord.UseCompatibleStateImageBehavior = false;
            this.lvMultipleRecord.View = System.Windows.Forms.View.Details;
            this.lvMultipleRecord.SelectedIndexChanged += new System.EventHandler(this.lvMultipleRecord_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "RPTID";
            // 
            // taxDec
            // 
            this.taxDec.Text = "Tax Dec Num.";
            this.taxDec.Width = 150;
            // 
            // taxpayerName
            // 
            this.taxpayerName.Text = "Tax Payer Name";
            this.taxpayerName.Width = 250;
            // 
            // Amount2Pay
            // 
            this.Amount2Pay.Text = "Amount To Pay";
            this.Amount2Pay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Amount2Pay.Width = 120;
            // 
            // YearQuarter
            // 
            this.YearQuarter.Text = "Year";
            this.YearQuarter.Width = 120;
            // 
            // qtr
            // 
            this.qtr.Text = "Quarter";
            this.qtr.Width = 80;
            // 
            // paymentChannel
            // 
            this.paymentChannel.Text = "Payment Channel";
            this.paymentChannel.Width = 180;
            // 
            // paymentDate
            // 
            this.paymentDate.Text = "Payment Date";
            this.paymentDate.Width = 130;
            // 
            // email
            // 
            this.email.Text = "Requesting Party";
            this.email.Width = 250;
            // 
            // remarks
            // 
            this.remarks.Text = "Remarks";
            this.remarks.Width = 150;
            // 
            // textTotalAmountToPay
            // 
            this.textTotalAmountToPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalAmountToPay.Enabled = false;
            this.textTotalAmountToPay.Location = new System.Drawing.Point(631, 15);
            this.textTotalAmountToPay.Name = "textTotalAmountToPay";
            this.textTotalAmountToPay.Size = new System.Drawing.Size(153, 20);
            this.textTotalAmountToPay.TabIndex = 47;
            this.textTotalAmountToPay.Text = "0.00";
            this.textTotalAmountToPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTotalAmountToPay.TextChanged += new System.EventHandler(this.textTotalAmountToPay_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(512, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Total Amount To Pay: ";
            // 
            // cboBankUsed
            // 
            this.cboBankUsed.FormattingEnabled = true;
            this.cboBankUsed.ItemHeight = 13;
            this.cboBankUsed.Items.AddRange(new object[] {
            "Please select a bank..."});
            this.cboBankUsed.Location = new System.Drawing.Point(141, 19);
            this.cboBankUsed.Name = "cboBankUsed";
            this.cboBankUsed.Size = new System.Drawing.Size(253, 21);
            this.cboBankUsed.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(41, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Payment Channel: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Date of Payment: ";
            // 
            // dtDateOfPayment
            // 
            this.dtDateOfPayment.CustomFormat = "MM/dd/yyyy";
            this.dtDateOfPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfPayment.Location = new System.Drawing.Point(141, 56);
            this.dtDateOfPayment.Name = "dtDateOfPayment";
            this.dtDateOfPayment.Size = new System.Drawing.Size(102, 20);
            this.dtDateOfPayment.TabIndex = 8;
            // 
            // textRequestingParty
            // 
            this.textRequestingParty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRequestingParty.Location = new System.Drawing.Point(141, 95);
            this.textRequestingParty.Name = "textRequestingParty";
            this.textRequestingParty.Size = new System.Drawing.Size(253, 20);
            this.textRequestingParty.TabIndex = 9;
            this.textRequestingParty.Click += new System.EventHandler(this.textRequestingParty_Click);
            this.textRequestingParty.Enter += new System.EventHandler(this.textRequestingParty_Enter);
            this.textRequestingParty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textRequestingParty_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Requesting Party: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 207;
            this.label1.Text = "Update Information";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 208;
            this.label7.Text = "Tax Declaration Number: ";
            // 
            // textTPName
            // 
            this.textTPName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTPName.Location = new System.Drawing.Point(141, 53);
            this.textTPName.Name = "textTPName";
            this.textTPName.Size = new System.Drawing.Size(253, 20);
            this.textTPName.TabIndex = 2;
            this.textTPName.Click += new System.EventHandler(this.textTPName_Click);
            this.textTPName.Enter += new System.EventHandler(this.textTPName_Enter);
            this.textTPName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTPName_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(40, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 206;
            this.label12.Text = "Taxpayer\'s Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 210;
            this.label2.Text = "Year: ";
            // 
            // textYearQuarter
            // 
            this.textYearQuarter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textYearQuarter.Location = new System.Drawing.Point(140, 92);
            this.textYearQuarter.Name = "textYearQuarter";
            this.textYearQuarter.Size = new System.Drawing.Size(80, 20);
            this.textYearQuarter.TabIndex = 3;
            this.textYearQuarter.Click += new System.EventHandler(this.textYearQuarter_Click);
            this.textYearQuarter.Enter += new System.EventHandler(this.textYearQuarter_Enter);
            this.textYearQuarter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textYearQuarter_KeyDown);
            // 
            // textTDN
            // 
            this.textTDN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTDN.Location = new System.Drawing.Point(141, 17);
            this.textTDN.Name = "textTDN";
            this.textTDN.Size = new System.Drawing.Size(253, 20);
            this.textTDN.TabIndex = 1;
            this.textTDN.Click += new System.EventHandler(this.textTDN_Click);
            this.textTDN.Enter += new System.EventHandler(this.textTDN_Enter);
            this.textTDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTDN_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textRemarks);
            this.panel1.Controls.Add(this.textAmountToBePay);
            this.panel1.Controls.Add(this.labelAmountToBPay);
            this.panel1.Controls.Add(this.cboQuarter);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textTPName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textYearQuarter);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textTDN);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(14, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 242);
            this.panel1.TabIndex = 209;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(74, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 216;
            this.label10.Text = "Remarks: ";
            // 
            // textRemarks
            // 
            this.textRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRemarks.Location = new System.Drawing.Point(140, 171);
            this.textRemarks.Multiline = true;
            this.textRemarks.Name = "textRemarks";
            this.textRemarks.Size = new System.Drawing.Size(253, 20);
            this.textRemarks.TabIndex = 6;
            // 
            // textAmountToBePay
            // 
            this.textAmountToBePay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAmountToBePay.Location = new System.Drawing.Point(140, 130);
            this.textAmountToBePay.Name = "textAmountToBePay";
            this.textAmountToBePay.Size = new System.Drawing.Size(134, 20);
            this.textAmountToBePay.TabIndex = 5;
            this.textAmountToBePay.Text = "0.00";
            this.textAmountToBePay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textAmountToBePay.Click += new System.EventHandler(this.textAmountToBePay_Click);
            this.textAmountToBePay.TextChanged += new System.EventHandler(this.textAmountToBePay_TextChanged);
            this.textAmountToBePay.Enter += new System.EventHandler(this.textAmountToBePay_Enter);
            this.textAmountToBePay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textAmountToBePay_KeyDown);
            this.textAmountToBePay.Leave += new System.EventHandler(this.textAmountToBePay_Leave);
            // 
            // labelAmountToBPay
            // 
            this.labelAmountToBPay.AutoSize = true;
            this.labelAmountToBPay.Location = new System.Drawing.Point(44, 137);
            this.labelAmountToBPay.Name = "labelAmountToBPay";
            this.labelAmountToBPay.Size = new System.Drawing.Size(86, 13);
            this.labelAmountToBPay.TabIndex = 214;
            this.labelAmountToBPay.Text = "Amount To Pay: ";
            // 
            // cboQuarter
            // 
            this.cboQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuarter.FormattingEnabled = true;
            this.cboQuarter.Location = new System.Drawing.Point(280, 92);
            this.cboQuarter.Name = "cboQuarter";
            this.cboQuarter.Size = new System.Drawing.Size(114, 21);
            this.cboQuarter.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 212;
            this.label3.Text = "Quarter: ";
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.Location = new System.Drawing.Point(141, 205);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(126, 23);
            this.btnSaveUpdate.TabIndex = 11;
            this.btnSaveUpdate.Text = "Save";
            this.btnSaveUpdate.UseVisualStyleBackColor = true;
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.Location = new System.Drawing.Point(1790, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 23);
            this.btnDelete.TabIndex = 214;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 143);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 13);
            this.label14.TabIndex = 218;
            this.label14.Text = "Total Amount Deposited: ";
            // 
            // textTotalTransferredAmount
            // 
            this.textTotalTransferredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalTransferredAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalTransferredAmount.Location = new System.Drawing.Point(141, 136);
            this.textTotalTransferredAmount.Name = "textTotalTransferredAmount";
            this.textTotalTransferredAmount.Size = new System.Drawing.Size(130, 20);
            this.textTotalTransferredAmount.TabIndex = 10;
            this.textTotalTransferredAmount.Text = "0.00";
            this.textTotalTransferredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTotalTransferredAmount.Leave += new System.EventHandler(this.textTotalTransferredAmount_Leave);
            // 
            // totalAmountTrans
            // 
            this.totalAmountTrans.Text = "Total Amount Transferred";
            this.totalAmountTrans.Width = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 219;
            this.label4.Text = "Payment Information";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cboBankUsed);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.textRequestingParty);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textTotalTransferredAmount);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.btnSaveUpdate);
            this.panel2.Controls.Add(this.dtDateOfPayment);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(13, 308);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 257);
            this.panel2.TabIndex = 220;
            // 
            // UpdateMultipleRPTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1871, 578);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvMultipleRecord);
            this.Controls.Add(this.textTotalAmountToPay);
            this.Controls.Add(this.label8);
            this.Name = "UpdateMultipleRPTForm";
            this.Text = "UpdateMultipleRPTForm";
            this.Load += new System.EventHandler(this.UpdateMultipleRPTForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvMultipleRecord;
        private System.Windows.Forms.ColumnHeader taxDec;
        private System.Windows.Forms.ColumnHeader taxpayerName;
        private System.Windows.Forms.ColumnHeader Amount2Pay;
        private System.Windows.Forms.ColumnHeader YearQuarter;
        private System.Windows.Forms.TextBox textTotalAmountToPay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboBankUsed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtDateOfPayment;
        private System.Windows.Forms.TextBox textRequestingParty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textTPName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textYearQuarter;
        private System.Windows.Forms.TextBox textTDN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader email;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnSaveUpdate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ColumnHeader paymentChannel;
        private System.Windows.Forms.ColumnHeader paymentDate;
        private System.Windows.Forms.ColumnHeader qtr;
        private System.Windows.Forms.ComboBox cboQuarter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox textAmountToBePay;
        private System.Windows.Forms.Label labelAmountToBPay;
        private System.Windows.Forms.ColumnHeader remarks;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textRemarks;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textTotalTransferredAmount;
        private System.Windows.Forms.ColumnHeader totalAmountTrans;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
    }
}