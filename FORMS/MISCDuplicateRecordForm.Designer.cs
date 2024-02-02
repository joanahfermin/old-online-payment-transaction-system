namespace SampleRPT1.FORMS
{
    partial class MISCDuplicateRecordForm
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
            this.MiscDuplicateLV = new System.Windows.Forms.ListView();
            this.pictureBoxReceipt = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // MiscDuplicateLV
            // 
            this.MiscDuplicateLV.FullRowSelect = true;
            this.MiscDuplicateLV.GridLines = true;
            this.MiscDuplicateLV.HideSelection = false;
            this.MiscDuplicateLV.Location = new System.Drawing.Point(12, 12);
            this.MiscDuplicateLV.Name = "MiscDuplicateLV";
            this.MiscDuplicateLV.Size = new System.Drawing.Size(842, 784);
            this.MiscDuplicateLV.TabIndex = 0;
            this.MiscDuplicateLV.UseCompatibleStateImageBehavior = false;
            this.MiscDuplicateLV.View = System.Windows.Forms.View.Details;
            this.MiscDuplicateLV.SelectedIndexChanged += new System.EventHandler(this.RPTDuplicateLV_SelectedIndexChanged);
            // 
            // pictureBoxReceipt
            // 
            this.pictureBoxReceipt.Location = new System.Drawing.Point(860, 12);
            this.pictureBoxReceipt.Name = "pictureBoxReceipt";
            this.pictureBoxReceipt.Size = new System.Drawing.Size(801, 784);
            this.pictureBoxReceipt.TabIndex = 1;
            this.pictureBoxReceipt.TabStop = false;
            // 
            // MISCDuplicateRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1673, 808);
            this.Controls.Add(this.pictureBoxReceipt);
            this.Controls.Add(this.MiscDuplicateLV);
            this.Name = "MISCDuplicateRecordForm";
            this.Text = "Online Payment Transaction System - Misc Duplicate Record Form";
            this.Load += new System.EventHandler(this.MISCDuplicateRecordForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReceipt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView MiscDuplicateLV;
        private System.Windows.Forms.PictureBox pictureBoxReceipt;
    }
}