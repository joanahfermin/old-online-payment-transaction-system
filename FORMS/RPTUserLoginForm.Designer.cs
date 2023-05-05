namespace SampleRPT1
{
    partial class RPTUserLoginForm
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
            this.textUserName = new System.Windows.Forms.TextBox();
            this.textPassWord = new System.Windows.Forms.TextBox();
            this.btnRptLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textUserName
            // 
            this.textUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textUserName.Location = new System.Drawing.Point(145, 52);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(204, 20);
            this.textUserName.TabIndex = 1;
            this.textUserName.Click += new System.EventHandler(this.textUserName_Click);
            this.textUserName.Enter += new System.EventHandler(this.textUserName_Enter);
            this.textUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textUserName_KeyDown);
            // 
            // textPassWord
            // 
            this.textPassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPassWord.Location = new System.Drawing.Point(145, 89);
            this.textPassWord.Name = "textPassWord";
            this.textPassWord.PasswordChar = '•';
            this.textPassWord.Size = new System.Drawing.Size(204, 20);
            this.textPassWord.TabIndex = 2;
            this.textPassWord.Click += new System.EventHandler(this.textPassWord_Click);
            this.textPassWord.Enter += new System.EventHandler(this.textPassWord_Enter);
            this.textPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textPassWord_KeyDown);
            // 
            // btnRptLogin
            // 
            this.btnRptLogin.Location = new System.Drawing.Point(145, 127);
            this.btnRptLogin.Name = "btnRptLogin";
            this.btnRptLogin.Size = new System.Drawing.Size(204, 23);
            this.btnRptLogin.TabIndex = 3;
            this.btnRptLogin.Text = "Login";
            this.btnRptLogin.UseVisualStyleBackColor = true;
            this.btnRptLogin.Click += new System.EventHandler(this.btnRptLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password: ";
            // 
            // RPTUserLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 210);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRptLogin);
            this.Controls.Add(this.textPassWord);
            this.Controls.Add(this.textUserName);
            this.Name = "RPTUserLoginForm";
            this.Text = "RPTUserLoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.TextBox textPassWord;
        private System.Windows.Forms.Button btnRptLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}