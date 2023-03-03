
namespace SampleRPT1.FORMS
{
    partial class RPT_ViewHistoryForm
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
            this.RPTInfoLV = new System.Windows.Forms.ListView();
            this.RPTId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TDNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PropertyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount2pay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amountrans = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalamountdep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.excessShortAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YearQuarter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EncodedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EncodedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RefNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reqParty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Remarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AssSentBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AssSentDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VerAndValLV = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.billed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numofBills = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.billedby = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VerifiedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateOfPayment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VerifiedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValidatedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValidatedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uplodby = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UplodedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RelesedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.relesedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VerRema = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValRema = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRestore = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textLastUpdatedBy = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textAction = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtLastUpdateDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.qtr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RPTInfoLV
            // 
            this.RPTInfoLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RPTId,
            this.TDNumber,
            this.PropertyName,
            this.amount2pay,
            this.amountrans,
            this.totalamountdep,
            this.excessShortAmount,
            this.bank,
            this.YearQuarter,
            this.qtr,
            this.Status,
            this.EncodedBy,
            this.EncodedDate,
            this.RefNum,
            this.reqParty,
            this.Remarks,
            this.AssSentBy,
            this.AssSentDate});
            this.RPTInfoLV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPTInfoLV.FullRowSelect = true;
            this.RPTInfoLV.GridLines = true;
            this.RPTInfoLV.HideSelection = false;
            this.RPTInfoLV.Location = new System.Drawing.Point(15, 90);
            this.RPTInfoLV.Name = "RPTInfoLV";
            this.RPTInfoLV.Size = new System.Drawing.Size(1875, 416);
            this.RPTInfoLV.TabIndex = 1;
            this.RPTInfoLV.UseCompatibleStateImageBehavior = false;
            this.RPTInfoLV.View = System.Windows.Forms.View.Details;
            this.RPTInfoLV.SelectedIndexChanged += new System.EventHandler(this.RPTInfoLV_SelectedIndexChanged);
            // 
            // RPTId
            // 
            this.RPTId.Text = "RPTId";
            // 
            // TDNumber
            // 
            this.TDNumber.Text = "TD Number";
            this.TDNumber.Width = 80;
            // 
            // PropertyName
            // 
            this.PropertyName.Text = "Taxpayer\'s Name";
            this.PropertyName.Width = 250;
            // 
            // amount2pay
            // 
            this.amount2pay.Text = "Amount to Pay";
            this.amount2pay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount2pay.Width = 100;
            // 
            // amountrans
            // 
            this.amountrans.Text = "Amount Transferred";
            this.amountrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amountrans.Width = 110;
            // 
            // totalamountdep
            // 
            this.totalamountdep.Text = "Total Amount Deposited";
            this.totalamountdep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalamountdep.Width = 130;
            // 
            // excessShortAmount
            // 
            this.excessShortAmount.Text = "ExcessShort";
            this.excessShortAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.excessShortAmount.Width = 100;
            // 
            // bank
            // 
            this.bank.Text = "Payment Channel";
            this.bank.Width = 100;
            // 
            // YearQuarter
            // 
            this.YearQuarter.Text = "Year/Quarter";
            this.YearQuarter.Width = 160;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 190;
            // 
            // EncodedBy
            // 
            this.EncodedBy.Text = "Encoded By";
            this.EncodedBy.Width = 100;
            // 
            // EncodedDate
            // 
            this.EncodedDate.Text = "Encoded Date";
            this.EncodedDate.Width = 100;
            // 
            // RefNum
            // 
            this.RefNum.Text = "Ref. Num.";
            this.RefNum.Width = 100;
            // 
            // reqParty
            // 
            this.reqParty.Text = "Requesting Party";
            this.reqParty.Width = 220;
            // 
            // Remarks
            // 
            this.Remarks.Text = "Remarks";
            this.Remarks.Width = 260;
            // 
            // AssSentBy
            // 
            this.AssSentBy.Text = "Ass. Sent By";
            this.AssSentBy.Width = 100;
            // 
            // AssSentDate
            // 
            this.AssSentDate.Text = "Ass Sent Date";
            this.AssSentDate.Width = 100;
            // 
            // VerAndValLV
            // 
            this.VerAndValLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.billed,
            this.numofBills,
            this.billedby,
            this.VerifiedBy,
            this.DateOfPayment,
            this.VerifiedDate,
            this.ValidatedBy,
            this.ValidatedDate,
            this.uplodby,
            this.UplodedDate,
            this.RelesedBy,
            this.relesedDate,
            this.VerRema,
            this.ValRema,
            this.rr,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.VerAndValLV.FullRowSelect = true;
            this.VerAndValLV.GridLines = true;
            this.VerAndValLV.HideSelection = false;
            this.VerAndValLV.Location = new System.Drawing.Point(15, 526);
            this.VerAndValLV.Name = "VerAndValLV";
            this.VerAndValLV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VerAndValLV.Size = new System.Drawing.Size(1875, 419);
            this.VerAndValLV.TabIndex = 2;
            this.VerAndValLV.UseCompatibleStateImageBehavior = false;
            this.VerAndValLV.View = System.Windows.Forms.View.Details;
            this.VerAndValLV.SelectedIndexChanged += new System.EventHandler(this.VerAndValLV_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "RPTId";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Loc. Code";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "TD Number";
            this.columnHeader2.Width = 120;
            // 
            // billed
            // 
            this.billed.Text = "Billed By";
            this.billed.Width = 120;
            // 
            // numofBills
            // 
            this.numofBills.Text = "Bill Count";
            // 
            // billedby
            // 
            this.billedby.Text = "Billed Date";
            this.billedby.Width = 120;
            // 
            // VerifiedBy
            // 
            this.VerifiedBy.Text = "Verified By";
            this.VerifiedBy.Width = 100;
            // 
            // DateOfPayment
            // 
            this.DateOfPayment.Text = "Date Of Payment";
            this.DateOfPayment.Width = 120;
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
            // uplodby
            // 
            this.uplodby.Text = "Uploaded By";
            this.uplodby.Width = 100;
            // 
            // UplodedDate
            // 
            this.UplodedDate.Text = "Uploaded Date";
            this.UplodedDate.Width = 100;
            // 
            // RelesedBy
            // 
            this.RelesedBy.Text = "Released By";
            this.RelesedBy.Width = 100;
            // 
            // relesedDate
            // 
            this.relesedDate.Text = "Released Date";
            this.relesedDate.Width = 100;
            // 
            // VerRema
            // 
            this.VerRema.Text = "Verification Remarks";
            this.VerRema.Width = 200;
            // 
            // ValRema
            // 
            this.ValRema.Text = "Validation Remarks";
            this.ValRema.Width = 250;
            // 
            // rr
            // 
            this.rr.Text = "Released Remarks";
            this.rr.Width = 250;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "LastUpdateBy";
            this.columnHeader4.Width = 191;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "LastUpdateDate";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Action";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(859, 27);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(91, 29);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Last Update by: ";
            // 
            // textLastUpdatedBy
            // 
            this.textLastUpdatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textLastUpdatedBy.Enabled = false;
            this.textLastUpdatedBy.Location = new System.Drawing.Point(103, 18);
            this.textLastUpdatedBy.Name = "textLastUpdatedBy";
            this.textLastUpdatedBy.Size = new System.Drawing.Size(169, 20);
            this.textLastUpdatedBy.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Last Update by: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(565, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Action:  ";
            // 
            // textAction
            // 
            this.textAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAction.Enabled = false;
            this.textAction.Location = new System.Drawing.Point(617, 18);
            this.textAction.Name = "textAction";
            this.textAction.Size = new System.Drawing.Size(169, 20);
            this.textAction.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtLastUpdateDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textLastUpdatedBy);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textAction);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 65);
            this.panel1.TabIndex = 7;
            // 
            // dtLastUpdateDate
            // 
            this.dtLastUpdateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLastUpdateDate.Location = new System.Drawing.Point(407, 18);
            this.dtLastUpdateDate.Name = "dtLastUpdateDate";
            this.dtLastUpdateDate.Size = new System.Drawing.Size(107, 20);
            this.dtLastUpdateDate.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Record History Information";
            // 
            // qtr
            // 
            this.qtr.Text = "Quarter";
            // 
            // ViewHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1913, 957);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.VerAndValLV);
            this.Controls.Add(this.RPTInfoLV);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewHistoryForm";
            this.Text = "ViewHistoryForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView RPTInfoLV;
        private System.Windows.Forms.ColumnHeader RPTId;
        private System.Windows.Forms.ColumnHeader TDNumber;
        private System.Windows.Forms.ColumnHeader PropertyName;
        private System.Windows.Forms.ColumnHeader amount2pay;
        private System.Windows.Forms.ColumnHeader amountrans;
        private System.Windows.Forms.ColumnHeader totalamountdep;
        private System.Windows.Forms.ColumnHeader excessShortAmount;
        private System.Windows.Forms.ColumnHeader bank;
        private System.Windows.Forms.ColumnHeader YearQuarter;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader EncodedBy;
        private System.Windows.Forms.ColumnHeader EncodedDate;
        private System.Windows.Forms.ColumnHeader RefNum;
        private System.Windows.Forms.ColumnHeader reqParty;
        private System.Windows.Forms.ColumnHeader Remarks;
        private System.Windows.Forms.ColumnHeader AssSentBy;
        private System.Windows.Forms.ColumnHeader AssSentDate;
        private System.Windows.Forms.ListView VerAndValLV;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader billed;
        private System.Windows.Forms.ColumnHeader numofBills;
        private System.Windows.Forms.ColumnHeader billedby;
        private System.Windows.Forms.ColumnHeader VerifiedBy;
        private System.Windows.Forms.ColumnHeader DateOfPayment;
        private System.Windows.Forms.ColumnHeader VerifiedDate;
        private System.Windows.Forms.ColumnHeader ValidatedBy;
        private System.Windows.Forms.ColumnHeader ValidatedDate;
        private System.Windows.Forms.ColumnHeader uplodby;
        private System.Windows.Forms.ColumnHeader UplodedDate;
        private System.Windows.Forms.ColumnHeader RelesedBy;
        private System.Windows.Forms.ColumnHeader relesedDate;
        private System.Windows.Forms.ColumnHeader VerRema;
        private System.Windows.Forms.ColumnHeader ValRema;
        private System.Windows.Forms.ColumnHeader rr;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textLastUpdatedBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textAction;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtLastUpdateDate;
        private System.Windows.Forms.ColumnHeader qtr;
    }
}