﻿namespace SampleRPT1.FORMS
{
    partial class SendEmailForm
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
            this.cboTemplates = new System.Windows.Forms.ComboBox();
            this.textSubject = new System.Windows.Forms.TextBox();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnSendAssessment = new System.Windows.Forms.Button();
            this.btnSendReceipt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new DG.MiniHTMLTextBox.MiniHTMLTextBox();
            this.labelLocCode = new System.Windows.Forms.Label();
            this.textLocCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboTemplates
            // 
            this.cboTemplates.FormattingEnabled = true;
            this.cboTemplates.Location = new System.Drawing.Point(15, 36);
            this.cboTemplates.Name = "cboTemplates";
            this.cboTemplates.Size = new System.Drawing.Size(256, 21);
            this.cboTemplates.TabIndex = 1;
            this.cboTemplates.SelectedIndexChanged += new System.EventHandler(this.cboTemplates_SelectedIndexChanged);
            // 
            // textSubject
            // 
            this.textSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSubject.Enabled = false;
            this.textSubject.Location = new System.Drawing.Point(315, 36);
            this.textSubject.Name = "textSubject";
            this.textSubject.Size = new System.Drawing.Size(375, 20);
            this.textSubject.TabIndex = 2;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(589, 721);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(101, 23);
            this.btnSendEmail.TabIndex = 6;
            this.btnSendEmail.Text = "Send Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // btnSendAssessment
            // 
            this.btnSendAssessment.Location = new System.Drawing.Point(335, 721);
            this.btnSendAssessment.Name = "btnSendAssessment";
            this.btnSendAssessment.Size = new System.Drawing.Size(101, 23);
            this.btnSendAssessment.TabIndex = 4;
            this.btnSendAssessment.Text = "Send Assessment";
            this.btnSendAssessment.UseVisualStyleBackColor = true;
            this.btnSendAssessment.Click += new System.EventHandler(this.btnSendAssessment_Click);
            // 
            // btnSendReceipt
            // 
            this.btnSendReceipt.Location = new System.Drawing.Point(464, 721);
            this.btnSendReceipt.Name = "btnSendReceipt";
            this.btnSendReceipt.Size = new System.Drawing.Size(101, 23);
            this.btnSendReceipt.TabIndex = 5;
            this.btnSendReceipt.Text = "Send Receipt";
            this.btnSendReceipt.UseVisualStyleBackColor = true;
            this.btnSendReceipt.Click += new System.EventHandler(this.btnSendReceipt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name of Template: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Subject of Email: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Draft: ";
            // 
            // richTextBox1
            // 
            this.richTextBox1.IllegalPatterns = new string[] {
        "<script.*?>",
        "<\\w+\\s+.*?(j|java|vb|ecma)script:.*?>",
        "<\\w+(\\s+|\\s+.*?\\s+)on\\w+\\s*=.+?>",
        "</?input.*?>"};
            this.richTextBox1.Location = new System.Drawing.Point(15, 85);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Padding = new System.Windows.Forms.Padding(1);
            this.richTextBox1.Size = new System.Drawing.Size(675, 617);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = null;
            // 
            // labelLocCode
            // 
            this.labelLocCode.AutoSize = true;
            this.labelLocCode.Location = new System.Drawing.Point(16, 728);
            this.labelLocCode.Name = "labelLocCode";
            this.labelLocCode.Size = new System.Drawing.Size(90, 13);
            this.labelLocCode.TabIndex = 11;
            this.labelLocCode.Text = "Enter Loc. Code: ";
            // 
            // textLocCode
            // 
            this.textLocCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textLocCode.Location = new System.Drawing.Point(112, 721);
            this.textLocCode.Name = "textLocCode";
            this.textLocCode.Size = new System.Drawing.Size(100, 20);
            this.textLocCode.TabIndex = 10;
            // 
            // SendEmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 756);
            this.Controls.Add(this.labelLocCode);
            this.Controls.Add(this.textLocCode);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendReceipt);
            this.Controls.Add(this.btnSendAssessment);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.textSubject);
            this.Controls.Add(this.cboTemplates);
            this.Name = "SendEmailForm";
            this.Text = "Online Payment Transaction System - Send Email Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTemplates;
        private System.Windows.Forms.TextBox textSubject;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnSendAssessment;
        private System.Windows.Forms.Button btnSendReceipt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DG.MiniHTMLTextBox.MiniHTMLTextBox richTextBox1;
        private System.Windows.Forms.Label labelLocCode;
        private System.Windows.Forms.TextBox textLocCode;
    }
}