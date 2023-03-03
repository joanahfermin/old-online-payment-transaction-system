namespace SampleRPT1.FORMS
{
    partial class MISC_ViewHistoryForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtLastUpdateDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textLastUpdatedBy = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textAction = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MISCinfoLV = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Record History Information";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(858, 27);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(91, 29);
            this.btnRestore.TabIndex = 48;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtLastUpdateDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textLastUpdatedBy);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textAction);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(14, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 65);
            this.panel1.TabIndex = 49;
            // 
            // dtLastUpdateDate
            // 
            this.dtLastUpdateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLastUpdateDate.Location = new System.Drawing.Point(409, 18);
            this.dtLastUpdateDate.Name = "dtLastUpdateDate";
            this.dtLastUpdateDate.Size = new System.Drawing.Size(107, 20);
            this.dtLastUpdateDate.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Last Update by: ";
            // 
            // textLastUpdatedBy
            // 
            this.textLastUpdatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textLastUpdatedBy.Enabled = false;
            this.textLastUpdatedBy.Location = new System.Drawing.Point(105, 18);
            this.textLastUpdatedBy.Name = "textLastUpdatedBy";
            this.textLastUpdatedBy.Size = new System.Drawing.Size(169, 20);
            this.textLastUpdatedBy.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Last Update by: ";
            // 
            // textAction
            // 
            this.textAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAction.Enabled = false;
            this.textAction.Location = new System.Drawing.Point(619, 18);
            this.textAction.Name = "textAction";
            this.textAction.Size = new System.Drawing.Size(169, 20);
            this.textAction.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(567, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Action:  ";
            // 
            // MISCinfoLV
            // 
            this.MISCinfoLV.FullRowSelect = true;
            this.MISCinfoLV.GridLines = true;
            this.MISCinfoLV.HideSelection = false;
            this.MISCinfoLV.Location = new System.Drawing.Point(14, 94);
            this.MISCinfoLV.Name = "MISCinfoLV";
            this.MISCinfoLV.Size = new System.Drawing.Size(1895, 835);
            this.MISCinfoLV.TabIndex = 51;
            this.MISCinfoLV.UseCompatibleStateImageBehavior = false;
            this.MISCinfoLV.View = System.Windows.Forms.View.Details;
            // 
            // MISC_ViewHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1925, 941);
            this.Controls.Add(this.MISCinfoLV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.panel1);
            this.Name = "MISC_ViewHistoryForm";
            this.Text = "MISC_ViewHistoryForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtLastUpdateDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textLastUpdatedBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textAction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView MISCinfoLV;
    }
}