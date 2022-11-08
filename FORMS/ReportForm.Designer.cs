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
            this.SuspendLayout();
            // 
            // cboReportName
            // 
            this.cboReportName.FormattingEnabled = true;
            this.cboReportName.Location = new System.Drawing.Point(104, 24);
            this.cboReportName.Name = "cboReportName";
            this.cboReportName.Size = new System.Drawing.Size(219, 21);
            this.cboReportName.TabIndex = 0;
            this.cboReportName.SelectedIndexChanged += new System.EventHandler(this.cboReportName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search report: ";
            // 
            // LVreport
            // 
            this.LVreport.FullRowSelect = true;
            this.LVreport.HideSelection = false;
            this.LVreport.Location = new System.Drawing.Point(24, 62);
            this.LVreport.Name = "LVreport";
            this.LVreport.Size = new System.Drawing.Size(1119, 591);
            this.LVreport.TabIndex = 2;
            this.LVreport.UseCompatibleStateImageBehavior = false;
            this.LVreport.View = System.Windows.Forms.View.Details;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 725);
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
    }
}