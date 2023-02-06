namespace SampleRPT1
{
    partial class ParentForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemRPT = new System.Windows.Forms.ToolStripMenuItem();
            this.MiscMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGcashPaymaya = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExcessShort = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAllocateExcess = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAllocateBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEmailTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemReviewEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.ReleasingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemRPT,
            this.MenuItemGcashPaymaya,
            this.MenuItemExcessShort,
            this.emailToolStripMenuItem,
            this.ReleasingMenuItem,
            this.historyMenuItem,
            this.ReportMenuItem,
            this.reorderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemRPT
            // 
            this.MenuItemRPT.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiscMenuItem});
            this.MenuItemRPT.Name = "MenuItemRPT";
            this.MenuItemRPT.Size = new System.Drawing.Size(39, 22);
            this.MenuItemRPT.Text = "RPT";
            this.MenuItemRPT.Click += new System.EventHandler(this.MenuItemHome_Click);
            // 
            // MiscMenuItem
            // 
            this.MiscMenuItem.Name = "MiscMenuItem";
            this.MiscMenuItem.Size = new System.Drawing.Size(180, 22);
            this.MiscMenuItem.Text = "MISC";
            this.MiscMenuItem.Click += new System.EventHandler(this.mISCToolStripMenuItem_Click);
            // 
            // MenuItemGcashPaymaya
            // 
            this.MenuItemGcashPaymaya.Name = "MenuItemGcashPaymaya";
            this.MenuItemGcashPaymaya.Size = new System.Drawing.Size(104, 22);
            this.MenuItemGcashPaymaya.Text = "Gcash/Paymaya";
            this.MenuItemGcashPaymaya.Click += new System.EventHandler(this.MenuItemGcashPaymaya_Click);
            // 
            // MenuItemExcessShort
            // 
            this.MenuItemExcessShort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAllocateExcess,
            this.MenuItemAllocateBalance});
            this.MenuItemExcessShort.Name = "MenuItemExcessShort";
            this.MenuItemExcessShort.Size = new System.Drawing.Size(66, 22);
            this.MenuItemExcessShort.Text = "Payment";
            // 
            // MenuItemAllocateExcess
            // 
            this.MenuItemAllocateExcess.Name = "MenuItemAllocateExcess";
            this.MenuItemAllocateExcess.Size = new System.Drawing.Size(154, 22);
            this.MenuItemAllocateExcess.Text = "Allocate Excess";
            this.MenuItemAllocateExcess.Click += new System.EventHandler(this.MenuItemAllocateExcess_Click);
            // 
            // MenuItemAllocateBalance
            // 
            this.MenuItemAllocateBalance.Name = "MenuItemAllocateBalance";
            this.MenuItemAllocateBalance.Size = new System.Drawing.Size(154, 22);
            this.MenuItemAllocateBalance.Text = "Balance Short";
            this.MenuItemAllocateBalance.Click += new System.EventHandler(this.MenuItemAllocateBalance_Click);
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSendEmail,
            this.MenuItemEmailTemplate,
            this.MenuItemReviewEmail});
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.emailToolStripMenuItem.Text = "Email";
            // 
            // MenuItemSendEmail
            // 
            this.MenuItemSendEmail.Name = "MenuItemSendEmail";
            this.MenuItemSendEmail.Size = new System.Drawing.Size(154, 22);
            this.MenuItemSendEmail.Text = "Send Email";
            this.MenuItemSendEmail.Click += new System.EventHandler(this.MenuItemSendEmail_Click);
            // 
            // MenuItemEmailTemplate
            // 
            this.MenuItemEmailTemplate.Name = "MenuItemEmailTemplate";
            this.MenuItemEmailTemplate.Size = new System.Drawing.Size(154, 22);
            this.MenuItemEmailTemplate.Text = "Email Template";
            this.MenuItemEmailTemplate.Click += new System.EventHandler(this.MenuItemEmailTemplate_Click);
            // 
            // MenuItemReviewEmail
            // 
            this.MenuItemReviewEmail.Name = "MenuItemReviewEmail";
            this.MenuItemReviewEmail.Size = new System.Drawing.Size(154, 22);
            this.MenuItemReviewEmail.Text = "Review Emails";
            this.MenuItemReviewEmail.Click += new System.EventHandler(this.MenuItemReviewEmail_Click);
            // 
            // ReleasingMenuItem
            // 
            this.ReleasingMenuItem.Name = "ReleasingMenuItem";
            this.ReleasingMenuItem.Size = new System.Drawing.Size(69, 22);
            this.ReleasingMenuItem.Text = "Releasing";
            this.ReleasingMenuItem.Click += new System.EventHandler(this.ReleasingMenuItem_Click);
            // 
            // historyMenuItem
            // 
            this.historyMenuItem.Name = "historyMenuItem";
            this.historyMenuItem.Size = new System.Drawing.Size(57, 22);
            this.historyMenuItem.Text = "History";
            this.historyMenuItem.Click += new System.EventHandler(this.historyMenuItem_Click);
            // 
            // ReportMenuItem
            // 
            this.ReportMenuItem.Name = "ReportMenuItem";
            this.ReportMenuItem.Size = new System.Drawing.Size(54, 22);
            this.ReportMenuItem.Text = "Report";
            this.ReportMenuItem.Click += new System.EventHandler(this.ReportMenuItem_Click);
            // 
            // reorderToolStripMenuItem
            // 
            this.reorderToolStripMenuItem.Name = "reorderToolStripMenuItem";
            this.reorderToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            this.reorderToolStripMenuItem.Text = "Reorder";
            this.reorderToolStripMenuItem.Click += new System.EventHandler(this.reorderToolStripMenuItem_Click);
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ParentForm";
            this.Text = "ParentForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ParentForm_FormClosed);
            this.Load += new System.EventHandler(this.ParentForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRPT;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGcashPaymaya;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExcessShort;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSendEmail;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEmailTemplate;
        private System.Windows.Forms.ToolStripMenuItem ReleasingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAllocateExcess;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAllocateBalance;
        private System.Windows.Forms.ToolStripMenuItem MenuItemReviewEmail;
        private System.Windows.Forms.ToolStripMenuItem historyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MiscMenuItem;
    }
}