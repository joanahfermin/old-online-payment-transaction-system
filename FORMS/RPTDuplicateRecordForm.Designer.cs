namespace SampleRPT1.FORMS
{
    partial class RPTDuplicateRecordForm
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
            this.RPTDuplicateLV = new System.Windows.Forms.ListView();
            this.pictureBoxReceipt = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // RPTDuplicateLV
            // 
            this.RPTDuplicateLV.FullRowSelect = true;
            this.RPTDuplicateLV.GridLines = true;
            this.RPTDuplicateLV.HideSelection = false;
            this.RPTDuplicateLV.Location = new System.Drawing.Point(12, 12);
            this.RPTDuplicateLV.Name = "RPTDuplicateLV";
            this.RPTDuplicateLV.Size = new System.Drawing.Size(842, 784);
            this.RPTDuplicateLV.TabIndex = 0;
            this.RPTDuplicateLV.UseCompatibleStateImageBehavior = false;
            this.RPTDuplicateLV.View = System.Windows.Forms.View.Details;
            this.RPTDuplicateLV.SelectedIndexChanged += new System.EventHandler(this.RPTDuplicateLV_SelectedIndexChanged);
            // 
            // pictureBoxReceipt
            // 
            this.pictureBoxReceipt.Location = new System.Drawing.Point(860, 12);
            this.pictureBoxReceipt.Name = "pictureBoxReceipt";
            this.pictureBoxReceipt.Size = new System.Drawing.Size(801, 784);
            this.pictureBoxReceipt.TabIndex = 1;
            this.pictureBoxReceipt.TabStop = false;
            // 
            // RPTDuplicateRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1673, 808);
            this.Controls.Add(this.pictureBoxReceipt);
            this.Controls.Add(this.RPTDuplicateLV);
            this.Name = "RPTDuplicateRecordForm";
            this.Text = "RPTDuplicateRecordForm";
            this.Load += new System.EventHandler(this.RPTDuplicateRecordForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReceipt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView RPTDuplicateLV;
        private System.Windows.Forms.PictureBox pictureBoxReceipt;
    }
}