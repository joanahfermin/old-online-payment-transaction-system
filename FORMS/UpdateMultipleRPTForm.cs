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
        MainForm parentForm;
        long RptiD;
        string taxdec;

        public UpdateMultipleRPTForm(string taxdec)
        {
            InitializeComponent();
            this.taxdec = taxdec;
            InitializeBank();
            cboBankUsed.SelectedIndex = 0;
            //rdUpdatePayment.Checked = true;

            List<RealPropertyTax> rptList = RPTDatabase.SelectBySameGroup(taxdec);
            PopulateListView(rptList);

            ComputeAllPayment();
        }

        public void setParent(MainForm mainForm)
        {
            parentForm = mainForm;
        }

        public void InitializeBank()
        {
            List<RPTBank> bankList = RPTBankDatabase.SelectAllBank();

            foreach (RPTBank bank in bankList)
            {
                cboBankUsed.Items.Add(bank.BankName);
            }
        }

        private void PopulateListView(List<RealPropertyTax> rptList)
        {
            ListViewUtil.copyFromListToListview<RealPropertyTax>(rptList, lvMultipleRecord, new List<string>
            { "RptID", "TaxDec", "TaxPayerName", "AmountToPay", "YearQuarter", "Bank", "PaymentDate", "RequestingParty",});
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
                textAmount2Pay.Text = rpt.AmountToPay.ToString();
                textYearQuarter.Text = rpt.YearQuarter;
                cboBankUsed.Text = rpt.Bank;
                dtDateOfPayment.Value = rpt.PaymentDate.Value;
                textRequestingParty.Text = rpt.RequestingParty;
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
            //rpt.YearQuarter = textYearQuarter.Text;
            rpt.RequestingParty = textRequestingParty.Text;

            RPTDatabase.Update(rpt);

            MessageBox.Show("Information successfully updated.");

            RefreshListview();

            parentForm.RefreshListView();

            textTDN.Clear();
            textTPName.Clear();
            //textAmount2Pay.Clear();
            //textYearQuarter.Clear();
            textRequestingParty.Clear();
        }

        //private void validateForm()
        //{
        //    errorProvider1.Clear();

        //    Validations.ValidateRequiredBank(errorProvider1, cboBankUsed, "Bank");
        //    Validations.ValidateRequiredTotalAmountDeposited(errorProvider1, textTotalAmountDeposited, "Total Amount Deposited");
        //}

        //private RealPropertyTax GetRetrieveRPT(List<RealPropertyTax> rptList)
        //{
        //    RealPropertyTax ret = rptList[0];

        //    foreach (RealPropertyTax item in rptList)
        //    {
        //        if (item.TotalAmountTransferred > 0)
        //        {
        //            ret = item;
        //        }
        //    }

        //    return ret;
        //}

        private void btnUpdatePayment_Click(object sender, EventArgs e)
        {
            //    validateForm();

            //    if (Validations.HaveErrors(errorProvider1))
            //    {
            //        return;
            //    }

            //    decimal TotalAmountTransferred = Convert.ToDecimal(textTotalAmountDeposited.Text);

            //    List<RealPropertyTax> rptList = RPTDatabase.SelectBySameGroup2(taxdec);

            //    RealPropertyTax RetrieveRpt = GetRetrieveRPT(rptList);
            //    RetrieveRpt.TotalAmountTransferred = RetrieveRpt.TotalAmountTransferred + TotalAmountTransferred;

            //    decimal totalAmounttoPay = 0;

            //    foreach (RealPropertyTax rpt in rptList)
            //    {
            //        totalAmounttoPay = totalAmounttoPay + rpt.AmountToPay;
            //    }

            //    RetrieveRpt.ExcessShortAmount = RetrieveRpt.TotalAmountTransferred - totalAmounttoPay;

            //    RetrieveRpt.RPTremarks = RetrieveRpt.RPTremarks + "Added payment of " + TotalAmountTransferred + " on " + dtDateOfPayment.Value.Date.ToShortDateString();


            //    RPTDatabase.Update(RetrieveRpt);
            //    decimal remainingMoney = RetrieveRpt.TotalAmountTransferred;

            //    foreach (RealPropertyTax rpt in rptList)
            //    {
            //        if (rpt.AmountTransferred < rpt.AmountToPay)
            //        {
            //            if (remainingMoney >= rpt.AmountToPay)
            //            {
            //                rpt.AmountTransferred = rpt.AmountToPay;
            //                remainingMoney = remainingMoney - rpt.AmountToPay;
            //            }
            //            else if (remainingMoney > 0)
            //            {
            //                rpt.AmountTransferred = remainingMoney;
            //                remainingMoney = 0;
            //            }
            //            else
            //            {
            //                rpt.AmountTransferred = 0;
            //            }

            //            RPTDatabase.Update(rpt);
            //            break;
            //        }

            //    }
            //    parentForm.RefreshListView();

            //    this.Close();
        }
    }
}
