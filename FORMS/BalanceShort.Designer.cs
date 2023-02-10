namespace SampleRPT1.FORMS
{
    partial class BalanceShort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalanceShort));
            this.textTotalAmountDeposited = new System.Windows.Forms.TextBox();
            this.textRefNum = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.dtDateOfPayment = new System.Windows.Forms.DateTimePicker();
            this.cboBankUsed = new System.Windows.Forms.ComboBox();
            this.labelBank = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textYearQuarter = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textRemarks = new System.Windows.Forms.TextBox();
            this.rdCash = new System.Windows.Forms.RadioButton();
            this.rdExcess = new System.Windows.Forms.RadioButton();
            this.rdShort = new System.Windows.Forms.RadioButton();
            this.rdMC = new System.Windows.Forms.RadioButton();
            this.rdNone = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textTotalAmountDeposited
            // 
            this.textTotalAmountDeposited.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalAmountDeposited.Location = new System.Drawing.Point(144, 122);
            this.textTotalAmountDeposited.Name = "textTotalAmountDeposited";
            this.textTotalAmountDeposited.Size = new System.Drawing.Size(95, 20);
            this.textTotalAmountDeposited.TabIndex = 1;
            this.textTotalAmountDeposited.Text = "0.00";
            this.textTotalAmountDeposited.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTotalAmountDeposited.Click += new System.EventHandler(this.textAmountTransferred_Click);
            this.textTotalAmountDeposited.Enter += new System.EventHandler(this.textAmountTransferred_Enter);
            this.textTotalAmountDeposited.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textAmountTransferred_KeyDown);
            this.textTotalAmountDeposited.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAmountTransferred_KeyPress);
            // 
            // textRefNum
            // 
            this.textRefNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRefNum.Enabled = false;
            this.textRefNum.Location = new System.Drawing.Point(144, 23);
            this.textRefNum.Name = "textRefNum";
            this.textRefNum.Size = new System.Drawing.Size(201, 20);
            this.textRefNum.TabIndex = 22;
            this.textRefNum.TextChanged += new System.EventHandler(this.textRefNum_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(250, 448);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Total Amount Deposited: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reference No.: ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Date of Payment: ";
            // 
            // dtDateOfPayment
            // 
            this.dtDateOfPayment.CustomFormat = "MM/dd/yyyy";
            this.dtDateOfPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateOfPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfPayment.Location = new System.Drawing.Point(144, 166);
            this.dtDateOfPayment.Name = "dtDateOfPayment";
            this.dtDateOfPayment.Size = new System.Drawing.Size(95, 23);
            this.dtDateOfPayment.TabIndex = 2;
            // 
            // cboBankUsed
            // 
            this.cboBankUsed.FormattingEnabled = true;
            this.cboBankUsed.Items.AddRange(new object[] {
            "Please select a bank..."});
            this.cboBankUsed.Location = new System.Drawing.Point(144, 216);
            this.cboBankUsed.Name = "cboBankUsed";
            this.cboBankUsed.Size = new System.Drawing.Size(201, 21);
            this.cboBankUsed.TabIndex = 24;
            // 
            // labelBank
            // 
            this.labelBank.AutoSize = true;
            this.labelBank.Location = new System.Drawing.Point(72, 224);
            this.labelBank.Name = "labelBank";
            this.labelBank.Size = new System.Drawing.Size(66, 13);
            this.labelBank.TabIndex = 25;
            this.labelBank.Text = "Bank Used: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Year: ";
            // 
            // textYearQuarter
            // 
            this.textYearQuarter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textYearQuarter.Enabled = false;
            this.textYearQuarter.Location = new System.Drawing.Point(144, 80);
            this.textYearQuarter.Name = "textYearQuarter";
            this.textYearQuarter.Size = new System.Drawing.Size(95, 20);
            this.textYearQuarter.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(83, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Remarks: ";
            // 
            // textRemarks
            // 
            this.textRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRemarks.Location = new System.Drawing.Point(144, 264);
            this.textRemarks.Multiline = true;
            this.textRemarks.Name = "textRemarks";
            this.textRemarks.Size = new System.Drawing.Size(201, 105);
            this.textRemarks.TabIndex = 29;
            // 
            // rdCash
            // 
            this.rdCash.AutoSize = true;
            this.rdCash.Location = new System.Drawing.Point(142, 412);
            this.rdCash.Name = "rdCash";
            this.rdCash.Size = new System.Drawing.Size(54, 17);
            this.rdCash.TabIndex = 30;
            this.rdCash.Text = "CASH";
            this.rdCash.UseVisualStyleBackColor = true;
            // 
            // rdExcess
            // 
            this.rdExcess.AutoSize = true;
            this.rdExcess.Location = new System.Drawing.Point(211, 389);
            this.rdExcess.Name = "rdExcess";
            this.rdExcess.Size = new System.Drawing.Size(67, 17);
            this.rdExcess.TabIndex = 31;
            this.rdExcess.Text = "EXCESS";
            this.rdExcess.UseVisualStyleBackColor = true;
            // 
            // rdShort
            // 
            this.rdShort.AutoSize = true;
            this.rdShort.Location = new System.Drawing.Point(284, 389);
            this.rdShort.Name = "rdShort";
            this.rdShort.Size = new System.Drawing.Size(63, 17);
            this.rdShort.TabIndex = 31;
            this.rdShort.Text = "SHORT";
            this.rdShort.UseVisualStyleBackColor = true;
            // 
            // rdMC
            // 
            this.rdMC.AutoSize = true;
            this.rdMC.Location = new System.Drawing.Point(211, 412);
            this.rdMC.Name = "rdMC";
            this.rdMC.Size = new System.Drawing.Size(61, 17);
            this.rdMC.TabIndex = 31;
            this.rdMC.Text = "CHECK";
            this.rdMC.UseVisualStyleBackColor = true;
            // 
            // rdNone
            // 
            this.rdNone.AutoSize = true;
            this.rdNone.Checked = true;
            this.rdNone.Location = new System.Drawing.Point(142, 389);
            this.rdNone.Name = "rdNone";
            this.rdNone.Size = new System.Drawing.Size(56, 17);
            this.rdNone.TabIndex = 31;
            this.rdNone.TabStop = true;
            this.rdNone.Text = "NONE";
            this.rdNone.UseVisualStyleBackColor = true;
            // 
            // BalanceShort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 491);
            this.Controls.Add(this.rdNone);
            this.Controls.Add(this.rdMC);
            this.Controls.Add(this.rdShort);
            this.Controls.Add(this.rdExcess);
            this.Controls.Add(this.rdCash);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textRemarks);
            this.Controls.Add(this.textYearQuarter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboBankUsed);
            this.Controls.Add(this.labelBank);
            this.Controls.Add(this.dtDateOfPayment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textRefNum);
            this.Controls.Add(this.textTotalAmountDeposited);
            this.Name = "BalanceShort";
            this.Text = "BalanceShort";
            this.Load += new System.EventHandler(this.BalanceShort_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textTotalAmountDeposited;
        private System.Windows.Forms.TextBox textRefNum;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDateOfPayment;
        private System.Windows.Forms.ComboBox cboBankUsed;
        private System.Windows.Forms.Label labelBank;
        private System.Windows.Forms.TextBox textYearQuarter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textRemarks;
        private System.Windows.Forms.RadioButton rdNone;
        private System.Windows.Forms.RadioButton rdMC;
        private System.Windows.Forms.RadioButton rdShort;
        private System.Windows.Forms.RadioButton rdExcess;
        private System.Windows.Forms.RadioButton rdCash;
    }
}