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
            this.rptRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.duplicateindb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.duplicateinlist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textRPTID = new System.Windows.Forms.TextBox();
            this.labelRPTID = new System.Windows.Forms.Label();
            this.textBillQuantity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnPrint = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.LabelTotalRecords = new System.Windows.Forms.Label();
            this.textNumRec = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textTotalAmount = new System.Windows.Forms.TextBox();
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
            this.FirstLVGcashPaymaya.Size = new System.Drawing.Size(1898, 932);
            this.FirstLVGcashPaymaya.TabIndex = 0;
            this.FirstLVGcashPaymaya.UseCompatibleStateImageBehavior = false;
            this.FirstLVGcashPaymaya.View = System.Windows.Forms.View.Details;
            this.FirstLVGcashPaymaya.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.FirstLVGcashPaymaya_ItemSelectionChanged);
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
            this.amountdue.Text = "Amount Due / Total Amount Deposited";
            this.amountdue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amountdue.Width = 250;
            // 
            // paymentdate
            // 
            this.paymentdate.Text = "Payment Date";
            this.paymentdate.Width = 150;
            // 
            // rptRemarks
            // 
            this.rptRemarks.Text = "Remarks";
            this.rptRemarks.Width = 180;
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
            // AddRecordGCASHPAYMAYAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1922, 1005);
            this.Controls.Add(this.textTotalAmount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textNumRec);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LabelTotalRecords);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.labelRPTID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textRPTID);
            this.Controls.Add(this.textBillQuantity);
            this.Controls.Add(this.FirstLVGcashPaymaya);
            this.Name = "AddRecordGCASHPAYMAYAForm";
            this.Text = "Online Payment Transaction System - Add EPayment Rpt Form";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView FirstLVGcashPaymaya;
        private System.Windows.Forms.TextBox textRPTID;
        private System.Windows.Forms.Label labelRPTID;
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
        private System.Windows.Forms.ColumnHeader taxpayername;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox textNumRec;
        private System.Windows.Forms.Label LabelTotalRecords;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textTotalAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColumnHeader rptRemarks;
    }
}