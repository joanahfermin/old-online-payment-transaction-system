
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
            this.year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Bank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uploadedby = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pbAttachedPicture = new System.Windows.Forms.PictureBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.rdAssessment = new System.Windows.Forms.RadioButton();
            this.rdReceipt = new System.Windows.Forms.RadioButton();
            this.checkRefreshAll = new System.Windows.Forms.CheckBox();
            this.textLocCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textRecSelected = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbAttachedPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // lvReview
            // 
            this.lvReview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rptID,
            this.docType,
            this.taxdec,
            this.year,
            this.Bank,
            this.email,
            this.uploadedby});
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
            this.lvReview.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvReview_ItemSelectionChanged);
            this.lvReview.SelectedIndexChanged += new System.EventHandler(this.lvReview_SelectedIndexChanged);
            this.lvReview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvReview_KeyDown);
            this.lvReview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvReview_MouseDown);
            this.lvReview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvReview_MouseMove);
            // 
            // rptID
            // 
            this.rptID.Text = "RPTID";
            this.rptID.Width = 80;
            // 
            // docType
            // 
            this.docType.Text = "Document Type";
            this.docType.Width = 100;
            // 
            // taxdec
            // 
            this.taxdec.Text = "Tax Dec";
            this.taxdec.Width = 180;
            // 
            // year
            // 
            this.year.Text = "Year";
            this.year.Width = 80;
            // 
            // Bank
            // 
            this.Bank.Text = "Bank";
            this.Bank.Width = 150;
            // 
            // email
            // 
            this.email.Text = "Requesting Party";
            this.email.Width = 200;
            // 
            // uploadedby
            // 
            this.uploadedby.Text = "EncodedBy/UploadedBy";
            this.uploadedby.Width = 100;
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
            this.btnConfirm.Location = new System.Drawing.Point(835, 8);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(86, 30);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm Send";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // rdAssessment
            // 
            this.rdAssessment.AutoSize = true;
            this.rdAssessment.Location = new System.Drawing.Point(99, 15);
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
            this.rdReceipt.Location = new System.Drawing.Point(213, 15);
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
            // textLocCode
            // 
            this.textLocCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textLocCode.Location = new System.Drawing.Point(583, 13);
            this.textLocCode.Name = "textLocCode";
            this.textLocCode.Size = new System.Drawing.Size(100, 20);
            this.textLocCode.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Enter Loc. Code: ";
            // 
            // textRecSelected
            // 
            this.textRecSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRecSelected.Enabled = false;
            this.textRecSelected.Location = new System.Drawing.Point(406, 13);
            this.textRecSelected.Name = "textRecSelected";
            this.textRecSelected.Size = new System.Drawing.Size(63, 20);
            this.textRecSelected.TabIndex = 61;
            this.textRecSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(302, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = "Records Selected: ";
            // 
            // ReviewEmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 974);
            this.Controls.Add(this.textRecSelected);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textLocCode);
            this.Controls.Add(this.checkRefreshAll);
            this.Controls.Add(this.rdReceipt);
            this.Controls.Add(this.rdAssessment);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.pbAttachedPicture);
            this.Controls.Add(this.lvReview);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReviewEmailForm";
            this.Text = "Online Payment Transaction System - Review Email Form";
            this.Load += new System.EventHandler(this.ReviewEmailForm_Load);
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
        private System.Windows.Forms.ColumnHeader uploadedby;
        private System.Windows.Forms.TextBox textLocCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textRecSelected;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader year;
        private System.Windows.Forms.ColumnHeader Bank;
    }
}