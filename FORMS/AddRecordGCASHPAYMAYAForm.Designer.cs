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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textServiceProvider = new System.Windows.Forms.TextBox();
            this.textTaxDec = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textEmailAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textAmountDue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textTransactionDate = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstLVGcashPaymaya
            // 
            this.FirstLVGcashPaymaya.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.FirstLVGcashPaymaya.FullRowSelect = true;
            this.FirstLVGcashPaymaya.HideSelection = false;
            this.FirstLVGcashPaymaya.Location = new System.Drawing.Point(12, 12);
            this.FirstLVGcashPaymaya.Name = "FirstLVGcashPaymaya";
            this.FirstLVGcashPaymaya.Size = new System.Drawing.Size(1214, 448);
            this.FirstLVGcashPaymaya.TabIndex = 0;
            this.FirstLVGcashPaymaya.UseCompatibleStateImageBehavior = false;
            this.FirstLVGcashPaymaya.View = System.Windows.Forms.View.Details;
            this.FirstLVGcashPaymaya.SelectedIndexChanged += new System.EventHandler(this.FirstLVGcashPaymaya_SelectedIndexChanged);
            this.FirstLVGcashPaymaya.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FirstLVGcashPaymaya_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Service Provider";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Biller Id";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Biller Info";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Requesting Party ";
            this.columnHeader4.Width = 250;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Amount Due";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Transaction Date";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Existing in DB";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Duplicate in Gcash/Paymaya";
            this.columnHeader8.Width = 150;
            // 
            // textServiceProvider
            // 
            this.textServiceProvider.Enabled = false;
            this.textServiceProvider.Location = new System.Drawing.Point(885, 499);
            this.textServiceProvider.Name = "textServiceProvider";
            this.textServiceProvider.Size = new System.Drawing.Size(203, 20);
            this.textServiceProvider.TabIndex = 1;
            // 
            // textTaxDec
            // 
            this.textTaxDec.Enabled = false;
            this.textTaxDec.Location = new System.Drawing.Point(278, 499);
            this.textTaxDec.Name = "textTaxDec";
            this.textTaxDec.Size = new System.Drawing.Size(203, 20);
            this.textTaxDec.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(882, 483);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Service Provider: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Biller ID or Tax Dec. No.: ";
            // 
            // textEmailAddress
            // 
            this.textEmailAddress.Enabled = false;
            this.textEmailAddress.Location = new System.Drawing.Point(521, 559);
            this.textEmailAddress.Name = "textEmailAddress";
            this.textEmailAddress.Size = new System.Drawing.Size(326, 20);
            this.textEmailAddress.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 543);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Requesting Party: ";
            // 
            // textAmountDue
            // 
            this.textAmountDue.Enabled = false;
            this.textAmountDue.Location = new System.Drawing.Point(278, 559);
            this.textAmountDue.Name = "textAmountDue";
            this.textAmountDue.Size = new System.Drawing.Size(203, 20);
            this.textAmountDue.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 543);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Amount Due: ";
            // 
            // textTransactionDate
            // 
            this.textTransactionDate.Enabled = false;
            this.textTransactionDate.Location = new System.Drawing.Point(885, 559);
            this.textTransactionDate.Name = "textTransactionDate";
            this.textTransactionDate.Size = new System.Drawing.Size(203, 20);
            this.textTransactionDate.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(882, 543);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Transaction Date: ";
            // 
            // textPropertyName
            // 
            this.textPropertyName.Location = new System.Drawing.Point(521, 499);
            this.textPropertyName.Name = "textPropertyName";
            this.textPropertyName.Size = new System.Drawing.Size(326, 20);
            this.textPropertyName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(518, 483);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Property Name: ";
            // 
            // textYearQuarter
            // 
            this.textYearQuarter.Location = new System.Drawing.Point(149, 559);
            this.textYearQuarter.Name = "textYearQuarter";
            this.textYearQuarter.Size = new System.Drawing.Size(83, 20);
            this.textYearQuarter.TabIndex = 1;
            this.textYearQuarter.TextChanged += new System.EventHandler(this.textYearQuarter_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 543);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Year/Quarter: ";
            // 
            // textRPTID
            // 
            this.textRPTID.Enabled = false;
            this.textRPTID.Location = new System.Drawing.Point(31, 499);
            this.textRPTID.Name = "textRPTID";
            this.textRPTID.Size = new System.Drawing.Size(203, 20);
            this.textRPTID.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(28, 483);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "RPT Id: ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1123, 499);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBillQuantity
            // 
            this.textBillQuantity.Location = new System.Drawing.Point(31, 559);
            this.textBillQuantity.Name = "textBillQuantity";
            this.textBillQuantity.Size = new System.Drawing.Size(86, 20);
            this.textBillQuantity.TabIndex = 1;
            this.textBillQuantity.Text = "1";
            this.textBillQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 543);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Tax Bill Quantity: ";
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(1123, 559);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(83, 23);
            this.btnSaveAll.TabIndex = 4;
            this.btnSaveAll.Text = "Save All";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // AddRecordGCASHPAYMAYAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 611);
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
            this.Controls.Add(this.textTransactionDate);
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
        private System.Windows.Forms.TextBox textTransactionDate;
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
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}