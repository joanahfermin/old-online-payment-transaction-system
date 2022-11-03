using SampleRPT1.MODEL;
using SampleRPT1.UTILITIES;
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
    public partial class UpdateMultipleRPTForm : Form
    {
        long RptiD;
        string taxdec;

        public UpdateMultipleRPTForm(string taxdec)
        {
            InitializeComponent();

            this.taxdec = taxdec;
            InitializeBank();
            cboBankUsed.SelectedIndex = 0;

            List<RealPropertyTax> rptList = RPTDatabase.SelectBySameGroup(taxdec);
            PopulateListView(rptList);

            ComputeAllPayment();
            InitializeQuarter();
        }

        public void InitializeBank()
        {
            List<RPTBank> bankList = RPTBankDatabase.SelectAllBank();

            foreach (RPTBank bank in bankList)
            {
                cboBankUsed.Items.Add(bank.BankName);
            }
        }

        public void InitializeQuarter()
        {
            foreach (string quarter in GlobalVariables.ALL_QUARTER)
            {
                cboQuarter.Items.Add(quarter);
            }
            cboQuarter.SelectedIndex = 3;
        }

        private void PopulateListView(List<RealPropertyTax> rptList)
        {
            ListViewUtil.copyFromListToListview<RealPropertyTax>(rptList, lvMultipleRecord, new List<string>
            { "RptID", "TaxDec", "TaxPayerName", "AmountToPay", "YearQuarter", "Quarter", "Bank", "PaymentDate", "RequestingParty",});
        }

        private void ComputeAllPayment()
        {
            decimal total = 0;

            foreach (ListViewItem item in lvMultipleRecord.Items)
            {
                total += decimal.Parse(item.SubItems[3].Text, System.Globalization.NumberStyles.Currency);
            }
            textTotalAmountToPay.Text = total.ToString("N2");
        }

        private void textTotalAmountToPay_TextChanged(object sender, EventArgs e)
        {
            ComputeAllPayment();
        }

        private void lvMultipleRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMultipleRecord.SelectedItems.Count > 0)
            {
                string RptId = lvMultipleRecord.SelectedItems[0].Text;
                RptiD = Convert.ToInt32(RptId);

                RealPropertyTax rpt = RPTDatabase.Get(RptiD);

                textTDN.Text = rpt.TaxDec.ToString();
                textTPName.Text = rpt.TaxPayerName;
                textYearQuarter.Text = rpt.YearQuarter;
                cboQuarter.SelectedIndex = 3;
                cboBankUsed.Text = rpt.Bank;
                dtDateOfPayment.Value = rpt.PaymentDate.Value;
                textRequestingParty.Text = rpt.RequestingParty;

                Clipboard.SetText(textTDN.Text);
            }
        }

        private void RefreshListview()
        {
            lvMultipleRecord.Items.Clear();

            RealPropertyTax rpt = RPTDatabase.Get(RptiD);
            string taxDec = rpt.TaxDec.ToString();

            List<RealPropertyTax> rptList = RPTDatabase.SelectBySameGroup(taxDec);
            PopulateListView(rptList);
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            RealPropertyTax rpt = RPTDatabase.Get(RptiD);

            rpt.TaxDec = textTDN.Text;
            rpt.TaxPayerName = textTPName.Text;
            //rpt.AmountToPay = Convert.ToDecimal(textAmount2Pay.Text);
            rpt.YearQuarter = textYearQuarter.Text;

            rpt.RequestingParty = textRequestingParty.Text;
            rpt.Bank = cboBankUsed.Text;
            rpt.Quarter = cboQuarter.Text;

            RPTDatabase.Update(rpt);

            MessageBox.Show("Information successfully updated.");

            RefreshListview();

            MainForm.INSTANCE.RefreshListView();

            textTDN.Clear();
            textTPName.Clear();
            //textAmount2Pay.Clear();
            //textYearQuarter.Clear();
            textRequestingParty.Clear();
        }
    }
}
