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
    public partial class UpdateRPTForm : Form
    {
        List<RealPropertyTax> RptList = new List<RealPropertyTax>();
        private static string MULTIPLE_MARKER = "***";
        private static DateTime MULTIPLE_MARKERDATE = DateTime.Parse("01/01/1900");

        //Initializes the passed list of rptid records from the main form. 
        public UpdateRPTForm(List<long> RptIDList)
        {
            InitializeComponent();

            foreach (var RptId in RptIDList)
            {
                RealPropertyTax rpt = RPTDatabase.Get(RptId);
                RptList.Add(rpt);
            }
            InitializeUpdateRecord();
            InitializeQuarter();
            InitializeBank();
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

        private void validateForm()
        {
            // clear muna natin lahat ng error from previous validation.
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textRequestingParty, "Requesting Party");

            //Validations.ValidateRequiredBank(errorProvider1, cboBankUsed, "Bank used");
        }

        /// <summary>
        /// Populates the textfields from the retrieved records in the main form using the passed RptList. 
        /// If, multiple records are selected and has different payment dates, MULTIPLE_MARKERDATE will auto-populate the datetime picker. 
        /// </summary>
        public void InitializeUpdateRecord()
        {
            Boolean FirstRecord = true;

            foreach (var rpt in RptList)
            {
                if (FirstRecord == true)
                {
                    textTaxDec.Text = rpt.TaxDec;
                    textTPName.Text = rpt.TaxPayerName;

                    if (rpt.Status != RPTStatus.FOR_ASSESSMENT)
                    {
                        textAmountToBePaid.Text = Convert.ToDecimal(rpt.AmountToPay).ToString();
                        labelAmountToBPay.Enabled = false;
                        textAmountToBePaid.Enabled = false;
                    }
                    else
                    {
                        textAmountToBePaid.Text = Convert.ToDecimal(rpt.AmountToPay).ToString();
                    }

                    //textAmountToBePaid.Text = rpt.AmountToPay.ToString();
                    //textTransferredAmount.Text = rpt.AmountTransferred.ToString();

                    cboBankUsed.Text = rpt.Bank;
                    textYear.Text = rpt.YearQuarter;

                    cboQuarter.Text = rpt.Quarter;
                    if (rpt.PaymentDate != null)
                    {
                        dtDateOfPayment.Value = rpt.PaymentDate.Value;
                    }
                    if (rpt.AmountTransferred == 0)
                    {
                        dtDateOfPayment.Enabled = false;
                        cboBankUsed.Enabled = false;
                    }
                    cbStatus.Text = rpt.Status;
                    textRequestingParty.Text = rpt.RequestingParty;
                    textRemarks.Text = rpt.RPTremarks;

                    if (rpt.Status == RPTStatus.BILL_SENT)
                    {
                        //textTransferredAmount.Text = rpt.AmountToPay.ToString();
                        //textTransferredAmount.Focus();
                        //textTransferredAmount.Select();
                    }

                    FirstRecord = false;
                }
                else
                {
                    if (textTaxDec.Text != rpt.TaxDec)
                    {
                        textTaxDec.Text = MULTIPLE_MARKER;
                    }
                    if (textTPName.Text != rpt.TaxPayerName)
                    {
                        textTPName.Text = MULTIPLE_MARKER;
                    }
                    //if (textAmountToBePaid.Text != rpt.AmountToPay.ToString())
                    //{
                    //    textAmountToBePaid.Text = MULTIPLE_MARKER;
                    //}
                    //if (textTransferredAmount.Text != rpt.AmountTransferred.ToString())
                    //{
                    //    textTransferredAmount.Text = MULTIPLE_MARKER;
                    //}
                    if (cboBankUsed.Text != rpt.Bank)
                    {
                        cboBankUsed.Text = MULTIPLE_MARKER;
                    }
                    //DETECT IF TWO CONSECUTIVE DATES ARE DIFFERENT. IF DIFFERENT, THEN ASSIGN MULTIPLE_MARKERDATE.
                    if ((rpt.PaymentDate == null && dtDateOfPayment.Value != MULTIPLE_MARKERDATE) ||
                    (rpt.PaymentDate != null && dtDateOfPayment.Value != rpt.PaymentDate.Value))
                    {
                        dtDateOfPayment.Value = MULTIPLE_MARKERDATE;
                    }
                    if (textYear.Text != rpt.YearQuarter)
                    {
                        textYear.Text = MULTIPLE_MARKER;
                    }
                    if (textRequestingParty.Text != rpt.RequestingParty)
                    {
                        textRequestingParty.Text = MULTIPLE_MARKER;
                    }
                    if (textRemarks.Text != rpt.RPTremarks)
                    {
                        textRemarks.Text = MULTIPLE_MARKER;
                    }
                }
            }
        }

        //Date of Payment and bank used will be enabled depending on the value of TransferredAmount textfield.
        private void CheckUncheckDateOfPayment()
        {
            //if (textTransferredAmount.Text != "0.00")
            //{
            //    dtDateOfPayment.Format = DateTimePickerFormat.Custom;
            //    dtDateOfPayment.CustomFormat = "MM/dd/yyyy";

            //    dtDateOfPayment.Checked = true;
            //    dtDateOfPayment.Enabled = true;
            //    cboBankUsed.Enabled = true;
            //}
            //else if (textTransferredAmount.Text == "0.00")
            //{
            //    cboBankUsed.SelectedIndex = 0;
            //    dtDateOfPayment.Format = DateTimePickerFormat.Custom;
            //    dtDateOfPayment.CustomFormat = " ";
            //    dtDateOfPayment.Checked = false;
            //    dtDateOfPayment.Enabled = false;
            //    cboBankUsed.Enabled = false;
            //    cboBankUsed.Text = string.Empty;
            //}
        }

        //Updates the record.
        private void btnUpdateRecord_Click(object sender, EventArgs e)
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            foreach (var rpt in RptList)
            {
                if (textTaxDec.Text != MULTIPLE_MARKER)
                {
                    rpt.TaxDec = textTaxDec.Text;
                }
                if (textTPName.Text != MULTIPLE_MARKER)
                {
                    rpt.TaxPayerName = textTPName.Text;
                }
                if (textAmountToBePaid.Text != MULTIPLE_MARKER)
                {
                    rpt.AmountToPay = Convert.ToDecimal(textAmountToBePaid.Text);
                }

                //if (textTransferredAmount.Text != MULTIPLE_MARKER)
                //{
                //    rpt.AmountTransferred = Convert.ToDecimal(textTransferredAmount.Text);
                //    rpt.ExcessShortAmount = rpt.AmountToPay - rpt.AmountTransferred;
                //}

                //IF USER ENTERED SPECIFIC DATE AND THERE IS AMOUNTOPAY AND AMOUNTTRANSFERRED,
                //THEN ASSIGN NEW VALUE TO THE DATE. OTHERWISE, RETAIN OLD DATE VALUE.

                if (dtDateOfPayment.Value != MULTIPLE_MARKERDATE
                    && rpt.AmountToPay != 0
                    && rpt.AmountTransferred != 0)
                {
                    if (dtDateOfPayment.Enabled)
                    {
                        rpt.PaymentDate = dtDateOfPayment.Value.Date;
                    }
                    else
                    {
                        rpt.PaymentDate = null;
                    }
                }

                if (cboBankUsed.Text != MULTIPLE_MARKER)
                {
                    rpt.Bank = cboBankUsed.Text.Trim();
                }

                if (textYear.Text != MULTIPLE_MARKER)
                {
                    rpt.YearQuarter = textYear.Text.Trim();
                }

                if (cboQuarter.Text != MULTIPLE_MARKER)
                {
                    rpt.Quarter = cboQuarter.Text;
                }
                if (textRequestingParty.Text != MULTIPLE_MARKER)
                {
                    rpt.RequestingParty = textRequestingParty.Text;
                }
                if (textRemarks.Text != MULTIPLE_MARKER)
                {
                    rpt.RPTremarks = textRemarks.Text;
                }

                if (rpt.Status == RPTStatus.BILL_SENT && rpt.AmountTransferred != 0)
                {
                    //validateForm();

                    if (Validations.HaveErrors(errorProvider1))
                    {
                        return;
                    }

                    rpt.Status = RPTStatus.PAYMENT_VERIFICATION;
                }

                if (rpt.Status == RPTStatus.PAYMENT_VERIFICATION && rpt.AmountTransferred == 0)
                {
                    UpdateRecordToForAssessment();
                }

                if (rpt.Status == RPTStatus.ASSESSMENT_PRINTED && rpt.AmountTransferred != 0)
                {
                    rpt.Status = RPTStatus.PAYMENT_VERIFICATION;
                }

                if (rpt.Status == RPTStatus.ASSESSMENT_PRINTED && rpt.AmountTransferred == 0)
                {
                    UpdateRecordToForAssessment();
                }

                RPTDatabase.Update(rpt);
            }
            MainForm.INSTANCE.RefreshListView();

            Close();
        }

        //Record will have the status of "FOR ASSESSSMENT" once it has an update in AmountTransferred.
        private void UpdateRecordToForAssessment()
        {
            foreach (var rpt in RptList)
            {
                rpt.Status = RPTStatus.FOR_ASSESSMENT;
                rpt.BillCount = null;
                rpt.BilledBy = null;
                rpt.BilledDate = null;
                rpt.PaymentDate = null;
            }
        }

        //Thousand separator.
        private void textAmountToBePaid_Leave(object sender, EventArgs e)
        {
            if (textAmountToBePaid.Text != MULTIPLE_MARKER)
            {
                double amounttobepaid;
                double.TryParse(textAmountToBePaid.Text, out amounttobepaid);
                textAmountToBePaid.Text = amounttobepaid.ToString("N2");
            }
        }

        //Thousand separator.
        private void textTransferredAmount_Leave(object sender, EventArgs e)
        {
            //if (textTransferredAmount.Text != MULTIPLE_MARKER)
            //{
            //    double TransferredAmount;
            //    double.TryParse(textTransferredAmount.Text, out TransferredAmount);
            //    textTransferredAmount.Text = TransferredAmount.ToString("N2");
            //}
            //CheckUncheckDateOfPayment();
        }

        private void textTransferredAmount_TextChanged(object sender, EventArgs e)
        {
            //CheckUncheckDateOfPayment();
        }

        private void UpdateRPTForm_Load(object sender, EventArgs e)
        {
            CheckUncheckDateOfPayment();
            //cboBankUsed.SelectedIndex = 0;
        }

        /// TEXTFIELDS BEHAVIOR FROM THIS POINT TO END USING KEYPRESS AND CLICK OF TAB OR CLICK IN THE MOUSE. <summary>
        private bool textTaxDecJustEntered = false;
        private void textTaxDec_Enter(object sender, EventArgs e)
        {
            textTaxDec.SelectAll();
            textTaxDecJustEntered = true;
        }

        private void textTaxDec_Click(object sender, EventArgs e)
        {
            if (textTaxDecJustEntered)
            {
                textTaxDec.SelectAll();
            }

            textTaxDecJustEntered = false;
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

        private bool textAmountToBePaidJustEntered = false;
        private void textAmountToBePaid_Enter(object sender, EventArgs e)
        {
            textAmountToBePaid.SelectAll();
            textAmountToBePaidJustEntered = true;
        }

        private void textAmountToBePaid_Click(object sender, EventArgs e)
        {
            if (textAmountToBePaidJustEntered)
            {
                textAmountToBePaid.SelectAll();
            }

            textAmountToBePaidJustEntered = false;
        }

        //private bool textTransferredAmountJustEntered = false;
        private void textTransferredAmount_Enter(object sender, EventArgs e)
        {
            //textTransferredAmount.SelectAll();
            //textTransferredAmountJustEntered = true;
        }

        private void textTransferredAmount_Click(object sender, EventArgs e)
        {
            //if (textTransferredAmountJustEntered)
            //{
            //    textTransferredAmount.SelectAll();
            //}

            //textTransferredAmountJustEntered = false;
        }

        private bool cboBankUsedJustEntered = false;
        private void cboBankUsed_Enter(object sender, EventArgs e)
        {
            cboBankUsed.SelectAll();
            cboBankUsedJustEntered = true;
        }

        private void cboBankUsed_Click(object sender, EventArgs e)
        {
            if (cboBankUsedJustEntered)
            {
                cboBankUsed.SelectAll();
            }

            cboBankUsedJustEntered = false;
        }

        private bool textYearJustEntered = false;
        private void textYear_Enter(object sender, EventArgs e)
        {
            textYear.SelectAll();
            textYearJustEntered = true;
        }

        private void textYear_Click(object sender, EventArgs e)
        {
            if (textYearJustEntered)
            {
                textYear.SelectAll();
            }

            textYearJustEntered = false;
        }

        private bool cboQuarterJustEntered = false;
        private void cboQuarter_Enter(object sender, EventArgs e)
        {
            cboQuarter.SelectAll();
            cboQuarterJustEntered = true;
        }

        private void cboQuarter_Click(object sender, EventArgs e)
        {
            if (cboQuarterJustEntered)
            {
                cboQuarter.SelectAll();
            }

            cboQuarterJustEntered = false;
        }

        private bool dtDateOfPaymentJustEntered = false;
        private void dtDateOfPayment_Enter(object sender, EventArgs e)
        {
            dtDateOfPayment.Select();
            dtDateOfPaymentJustEntered = true;
        }

        private bool cbStatusJustEntered = false;
        private void cbStatus_Enter(object sender, EventArgs e)
        {
            cbStatus.SelectAll();
            cbStatusJustEntered = true;
        }

        private void cbStatus_Click(object sender, EventArgs e)
        {
            if (cbStatusJustEntered)
            {
                cbStatus.SelectAll();
            }

            cbStatusJustEntered = false;
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

        private bool textRemarksJustEntered = false;
        private void textRemarks_Enter(object sender, EventArgs e)
        {
            textRemarks.SelectAll();
            textRemarksJustEntered = true;
        }

        private void textRemarks_Click(object sender, EventArgs e)
        {
            if (textRemarksJustEntered)
            {
                textRemarks.SelectAll();
            }

            textRemarksJustEntered = false;
        }

        //Numeric value and one decimal only.
        private void textAmountToBePaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            //OneDecimalPointOnly(sender, e);
        }

        private void textTransferredAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //OneDecimalPointOnly(sender, e);
        }

        private void textTaxDec_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textTPName_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textAmountToBePaid_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textTransferredAmount_KeyDown(object sender, KeyEventArgs e)
        {
            //EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void cboBankUsed_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textYear_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void dtDateOfPayment_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void cbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textRequestingParty_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void cboQuarter_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textAmountToBePaid_TextChanged(object sender, EventArgs e)
        {
            if (textAmountToBePaid.Text != MULTIPLE_MARKER)
            {
                double amounttobepaid;
                double.TryParse(textAmountToBePaid.Text, out amounttobepaid);
                textAmountToBePaid.Text = amounttobepaid.ToString("N2");
            }
        }
    }
}
