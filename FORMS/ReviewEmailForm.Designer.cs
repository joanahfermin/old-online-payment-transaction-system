
namespace SampleRPT1.FORMS
{
    partial class ReviewEmailForm
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
            this.lvReview = new System.Windows.Forms.ListView();
            this.rptID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.docType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taxdec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pbAttachedPicture = new System.Windows.Forms.PictureBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.rdAssessment = new System.Windows.Forms.RadioButton();
            this.rdReceipt = new System.Windows.Forms.RadioButton();
            this.checkRefreshAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAttachedPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // lvReview
            // 
            this.lvReview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rptID,
            this.docType,
            this.taxdec,
            this.email});
            this.lvReview.FullRowSelect = true;
            this.lvReview.GridLines = true;
            this.lvReview.HideSelection = false;
            this.lvReview.Location = new System.Drawing.Point(22, 47);
            this.lvReview.Margin = new System.Windows.Forms.Padding(2);
            this.lvReview.Name = "lvReview";
            this.lvReview.Size = new System.Drawing.Size(899, 912);
            this.lvReview.TabIndex = 1;
            this.lvReview.UseCompatibleStateImageBehavior = false;
            this.lvReview.View = System.Windows.Forms.View.Details;
            this.lvReview.SelectedIndexChanged += new System.EventHandler(this.lvReview_SelectedIndexChanged);
            // 
            // rptID
            // 
            this.rptID.Text = "RPTID";
            this.rptID.Width = 100;
            // 
            // docType
            // 
            this.docType.Text = "Document Type";
            this.docType.Width = 180;
            // 
            // taxdec
            // 
            this.taxdec.Text = "Tax Dec";
            this.taxdec.Width = 280;
            // 
            // email
            // 
            this.email.Text = "Requesting Party";
            this.email.Width = 330;
            // 
            // pbAttachedPicture
            // 
            this.pbAttachedPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAttachedPicture.Location = new System.Drawing.Point(941, 11);
            this.pbAttachedPicture.Margin = new System.Windows.Forms.Padding(2);
            this.pbAttachedPicture.Name = "pbAttachedPicture";
            this.pbAttachedPicture.Size = new System.Drawing.Size(950, 948);
            this.pbAttachedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAttachedPicture.TabIndex = 2;
            this.pbAttachedPicture.TabStop = false;
            this.pbAttachedPicture.Click += new System.EventHandler(this.pbAttachedPicture_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(740, 8);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(181, 30);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm Selected for Sending Email";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // rdAssessment
            // 
            this.rdAssessment.AutoSize = true;
            this.rdAssessment.Location = new System.Drawing.Point(515, 15);
            this.rdAssessment.Name = "rdAssessment";
            this.rdAssessment.Size = new System.Drawing.Size(95, 17);
            this.rdAssessment.TabIndex = 5;
            this.rdAssessment.TabStop = true;
            this.rdAssessment.Text = "All Assessment";
            this.rdAssessment.UseVisualStyleBackColor = true;
            this.rdAssessment.CheckedChanged += new System.EventHandler(this.rdAssessment_CheckedChanged);
            // 
            // rdReceipt
            // 
            this.rdReceipt.AutoSize = true;
            this.rdReceipt.Location = new System.Drawing.Point(629, 15);
            this.rdReceipt.Name = "rdReceipt";
            this.rdReceipt.Size = new System.Drawing.Size(76, 17);
            this.rdReceipt.TabIndex = 6;
            this.rdReceipt.TabStop = true;
            this.rdReceipt.Text = "All Receipt";
            this.rdReceipt.UseVisualStyleBackColor = true;
            this.rdReceipt.CheckedChanged += new System.EventHandler(this.rdReceipt_CheckedChanged);
            // 
            // checkRefreshAll
            // 
            this.checkRefreshAll.AutoSize = true;
            this.checkRefreshAll.Location = new System.Drawing.Point(22, 16);
            this.checkRefreshAll.Name = "checkRefreshAll";
            this.checkRefreshAll.Size = new System.Drawing.Size(63, 17);
            this.checkRefreshAll.TabIndex = 7;
            this.checkRefreshAll.Text = "Refresh";
            this.checkRefreshAll.UseVisualStyleBackColor = true;
            this.checkRefreshAll.CheckedChanged += new System.EventHandler(this.checkRefreshAll_CheckedChanged);
            // 
            // ReviewEmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 974);
            this.Controls.Add(this.checkRefreshAll);
            this.Controls.Add(this.rdReceipt);
            this.Controls.Add(this.rdAssessment);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.pbAttachedPicture);
            this.Controls.Add(this.lvReview);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReviewEmailForm";
            this.Text = "ReviewEmailForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbAttachedPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvReview;
        private System.Windows.Forms.ColumnHeader rptID;
        private System.Windows.Forms.ColumnHeader taxdec;
        private System.Windows.Forms.ColumnHeader email;
        private System.Windows.Forms.PictureBox pbAttachedPicture;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ColumnHeader docType;
        private System.Windows.Forms.RadioButton rdAssessment;
        private System.Windows.Forms.RadioButton rdReceipt;
        private System.Windows.Forms.CheckBox checkRefreshAll;
    }
}