using SampleRPT1.FORMS;
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
            InitializePaymentType();
            InitializeBillingSelection();

            cboBankUsed.Text = rptList[0].Bank;
            dtDateOfPayment.Value = rptList[0].PaymentDate.Value;
            textRequestingParty.Text = rptList[0].RequestingParty;
            cboPaymentType.Text = rptList[0].PaymentType;
            cboBillingSelection.Text = rptList[0].BillingSelection;
            textTotalTransferredAmount.Text = rptList[0].TotalAmountTransferred.ToString("N2");
            textRemarks.Text = rptList[0].RPTremarks;
        }

        public void InitializePaymentType()
        {
            foreach (string type in RPTPaymentTypeUtil.ALL_PAYMENT_TYPE)
            {
                cboPaymentType.Items.Add(type);
            }
            cboPaymentType.SelectedIndex = 3;
        }

        public void InitializeBillingSelection()
        {
            foreach (string type in RPTBillingSelection.ALL_BILLING_SELECTION)
            {
                cboBillingSelection.Items.Add(type);
            }
            cboBillingSelection.SelectedIndex = 0;
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
            ListViewUtil.copyFromListToListview<RealPropertyTax>(rptList, labelTotalAmountDep, new List<string>
            { "RptID", "TaxDec", "TaxPayerName", "AmountToPay", "TotalAmountTransferred", "YearQuarter", "Quarter", "PaymentType", "BillingSelection", "Bank", "PaymentDate", "RequestingParty", "RPTremarks",});
        }

        private void ComputeAllPayment()
        {
            decimal total = 0;

            foreach (ListViewItem item in labelTotalAmountDep.Items)
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
            if (labelTotalAmountDep.SelectedItems.Count > 0)
            {
                var selectedRecord = labelTotalAmountDep.SelectedItems[0];

                textTDN.Text = selectedRecord.SubItems[1].Text;
                textTPName.Text = selectedRecord.SubItems[2].Text;
                textAmountToBePay.Text = selectedRecord.SubItems[3].Text;
                textYearQuarter.Text = selectedRecord.SubItems[5].Text;
                cboQuarter.Text = selectedRecord.SubItems[6].Text;
                cboPaymentType.Text = selectedRecord.SubItems[7].Text;
                cboBillingSelection.Text = selectedRecord.SubItems[8].Text;
                textRemarks.Text = selectedRecord.SubItems[12].Text;

                if (labelTotalAmountDep.SelectedItems[0].Index > 0)
                {
                    textTotalTransferredAmount.Enabled = false;
                }
                else
                {
                    textTotalTransferredAmount.Enabled = true;
                }
            }
        }

        private void RefreshListview()
        {
            labelTotalAmountDep.Items.Clear();

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
            Validations.ValidateEmailAddressFormat(errorProvider1, textRequestingParty, "Requesting Party");

            //Validations.ValidateRequiredBank(errorProvider1, cboBankUsed, "Bank used");
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            bool FirstRecord = true;
            decimal TotalAmountDeposited = Convert.ToDecimal(textTotalTransferredAmount.Text);

            decimal TotalAmount2Pay = 0;

            foreach (ListViewItem item in labelTotalAmountDep.Items)
            {
                string Amount2Pay = item.SubItems[3].Text;
                TotalAmount2Pay = TotalAmount2Pay + Convert.ToDecimal(Amount2Pay);
            }

            foreach (ListViewItem item in labelTotalAmountDep.Items)
            {
                long RPTid = Convert.ToInt64(item.SubItems[0].Text);

                string TaxDec = item.SubItems[1].Text;
                string TaxPayerName = item.SubItems[2].Text;

                string Amount2Pay = item.SubItems[3].Text;
                string YearQuarter = item.SubItems[5].Text;
                string Quarter = item.SubItems[6].Text;
                string P_Type = item.SubItems[7].Text;
                string B_Selection = item.SubItems[8].Text;
                string Remarks = item.SubItems[10].Text;

                RealPropertyTax rpt = RPTDatabase.Get(RPTid);

                rpt.TaxDec = TaxDec;
                rpt.TaxPayerName = TaxPayerName;
                rpt.AmountToPay = Convert.ToDecimal(Amount2Pay);
                rpt.YearQuarter = YearQuarter;
                rpt.Quarter = Quarter;
                rpt.PaymentType = P_Type;
                rpt.BillingSelection = B_Selection;
                rpt.RPTremarks = Remarks;

                //Babayarn ko total of 100, deposit ako 150... 100 - 150, 50 para sa ExcessShortAmount.
                if (FirstRecord)
                {
                    if (RPTGcashPaymaya.isElectronicBankName(rpt.Bank) && rpt.TotalAmountTransferred == 0)
                    {
                        rpt.ExcessShortAmount = 0;
                    }
                    else
                    {
                        rpt.TotalAmountTransferred = Convert.ToDecimal(textTotalTransferredAmount.Text);
                        rpt.ExcessShortAmount = rpt.TotalAmountTransferred - TotalAmount2Pay;
                    }
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
                    if (RPTGcashPaymaya.isElectronicBankName(rpt.Bank))
                    {
                        rpt.AmountTransferred = Convert.ToDecimal(rpt.AmountToPay);
                    }
                    else
                    {
                        rpt.AmountTransferred = TotalAmountDeposited;
                    }
                    TotalAmountDeposited = 0;
                }

                rpt.YearQuarter = YearQuarter;
                rpt.Bank = cboBankUsed.Text.Trim();

                rpt.PaymentDate = dtDateOfPayment.Value.Date;

                rpt.RequestingParty = textRequestingParty.Text.Trim();

                //upon saving, system shall notify the user if there's an existing record/s in the db.
                List<RealPropertyTax> Detect_Existing_Record = RPTDatabase.Update_SelectBy_TaxDec_Year_Quarter(rpt.TaxDec, rpt.YearQuarter, rpt.Quarter, rpt.RptID);

                if (Detect_Existing_Record.Count > 0)
                {
                    RPTDuplicateRecordForm rptduplicateForm = new RPTDuplicateRecordForm(Detect_Existing_Record);
                    rptduplicateForm.Show();
                    return;
                }

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
            if (labelTotalAmountDep.Items.Count > 0)
            {
                labelTotalAmountDep.Items[0].Selected = true;
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
            if (labelTotalAmountDep.SelectedItems.Count > 0)
            {
                var selectedRecord = labelTotalAmountDep.SelectedItems[0];

                selectedRecord.SubItems[1].Text = textTDN.Text;
                selectedRecord.SubItems[2].Text = textTPName.Text;
                selectedRecord.SubItems[3].Text = textAmountToBePay.Text;
                selectedRecord.SubItems[5].Text = textYearQuarter.Text;
                selectedRecord.SubItems[6].Text = cboQuarter.Text;
                selectedRecord.SubItems[7].Text = cboPaymentType.Text;
                selectedRecord.SubItems[8].Text = cboBillingSelection.Text;
                selectedRecord.SubItems[12].Text = textRemarks.Text;

                MessageBox.Show("Record successfully updated.");
            }
        }
    }
}
