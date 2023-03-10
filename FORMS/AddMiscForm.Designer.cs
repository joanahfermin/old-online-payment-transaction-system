namespace SampleRPT1.FORMS
{
    partial class AddMiscForm
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
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMiscType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textTotalTransferredAmount = new System.Windows.Forms.TextBox();
            this.textAmountToBePaid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboBankUsed = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDateOfPayment = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.textOPAtrackingNum = new System.Windows.Forms.TextBox();
            this.textOPNum = new System.Windows.Forms.TextBox();
            this.textTPName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Add New Record";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboStatus);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cboMiscType);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.textTotalTransferredAmount);
            this.panel1.Controls.Add(this.textAmountToBePaid);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboBankUsed);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtDateOfPayment);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.textTPName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(12, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 595);
            this.panel1.TabIndex = 18;
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(150, 287);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(254, 21);
            this.cboStatus.TabIndex = 25;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(291, 549);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(114, 23);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Update Record";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Misc. Type:";
            // 
            // cboMiscType
            // 
            this.cboMiscType.Enabled = false;
            this.cboMiscType.FormattingEnabled = true;
            this.cboMiscType.Location = new System.Drawing.Point(151, 30);
            this.cboMiscType.Name = "cboMiscType";
            this.cboMiscType.Size = new System.Drawing.Size(254, 21);
            this.cboMiscType.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 174);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Total Transferred Amount: ";
            // 
            // textTotalTransferredAmount
            // 
            this.textTotalTransferredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalTransferredAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalTransferredAmount.Location = new System.Drawing.Point(151, 167);
            this.textTotalTransferredAmount.Name = "textTotalTransferredAmount";
            this.textTotalTransferredAmount.Size = new System.Drawing.Size(115, 23);
            this.textTotalTransferredAmount.TabIndex = 5;
            this.textTotalTransferredAmount.Text = "0.00";
            this.textTotalTransferredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textAmountToBePaid
            // 
            this.textAmountToBePaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAmountToBePaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAmountToBePaid.Location = new System.Drawing.Point(151, 126);
            this.textAmountToBePaid.Name = "textAmountToBePaid";
            this.textAmountToBePaid.Size = new System.Drawing.Size(115, 23);
            this.textAmountToBePaid.TabIndex = 4;
            this.textAmountToBePaid.Text = "0.00";
            this.textAmountToBePaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Amount To Be Paid: ";
            // 
            // cboBankUsed
            // 
            this.cboBankUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBankUsed.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboBankUsed.FormattingEnabled = true;
            this.cboBankUsed.Items.AddRange(new object[] {
            "Please select a bank..."});
            this.cboBankUsed.Location = new System.Drawing.Point(151, 249);
            this.cboBankUsed.Name = "cboBankUsed";
            this.cboBankUsed.Size = new System.Drawing.Size(253, 21);
            this.cboBankUsed.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(-47, -269);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "label11";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Date of Payment: ";
            // 
            // dtDateOfPayment
            // 
            this.dtDateOfPayment.CustomFormat = "MM/dd/yyyy";
            this.dtDateOfPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateOfPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfPayment.Location = new System.Drawing.Point(151, 208);
            this.dtDateOfPayment.Name = "dtDateOfPayment";
            this.dtDateOfPayment.ShowCheckBox = true;
            this.dtDateOfPayment.Size = new System.Drawing.Size(114, 23);
            this.dtDateOfPayment.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(152, 549);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save Record";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // textOPAtrackingNum
            // 
            this.textOPAtrackingNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textOPAtrackingNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOPAtrackingNum.Location = new System.Drawing.Point(842, 169);
            this.textOPAtrackingNum.Name = "textOPAtrackingNum";
            this.textOPAtrackingNum.Size = new System.Drawing.Size(253, 23);
            this.textOPAtrackingNum.TabIndex = 3;
            // 
            // textOPNum
            // 
            this.textOPNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textOPNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOPNum.Location = new System.Drawing.Point(842, 133);
            this.textOPNum.Name = "textOPNum";
            this.textOPNum.Size = new System.Drawing.Size(253, 23);
            this.textOPNum.TabIndex = 2;
            // 
            // textTPName
            // 
            this.textTPName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTPName.Location = new System.Drawing.Point(152, 84);
            this.textTPName.Name = "textTPName";
            this.textTPName.Size = new System.Drawing.Size(253, 23);
            this.textTPName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Taxpayer\'s Name: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Bank Used: ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(96, 295);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Status: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(724, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "OPA Tracking Num: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(758, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "O.P Number: ";
            // 
            // AddMiscForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 625);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textOPNum);
            this.Controls.Add(this.textOPAtrackingNum);
            this.Name = "AddMiscForm";
            this.Text = "AddMiscForm";
            this.Load += new System.EventHandler(this.AddMiscForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMiscType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textTotalTransferredAmount;
        private System.Windows.Forms.TextBox textAmountToBePaid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBankUsed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDateOfPayment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textTPName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textOPAtrackingNum;
        private System.Windows.Forms.TextBox textOPNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}