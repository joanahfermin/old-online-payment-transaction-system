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
            this.paymentChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paymentDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.qtr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboQuarter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvMultipleRecord
            // 
            this.lvMultipleRecord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.taxDec,
            this.taxpayerName,
            this.Amount2Pay,
            this.YearQuarter,
            this.qtr,
            this.paymentChannel,
            this.paymentDate,
            this.email});
            this.lvMultipleRecord.FullRowSelect = true;
            this.lvMultipleRecord.GridLines = true;
            this.lvMultipleRecord.HideSelection = false;
            this.lvMultipleRecord.Location = new System.Drawing.Point(513, 22);
            this.lvMultipleRecord.Name = "lvMultipleRecord";
            this.lvMultipleRecord.Size = new System.Drawing.Size(1346, 488);
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
            this.YearQuarter.Text = "YearQuarter";
            this.YearQuarter.Width = 120;
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
            // textTotalAmountToPay
            // 
            this.textTotalAmountToPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalAmountToPay.Enabled = false;
            this.textTotalAmountToPay.Location = new System.Drawing.Point(155, 29);
            this.textTotalAmountToPay.Name = "textTotalAmountToPay";
            this.textTotalAmountToPay.Size = new System.Drawing.Size(253, 20);
            this.textTotalAmountToPay.TabIndex = 47;
            this.textTotalAmountToPay.Text = "0.00";
            this.textTotalAmountToPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTotalAmountToPay.TextChanged += new System.EventHandler(this.textTotalAmountToPay_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 36);
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
            this.cboBankUsed.Location = new System.Drawing.Point(155, 288);
            this.cboBankUsed.Name = "cboBankUsed";
            this.cboBankUsed.Size = new System.Drawing.Size(253, 21);
            this.cboBankUsed.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(48, 296);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Payment Channel: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Date of Payment: ";
            // 
            // dtDateOfPayment
            // 
            this.dtDateOfPayment.CustomFormat = "MM/dd/yyyy";
            this.dtDateOfPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfPayment.Location = new System.Drawing.Point(155, 340);
            this.dtDateOfPayment.Name = "dtDateOfPayment";
            this.dtDateOfPayment.Size = new System.Drawing.Size(253, 20);
            this.dtDateOfPayment.TabIndex = 9;
            // 
            // textRequestingParty
            // 
            this.textRequestingParty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRequestingParty.Location = new System.Drawing.Point(155, 192);
            this.textRequestingParty.Name = "textRequestingParty";
            this.textRequestingParty.Size = new System.Drawing.Size(253, 20);
            this.textRequestingParty.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Requesting Party: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 207;
            this.label1.Text = "Update Information";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 208;
            this.label7.Text = "Tax Declaration Number: ";
            // 
            // textTPName
            // 
            this.textTPName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTPName.Location = new System.Drawing.Point(155, 143);
            this.textTPName.Name = "textTPName";
            this.textTPName.Size = new System.Drawing.Size(253, 20);
            this.textTPName.TabIndex = 202;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(50, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 206;
            this.label12.Text = "Taxpayer\'s Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 210;
            this.label2.Text = "Year/Quarter: ";
            // 
            // textYearQuarter
            // 
            this.textYearQuarter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textYearQuarter.Location = new System.Drawing.Point(155, 240);
            this.textYearQuarter.Name = "textYearQuarter";
            this.textYearQuarter.Size = new System.Drawing.Size(80, 20);
            this.textYearQuarter.TabIndex = 204;
            // 
            // textTDN
            // 
            this.textTDN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTDN.Location = new System.Drawing.Point(155, 97);
            this.textTDN.Name = "textTDN";
            this.textTDN.Size = new System.Drawing.Size(253, 20);
            this.textTDN.TabIndex = 201;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboQuarter);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSaveUpdate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboBankUsed);
            this.panel1.Controls.Add(this.textTPName);
            this.panel1.Controls.Add(this.dtDateOfPayment);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.textTotalAmountToPay);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textYearQuarter);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textTDN);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.textRequestingParty);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(12, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 488);
            this.panel1.TabIndex = 209;
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.Location = new System.Drawing.Point(282, 438);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(126, 23);
            this.btnSaveUpdate.TabIndex = 211;
            this.btnSaveUpdate.Text = "Save";
            this.btnSaveUpdate.UseVisualStyleBackColor = true;
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // qtr
            // 
            this.qtr.Text = "Quarter";
            this.qtr.Width = 80;
            // 
            // cboQuarter
            // 
            this.cboQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuarter.FormattingEnabled = true;
            this.cboQuarter.Location = new System.Drawing.Point(294, 239);
            this.cboQuarter.Name = "cboQuarter";
            this.cboQuarter.Size = new System.Drawing.Size(114, 21);
            this.cboQuarter.TabIndex = 213;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 212;
            this.label3.Text = "Quarter: ";
            // 
            // UpdateMultipleRPTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1871, 529);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvMultipleRecord);
            this.Name = "UpdateMultipleRPTForm";
            this.Text = "UpdateMultipleRPTForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
    }
}