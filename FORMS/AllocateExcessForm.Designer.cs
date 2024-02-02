namespace SampleRPT1.FORMS
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
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboQuarter = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textTDN
            // 
            this.textTDN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTDN.Location = new System.Drawing.Point(104, 106);
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
            this.textYearQuarter.Location = new System.Drawing.Point(104, 146);
            this.textYearQuarter.Name = "textYearQuarter";
            this.textYearQuarter.Size = new System.Drawing.Size(91, 20);
            this.textYearQuarter.TabIndex = 2;
            this.textYearQuarter.Click += new System.EventHandler(this.textYearQuarter_Click);
            this.textYearQuarter.Enter += new System.EventHandler(this.textYearQuarter_Enter);
            this.textYearQuarter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textYearQuarter_KeyDown);
            // 
            // textAmount2Pay
            // 
            this.textAmount2Pay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAmount2Pay.Location = new System.Drawing.Point(104, 191);
            this.textAmount2Pay.Name = "textAmount2Pay";
            this.textAmount2Pay.Size = new System.Drawing.Size(91, 20);
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
            this.label1.Location = new System.Drawing.Point(13, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tax Dec. Num.: ";
            // 
            // textRefNum
            // 
            this.textRefNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRefNum.Enabled = false;
            this.textRefNum.Location = new System.Drawing.Point(104, 23);
            this.textRefNum.Name = "textRefNum";
            this.textRefNum.Size = new System.Drawing.Size(264, 20);
            this.textRefNum.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Year:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Amount To Pay: ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(189, 365);
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
            // cboQuarter
            // 
            this.cboQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuarter.FormattingEnabled = true;
            this.cboQuarter.Location = new System.Drawing.Point(254, 145);
            this.cboQuarter.Name = "cboQuarter";
            this.cboQuarter.Size = new System.Drawing.Size(114, 21);
            this.cboQuarter.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(201, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Quarter: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Remarks: ";
            // 
            // textRemarks
            // 
            this.textRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRemarks.Location = new System.Drawing.Point(104, 235);
            this.textRemarks.Multiline = true;
            this.textRemarks.Name = "textRemarks";
            this.textRemarks.Size = new System.Drawing.Size(264, 105);
            this.textRemarks.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Reference No.: ";
            // 
            // AllocateExcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 413);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textRemarks);
            this.Controls.Add(this.cboQuarter);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textRefNum);
            this.Controls.Add(this.textAmount2Pay);
            this.Controls.Add(this.textYearQuarter);
            this.Controls.Add(this.textTDN);
            this.Name = "AllocateExcessForm";
            this.Text = "Online Payment Transaction System - Allocate Excess Form";
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cboQuarter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textRemarks;
        private System.Windows.Forms.Label label4;
    }
}