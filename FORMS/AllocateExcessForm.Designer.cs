﻿namespace SampleRPT1.FORMS
{
    partial class AllocateExcessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllocateExcessForm));
            this.textTDN = new System.Windows.Forms.TextBox();
            this.textYearQuarter = new System.Windows.Forms.TextBox();
            this.textAmount2Pay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textRefNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textTDN
            // 
            this.textTDN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTDN.Location = new System.Drawing.Point(137, 119);
            this.textTDN.Name = "textTDN";
            this.textTDN.Size = new System.Drawing.Size(264, 20);
            this.textTDN.TabIndex = 1;
            this.textTDN.Click += new System.EventHandler(this.textTDN_Click);
            this.textTDN.Enter += new System.EventHandler(this.textTDN_Enter);
            this.textTDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTDN_KeyDown);
            // 
            // textYearQuarter
            // 
            this.textYearQuarter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textYearQuarter.Location = new System.Drawing.Point(137, 159);
            this.textYearQuarter.Name = "textYearQuarter";
            this.textYearQuarter.Size = new System.Drawing.Size(264, 20);
            this.textYearQuarter.TabIndex = 2;
            this.textYearQuarter.Click += new System.EventHandler(this.textYearQuarter_Click);
            this.textYearQuarter.Enter += new System.EventHandler(this.textYearQuarter_Enter);
            this.textYearQuarter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textYearQuarter_KeyDown);
            // 
            // textAmount2Pay
            // 
            this.textAmount2Pay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAmount2Pay.Location = new System.Drawing.Point(137, 204);
            this.textAmount2Pay.Name = "textAmount2Pay";
            this.textAmount2Pay.Size = new System.Drawing.Size(264, 20);
            this.textAmount2Pay.TabIndex = 3;
            this.textAmount2Pay.Text = "0.00";
            this.textAmount2Pay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textAmount2Pay.Click += new System.EventHandler(this.textAmount2Pay_Click);
            this.textAmount2Pay.Enter += new System.EventHandler(this.textAmount2Pay_Enter);
            this.textAmount2Pay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textAmount2Pay_KeyDown);
            this.textAmount2Pay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAmount2Pay_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tax Dec. Num.: ";
            // 
            // textRefNum
            // 
            this.textRefNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRefNum.Enabled = false;
            this.textRefNum.Location = new System.Drawing.Point(137, 36);
            this.textRefNum.Name = "textRefNum";
            this.textRefNum.Size = new System.Drawing.Size(264, 20);
            this.textRefNum.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "YearQuarter: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Amount To Pay: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Ref. Num.: ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(228, 262);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // AllocateExcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 329);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textRefNum);
            this.Controls.Add(this.textAmount2Pay);
            this.Controls.Add(this.textYearQuarter);
            this.Controls.Add(this.textTDN);
            this.Name = "AllocateExcessForm";
            this.Text = "AllocateExcessForm";
            this.Load += new System.EventHandler(this.AllocateExcessForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textTDN;
        private System.Windows.Forms.TextBox textYearQuarter;
        private System.Windows.Forms.TextBox textAmount2Pay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textRefNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}