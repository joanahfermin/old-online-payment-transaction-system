namespace SampleRPT1.FORMS
{
    partial class BusinessTaxForm
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
            this.textRecSelected = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.cboAction = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textTotalAmountTransferred = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textTotalAmount2Pay = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textTDN = new System.Windows.Forms.TextBox();
            this.btnMultipleRecordOnePayment = new System.Windows.Forms.Button();
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RPTInfoLV = new System.Windows.Forms.ListView();
            this.BusId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Bus_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MPNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaxpayersName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BusinessName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BillNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BillAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MiscFees = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Year_Qtrs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PaymentChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VerifiedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VerifiedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValidatedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValidatedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reqParty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContactNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BussinessRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EncodedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EncodedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UploadedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UploadedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReleasedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReleasedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textRecSelected
            // 
            this.textRecSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRecSelected.Enabled = false;
            this.textRecSelected.Location = new System.Drawing.Point(610, 110);
            this.textRecSelected.Name = "textRecSelected";
            this.textRecSelected.Size = new System.Drawing.Size(63, 20);
            this.textRecSelected.TabIndex = 70;
            this.textRecSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Search by Tax Declaration Number";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(598, 60);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 61;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // cboAction
            // 
            this.cboAction.FormattingEnabled = true;
            this.cboAction.Location = new System.Drawing.Point(471, 35);
            this.cboAction.Name = "cboAction";
            this.cboAction.Size = new System.Drawing.Size(202, 21);
            this.cboAction.Sorted = true;
            this.cboAction.TabIndex = 60;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(422, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 69;
            this.label15.Text = "Action: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(506, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Records Selected: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(256, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 13);
            this.label11.TabIndex = 66;
            this.label11.Text = "Total Amount Transferred:";
            // 
            // textTotalAmountTransferred
            // 
            this.textTotalAmountTransferred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalAmountTransferred.Enabled = false;
            this.textTotalAmountTransferred.Location = new System.Drawing.Point(392, 110);
            this.textTotalAmountTransferred.Name = "textTotalAmountTransferred";
            this.textTotalAmountTransferred.Size = new System.Drawing.Size(92, 20);
            this.textTotalAmountTransferred.TabIndex = 62;
            this.textTotalAmountTransferred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 64;
            this.label10.Text = "Total Amount To Pay: ";
            // 
            // textTotalAmount2Pay
            // 
            this.textTotalAmount2Pay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalAmount2Pay.Enabled = false;
            this.textTotalAmount2Pay.Location = new System.Drawing.Point(143, 110);
            this.textTotalAmount2Pay.Name = "textTotalAmount2Pay";
            this.textTotalAmount2Pay.Size = new System.Drawing.Size(92, 20);
            this.textTotalAmount2Pay.TabIndex = 63;
            this.textTotalAmount2Pay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textTDN);
            this.panel1.Controls.Add(this.btnMultipleRecordOnePayment);
            this.panel1.Controls.Add(this.btnAddRecord);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(21, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 75);
            this.panel1.TabIndex = 67;
            // 
            // textTDN
            // 
            this.textTDN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTDN.Location = new System.Drawing.Point(82, 13);
            this.textTDN.Name = "textTDN";
            this.textTDN.Size = new System.Drawing.Size(276, 20);
            this.textTDN.TabIndex = 0;
            this.textTDN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnMultipleRecordOnePayment
            // 
            this.btnMultipleRecordOnePayment.Location = new System.Drawing.Point(213, 37);
            this.btnMultipleRecordOnePayment.Name = "btnMultipleRecordOnePayment";
            this.btnMultipleRecordOnePayment.Size = new System.Drawing.Size(145, 23);
            this.btnMultipleRecordOnePayment.TabIndex = 2;
            this.btnMultipleRecordOnePayment.Text = "Multiple Record 1 Payment";
            this.btnMultipleRecordOnePayment.UseVisualStyleBackColor = true;
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(82, 37);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(125, 23);
            this.btnAddRecord.TabIndex = 1;
            this.btnAddRecord.Text = "Add New Record";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Enter TDN: ";
            // 
            // RPTInfoLV
            // 
            this.RPTInfoLV.BackColor = System.Drawing.SystemColors.Window;
            this.RPTInfoLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BusId,
            this.Bus_Type,
            this.MPNum,
            this.TaxpayersName,
            this.BusinessName,
            this.BillNumber,
            this.BillAmount,
            this.MiscFees,
            this.TotalAmount,
            this.Year_Qtrs,
            this.stat,
            this.PaymentChannel,
            this.VerifiedBy,
            this.VerifiedDate,
            this.ValidatedBy,
            this.ValidatedDate,
            this.reqParty,
            this.ContactNumber,
            this.BussinessRemarks,
            this.EncodedBy,
            this.EncodedDate,
            this.UploadedBy,
            this.UploadedDate,
            this.ReleasedBy,
            this.ReleasedDate});
            this.RPTInfoLV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPTInfoLV.FullRowSelect = true;
            this.RPTInfoLV.GridLines = true;
            this.RPTInfoLV.HideSelection = false;
            this.RPTInfoLV.Location = new System.Drawing.Point(21, 146);
            this.RPTInfoLV.Name = "RPTInfoLV";
            this.RPTInfoLV.Size = new System.Drawing.Size(1875, 814);
            this.RPTInfoLV.TabIndex = 71;
            this.RPTInfoLV.UseCompatibleStateImageBehavior = false;
            this.RPTInfoLV.View = System.Windows.Forms.View.Details;
            // 
            // BusId
            // 
            this.BusId.Text = "BusinessId";
            this.BusId.Width = 80;
            // 
            // Bus_Type
            // 
            this.Bus_Type.Text = "Business Type";
            this.Bus_Type.Width = 100;
            // 
            // MPNum
            // 
            this.MPNum.Text = "MP Number";
            this.MPNum.Width = 100;
            // 
            // TaxpayersName
            // 
            this.TaxpayersName.Text = "Taxpayers Name";
            this.TaxpayersName.Width = 180;
            // 
            // BusinessName
            // 
            this.BusinessName.Text = "BusinessName";
            this.BusinessName.Width = 250;
            // 
            // BillNumber
            // 
            this.BillNumber.Text = "Billl Number";
            this.BillNumber.Width = 130;
            // 
            // BillAmount
            // 
            this.BillAmount.Text = "Bill Amount";
            this.BillAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BillAmount.Width = 100;
            // 
            // MiscFees
            // 
            this.MiscFees.Text = "Misc Fees";
            this.MiscFees.Width = 100;
            // 
            // TotalAmount
            // 
            this.TotalAmount.Text = "Total Amount";
            this.TotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalAmount.Width = 100;
            // 
            // Year_Qtrs
            // 
            this.Year_Qtrs.Text = "Year_Qtrs";
            // 
            // stat
            // 
            this.stat.Text = "Status";
            // 
            // PaymentChannel
            // 
            this.PaymentChannel.Text = "Payment Channel";
            this.PaymentChannel.Width = 100;
            // 
            // VerifiedBy
            // 
            this.VerifiedBy.Text = "Verified By";
            this.VerifiedBy.Width = 80;
            // 
            // VerifiedDate
            // 
            this.VerifiedDate.Text = "Verified Date";
            this.VerifiedDate.Width = 100;
            // 
            // ValidatedBy
            // 
            this.ValidatedBy.Text = "Validated By";
            this.ValidatedBy.Width = 100;
            // 
            // ValidatedDate
            // 
            this.ValidatedDate.Text = "Validated Date";
            this.ValidatedDate.Width = 100;
            // 
            // reqParty
            // 
            this.reqParty.Text = "Requesting Party";
            this.reqParty.Width = 220;
            // 
            // ContactNumber
            // 
            this.ContactNumber.Text = "Contact Number";
            this.ContactNumber.Width = 100;
            // 
            // BussinessRemarks
            // 
            this.BussinessRemarks.Text = "Bussiness Remarks";
            this.BussinessRemarks.Width = 250;
            // 
            // EncodedBy
            // 
            this.EncodedBy.Text = "Encoded By";
            this.EncodedBy.Width = 100;
            // 
            // EncodedDate
            // 
            this.EncodedDate.Text = "Encoded Date";
            // 
            // UploadedBy
            // 
            this.UploadedBy.Text = "Uploaded By";
            // 
            // UploadedDate
            // 
            this.UploadedDate.Text = "Uploaded Date";
            // 
            // ReleasedBy
            // 
            this.ReleasedBy.Text = "Released By";
            // 
            // ReleasedDate
            // 
            this.ReleasedDate.Text = "Released Date";
            // 
            // BusinessTaxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1797, 972);
            this.Controls.Add(this.RPTInfoLV);
            this.Controls.Add(this.textRecSelected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboAction);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textTotalAmountTransferred);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textTotalAmount2Pay);
            this.Controls.Add(this.panel1);
            this.Name = "BusinessTaxForm";
            this.Text = "BusinessTaxForm";
            this.Load += new System.EventHandler(this.BusinessTaxForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textRecSelected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ComboBox cboAction;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textTotalAmountTransferred;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textTotalAmount2Pay;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox textTDN;
        private System.Windows.Forms.Button btnMultipleRecordOnePayment;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView RPTInfoLV;
        private System.Windows.Forms.ColumnHeader BusId;
        private System.Windows.Forms.ColumnHeader Bus_Type;
        private System.Windows.Forms.ColumnHeader MPNum;
        private System.Windows.Forms.ColumnHeader TaxpayersName;
        private System.Windows.Forms.ColumnHeader BusinessName;
        private System.Windows.Forms.ColumnHeader BillNumber;
        private System.Windows.Forms.ColumnHeader BillAmount;
        private System.Windows.Forms.ColumnHeader MiscFees;
        private System.Windows.Forms.ColumnHeader TotalAmount;
        private System.Windows.Forms.ColumnHeader Year_Qtrs;
        private System.Windows.Forms.ColumnHeader stat;
        private System.Windows.Forms.ColumnHeader PaymentChannel;
        private System.Windows.Forms.ColumnHeader VerifiedBy;
        private System.Windows.Forms.ColumnHeader VerifiedDate;
        private System.Windows.Forms.ColumnHeader ValidatedBy;
        private System.Windows.Forms.ColumnHeader ValidatedDate;
        private System.Windows.Forms.ColumnHeader reqParty;
        private System.Windows.Forms.ColumnHeader ContactNumber;
        private System.Windows.Forms.ColumnHeader BussinessRemarks;
        private System.Windows.Forms.ColumnHeader EncodedBy;
        private System.Windows.Forms.ColumnHeader EncodedDate;
        private System.Windows.Forms.ColumnHeader UploadedBy;
        private System.Windows.Forms.ColumnHeader UploadedDate;
        private System.Windows.Forms.ColumnHeader ReleasedBy;
        private System.Windows.Forms.ColumnHeader ReleasedDate;
    }
}