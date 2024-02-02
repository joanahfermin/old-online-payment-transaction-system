namespace SampleRPT1.FORMS
{
    partial class ReportForm
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
            this.cboReportName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LVreport = new System.Windows.Forms.ListView();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnReportCollector = new System.Windows.Forms.Button();
            this.textTotalCollection = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textTotalBilling = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textShttc = new System.Windows.Forms.TextBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboReportName
            // 
            this.cboReportName.FormattingEnabled = true;
            this.cboReportName.Location = new System.Drawing.Point(23, 36);
            this.cboReportName.Name = "cboReportName";
            this.cboReportName.Size = new System.Drawing.Size(373, 21);
            this.cboReportName.TabIndex = 0;
            this.cboReportName.SelectedIndexChanged += new System.EventHandler(this.cboReportName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search report: ";
            // 
            // LVreport
            // 
            this.LVreport.FullRowSelect = true;
            this.LVreport.GridLines = true;
            this.LVreport.HideSelection = false;
            this.LVreport.Location = new System.Drawing.Point(23, 73);
            this.LVreport.Name = "LVreport";
            this.LVreport.Size = new System.Drawing.Size(1193, 876);
            this.LVreport.TabIndex = 2;
            this.LVreport.UseCompatibleStateImageBehavior = false;
            this.LVreport.View = System.Windows.Forms.View.Details;
            // 
            // dtDate
            // 
            this.dtDate.Checked = false;
            this.dtDate.CustomFormat = "MM/dd/yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(421, 36);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(95, 20);
            this.dtDate.TabIndex = 46;
            this.dtDate.Value = new System.DateTime(2022, 8, 25, 0, 0, 0, 0);
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // dtDateTo
            // 
            this.dtDateTo.CustomFormat = "MM/dd/yyyy";
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(535, 36);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(95, 20);
            this.dtDateTo.TabIndex = 47;
            this.dtDateTo.Value = new System.DateTime(2022, 8, 17, 0, 0, 0, 0);
            this.dtDateTo.ValueChanged += new System.EventHandler(this.dtDateTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Date From: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(532, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 49;
            this.label13.Text = "To: ";
            // 
            // btnReportCollector
            // 
            this.btnReportCollector.Location = new System.Drawing.Point(1116, 34);
            this.btnReportCollector.Name = "btnReportCollector";
            this.btnReportCollector.Size = new System.Drawing.Size(100, 23);
            this.btnReportCollector.TabIndex = 50;
            this.btnReportCollector.Text = "Generate Report";
            this.btnReportCollector.UseVisualStyleBackColor = true;
            this.btnReportCollector.Click += new System.EventHandler(this.btnReportCollector_Click);
            // 
            // textTotalCollection
            // 
            this.textTotalCollection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalCollection.Location = new System.Drawing.Point(648, 36);
            this.textTotalCollection.Name = "textTotalCollection";
            this.textTotalCollection.Size = new System.Drawing.Size(143, 20);
            this.textTotalCollection.TabIndex = 51;
            this.textTotalCollection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTotalCollection.TextChanged += new System.EventHandler(this.textTotalCollection_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(645, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Total Collection: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(807, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Total Billing: ";
            // 
            // textTotalBilling
            // 
            this.textTotalBilling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalBilling.Location = new System.Drawing.Point(810, 36);
            this.textTotalBilling.Name = "textTotalBilling";
            this.textTotalBilling.Size = new System.Drawing.Size(143, 20);
            this.textTotalBilling.TabIndex = 51;
            this.textTotalBilling.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(970, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "SHT-TC: ";
            // 
            // textShttc
            // 
            this.textShttc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textShttc.Location = new System.Drawing.Point(973, 36);
            this.textShttc.Name = "textShttc";
            this.textShttc.Size = new System.Drawing.Size(131, 20);
            this.textShttc.TabIndex = 51;
            this.textShttc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textShttc.TextChanged += new System.EventHandler(this.textShttc_TextChanged);
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(1222, 73);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(121, 23);
            this.btnValidate.TabIndex = 52;
            this.btnValidate.Text = "Validate Payments";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1828, 971);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.textShttc);
            this.Controls.Add(this.textTotalBilling);
            this.Controls.Add(this.textTotalCollection);
            this.Controls.Add(this.btnReportCollector);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtDateTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.LVreport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboReportName);
            this.Name = "ReportForm";
            this.Text = "Online Payment Transaction System - Report Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboReportName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView LVreport;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnReportCollector;
        private System.Windows.Forms.TextBox textTotalCollection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textTotalBilling;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textShttc;
        private System.Windows.Forms.Button btnValidate;
    }
}