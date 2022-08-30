namespace SampleRPT1.FORMS
{
    partial class EmailTemplateForm
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
            this.LVEmail = new System.Windows.Forms.ListView();
            this.templateID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Subject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Assessment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Receipt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.textName = new System.Windows.Forms.TextBox();
            this.textSubject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new DG.MiniHTMLTextBox.MiniHTMLTextBox();
            this.cbAssessment = new System.Windows.Forms.CheckBox();
            this.cbReceipt = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LVEmail
            // 
            this.LVEmail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.templateID,
            this.name,
            this.Subject,
            this.Assessment,
            this.Receipt});
            this.LVEmail.FullRowSelect = true;
            this.LVEmail.GridLines = true;
            this.LVEmail.HideSelection = false;
            this.LVEmail.Location = new System.Drawing.Point(12, 12);
            this.LVEmail.Name = "LVEmail";
            this.LVEmail.Size = new System.Drawing.Size(994, 336);
            this.LVEmail.TabIndex = 0;
            this.LVEmail.UseCompatibleStateImageBehavior = false;
            this.LVEmail.View = System.Windows.Forms.View.Details;
            this.LVEmail.SelectedIndexChanged += new System.EventHandler(this.LVEmail_SelectedIndexChanged);
            // 
            // templateID
            // 
            this.templateID.Text = "TemplateID";
            this.templateID.Width = 100;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 200;
            // 
            // Subject
            // 
            this.Subject.Text = "Subject";
            this.Subject.Width = 400;
            // 
            // Assessment
            // 
            this.Assessment.Text = "Assessment";
            this.Assessment.Width = 120;
            // 
            // Receipt
            // 
            this.Receipt.Text = "Receipt";
            this.Receipt.Width = 120;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(745, 381);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add Template";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(834, 381);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(83, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit/Update";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(923, 382);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(15, 382);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(225, 20);
            this.textName.TabIndex = 5;
            // 
            // textSubject
            // 
            this.textSubject.Location = new System.Drawing.Point(269, 382);
            this.textSubject.Name = "textSubject";
            this.textSubject.Size = new System.Drawing.Size(225, 20);
            this.textSubject.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Subject:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Message Template: ";
            // 
            // richTextBox1
            // 
            this.richTextBox1.IllegalPatterns = new string[] {
        "<script.*?>",
        "<\\w+\\s+.*?(j|java|vb|ecma)script:.*?>",
        "<\\w+(\\s+|\\s+.*?\\s+)on\\w+\\s*=.+?>",
        "</?input.*?>"};
            this.richTextBox1.Location = new System.Drawing.Point(12, 430);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.richTextBox1.Size = new System.Drawing.Size(994, 377);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = null;
            // 
            // cbAssessment
            // 
            this.cbAssessment.AutoSize = true;
            this.cbAssessment.Location = new System.Drawing.Point(512, 386);
            this.cbAssessment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbAssessment.Name = "cbAssessment";
            this.cbAssessment.Size = new System.Drawing.Size(82, 17);
            this.cbAssessment.TabIndex = 9;
            this.cbAssessment.Text = "Assessment";
            this.cbAssessment.UseVisualStyleBackColor = true;
            // 
            // cbReceipt
            // 
            this.cbReceipt.AutoSize = true;
            this.cbReceipt.Location = new System.Drawing.Point(598, 386);
            this.cbReceipt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbReceipt.Name = "cbReceipt";
            this.cbReceipt.Size = new System.Drawing.Size(63, 17);
            this.cbReceipt.TabIndex = 10;
            this.cbReceipt.Text = "Receipt";
            this.cbReceipt.UseVisualStyleBackColor = true;
            // 
            // EmailTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 819);
            this.Controls.Add(this.cbReceipt);
            this.Controls.Add(this.cbAssessment);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textSubject);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.LVEmail);
            this.Name = "EmailTemplateForm";
            this.Text = "EmailTemplate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LVEmail;
        private System.Windows.Forms.ColumnHeader templateID;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader Subject;
        private System.Windows.Forms.ColumnHeader Assessment;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DG.MiniHTMLTextBox.MiniHTMLTextBox richTextBox1;
        private System.Windows.Forms.CheckBox cbAssessment;
        private System.Windows.Forms.CheckBox cbReceipt;
        private System.Windows.Forms.ColumnHeader Receipt;
    }
}