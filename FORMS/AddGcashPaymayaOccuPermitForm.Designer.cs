namespace SampleRPT1.FORMS
{
    partial class AddGcashPaymayaOccuPermitForm
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
            this.textTotalAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textNumRec = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LabelTotalRecords = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.MISCGcashPaymayaLV = new System.Windows.Forms.ListView();
            this.serviceProv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OPAtrackingNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OPnumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taxpayername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailadd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amountdue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paymentdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.duplicateindb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.duplicateinlist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRetrieveName = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textTotalAmount
            // 
            this.textTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalAmount.Enabled = false;
            this.textTotalAmount.Location = new System.Drawing.Point(246, 12);
            this.textTotalAmount.Name = "textTotalAmount";
            this.textTotalAmount.Size = new System.Drawing.Size(113, 20);
            this.textTotalAmount.TabIndex = 32;
            this.textTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(256, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 28;
            // 
            // textNumRec
            // 
            this.textNumRec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textNumRec.Enabled = false;
            this.textNumRec.Location = new System.Drawing.Point(107, 12);
            this.textNumRec.Name = "textNumRec";
            this.textNumRec.Size = new System.Drawing.Size(55, 20);
            this.textNumRec.TabIndex = 33;
            this.textNumRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(170, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Total Amount: ";
            // 
            // LabelTotalRecords
            // 
            this.LabelTotalRecords.AutoSize = true;
            this.LabelTotalRecords.Location = new System.Drawing.Point(107, 19);
            this.LabelTotalRecords.Name = "LabelTotalRecords";
            this.LabelTotalRecords.Size = new System.Drawing.Size(0, 13);
            this.LabelTotalRecords.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Total Records: ";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1835, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 27;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(1762, 19);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(67, 23);
            this.btnSaveAll.TabIndex = 26;
            this.btnSaveAll.Text = "Save All";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // MISCGcashPaymayaLV
            // 
            this.MISCGcashPaymayaLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serviceProv,
            this.OPAtrackingNum,
            this.OPnumber,
            this.taxpayername,
            this.emailadd,
            this.amountdue,
            this.paymentdate,
            this.duplicateindb,
            this.duplicateinlist});
            this.MISCGcashPaymayaLV.FullRowSelect = true;
            this.MISCGcashPaymayaLV.GridLines = true;
            this.MISCGcashPaymayaLV.HideSelection = false;
            this.MISCGcashPaymayaLV.Location = new System.Drawing.Point(12, 48);
            this.MISCGcashPaymayaLV.Name = "MISCGcashPaymayaLV";
            this.MISCGcashPaymayaLV.Size = new System.Drawing.Size(1898, 923);
            this.MISCGcashPaymayaLV.TabIndex = 25;
            this.MISCGcashPaymayaLV.UseCompatibleStateImageBehavior = false;
            this.MISCGcashPaymayaLV.View = System.Windows.Forms.View.Details;
            this.MISCGcashPaymayaLV.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.FirstLVGcashPaymaya_ItemSelectionChanged);
            // 
            // serviceProv
            // 
            this.serviceProv.Text = "Service Provider";
            this.serviceProv.Width = 90;
            // 
            // OPAtrackingNum
            // 
            this.OPAtrackingNum.Text = "OPA Tracking Number";
            this.OPAtrackingNum.Width = 150;
            // 
            // OPnumber
            // 
            this.OPnumber.Text = "Order of Payment Number";
            this.OPnumber.Width = 220;
            // 
            // taxpayername
            // 
            this.taxpayername.Text = "Taxpayer\'s Name";
            this.taxpayername.Width = 300;
            // 
            // emailadd
            // 
            this.emailadd.Text = "Requesting Party ";
            this.emailadd.Width = 300;
            // 
            // amountdue
            // 
            this.amountdue.Text = "Amount Due";
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
            // btnRetrieveName
            // 
            this.btnRetrieveName.Location = new System.Drawing.Point(377, 12);
            this.btnRetrieveName.Name = "btnRetrieveName";
            this.btnRetrieveName.Size = new System.Drawing.Size(93, 23);
            this.btnRetrieveName.TabIndex = 35;
            this.btnRetrieveName.Text = "Retrieve Name";
            this.btnRetrieveName.UseVisualStyleBackColor = true;
            this.btnRetrieveName.Visible = false;
            this.btnRetrieveName.Click += new System.EventHandler(this.btnRetrieveName_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddGcashPaymayaOccuPermitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 988);
            this.Controls.Add(this.btnRetrieveName);
            this.Controls.Add(this.textTotalAmount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textNumRec);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LabelTotalRecords);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.MISCGcashPaymayaLV);
            this.Name = "AddGcashPaymayaOccuPermitForm";
            this.Text = "AddGcashPaymayaOccuPermit";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textTotalAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textNumRec;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LabelTotalRecords;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.ListView MISCGcashPaymayaLV;
        private System.Windows.Forms.ColumnHeader serviceProv;
        private System.Windows.Forms.ColumnHeader OPAtrackingNum;
        private System.Windows.Forms.ColumnHeader OPnumber;
        private System.Windows.Forms.ColumnHeader taxpayername;
        private System.Windows.Forms.ColumnHeader emailadd;
        private System.Windows.Forms.ColumnHeader amountdue;
        private System.Windows.Forms.ColumnHeader paymentdate;
        private System.Windows.Forms.ColumnHeader duplicateindb;
        private System.Windows.Forms.ColumnHeader duplicateinlist;
        private System.Windows.Forms.Button btnRetrieveName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}