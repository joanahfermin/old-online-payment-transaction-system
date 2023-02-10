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
        string RefNum;
        string EAdd;

        public UpdateMultipleRPTForm(string refNum, string eAdd)
        {
            InitializeComponent();

            this.RefNum = refNum;
            this.EAdd = eAdd;
            InitializeBank();
            cboBankUsed.SelectedIndex = 0;

            //List<RealPropertyTax> rptList = RPTDatabase.SelectBySameGroup(taxdec);
            List<RealPropertyTax> rptList = RPTDatabase.SelectByRefNumAndReqParty(RefNum, eAdd);

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
            { "RptID", "TaxDec", "TaxPayerName", "AmountToPay", "TotalAmountTransferred", "YearQuarter", "Quarter", "Bank", "PaymentDate", "RequestingParty", "RPTremarks",});
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

                textAmountToBePay.Text = Convert.ToDecimal(rpt.AmountToPay).ToString();
                textTotalTransferredAmount.Text = Convert.ToDecimal(rpt.TotalAmountTransferred).ToString();
                textTDN.Text = rpt.TaxDec.ToString();
                textTPName.Text = rpt.TaxPayerName;
                textYearQuarter.Text = rpt.YearQuarter;
                cboQuarter.SelectedIndex = 3;
                cboBankUsed.Text = rpt.Bank;
                dtDateOfPayment.Value = rpt.PaymentDate.Value;
                textRequestingParty.Text = rpt.RequestingParty;
                //textRemarks.Text = rpt.RPTremarks;

                Clipboard.SetText(textTDN.Text);
            }
        }

        private void RefreshListview()
        {
            lvMultipleRecord.Items.Clear();

            //RealPropertyTax rpt = RPTDatabase.Get(RptiD);
            //string refNum = rpt.RefNum.ToString();

            //List<RealPropertyTax> rptList = RPTDatabase.SelectBySameGroup(taxDec);
            List<RealPropertyTax> rptList = RPTDatabase.SelectByRefNumAndReqParty(RefNum, EAdd);
            PopulateListView(rptList);
        }

        private void validateForm()
        {
            // clear muna natin lahat ng error from previous validation.
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textRequestingParty, "Requesting Party");

            //Validations.ValidateRequiredBank(errorProvider1, cboBankUsed, "Bank used");
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            bool FirstRecord = true;
            decimal TotalAmountDeposited = Convert.ToDecimal(textTotalTransferredAmount.Text);

            decimal TotalAmount2Pay = 0;

            foreach (ListViewItem item in lvMultipleRecord.Items)
            {
                string Amount2Pay = item.SubItems[3].Text;
                TotalAmount2Pay = TotalAmount2Pay + Convert.ToDecimal(Amount2Pay);
            }

            foreach (ListViewItem item in lvMultipleRecord.Items)
            {
                long RPTid = Convert.ToInt64(item.SubItems[0].Text);

                string TaxDec = item.SubItems[1].Text;
                string TaxPayerName = item.SubItems[2].Text;

                string Amount2Pay = item.SubItems[3].Text;
                string YearQuarter = item.SubItems[5].Text;
                string Quarter = item.SubItems[6].Text;
                string Remarks = item.SubItems[10].Text;

                RealPropertyTax rpt = RPTDatabase.Get(RPTid);

                rpt.TaxDec = TaxDec;
                rpt.TaxPayerName = TaxPayerName;
                rpt.AmountToPay = Convert.ToDecimal(Amount2Pay);
                rpt.YearQuarter = YearQuarter;
                rpt.Quarter = Quarter;
                rpt.RPTremarks = Remarks;

                //Babayarn ko total of 100, deposit ako 150... 100 - 150, 50 para sa ExcessShortAmount.
                if (FirstRecord)
                {
                    rpt.TotalAmountTransferred = Convert.ToDecimal(textTotalTransferredAmount.Text);
                    rpt.ExcessShortAmount = rpt.TotalAmountTransferred - TotalAmount2Pay;
                }

                //first record: amount to pay = 50.
                // 150 > 50, so AmountTransferred = 50.
                if (TotalAmountDeposited >= rpt.AmountToPay)
                {
                    rpt.AmountTransferred = rpt.AmountToPay;
                    //150 - 50 = 100. Balik ulit hanggang meron pang excess.
                    TotalAmountDeposited = TotalAmountDeposited - rpt.AmountToPay;
                }
                else
                {
                    rpt.AmountTransferred = TotalAmountDeposited;
                    TotalAmountDeposited = 0;
                }

                rpt.YearQuarter = YearQuarter;
                rpt.Bank = cboBankUsed.Text.Trim();

                rpt.PaymentDate = dtDateOfPayment.Value.Date;

                rpt.RequestingParty = textRequestingParty.Text.Trim();

                RPTDatabase.Update(rpt);

                FirstRecord = false;
            }

            if (textTotalAmountToPay.Text != textTotalTransferredAmount.Text)
            {
                MessageBox.Show("Please be advised that the record/s have insufficient or excess payment.");
            }

            MessageBox.Show("Information successfully updated.");

            RefreshListview();

            MainForm.INSTANCE.RefreshListView();

            UpdateMultipleRPTForm_Load(sender, e);
        }

        private void textAmountToBePay_TextChanged(object sender, EventArgs e)
        {
            //double amounttobepaid;
            //double.TryParse(textAmountToBePay.Text, out amounttobepaid);
            //textAmountToBePay.Text = amounttobepaid.ToString("N2");
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

        private void UpdateMultipleRPTForm_Load(object sender, EventArgs e)
        {
            if (lvMultipleRecord.Items.Count > 0)
            {
                lvMultipleRecord.Items[0].Selected = true;
            }
        }

        private void textAmountToBePay_Leave(object sender, EventArgs e)
        {
            decimal amounttobepaid;
            decimal.TryParse(textAmountToBePay.Text, out amounttobepaid);
            textAmountToBePay.Text = amounttobepaid.ToString("N2");
        }

        private void textTotalTransferredAmount_Leave(object sender, EventArgs e)
        {
            decimal totalTransferredAmount;
            decimal.TryParse(textTotalTransferredAmount.Text, out totalTransferredAmount);
            textTotalTransferredAmount.Text = totalTransferredAmount.ToString("N2");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvMultipleRecord.SelectedItems.Count > 0)
            {
                var selectedRecord = lvMultipleRecord.SelectedItems[0];

                selectedRecord.SubItems[1].Text = textTDN.Text;
                selectedRecord.SubItems[2].Text = textTPName.Text;
                selectedRecord.SubItems[3].Text = textAmountToBePay.Text;
                selectedRecord.SubItems[5].Text = textYearQuarter.Text;
                selectedRecord.SubItems[6].Text = cboQuarter.Text;
                selectedRecord.SubItems[10].Text = textRemarks.Text;

                MessageBox.Show("Record successfully updated.");
            }
        }
    }
}
