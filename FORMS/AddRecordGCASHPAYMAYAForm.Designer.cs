namespace SampleRPT1
{
    partial class AddRecordGCASHPAYMAYAForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRecordGCASHPAYMAYAForm));
            this.FirstLVGcashPaymaya = new System.Windows.Forms.ListView();
            this.serviceProv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taxdec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taxpayername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailadd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amountdue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paymentdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.duplicateindb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.duplicateinlist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textServiceProvider = new System.Windows.Forms.TextBox();
            this.textTaxDec = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textEmailAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textAmountDue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textPropertyName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textYearQuarter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textRPTID = new System.Windows.Forms.TextBox();
            this.labelRPTID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBillQuantity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtTransactionPayment = new System.Windows.Forms.DateTimePicker();
            this.cboQuarter = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.LabelTotalRecords = new System.Windows.Forms.Label();
            this.textNumRec = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textTotalAmount = new System.Windows.Forms.TextBox();
            this.checkSelectAll = new System.Windows.Forms.CheckBox();
            this.rptRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstLVGcashPaymaya
            // 
            this.FirstLVGcashPaymaya.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serviceProv,
            this.taxdec,
            this.year,
            this.taxpayername,
            this.emailadd,
            this.amountdue,
            this.paymentdate,
            this.rptRemarks,
            this.duplicateindb,
            this.duplicateinlist});
            this.FirstLVGcashPaymaya.FullRowSelect = true;
            this.FirstLVGcashPaymaya.GridLines = true;
            this.FirstLVGcashPaymaya.HideSelection = false;
            this.FirstLVGcashPaymaya.Location = new System.Drawing.Point(12, 48);
            this.FirstLVGcashPaymaya.Name = "FirstLVGcashPaymaya";
            this.FirstLVGcashPaymaya.Size = new System.Drawing.Size(1898, 945);
            this.FirstLVGcashPaymaya.TabIndex = 0;
            this.FirstLVGcashPaymaya.UseCompatibleStateImageBehavior = false;
            this.FirstLVGcashPaymaya.View = System.Windows.Forms.View.Details;
            this.FirstLVGcashPaymaya.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.FirstLVGcashPaymaya_ItemSelectionChanged);
            this.FirstLVGcashPaymaya.SelectedIndexChanged += new System.EventHandler(this.FirstLVGcashPaymaya_SelectedIndexChanged);
            // 
            // serviceProv
            // 
            this.serviceProv.Text = "Service Provider";
            this.serviceProv.Width = 130;
            // 
            // taxdec
            // 
            this.taxdec.Text = "Biller Id";
            this.taxdec.Width = 200;
            // 
            // year
            // 
            this.year.Text = "Year";
            this.year.Width = 130;
            // 
            // taxpayername
            // 
            this.taxpayername.Text = "Taxpayer Name";
            this.taxpayername.Width = 320;
            // 
            // emailadd
            // 
            this.emailadd.Text = "Requesting Party ";
            this.emailadd.Width = 280;
            // 
            // amountdue
            // 
            this.amountdue.Text = "Amount Due";
            this.amountdue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amountdue.Width = 250;
            // 
            // paymentdate
            // 
            this.paymentdate.Text = "Transaction Payment Date";
            this.paymentdate.Width = 150;
            // 
            // duplicateindb
            // 
            this.duplicateindb.Text = "Existing in DB";
            this.duplicateindb.Width = 100;
            // 
            // duplicateinlist
            // 
            this.duplicateinlist.Text = "Duplicate in Gcash/Paymaya";
            this.duplicateinlist.Width = 150;
            // 
            // textServiceProvider
            // 
            this.textServiceProvider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textServiceProvider.Enabled = false;
            this.textServiceProvider.Location = new System.Drawing.Point(633, 12);
            this.textServiceProvider.Name = "textServiceProvider";
            this.textServiceProvider.Size = new System.Drawing.Size(88, 20);
            this.textServiceProvider.TabIndex = 10;
            this.textServiceProvider.Visible = false;
            // 
            // textTaxDec
            // 
            this.textTaxDec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTaxDec.Enabled = false;
            this.textTaxDec.Location = new System.Drawing.Point(732, 12);
            this.textTaxDec.Name = "textTaxDec";
            this.textTaxDec.Size = new System.Drawing.Size(129, 20);
            this.textTaxDec.TabIndex = 7;
            this.textTaxDec.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, -4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Service Provider: ";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(733, -4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Biller ID or Tax Dec. No.: ";
            this.label2.Visible = false;
            // 
            // textEmailAddress
            // 
            this.textEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEmailAddress.Enabled = false;
            this.textEmailAddress.Location = new System.Drawing.Point(1458, 12);
            this.textEmailAddress.Name = "textEmailAddress";
            this.textEmailAddress.Size = new System.Drawing.Size(102, 20);
            this.textEmailAddress.TabIndex = 9;
            this.textEmailAddress.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1455, -4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Requesting Party: ";
            this.label3.Visible = false;
            // 
            // textAmountDue
            // 
            this.textAmountDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAmountDue.Enabled = false;
            this.textAmountDue.Location = new System.Drawing.Point(965, 12);
            this.textAmountDue.Name = "textAmountDue";
            this.textAmountDue.Size = new System.Drawing.Size(110, 20);
            this.textAmountDue.TabIndex = 8;
            this.textAmountDue.Text = "0.00";
            this.textAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textAmountDue.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(962, -4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Amount Due: ";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1297, -4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Transaction Date: ";
            this.label5.Visible = false;
            // 
            // textPropertyName
            // 
            this.textPropertyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPropertyName.Location = new System.Drawing.Point(1211, 12);
            this.textPropertyName.Name = "textPropertyName";
            this.textPropertyName.Size = new System.Drawing.Size(80, 20);
            this.textPropertyName.TabIndex = 3;
            this.textPropertyName.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1208, -4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Property Name: ";
            this.label6.Visible = false;
            // 
            // textYearQuarter
            // 
            this.textYearQuarter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textYearQuarter.Location = new System.Drawing.Point(870, 12);
            this.textYearQuarter.Name = "textYearQuarter";
            this.textYearQuarter.Size = new System.Drawing.Size(83, 20);
            this.textYearQuarter.TabIndex = 1;
            this.textYearQuarter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textYearQuarter.Visible = false;
            this.textYearQuarter.TextChanged += new System.EventHandler(this.textYearQuarter_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(867, -4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Year/Quarter: ";
            this.label7.Visible = false;
            // 
            // textRPTID
            // 
            this.textRPTID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRPTID.Enabled = false;
            this.textRPTID.Location = new System.Drawing.Point(556, 12);
            this.textRPTID.Name = "textRPTID";
            this.textRPTID.Size = new System.Drawing.Size(71, 20);
            this.textRPTID.TabIndex = 6;
            this.textRPTID.Visible = false;
            // 
            // labelRPTID
            // 
            this.labelRPTID.AutoSize = true;
            this.labelRPTID.Location = new System.Drawing.Point(503, 19);
            this.labelRPTID.Name = "labelRPTID";
            this.labelRPTID.Size = new System.Drawing.Size(47, 13);
            this.labelRPTID.TabIndex = 2;
            this.labelRPTID.Text = "RPT Id: ";
            this.labelRPTID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(1566, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBillQuantity
            // 
            this.textBillQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBillQuantity.Location = new System.Drawing.Point(463, 12);
            this.textBillQuantity.Name = "textBillQuantity";
            this.textBillQuantity.Size = new System.Drawing.Size(27, 20);
            this.textBillQuantity.TabIndex = 2;
            this.textBillQuantity.Text = "1";
            this.textBillQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBillQuantity.Visible = false;
            this.textBillQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBillQuantity_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(368, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Tax Bill Quantity: ";
            this.label9.Visible = false;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(1762, 19);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(67, 23);
            this.btnSaveAll.TabIndex = 5;
            this.btnSaveAll.Text = "Save All";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // dtTransactionPayment
            // 
            this.dtTransactionPayment.CustomFormat = "MM/dd/yyyy HH:mm:ss ";
            this.dtTransactionPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransactionPayment.Location = new System.Drawing.Point(1300, 12);
            this.dtTransactionPayment.Name = "dtTransactionPayment";
            this.dtTransactionPayment.Size = new System.Drawing.Size(149, 20);
            this.dtTransactionPayment.TabIndex = 12;
            this.dtTransactionPayment.Value = new System.DateTime(2022, 9, 5, 14, 56, 11, 0);
            this.dtTransactionPayment.Visible = false;
            // 
            // cboQuarter
            // 
            this.cboQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuarter.FormattingEnabled = true;
            this.cboQuarter.Location = new System.Drawing.Point(1087, 12);
            this.cboQuarter.Name = "cboQuarter";
            this.cboQuarter.Size = new System.Drawing.Size(114, 21);
            this.cboQuarter.TabIndex = 20;
            this.cboQuarter.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1084, -4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Quarter: ";
            this.label13.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1835, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Total Records: ";
            // 
            // LabelTotalRecords
            // 
            this.LabelTotalRecords.AutoSize = true;
            this.LabelTotalRecords.Location = new System.Drawing.Point(107, 19);
            this.LabelTotalRecords.Name = "LabelTotalRecords";
            this.LabelTotalRecords.Size = new System.Drawing.Size(0, 13);
            this.LabelTotalRecords.TabIndex = 22;
            // 
            // textNumRec
            // 
            this.textNumRec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textNumRec.Enabled = false;
            this.textNumRec.Location = new System.Drawing.Point(107, 12);
            this.textNumRec.Name = "textNumRec";
            this.textNumRec.Size = new System.Drawing.Size(55, 20);
            this.textNumRec.TabIndex = 23;
            this.textNumRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(170, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Total Amount: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(256, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 22;
            // 
            // textTotalAmount
            // 
            this.textTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalAmount.Enabled = false;
            this.textTotalAmount.Location = new System.Drawing.Point(246, 12);
            this.textTotalAmount.Name = "textTotalAmount";
            this.textTotalAmount.Size = new System.Drawing.Size(113, 20);
            this.textTotalAmount.TabIndex = 23;
            this.textTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkSelectAll
            // 
            this.checkSelectAll.AutoSize = true;
            this.checkSelectAll.Location = new System.Drawing.Point(1686, 23);
            this.checkSelectAll.Name = "checkSelectAll";
            this.checkSelectAll.Size = new System.Drawing.Size(70, 17);
            this.checkSelectAll.TabIndex = 24;
            this.checkSelectAll.Text = "Select All";
            this.checkSelectAll.UseVisualStyleBackColor = true;
            this.checkSelectAll.CheckedChanged += new System.EventHandler(this.checkSelectAll_CheckedChanged);
            // 
            // rptRemarks
            // 
            this.rptRemarks.Text = "Remarks";
            this.rptRemarks.Width = 180;
            // 
            // AddRecordGCASHPAYMAYAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1922, 1005);
            this.Controls.Add(this.checkSelectAll);
            this.Controls.Add(this.textTotalAmount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textNumRec);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LabelTotalRecords);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cboQuarter);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtTransactionPayment);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelRPTID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textYearQuarter);
            this.Controls.Add(this.textRPTID);
            this.Controls.Add(this.textBillQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textPropertyName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textAmountDue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textEmailAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textTaxDec);
            this.Controls.Add(this.textServiceProvider);
            this.Controls.Add(this.FirstLVGcashPaymaya);
            this.Name = "AddRecordGCASHPAYMAYAForm";
            this.Text = "AddRecordGCASHPAYMAYAForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView FirstLVGcashPaymaya;
        private System.Windows.Forms.TextBox textServiceProvider;
        private System.Windows.Forms.TextBox textTaxDec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textEmailAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textAmountDue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPropertyName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textYearQuarter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textRPTID;
        private System.Windows.Forms.Label labelRPTID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBillQuantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader serviceProv;
        private System.Windows.Forms.ColumnHeader taxdec;
        private System.Windows.Forms.ColumnHeader year;
        private System.Windows.Forms.ColumnHeader emailadd;
        private System.Windows.Forms.ColumnHeader amountdue;
        private System.Windows.Forms.ColumnHeader paymentdate;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.ColumnHeader duplicateindb;
        private System.Windows.Forms.ColumnHeader duplicateinlist;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker dtTransactionPayment;
        private System.Windows.Forms.ColumnHeader taxpayername;
        private System.Windows.Forms.ComboBox cboQuarter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox textNumRec;
        private System.Windows.Forms.Label LabelTotalRecords;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textTotalAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkSelectAll;
        private System.Windows.Forms.ColumnHeader rptRemarks;
    }
}