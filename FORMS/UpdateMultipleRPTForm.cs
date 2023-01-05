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
            { "RptID", "TaxDec", "TaxPayerName", "AmountToPay", "YearQuarter", "Quarter", "Bank", "PaymentDate", "RequestingParty", "RPTremarks",});
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

                if (rpt.Status != RPTStatus.FOR_ASSESSMENT)
                {
                    textAmountToBePay.Text = Convert.ToDecimal(rpt.AmountToPay).ToString();
                    labelAmountToBPay.Enabled = false;
                    textAmountToBePay.Enabled = false;
                }
                else
                {
                    textAmountToBePay.Text = Convert.ToDecimal(rpt.AmountToPay).ToString();
                }

                textTDN.Text = rpt.TaxDec.ToString();
                textTPName.Text = rpt.TaxPayerName;
                textYearQuarter.Text = rpt.YearQuarter;
                cboQuarter.SelectedIndex = 3;
                cboBankUsed.Text = rpt.Bank;
                dtDateOfPayment.Value = rpt.PaymentDate.Value;
                textRequestingParty.Text = rpt.RequestingParty;
                textRemarks.Text = rpt.RPTremarks;

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
            rpt.AmountToPay = Convert.ToDecimal(textAmountToBePay.Text);
            rpt.YearQuarter = textYearQuarter.Text;

            rpt.RequestingParty = textRequestingParty.Text;
            rpt.Bank = cboBankUsed.Text;
            rpt.Quarter = cboQuarter.Text;
            rpt.RPTremarks = textRemarks.Text;

            RPTDatabase.Update(rpt);

            MessageBox.Show("Information successfully updated.");

            RefreshListview();

            MainForm.INSTANCE.RefreshListView();

            textTDN.Clear();
            textTPName.Clear();
            textAmountToBePay.Clear();
            //textYearQuarter.Clear();
            textRequestingParty.Clear();
            textRemarks.Clear();
        }

        private void textAmountToBePay_TextChanged(object sender, EventArgs e)
        {
            double amounttobepaid;
            double.TryParse(textAmountToBePay.Text, out amounttobepaid);
            textAmountToBePay.Text = amounttobepaid.ToString("N2");
        }

        private void textAmountToBePay_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private bool textAmountToBePayJustEntered = false;
        private void textAmountToBePay_Enter(object sender, EventArgs e)
        {
            textAmountToBePay.SelectAll();
            textAmountToBePayJustEntered = true;
        }

        private void textAmountToBePay_Click(object sender, EventArgs e)
        {
            if (textAmountToBePayJustEntered)
            {
                textAmountToBePay.SelectAll();
            }
            textAmountToBePayJustEntered = false;
        }

        private bool textTPNameJustEntered = false;
        private void textTPName_Enter(object sender, EventArgs e)
        {
            textTPName.SelectAll();
            textTPNameJustEntered = true;
        }

        private void textTPName_Click(object sender, EventArgs e)
        {
            if (textTPNameJustEntered)
            {
                textTPName.SelectAll();
            }

            textTPNameJustEntered = false;
        }

        private void textTPName_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private bool textTDNJustEntered = false;
        private void textTDN_Enter(object sender, EventArgs e)
        {
            textTDN.SelectAll();
            textTDNJustEntered = true;
        }

        private void textTDN_Click(object sender, EventArgs e)
        {
            if (textTDNJustEntered)
            {
                textTDN.SelectAll();
            }

            textTDNJustEntered = false;
        }

        private void textTDN_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private bool textYearQuarterJustEntered = false;
        private void textYearQuarter_Enter(object sender, EventArgs e)
        {
            textYearQuarter.SelectAll();
            textYearQuarterJustEntered = true;
        }

        private void textYearQuarter_Click(object sender, EventArgs e)
        {
            if (textYearQuarterJustEntered)
            {
                textYearQuarter.SelectAll();
            }

            textYearQuarterJustEntered = false;
        }
       
        private void textYearQuarter_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);

        }

        private bool textRequestingPartyJustEntered = false;
        private void textRequestingParty_Enter(object sender, EventArgs e)
        {
            textRequestingParty.SelectAll();
            textRequestingPartyJustEntered = true;
        }

        private void textRequestingParty_Click(object sender, EventArgs e)
        {
            if (textRequestingPartyJustEntered)
            {
                textRequestingParty.SelectAll();
            }

            textRequestingPartyJustEntered = false;
        }

        private void textRequestingParty_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }
    }
}
