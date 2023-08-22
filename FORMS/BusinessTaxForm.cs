using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.FORMS
{
    public partial class BusinessTaxForm : Form
    {
        public static BusinessTaxForm INSTANCE;

        public BusinessTaxForm(Form parentForm)
        {
            InitializeComponent();

            INSTANCE = this;
            MdiParent = parentForm;
            ControlBox = false;
        }

        public void Show()
        {
            base.Show();
            WindowState = FormWindowState.Maximized;
        }


        private void BusinessTaxForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            AddBusinessForm addBusinessForm = new AddBusinessForm();
            addBusinessForm.ShowDialog();
        }
    }
}
