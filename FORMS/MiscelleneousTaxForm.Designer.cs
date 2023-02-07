namespace SampleRPT1
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
            this.SuspendLayout();
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(336, 12);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(163, 23);
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
            this.MISCinfoLV.Location = new System.Drawing.Point(12, 98);
            this.MISCinfoLV.Name = "MISCinfoLV";
            this.MISCinfoLV.Size = new System.Drawing.Size(1774, 491);
            this.MISCinfoLV.TabIndex = 1;
            this.MISCinfoLV.UseCompatibleStateImageBehavior = false;
            this.MISCinfoLV.View = System.Windows.Forms.View.Details;
            this.MISCinfoLV.DoubleClick += new System.EventHandler(this.MISCinfoLV_DoubleClick);
            // 
            // cboMiscType
            // 
            this.cboMiscType.FormattingEnabled = true;
            this.cboMiscType.Location = new System.Drawing.Point(93, 12);
            this.cboMiscType.Name = "cboMiscType";
            this.cboMiscType.Size = new System.Drawing.Size(221, 21);
            this.cboMiscType.TabIndex = 2;
            this.cboMiscType.SelectedIndexChanged += new System.EventHandler(this.cboMiscType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Misc. Type: ";
            // 
            // MiscelleneousTaxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1798, 805);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMiscType);
            this.Controls.Add(this.MISCinfoLV);
            this.Controls.Add(this.btnAddRecord);
            this.Name = "MiscelleneousTaxForm";
            this.Text = "MiscelleneousTax";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.ListView MISCinfoLV;
        private System.Windows.Forms.ComboBox cboMiscType;
        private System.Windows.Forms.Label label1;
    }
}