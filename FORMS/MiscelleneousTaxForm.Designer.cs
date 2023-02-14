﻿namespace SampleRPT1
{
    partial class MiscelleneousTaxForm
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
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.MISCinfoLV = new System.Windows.Forms.ListView();
            this.cboMiscType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearchDateStatus = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.cboAction = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddGcashPaymaya = new System.Windows.Forms.Button();
            this.textRecSelected = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textTotalAmountTransferred = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textTotalAmount2Pay = new System.Windows.Forms.TextBox();
            this.labelPaymentChannel = new System.Windows.Forms.Label();
            this.cboPaymentChannel = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(440, 30);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(86, 23);
            this.btnAddRecord.TabIndex = 0;
            this.btnAddRecord.Text = "Add Record";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // MISCinfoLV
            // 
            this.MISCinfoLV.FullRowSelect = true;
            this.MISCinfoLV.GridLines = true;
            this.MISCinfoLV.HideSelection = false;
            this.MISCinfoLV.Location = new System.Drawing.Point(12, 139);
            this.MISCinfoLV.Name = "MISCinfoLV";
            this.MISCinfoLV.Size = new System.Drawing.Size(1895, 835);
            this.MISCinfoLV.TabIndex = 1;
            this.MISCinfoLV.UseCompatibleStateImageBehavior = false;
            this.MISCinfoLV.View = System.Windows.Forms.View.Details;
            this.MISCinfoLV.DoubleClick += new System.EventHandler(this.MISCinfoLV_DoubleClick);
            // 
            // cboMiscType
            // 
            this.cboMiscType.FormattingEnabled = true;
            this.cboMiscType.Location = new System.Drawing.Point(10, 33);
            this.cboMiscType.Name = "cboMiscType";
            this.cboMiscType.Size = new System.Drawing.Size(221, 21);
            this.cboMiscType.TabIndex = 2;
            this.cboMiscType.SelectedIndexChanged += new System.EventHandler(this.cboMiscType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Misc. Type: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search: ";
            // 
            // textSearch
            // 
            this.textSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSearch.Location = new System.Drawing.Point(248, 33);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(177, 20);
            this.textSearch.TabIndex = 5;
            this.textSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSearch_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Search by Order of Payment Number";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textSearch);
            this.panel1.Controls.Add(this.cboMiscType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAddRecord);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(13, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 75);
            this.panel1.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(577, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Search by Date And Status";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dtDate);
            this.panel2.Controls.Add(this.cboStatus);
            this.panel2.Controls.Add(this.dtDateTo);
            this.panel2.Controls.Add(this.btnSearchDateStatus);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(567, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 75);
            this.panel2.TabIndex = 54;
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "MM/dd/yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(11, 34);
            this.dtDate.Name = "dtDate";
            this.dtDate.ShowCheckBox = true;
            this.dtDate.Size = new System.Drawing.Size(95, 20);
            this.dtDate.TabIndex = 3;
            this.dtDate.Value = new System.DateTime(2022, 8, 25, 0, 0, 0, 0);
            this.dtDate.ValueChanged += new System.EventHandler(this.btnSearchDateStatus_Click);
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(253, 34);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(181, 21);
            this.cboStatus.TabIndex = 5;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // dtDateTo
            // 
            this.dtDateTo.CustomFormat = "MM/dd/yyyy";
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(132, 34);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(95, 20);
            this.dtDateTo.TabIndex = 4;
            this.dtDateTo.Value = new System.DateTime(2022, 8, 17, 0, 0, 0, 0);
            // 
            // btnSearchDateStatus
            // 
            this.btnSearchDateStatus.Location = new System.Drawing.Point(440, 32);
            this.btnSearchDateStatus.Name = "btnSearchDateStatus";
            this.btnSearchDateStatus.Size = new System.Drawing.Size(75, 23);
            this.btnSearchDateStatus.TabIndex = 6;
            this.btnSearchDateStatus.Text = "Search";
            this.btnSearchDateStatus.UseVisualStyleBackColor = true;
            this.btnSearchDateStatus.Click += new System.EventHandler(this.btnSearchDateStatus_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Date From: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(250, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 46;
            this.label14.Text = "Status:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(129, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "Date To: ";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(1295, 49);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 57;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cboAction
            // 
            this.cboAction.FormattingEnabled = true;
            this.cboAction.Location = new System.Drawing.Point(1110, 51);
            this.cboAction.Name = "cboAction";
            this.cboAction.Size = new System.Drawing.Size(179, 21);
            this.cboAction.TabIndex = 56;
            this.cboAction.SelectedIndexChanged += new System.EventHandler(this.cboAction_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1107, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Action:";
            // 
            // btnAddGcashPaymaya
            // 
            this.btnAddGcashPaymaya.Location = new System.Drawing.Point(856, 103);
            this.btnAddGcashPaymaya.Name = "btnAddGcashPaymaya";
            this.btnAddGcashPaymaya.Size = new System.Drawing.Size(134, 23);
            this.btnAddGcashPaymaya.TabIndex = 58;
            this.btnAddGcashPaymaya.Text = "Add Gcash/Paymaya";
            this.btnAddGcashPaymaya.UseVisualStyleBackColor = true;
            this.btnAddGcashPaymaya.Click += new System.EventHandler(this.btnAddGcashPaymaya_Click);
            // 
            // textRecSelected
            // 
            this.textRecSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRecSelected.Enabled = false;
            this.textRecSelected.Location = new System.Drawing.Point(775, 106);
            this.textRecSelected.Name = "textRecSelected";
            this.textRecSelected.Size = new System.Drawing.Size(63, 20);
            this.textRecSelected.TabIndex = 65;
            this.textRecSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(671, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 63;
            this.label8.Text = "Records Selected: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(333, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 13);
            this.label11.TabIndex = 64;
            this.label11.Text = "Total Amount Transferred:";
            // 
            // textTotalAmountTransferred
            // 
            this.textTotalAmountTransferred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalAmountTransferred.Enabled = false;
            this.textTotalAmountTransferred.Location = new System.Drawing.Point(469, 106);
            this.textTotalAmountTransferred.Name = "textTotalAmountTransferred";
            this.textTotalAmountTransferred.Size = new System.Drawing.Size(160, 20);
            this.textTotalAmountTransferred.TabIndex = 60;
            this.textTotalAmountTransferred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "Total Amount To Pay: ";
            // 
            // textTotalAmount2Pay
            // 
            this.textTotalAmount2Pay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalAmount2Pay.Enabled = false;
            this.textTotalAmount2Pay.Location = new System.Drawing.Point(136, 106);
            this.textTotalAmount2Pay.Name = "textTotalAmount2Pay";
            this.textTotalAmount2Pay.Size = new System.Drawing.Size(160, 20);
            this.textTotalAmount2Pay.TabIndex = 61;
            this.textTotalAmount2Pay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelPaymentChannel
            // 
            this.labelPaymentChannel.AutoSize = true;
            this.labelPaymentChannel.Location = new System.Drawing.Point(1387, 31);
            this.labelPaymentChannel.Name = "labelPaymentChannel";
            this.labelPaymentChannel.Size = new System.Drawing.Size(93, 13);
            this.labelPaymentChannel.TabIndex = 67;
            this.labelPaymentChannel.Text = "Payment Channel:";
            // 
            // cboPaymentChannel
            // 
            this.cboPaymentChannel.FormattingEnabled = true;
            this.cboPaymentChannel.Location = new System.Drawing.Point(1390, 49);
            this.cboPaymentChannel.Name = "cboPaymentChannel";
            this.cboPaymentChannel.Size = new System.Drawing.Size(202, 21);
            this.cboPaymentChannel.TabIndex = 66;
            this.cboPaymentChannel.SelectedIndexChanged += new System.EventHandler(this.cboPaymentChannel_SelectedIndexChanged);
            // 
            // MiscelleneousTaxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1919, 1014);
            this.Controls.Add(this.labelPaymentChannel);
            this.Controls.Add(this.cboPaymentChannel);
            this.Controls.Add(this.textRecSelected);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textTotalAmountTransferred);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textTotalAmount2Pay);
            this.Controls.Add(this.btnAddGcashPaymaya);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.cboAction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MISCinfoLV);
            this.Name = "MiscelleneousTaxForm";
            this.Text = "MiscelleneousTax";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.ListView MISCinfoLV;
        private System.Windows.Forms.ComboBox cboMiscType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.Button btnSearchDateStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ComboBox cboAction;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddGcashPaymaya;
        private System.Windows.Forms.TextBox textRecSelected;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textTotalAmountTransferred;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textTotalAmount2Pay;
        private System.Windows.Forms.Label labelPaymentChannel;
        private System.Windows.Forms.ComboBox cboPaymentChannel;
    }
}