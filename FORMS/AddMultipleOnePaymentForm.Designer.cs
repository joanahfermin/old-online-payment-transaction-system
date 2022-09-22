namespace SampleRPT1
{
    partial class AddMultipleOnePaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMultipleOnePaymentForm));
            this.lvMultipleRecord = new System.Windows.Forms.ListView();
            this.taxDec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taxpayerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount2Pay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YearQuarter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textTDN = new System.Windows.Forms.TextBox();
            this.textYearQuarter = new System.Windows.Forms.TextBox();
            this.textAmount2Pay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTotalAmountDeposited = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtDateOfPayment = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textRequestingParty = new System.Windows.Forms.TextBox();
            this.textTPName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkTaxNameRetain = new System.Windows.Forms.CheckBox();
            this.checkTaxDecRetain = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboBankUsed = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textTotalAmountToPay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvMultipleRecord
            // 
            this.lvMultipleRecord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.taxDec,
            this.taxpayerName,
            this.Amount2Pay,
            this.YearQuarter});
            this.lvMultipleRecord.FullRowSelect = true;
            this.lvMultipleRecord.GridLines = true;
            this.lvMultipleRecord.HideSelection = false;
            this.lvMultipleRecord.Location = new System.Drawing.Point(515, 44);
            this.lvMultipleRecord.Name = "lvMultipleRecord";
            this.lvMultipleRecord.Size = new System.Drawing.Size(697, 488);
            this.lvMultipleRecord.TabIndex = 0;
            this.lvMultipleRecord.UseCompatibleStateImageBehavior = false;
            this.lvMultipleRecord.View = System.Windows.Forms.View.Details;
            this.lvMultipleRecord.SelectedIndexChanged += new System.EventHandler(this.lvMultipleRecord_SelectedIndexChanged);
            // 
            // taxDec
            // 
            this.taxDec.Text = "Tax Dec Num.";
            this.taxDec.Width = 200;
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
            // textTDN
            // 
            this.textTDN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTDN.Location = new System.Drawing.Point(158, 63);
            this.textTDN.Name = "textTDN";
            this.textTDN.Size = new System.Drawing.Size(253, 20);
            this.textTDN.TabIndex = 1;
            this.textTDN.Click += new System.EventHandler(this.textTDN_Click);
            this.textTDN.Enter += new System.EventHandler(this.textTDN_Enter);
            this.textTDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTDN_KeyDown);
            // 
            // textYearQuarter
            // 
            this.textYearQuarter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textYearQuarter.Location = new System.Drawing.Point(158, 174);
            this.textYearQuarter.Name = "textYearQuarter";
            this.textYearQuarter.Size = new System.Drawing.Size(126, 20);
            this.textYearQuarter.TabIndex = 4;
            this.textYearQuarter.Click += new System.EventHandler(this.textYearQuarter_Click);
            this.textYearQuarter.Enter += new System.EventHandler(this.textYearQuarter_Enter);
            this.textYearQuarter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textYearQuarter_KeyDown);
            // 
            // textAmount2Pay
            // 
            this.textAmount2Pay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAmount2Pay.Location = new System.Drawing.Point(158, 136);
            this.textAmount2Pay.Name = "textAmount2Pay";
            this.textAmount2Pay.Size = new System.Drawing.Size(126, 20);
            this.textAmount2Pay.TabIndex = 3;
            this.textAmount2Pay.Text = "0.00";
            this.textAmount2Pay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textAmount2Pay.Click += new System.EventHandler(this.textAmount2Pay_Click);
            this.textAmount2Pay.Enter += new System.EventHandler(this.textAmount2Pay_Enter);
            this.textAmount2Pay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textAmount2Pay_KeyDown);
            this.textAmount2Pay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAmount2Pay_KeyPress);
            this.textAmount2Pay.Leave += new System.EventHandler(this.textAmount2Pay_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 200;
            this.label2.Text = "Year/Quarter: ";
            // 
            // textTotalAmountDeposited
            // 
            this.textTotalAmountDeposited.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalAmountDeposited.Location = new System.Drawing.Point(144, 139);
            this.textTotalAmountDeposited.Name = "textTotalAmountDeposited";
            this.textTotalAmountDeposited.Size = new System.Drawing.Size(126, 20);
            this.textTotalAmountDeposited.TabIndex = 11;
            this.textTotalAmountDeposited.Text = "0.00";
            this.textTotalAmountDeposited.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTotalAmountDeposited.Click += new System.EventHandler(this.textTotalAmountDeposited_Click);
            this.textTotalAmountDeposited.Enter += new System.EventHandler(this.textTotalAmountDeposited_Enter);
            this.textTotalAmountDeposited.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTotalAmountDeposited_KeyDown);
            this.textTotalAmountDeposited.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTotalAmountDeposited_KeyPress);
            this.textTotalAmountDeposited.Leave += new System.EventHandler(this.textTotalAmountDeposited_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 201;
            this.label4.Text = "Total Amount Deposited: ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(144, 209);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save to Main List";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(145, 165);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(126, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add To List";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Date of Payment: ";
            // 
            // dtDateOfPayment
            // 
            this.dtDateOfPayment.CustomFormat = "MM/dd/yyyy";
            this.dtDateOfPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfPayment.Location = new System.Drawing.Point(144, 55);
            this.dtDateOfPayment.Name = "dtDateOfPayment";
            this.dtDateOfPayment.Size = new System.Drawing.Size(126, 20);
            this.dtDateOfPayment.TabIndex = 9;
            this.dtDateOfPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtDateOfPayment_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Tax Declaration Number: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Requesting Party: ";
            // 
            // textRequestingParty
            // 
            this.textRequestingParty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRequestingParty.Location = new System.Drawing.Point(144, 94);
            this.textRequestingParty.Name = "textRequestingParty";
            this.textRequestingParty.Size = new System.Drawing.Size(253, 20);
            this.textRequestingParty.TabIndex = 10;
            this.textRequestingParty.Click += new System.EventHandler(this.textRequestingParty_Click);
            this.textRequestingParty.Enter += new System.EventHandler(this.textRequestingParty_Enter);
            this.textRequestingParty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textRequestingParty_KeyDown);
            // 
            // textTPName
            // 
            this.textTPName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTPName.Location = new System.Drawing.Point(158, 98);
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
            this.label12.Location = new System.Drawing.Point(53, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Taxpayer\'s Name: ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(62, 143);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Amount To Pay: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(42, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Payment Channel: ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkTaxNameRetain);
            this.panel1.Controls.Add(this.checkTaxDecRetain);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Location = new System.Drawing.Point(12, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 208);
            this.panel1.TabIndex = 43;
            // 
            // checkTaxNameRetain
            // 
            this.checkTaxNameRetain.AutoSize = true;
            this.checkTaxNameRetain.Location = new System.Drawing.Point(414, 56);
            this.checkTaxNameRetain.Name = "checkTaxNameRetain";
            this.checkTaxNameRetain.Size = new System.Drawing.Size(57, 17);
            this.checkTaxNameRetain.TabIndex = 7;
            this.checkTaxNameRetain.Text = "Retain";
            this.checkTaxNameRetain.UseVisualStyleBackColor = true;
            this.checkTaxNameRetain.CheckedChanged += new System.EventHandler(this.checkTaxNameRetain_CheckedChanged);
            // 
            // checkTaxDecRetain
            // 
            this.checkTaxDecRetain.AutoSize = true;
            this.checkTaxDecRetain.Location = new System.Drawing.Point(414, 19);
            this.checkTaxDecRetain.Name = "checkTaxDecRetain";
            this.checkTaxDecRetain.Size = new System.Drawing.Size(57, 17);
            this.checkTaxDecRetain.TabIndex = 6;
            this.checkTaxDecRetain.Text = "Retain";
            this.checkTaxDecRetain.UseVisualStyleBackColor = true;
            this.checkTaxDecRetain.CheckedChanged += new System.EventHandler(this.checkTaxDecRetain_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Information";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cboBankUsed);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.textTotalAmountDeposited);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtDateOfPayment);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.textRequestingParty);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(12, 279);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 253);
            this.panel2.TabIndex = 44;
            // 
            // cboBankUsed
            // 
            this.cboBankUsed.FormattingEnabled = true;
            this.cboBankUsed.ItemHeight = 13;
            this.cboBankUsed.Items.AddRange(new object[] {
            "Please select a bank..."});
            this.cboBankUsed.Location = new System.Drawing.Point(144, 16);
            this.cboBankUsed.Name = "cboBankUsed";
            this.cboBankUsed.Size = new System.Drawing.Size(253, 21);
            this.cboBankUsed.TabIndex = 8;
            this.cboBankUsed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboBankUsed_KeyDown);
            this.cboBankUsed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboBankUsed_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Payment Information";
            // 
            // textTotalAmountToPay
            // 
            this.textTotalAmountToPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalAmountToPay.Enabled = false;
            this.textTotalAmountToPay.Location = new System.Drawing.Point(1032, 12);
            this.textTotalAmountToPay.Name = "textTotalAmountToPay";
            this.textTotalAmountToPay.Size = new System.Drawing.Size(180, 20);
            this.textTotalAmountToPay.TabIndex = 45;
            this.textTotalAmountToPay.Text = "0.00";
            this.textTotalAmountToPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTotalAmountToPay.TextChanged += new System.EventHandler(this.textTotalAmountToPay_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(913, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Total Amount To Pay: ";
            // 
            // AddMultipleOnePaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 550);
            this.Controls.Add(this.textTotalAmountToPay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textTPName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textAmount2Pay);
            this.Controls.Add(this.textYearQuarter);
            this.Controls.Add(this.textTDN);
            this.Controls.Add(this.lvMultipleRecord);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "AddMultipleOnePaymentForm";
            this.Text = "AddMultipleOnePaymentForm";
            this.Load += new System.EventHandler(this.AddMultipleOnePaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvMultipleRecord;
        private System.Windows.Forms.ColumnHeader taxDec;
        private System.Windows.Forms.ColumnHeader YearQuarter;
        private System.Windows.Forms.ColumnHeader Amount2Pay;
        private System.Windows.Forms.TextBox textTDN;
        private System.Windows.Forms.TextBox textYearQuarter;
        private System.Windows.Forms.TextBox textAmount2Pay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTotalAmountDeposited;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtDateOfPayment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textRequestingParty;
        private System.Windows.Forms.TextBox textTPName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ColumnHeader taxpayerName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textTotalAmountToPay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboBankUsed;
        private System.Windows.Forms.CheckBox checkTaxNameRetain;
        private System.Windows.Forms.CheckBox checkTaxDecRetain;
    }
}