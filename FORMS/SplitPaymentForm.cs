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
    public partial class SplitPaymentForm : Form
    {
        RealPropertyTax rpt;

        public SplitPaymentForm(long RPTid)
        {
            rpt = RPTDatabase.Get(RPTid);
            InitializeComponent();
            InitializeQuarter();

            textExcess.Text = rpt.AmountToPay.ToString();
            textYear.Text = (Convert.ToInt32(rpt.YearQuarter) + 1).ToString();
        }

        public void InitializeQuarter()
        {
            foreach (string quarter in GlobalVariables.ALL_QUARTER)
            {
                cboQuarter.Items.Add(quarter);
            }
            cboQuarter.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal originalAmountToPay = rpt.AmountToPay;
            decimal excessAmount = Convert.ToDecimal(textExcess.Text);
            decimal newAmountToPay = originalAmountToPay - excessAmount;
            rpt.AmountToPay = newAmountToPay;

            rpt.AmountTransferred = newAmountToPay;

            RPTDatabase.Update(rpt);

            rpt.AmountToPay = excessAmount;
            rpt.AmountTransferred = excessAmount;
            rpt.YearQuarter = textYear.Text;
            rpt.Quarter = cboQuarter.Text;

            RPTDatabase.Insert(rpt);

            MainForm.INSTANCE.RefreshListView();
        }
    }
}
