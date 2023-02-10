namespace SampleRPT1.FORMS
{
    partial class RPTgenerateRefNumWithPayment
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
            this.label10 = new System.Windows.Forms.Label();
            this.textRemarks = new System.Windows.Forms.TextBox();
            this.cboBankUsed = new System.Windows.Forms.ComboBox();
            this.labelBank = new System.Windows.Forms.Label();
            this.dtDateOfPayment = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.textTotalAmountDeposited = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(86, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Remarks: ";
            // 
            // textRemarks
            // 
            this.textRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRemarks.Location = new System.Drawing.Point(147, 170);
            this.textRemarks.Multiline = true;
            this.textRemarks.Name = "textRemarks";
            this.textRemarks.Size = new System.Drawing.Size(201, 105);
            this.textRemarks.TabIndex = 4;
            // 
            // cboBankUsed
            // 
            this.cboBankUsed.FormattingEnabled = true;
            this.cboBankUsed.Items.AddRange(new object[] {
            "Please select a bank..."});
            this.cboBankUsed.Location = new System.Drawing.Point(147, 118);
            this.cboBankUsed.Name = "cboBankUsed";
            this.cboBankUsed.Size = new System.Drawing.Size(201, 21);
            this.cboBankUsed.TabIndex = 3;
            // 
            // labelBank
            // 
            this.labelBank.AutoSize = true;
            this.labelBank.Location = new System.Drawing.Point(75, 126);
            this.labelBank.Name = "labelBank";
            this.labelBank.Size = new System.Drawing.Size(66, 13);
            this.labelBank.TabIndex = 36;
            this.labelBank.Text = "Bank Used: ";
            // 
            // dtDateOfPayment
            // 
            this.dtDateOfPayment.CustomFormat = "MM/dd/yyyy";
            this.dtDateOfPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateOfPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfPayment.Location = new System.Drawing.Point(147, 68);
            this.dtDateOfPayment.Name = "dtDateOfPayment";
            this.dtDateOfPayment.Size = new System.Drawing.Size(93, 23);
            this.dtDateOfPayment.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Date of Payment: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Total Amount Deposited: ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(273, 301);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textTotalAmountDeposited
            // 
            this.textTotalAmountDeposited.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalAmountDeposited.Location = new System.Drawing.Point(147, 24);
            this.textTotalAmountDeposited.Name = "textTotalAmountDeposited";
            this.textTotalAmountDeposited.Size = new System.Drawing.Size(93, 20);
            this.textTotalAmountDeposited.TabIndex = 1;
            this.textTotalAmountDeposited.Text = "0.00";
            this.textTotalAmountDeposited.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RPTgenerateRefNumWithPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 342);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textRemarks);
            this.Controls.Add(this.cboBankUsed);
            this.Controls.Add(this.labelBank);
            this.Controls.Add(this.dtDateOfPayment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textTotalAmountDeposited);
            this.Name = "RPTgenerateRefNumWithPayment";
            this.Text = "RPTgenerateRefNumWithPayment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textRemarks;
        private System.Windows.Forms.ComboBox cboBankUsed;
        private System.Windows.Forms.Label labelBank;
        private System.Windows.Forms.DateTimePicker dtDateOfPayment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textTotalAmountDeposited;
    }
}