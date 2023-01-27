namespace SampleRPT1
{
    partial class ReorderEncodeDateForm
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
            this.textSQL = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnup = new System.Windows.Forms.Button();
            this.btndown = new System.Windows.Forms.Button();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // textSQL
            // 
            this.textSQL.Location = new System.Drawing.Point(29, 49);
            this.textSQL.Name = "textSQL";
            this.textSQL.Size = new System.Drawing.Size(1265, 20);
            this.textSQL.TabIndex = 0;
            this.textSQL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSQL_KeyDown);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(29, 99);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1265, 307);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "RptID";
            this.columnHeader1.Width = 95;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "TaxDec";
            this.columnHeader2.Width = 133;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "TaxPayerName";
            this.columnHeader3.Width = 453;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "RefNum";
            this.columnHeader4.Width = 213;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "EncodedDate";
            this.columnHeader5.Width = 287;
            // 
            // btnup
            // 
            this.btnup.Location = new System.Drawing.Point(676, 415);
            this.btnup.Name = "btnup";
            this.btnup.Size = new System.Drawing.Size(75, 23);
            this.btnup.TabIndex = 2;
            this.btnup.Text = "UP";
            this.btnup.UseVisualStyleBackColor = true;
            this.btnup.Click += new System.EventHandler(this.btnup_Click);
            // 
            // btndown
            // 
            this.btndown.Location = new System.Drawing.Point(786, 415);
            this.btndown.Name = "btndown";
            this.btndown.Size = new System.Drawing.Size(75, 23);
            this.btndown.TabIndex = 2;
            this.btndown.Text = "DONW";
            this.btndown.UseVisualStyleBackColor = true;
            this.btndown.Click += new System.EventHandler(this.btndown_Click);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "AmountToPay";
            // 
            // ReorderEncodeDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 450);
            this.Controls.Add(this.btndown);
            this.Controls.Add(this.btnup);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textSQL);
            this.Name = "ReorderEncodeDateForm";
            this.Text = "ReorderEncodeDateForm";
            this.Load += new System.EventHandler(this.ReorderEncodeDateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textSQL;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnup;
        private System.Windows.Forms.Button btndown;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}