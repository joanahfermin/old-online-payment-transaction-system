using SampleRPT1.MODEL;
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
    public partial class RPTgenerateRefNumWithPayment : Form
    {
        List<RealPropertyTax> RptList = new List<RealPropertyTax>();
        decimal ComputedTotalAmountTransferred;

        public RPTgenerateRefNumWithPayment(List<long> rptList)
        {
            InitializeComponent();
            InitializeBank();
            dtDateOfPayment.Value = DateTime.Now;

            foreach (var item in rptList)
            {
                RealPropertyTax rpt = RPTDatabase.Get(item);
                ComputedTotalAmountTransferred = ComputedTotalAmountTransferred + Convert.ToDecimal(rpt.AmountToPay) - rpt.TotalAmountTransferred;

                RptList.Add(rpt);
            }
            textTotalAmountDeposited.Text = ComputedTotalAmountTransferred.ToString("N2");
        }

        public void InitializeBank()
        {
            List<RPTBank> bankList = RPTBankDatabase.SelectAllBank();

            foreach (RPTBank bank in bankList)
            {
                cboBankUsed.Items.Add(bank.BankName);
                cboBankUsed.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
