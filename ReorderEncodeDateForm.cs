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
    public partial class ReorderEncodeDateForm : Form
    {
        public static ReorderEncodeDateForm INSTANCE;

        public ReorderEncodeDateForm()
        {
            InitializeComponent();
        }

        public ReorderEncodeDateForm(Form parentForm)
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

        private void ReorderEncodeDateForm_Load(object sender, EventArgs e)
        {

        }

        private void textSQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                refreshlistview();
                
            }
        }

        private void refreshlistview()
        {
            List<RealPropertyTax> rptlist =  RPTDatabase.SelectSQL(textSQL.Text);

            ListViewUtil.copyFromListToListview<RealPropertyTax>(rptlist, listView1, new List<string>
            { "RptID", "TaxDec", "TaxPayerName", "AmountToPay", "RefNum", "EncodedDate"});
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int index = listView1.SelectedItems[0].Index;

                if (index > 0)
                {
                    long rptid = Convert.ToInt64(listView1.Items[index].Text);
                    long rptid2 = Convert.ToInt64(listView1.Items[index - 1].Text);
                    RealPropertyTax rpt = RPTDatabase.Get(rptid);
                    RealPropertyTax rpt2 = RPTDatabase.Get(rptid2);

                    DateTime? date = rpt.EncodedDate;
                    rpt.EncodedDate = rpt2.EncodedDate;
                    rpt2.EncodedDate = date;
                    RPTDatabase.Update(rpt);
                    RPTDatabase.Update(rpt2);
                    refreshlistview();
                    listView1.Items[index - 1].Selected = true;
                }
            }
        }

        private void btndown_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int index = listView1.SelectedItems[0].Index;

                if (index < listView1.Items.Count - 1)
                {
                    long rptid = Convert.ToInt64(listView1.Items[index].Text);
                    long rptid2 = Convert.ToInt64(listView1.Items[index + 1].Text);
                    RealPropertyTax rpt = RPTDatabase.Get(rptid);
                    RealPropertyTax rpt2 = RPTDatabase.Get(rptid2);

                    DateTime? date = rpt.EncodedDate;
                    rpt.EncodedDate = rpt2.EncodedDate;
                    rpt2.EncodedDate = date;
                    RPTDatabase.Update(rpt);
                    RPTDatabase.Update(rpt2);
                    refreshlistview();
                    listView1.Items[index + 1].Selected = true;
                }
            }
        }
    }
}
