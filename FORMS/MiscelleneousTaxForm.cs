using SampleRPT1.FORMS;
using SampleRPT1.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1
{
    public partial class MiscelleneousTaxForm : Form
    {
        public static MiscelleneousTaxForm INSTANCE;

        public MiscelleneousTaxForm(Form parentForm)
        {
            InitializeComponent();
            InitializeMiscType();

            INSTANCE = this;
            MdiParent = parentForm;
            ControlBox = false;
        }

        public void InitializeMiscType()
        {
            cboMiscType.Items.Clear();

            foreach (string misc in MISCtype.ALL_MISC_TYPE)
            {
                cboMiscType.Items.Add(misc);
            }
            cboMiscType.SelectedIndex = 0;
        }

        public void Show()
        {
            base.Show();
            WindowState = FormWindowState.Maximized;
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            AddMISCrecord addMISCrecord = new AddMISCrecord();
            addMISCrecord.ShowDialog();
        }

        private void MiscelleneousTaxForm_Load(object sender, EventArgs e)
        {

        }
    }
}
