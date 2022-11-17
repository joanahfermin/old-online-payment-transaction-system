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
            this.SuspendLayout();
            // 
            // cboReportName
            // 
            this.cboReportName.FormattingEnabled = true;
            this.cboReportName.Location = new System.Drawing.Point(103, 68);
            this.cboReportName.Name = "cboReportName";
            this.cboReportName.Size = new System.Drawing.Size(236, 21);
            this.cboReportName.TabIndex = 0;
            this.cboReportName.SelectedIndexChanged += new System.EventHandler(this.cboReportName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search report: ";
            // 
            // LVreport
            // 
            this.LVreport.FullRowSelect = true;
            this.LVreport.HideSelection = false;
            this.LVreport.Location = new System.Drawing.Point(23, 106);
            this.LVreport.Name = "LVreport";
            this.LVreport.Size = new System.Drawing.Size(1119, 591);
            this.LVreport.TabIndex = 2;
            this.LVreport.UseCompatibleStateImageBehavior = false;
            this.LVreport.View = System.Windows.Forms.View.Details;
            // 
            // dtDate
            // 
            this.dtDate.Checked = false;
            this.dtDate.CustomFormat = "MM/dd/yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(103, 29);
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
            this.dtDateTo.Location = new System.Drawing.Point(244, 28);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(95, 20);
            this.dtDateTo.TabIndex = 47;
            this.dtDateTo.Value = new System.DateTime(2022, 8, 17, 0, 0, 0, 0);
            this.dtDateTo.ValueChanged += new System.EventHandler(this.dtDateTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Date From: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(212, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 49;
            this.label13.Text = "To: ";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 725);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.dtDateTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.LVreport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboReportName);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
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
    }
}