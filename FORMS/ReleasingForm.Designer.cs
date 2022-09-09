namespace SampleRPT1.FORMS
{
    partial class ReleasingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReleasingForm));
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textTDN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearchDateStatus = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.cboAction = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
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
            this.textRepName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textRepContactNum = new System.Windows.Forms.TextBox();
            this.checkAutLetter = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureCam = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStopStart = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.checkEnableCam = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCam)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Search by Tax Declaration Number";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textTDN);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(20, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 75);
            this.panel1.TabIndex = 34;
            // 
            // textTDN
            // 
            this.textTDN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTDN.Location = new System.Drawing.Point(82, 13);
            this.textTDN.Name = "textTDN";
            this.textTDN.Size = new System.Drawing.Size(276, 20);
            this.textTDN.TabIndex = 1;
            this.textTDN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTDN.TextChanged += new System.EventHandler(this.textTDN_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Enter TDN: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Search by Date And Status";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dtDate);
            this.panel2.Controls.Add(this.cboStatus);
            this.panel2.Controls.Add(this.dtDateTo);
            this.panel2.Controls.Add(this.btnSearchDateStatus);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(418, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 75);
            this.panel2.TabIndex = 36;
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "MM/dd/yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(50, 13);
            this.dtDate.Name = "dtDate";
            this.dtDate.ShowCheckBox = true;
            this.dtDate.Size = new System.Drawing.Size(95, 20);
            this.dtDate.TabIndex = 2;
            this.dtDate.Value = new System.DateTime(2022, 8, 23, 0, 0, 0, 0);
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(383, 13);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(231, 21);
            this.cboStatus.TabIndex = 4;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // dtDateTo
            // 
            this.dtDateTo.CustomFormat = "MM/dd/yyyy";
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(183, 13);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(95, 20);
            this.dtDateTo.TabIndex = 3;
            this.dtDateTo.Value = new System.DateTime(2022, 8, 23, 0, 0, 0, 0);
            // 
            // btnSearchDateStatus
            // 
            this.btnSearchDateStatus.Location = new System.Drawing.Point(539, 37);
            this.btnSearchDateStatus.Name = "btnSearchDateStatus";
            this.btnSearchDateStatus.Size = new System.Drawing.Size(75, 23);
            this.btnSearchDateStatus.TabIndex = 5;
            this.btnSearchDateStatus.Text = "Search";
            this.btnSearchDateStatus.UseVisualStyleBackColor = true;
            this.btnSearchDateStatus.Click += new System.EventHandler(this.btnSearchDateStatus_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "From: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(297, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 44;
            this.label14.Text = "Filter By Status:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(151, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "To: ";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(1804, 66);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 9;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cboAction
            // 
            this.cboAction.FormattingEnabled = true;
            this.cboAction.Location = new System.Drawing.Point(1720, 30);
            this.cboAction.Name = "cboAction";
            this.cboAction.Size = new System.Drawing.Size(159, 21);
            this.cboAction.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1671, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Action: ";
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
            this.RPTInfoLV.Location = new System.Drawing.Point(18, 119);
            this.RPTInfoLV.Name = "RPTInfoLV";
            this.RPTInfoLV.Size = new System.Drawing.Size(1875, 416);
            this.RPTInfoLV.TabIndex = 40;
            this.RPTInfoLV.UseCompatibleStateImageBehavior = false;
            this.RPTInfoLV.View = System.Windows.Forms.View.Details;
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
            this.rr});
            this.VerAndValLV.FullRowSelect = true;
            this.VerAndValLV.GridLines = true;
            this.VerAndValLV.HideSelection = false;
            this.VerAndValLV.Location = new System.Drawing.Point(18, 549);
            this.VerAndValLV.Name = "VerAndValLV";
            this.VerAndValLV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VerAndValLV.Size = new System.Drawing.Size(1404, 383);
            this.VerAndValLV.TabIndex = 41;
            this.VerAndValLV.UseCompatibleStateImageBehavior = false;
            this.VerAndValLV.View = System.Windows.Forms.View.Details;
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
            // textRepName
            // 
            this.textRepName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRepName.Location = new System.Drawing.Point(1196, 27);
            this.textRepName.Name = "textRepName";
            this.textRepName.Size = new System.Drawing.Size(223, 20);
            this.textRepName.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1062, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Name of Representative: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1100, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Contact Number: ";
            // 
            // textRepContactNum
            // 
            this.textRepContactNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRepContactNum.Location = new System.Drawing.Point(1196, 64);
            this.textRepContactNum.Name = "textRepContactNum";
            this.textRepContactNum.Size = new System.Drawing.Size(223, 20);
            this.textRepContactNum.TabIndex = 7;
            // 
            // checkAutLetter
            // 
            this.checkAutLetter.AutoSize = true;
            this.checkAutLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAutLetter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.checkAutLetter.Location = new System.Drawing.Point(1440, 67);
            this.checkAutLetter.Name = "checkAutLetter";
            this.checkAutLetter.Size = new System.Drawing.Size(137, 17);
            this.checkAutLetter.TabIndex = 8;
            this.checkAutLetter.Text = "with authorization letter.";
            this.checkAutLetter.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // pictureCam
            // 
            this.pictureCam.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureCam.Location = new System.Drawing.Point(1428, 549);
            this.pictureCam.Name = "pictureCam";
            this.pictureCam.Size = new System.Drawing.Size(463, 354);
            this.pictureCam.TabIndex = 42;
            this.pictureCam.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1656, 909);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 43;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStopStart
            // 
            this.btnStopStart.Location = new System.Drawing.Point(1737, 909);
            this.btnStopStart.Name = "btnStopStart";
            this.btnStopStart.Size = new System.Drawing.Size(75, 23);
            this.btnStopStart.TabIndex = 44;
            this.btnStopStart.Text = "a";
            this.btnStopStart.UseVisualStyleBackColor = true;
            this.btnStopStart.Click += new System.EventHandler(this.btnStopStart_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1818, 909);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // checkEnableCam
            // 
            this.checkEnableCam.AutoSize = true;
            this.checkEnableCam.Location = new System.Drawing.Point(1440, 913);
            this.checkEnableCam.Name = "checkEnableCam";
            this.checkEnableCam.Size = new System.Drawing.Size(101, 17);
            this.checkEnableCam.TabIndex = 46;
            this.checkEnableCam.Text = "Launch Camera";
            this.checkEnableCam.UseVisualStyleBackColor = true;
            // 
            // ReleasingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 948);
            this.Controls.Add(this.checkEnableCam);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnStopStart);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureCam);
            this.Controls.Add(this.checkAutLetter);
            this.Controls.Add(this.textRepContactNum);
            this.Controls.Add(this.textRepName);
            this.Controls.Add(this.VerAndValLV);
            this.Controls.Add(this.RPTInfoLV);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.cboAction);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "ReleasingForm";
            this.Text = "ReleasingForm";
            this.Activated += new System.EventHandler(this.ReleasingForm_Activated);
            this.Deactivate += new System.EventHandler(this.ReleasingForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReleasingForm_FormClosing);
            this.Load += new System.EventHandler(this.ReleasingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox textTDN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.Button btnSearchDateStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ComboBox cboAction;
        private System.Windows.Forms.Label label15;
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
        private System.Windows.Forms.TextBox textRepName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textRepContactNum;
        private System.Windows.Forms.CheckBox checkAutLetter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureCam;
        private System.Windows.Forms.CheckBox checkEnableCam;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnStopStart;
        private System.Windows.Forms.Button btnStart;
    }
}