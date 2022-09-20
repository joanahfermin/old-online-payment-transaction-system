
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
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lvReview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pbAttachedPicture = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbAttachedPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(67, 29);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(516, 28);
            this.cbType.TabIndex = 0;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // lvReview
            // 
            this.lvReview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvReview.FullRowSelect = true;
            this.lvReview.HideSelection = false;
            this.lvReview.Location = new System.Drawing.Point(67, 97);
            this.lvReview.Name = "lvReview";
            this.lvReview.Size = new System.Drawing.Size(1528, 603);
            this.lvReview.TabIndex = 1;
            this.lvReview.UseCompatibleStateImageBehavior = false;
            this.lvReview.View = System.Windows.Forms.View.Details;
            this.lvReview.SelectedIndexChanged += new System.EventHandler(this.lvReview_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "RPTID";
            this.columnHeader1.Width = 206;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tax Dec";
            this.columnHeader2.Width = 209;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Requesting Party";
            this.columnHeader3.Width = 502;
            // 
            // pbAttachedPicture
            // 
            this.pbAttachedPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAttachedPicture.Location = new System.Drawing.Point(67, 727);
            this.pbAttachedPicture.Name = "pbAttachedPicture";
            this.pbAttachedPicture.Size = new System.Drawing.Size(470, 236);
            this.pbAttachedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAttachedPicture.TabIndex = 2;
            this.pbAttachedPicture.TabStop = false;
            this.pbAttachedPicture.Click += new System.EventHandler(this.pbAttachedPicture_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(639, 29);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(97, 37);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(806, 736);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(789, 65);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm Selected for Sending Email";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // ReviewEmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1726, 996);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pbAttachedPicture);
            this.Controls.Add(this.lvReview);
            this.Controls.Add(this.cbType);
            this.Name = "ReviewEmailForm";
            this.Text = "ReviewEmailForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbAttachedPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ListView lvReview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.PictureBox pbAttachedPicture;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnConfirm;
    }
}