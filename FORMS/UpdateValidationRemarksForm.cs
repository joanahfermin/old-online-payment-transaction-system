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
    public partial class UpdateValidationRemarksForm : Form
    {
        RealPropertyTax RetrieveRPT;

        public UpdateValidationRemarksForm(long RPTid)
        {
            InitializeComponent();

            RetrieveRPT = RPTDatabase.Get(RPTid);
            textTDN.Text = RetrieveRPT.TaxDec;
            textValRemarks.Text = RetrieveRPT.ValRemarks;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RetrieveRPT.ValRemarks = textValRemarks.Text;

            RPTDatabase.Update(RetrieveRPT);

            MainForm.INSTANCE.RefreshListView();
            this.Close();
        }

    }
}
