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
            this.MenuItemGcashPaymaya = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExcessShort = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAllocateExcess = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAllocateBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEmailTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemRPT,
            this.MenuItemGcashPaymaya,
            this.MenuItemExcessShort,
            this.emailToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemRPT
            // 
            this.MenuItemRPT.Name = "MenuItemRPT";
            this.MenuItemRPT.Size = new System.Drawing.Size(39, 20);
            this.MenuItemRPT.Text = "RPT";
            this.MenuItemRPT.Click += new System.EventHandler(this.MenuItemHome_Click);
            // 
            // MenuItemGcashPaymaya
            // 
            this.MenuItemGcashPaymaya.Name = "MenuItemGcashPaymaya";
            this.MenuItemGcashPaymaya.Size = new System.Drawing.Size(104, 20);
            this.MenuItemGcashPaymaya.Text = "Gcash/Paymaya";
            this.MenuItemGcashPaymaya.Click += new System.EventHandler(this.MenuItemGcashPaymaya_Click);
            // 
            // MenuItemExcessShort
            // 
            this.MenuItemExcessShort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAllocateExcess,
            this.MenuItemAllocateBalance});
            this.MenuItemExcessShort.Name = "MenuItemExcessShort";
            this.MenuItemExcessShort.Size = new System.Drawing.Size(62, 20);
            this.MenuItemExcessShort.Text = "Allocate";
            // 
            // MenuItemAllocateExcess
            // 
            this.MenuItemAllocateExcess.Name = "MenuItemAllocateExcess";
            this.MenuItemAllocateExcess.Size = new System.Drawing.Size(108, 22);
            this.MenuItemAllocateExcess.Text = "Excess";
            this.MenuItemAllocateExcess.Click += new System.EventHandler(this.MenuItemAllocateExcess_Click);
            // 
            // MenuItemAllocateBalance
            // 
            this.MenuItemAllocateBalance.Name = "MenuItemAllocateBalance";
            this.MenuItemAllocateBalance.Size = new System.Drawing.Size(108, 22);
            this.MenuItemAllocateBalance.Text = "Short";
            this.MenuItemAllocateBalance.Click += new System.EventHandler(this.MenuItemAllocateBalance_Click);
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSendEmail,
            this.MenuItemEmailTemplate});
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
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
        private System.Windows.Forms.ToolStripMenuItem MenuItemAllocateExcess;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAllocateBalance;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSendEmail;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEmailTemplate;
    }
}