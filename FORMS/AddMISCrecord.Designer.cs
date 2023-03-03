namespace SampleRPT1.FORMS
{
    partial class AddMISCrecord
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
            this.label10 = new System.Windows.Forms.Label();
            this.textRemarks = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textRequestingParty = new System.Windows.Forms.TextBox();
            this.textOPAtrackingNum = new System.Windows.Forms.TextBox();
            this.textOPNum = new System.Windows.Forms.TextBox();
            this.textTPName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textRemarks);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textRequestingParty);
            this.panel1.Controls.Add(this.textOPAtrackingNum);
            this.panel1.Controls.Add(this.textOPNum);
            this.panel1.Controls.Add(this.textTPName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 595);
            this.panel1.TabIndex = 16;
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(151, 366);
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
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            this.cboMiscType.FormattingEnabled = true;
            this.cboMiscType.Location = new System.Drawing.Point(151, 30);
            this.cboMiscType.Name = "cboMiscType";
            this.cboMiscType.Size = new System.Drawing.Size(254, 21);
            this.cboMiscType.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 248);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Total Transferred Amount: ";
            // 
            // textTotalTransferredAmount
            // 
            this.textTotalTransferredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalTransferredAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalTransferredAmount.Location = new System.Drawing.Point(151, 241);
            this.textTotalTransferredAmount.Name = "textTotalTransferredAmount";
            this.textTotalTransferredAmount.Size = new System.Drawing.Size(115, 23);
            this.textTotalTransferredAmount.TabIndex = 5;
            this.textTotalTransferredAmount.Text = "0.00";
            this.textTotalTransferredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTotalTransferredAmount.Click += new System.EventHandler(this.textTotalTransferredAmount_Click);
            this.textTotalTransferredAmount.TextChanged += new System.EventHandler(this.textTotalTransferredAmount_TextChanged);
            this.textTotalTransferredAmount.Enter += new System.EventHandler(this.textTotalTransferredAmount_Enter);
            this.textTotalTransferredAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTotalTransferredAmount_KeyDown);
            this.textTotalTransferredAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTotalTransferredAmount_KeyPress);
            this.textTotalTransferredAmount.Leave += new System.EventHandler(this.textTotalTransferredAmount_Leave);
            // 
            // textAmountToBePaid
            // 
            this.textAmountToBePaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAmountToBePaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAmountToBePaid.Location = new System.Drawing.Point(151, 200);
            this.textAmountToBePaid.Name = "textAmountToBePaid";
            this.textAmountToBePaid.Size = new System.Drawing.Size(115, 23);
            this.textAmountToBePaid.TabIndex = 4;
            this.textAmountToBePaid.Text = "0.00";
            this.textAmountToBePaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textAmountToBePaid.Click += new System.EventHandler(this.textAmountToBePaid_Click);
            this.textAmountToBePaid.Enter += new System.EventHandler(this.textAmountToBePaid_Enter);
            this.textAmountToBePaid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textAmountToBePaid_KeyDown);
            this.textAmountToBePaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAmountToBePaid_KeyPress);
            this.textAmountToBePaid.Leave += new System.EventHandler(this.textAmountToBePaid_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 207);
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
            this.cboBankUsed.Location = new System.Drawing.Point(151, 323);
            this.cboBankUsed.Name = "cboBankUsed";
            this.cboBankUsed.Size = new System.Drawing.Size(253, 21);
            this.cboBankUsed.TabIndex = 7;
            this.cboBankUsed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboBankUsed_KeyDown);
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
            this.label2.Location = new System.Drawing.Point(48, 288);
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
            this.dtDateOfPayment.Location = new System.Drawing.Point(151, 282);
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(90, 446);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Remarks: ";
            // 
            // textRemarks
            // 
            this.textRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRemarks.Location = new System.Drawing.Point(151, 446);
            this.textRemarks.Multiline = true;
            this.textRemarks.Name = "textRemarks";
            this.textRemarks.Size = new System.Drawing.Size(253, 84);
            this.textRemarks.TabIndex = 10;
            this.textRemarks.Click += new System.EventHandler(this.textRemarks_Click);
            this.textRemarks.Enter += new System.EventHandler(this.textRemarks_Enter);
            this.textRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textRemarks_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 411);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Requesting Party: ";
            // 
            // textRequestingParty
            // 
            this.textRequestingParty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRequestingParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRequestingParty.Location = new System.Drawing.Point(151, 404);
            this.textRequestingParty.Name = "textRequestingParty";
            this.textRequestingParty.Size = new System.Drawing.Size(253, 23);
            this.textRequestingParty.TabIndex = 9;
            this.textRequestingParty.Click += new System.EventHandler(this.textRequestingParty_Click);
            this.textRequestingParty.Enter += new System.EventHandler(this.textRequestingParty_Enter);
            this.textRequestingParty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textRequestingParty_KeyDown);
            // 
            // textOPAtrackingNum
            // 
            this.textOPAtrackingNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textOPAtrackingNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOPAtrackingNum.Location = new System.Drawing.Point(151, 158);
            this.textOPAtrackingNum.Name = "textOPAtrackingNum";
            this.textOPAtrackingNum.Size = new System.Drawing.Size(253, 23);
            this.textOPAtrackingNum.TabIndex = 3;
            this.textOPAtrackingNum.Click += new System.EventHandler(this.textOPAtrackingNum_Click);
            this.textOPAtrackingNum.Enter += new System.EventHandler(this.textOPAtrackingNum_Enter);
            this.textOPAtrackingNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textOPAtrackingNum_KeyDown);
            // 
            // textOPNum
            // 
            this.textOPNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textOPNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOPNum.Location = new System.Drawing.Point(151, 122);
            this.textOPNum.Name = "textOPNum";
            this.textOPNum.Size = new System.Drawing.Size(253, 23);
            this.textOPNum.TabIndex = 2;
            this.textOPNum.Click += new System.EventHandler(this.textOPNum_Click);
            this.textOPNum.Enter += new System.EventHandler(this.textOPNum_Enter);
            this.textOPNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textOPNum_KeyDown);
            // 
            // textTPName
            // 
            this.textTPName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTPName.Location = new System.Drawing.Point(152, 84);
            this.textTPName.Name = "textTPName";
            this.textTPName.Size = new System.Drawing.Size(253, 23);
            this.textTPName.TabIndex = 1;
            this.textTPName.Click += new System.EventHandler(this.textTPName_Click);
            this.textTPName.Enter += new System.EventHandler(this.textTPName_Enter);
            this.textTPName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTPName_KeyDown);
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
            this.label6.Location = new System.Drawing.Point(76, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Bank Used: ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(97, 374);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Status: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "OPA Tracking Num: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "O.P Number: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Add New Record";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddMISCrecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 619);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Name = "AddMISCrecord";
            this.Text = "AddMISCrecord";
            this.Load += new System.EventHandler(this.AddMISCrecord_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboBankUsed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDateOfPayment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textRemarks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textRequestingParty;
        private System.Windows.Forms.TextBox textTPName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textOPAtrackingNum;
        private System.Windows.Forms.TextBox textOPNum;
        private System.Windows.Forms.TextBox textAmountToBePaid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textTotalTransferredAmount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMiscType;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}