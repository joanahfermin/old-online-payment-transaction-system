﻿namespace SampleRPT1
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
            this.amountdue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taxpayername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paymentdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailadd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBillQuantity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtTransactionPayment = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstLVGcashPaymaya
            // 
            this.FirstLVGcashPaymaya.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serviceProv,
            this.taxdec,
            this.year,
            this.amountdue,
            this.taxpayername,
            this.paymentdate,
            this.emailadd,
            this.duplicateindb,
            this.duplicateinlist});
            this.FirstLVGcashPaymaya.FullRowSelect = true;
            this.FirstLVGcashPaymaya.GridLines = true;
            this.FirstLVGcashPaymaya.HideSelection = false;
            this.FirstLVGcashPaymaya.Location = new System.Drawing.Point(12, 91);
            this.FirstLVGcashPaymaya.Name = "FirstLVGcashPaymaya";
            this.FirstLVGcashPaymaya.Size = new System.Drawing.Size(1537, 448);
            this.FirstLVGcashPaymaya.TabIndex = 0;
            this.FirstLVGcashPaymaya.UseCompatibleStateImageBehavior = false;
            this.FirstLVGcashPaymaya.View = System.Windows.Forms.View.Details;
            this.FirstLVGcashPaymaya.SelectedIndexChanged += new System.EventHandler(this.FirstLVGcashPaymaya_SelectedIndexChanged);
            this.FirstLVGcashPaymaya.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FirstLVGcashPaymaya_MouseClick);
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
            this.year.Text = "YearQuarter";
            this.year.Width = 100;
            // 
            // amountdue
            // 
            this.amountdue.Text = "Amount Due";
            this.amountdue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amountdue.Width = 150;
            // 
            // taxpayername
            // 
            this.taxpayername.Text = "Taxpayer Name";
            this.taxpayername.Width = 300;
            // 
            // paymentdate
            // 
            this.paymentdate.Text = "Transaction Payment Date";
            this.paymentdate.Width = 150;
            // 
            // emailadd
            // 
            this.emailadd.Text = "Requesting Party ";
            this.emailadd.Width = 250;
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
            this.textServiceProvider.Location = new System.Drawing.Point(15, 61);
            this.textServiceProvider.Name = "textServiceProvider";
            this.textServiceProvider.Size = new System.Drawing.Size(162, 20);
            this.textServiceProvider.TabIndex = 10;
            // 
            // textTaxDec
            // 
            this.textTaxDec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTaxDec.Enabled = false;
            this.textTaxDec.Location = new System.Drawing.Point(199, 61);
            this.textTaxDec.Name = "textTaxDec";
            this.textTaxDec.Size = new System.Drawing.Size(203, 20);
            this.textTaxDec.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Service Provider: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Biller ID or Tax Dec. No.: ";
            // 
            // textEmailAddress
            // 
            this.textEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEmailAddress.Enabled = false;
            this.textEmailAddress.Location = new System.Drawing.Point(1093, 61);
            this.textEmailAddress.Name = "textEmailAddress";
            this.textEmailAddress.Size = new System.Drawing.Size(203, 20);
            this.textEmailAddress.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1090, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Requesting Party: ";
            // 
            // textAmountDue
            // 
            this.textAmountDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAmountDue.Enabled = false;
            this.textAmountDue.Location = new System.Drawing.Point(530, 61);
            this.textAmountDue.Name = "textAmountDue";
            this.textAmountDue.Size = new System.Drawing.Size(110, 20);
            this.textAmountDue.TabIndex = 8;
            this.textAmountDue.Text = "0.00";
            this.textAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Amount Due: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(920, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Transaction Date: ";
            // 
            // textPropertyName
            // 
            this.textPropertyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPropertyName.Location = new System.Drawing.Point(663, 61);
            this.textPropertyName.Name = "textPropertyName";
            this.textPropertyName.Size = new System.Drawing.Size(237, 20);
            this.textPropertyName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(660, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Property Name: ";
            // 
            // textYearQuarter
            // 
            this.textYearQuarter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textYearQuarter.Location = new System.Drawing.Point(424, 61);
            this.textYearQuarter.Name = "textYearQuarter";
            this.textYearQuarter.Size = new System.Drawing.Size(83, 20);
            this.textYearQuarter.TabIndex = 1;
            this.textYearQuarter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textYearQuarter.TextChanged += new System.EventHandler(this.textYearQuarter_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(421, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Year/Quarter: ";
            // 
            // textRPTID
            // 
            this.textRPTID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRPTID.Enabled = false;
            this.textRPTID.Location = new System.Drawing.Point(65, 12);
            this.textRPTID.Name = "textRPTID";
            this.textRPTID.Size = new System.Drawing.Size(71, 20);
            this.textRPTID.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "RPT Id: ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1383, 48);
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
            this.textBillQuantity.Location = new System.Drawing.Point(246, 12);
            this.textBillQuantity.Name = "textBillQuantity";
            this.textBillQuantity.Size = new System.Drawing.Size(27, 20);
            this.textBillQuantity.TabIndex = 2;
            this.textBillQuantity.Text = "1";
            this.textBillQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBillQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBillQuantity_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(151, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Tax Bill Quantity: ";
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(1383, 19);
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
            this.dtTransactionPayment.Location = new System.Drawing.Point(923, 61);
            this.dtTransactionPayment.Name = "dtTransactionPayment";
            this.dtTransactionPayment.Size = new System.Drawing.Size(149, 20);
            this.dtTransactionPayment.TabIndex = 12;
            this.dtTransactionPayment.Value = new System.DateTime(2022, 9, 5, 14, 56, 11, 0);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.Location = new System.Drawing.Point(1456, 48);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // AddRecordGCASHPAYMAYAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1563, 553);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dtTransactionPayment);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
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
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.Button btnDelete;
    }
}