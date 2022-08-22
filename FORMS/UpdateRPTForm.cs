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
        MainForm parentForm;

        List<RealPropertyTax> RptList = new List<RealPropertyTax>();
        private static string MULTIPLE_MARKER = "***";
        private static DateTime MULTIPLE_MARKERDATE = DateTime.Parse ("01/01/1900");

        public UpdateRPTForm(List<long> RptIDList)
        {
            InitializeComponent();
            foreach (var RptId in RptIDList)
            {
                RealPropertyTax rpt = RPTDatabase.Get(RptId);
                RptList.Add(rpt);
            }
            InitializeUpdateRecord();
        }

        public void setParent(MainForm mainForm)
        {
            parentForm = mainForm;
        }

        public void InitializeUpdateRecord()
        {
            Boolean FirstRecord = true;

            foreach (var rpt in RptList)
            {
                if (FirstRecord == true)
                {
                    textTaxDec.Text = rpt.TaxDec;
                    textTPName.Text = rpt.TaxPayerName;
                    textAmountToBePaid.Text = rpt.AmountToPay.ToString();
                    textTransferredAmount.Text = rpt.AmountTransferred.ToString();
                    cboBankUsed.Text = rpt.Bank;
                    textYearQuarter.Text = rpt.YearQuarter;
                    if (rpt.PaymentDate != null)
                    {
                        dtDateOfPayment.Value = rpt.PaymentDate.Value;
                    }
                    cbStatus.Text = rpt.Status;
                    textRequestingParty.Text = rpt.RequestingParty;
                    textRemarks.Text = rpt.RPTremarks;

                    if (rpt.Status == RPTStatus.BILL_SENT)
                    {
                        textTransferredAmount.Text = rpt.AmountToPay.ToString();
                        textTransferredAmount.Focus();
                        textTransferredAmount.Select();
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
                    if (textAmountToBePaid.Text != rpt.AmountToPay.ToString())
                    {
                        textAmountToBePaid.Text = MULTIPLE_MARKER;
                    }
                    if (textTransferredAmount.Text != rpt.AmountTransferred.ToString())
                    {
                        textTransferredAmount.Text = MULTIPLE_MARKER;
                    }
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
                    if (textYearQuarter.Text != rpt.YearQuarter)
                    {
                        textYearQuarter.Text = MULTIPLE_MARKER;
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

        private void CheckUncheckDateOfPayment()
        {
            if (textTransferredAmount.Text != "0.00")
            {
                dtDateOfPayment.Format = DateTimePickerFormat.Custom;
                dtDateOfPayment.CustomFormat = "MM/dd/yyyy";

                dtDateOfPayment.Checked = true;
                dtDateOfPayment.Enabled = true;
                cboBankUsed.Enabled = true;
            }
            else if (textTransferredAmount.Text == "0.00")
            {

                dtDateOfPayment.Format = DateTimePickerFormat.Custom;
                dtDateOfPayment.CustomFormat = " ";
                dtDateOfPayment.Checked = false;
                dtDateOfPayment.Enabled = false;
                cboBankUsed.Enabled = false;
                cboBankUsed.Text = string.Empty;
            }
        }

        private void btnUpdateRecord_Click(object sender, EventArgs e)
        {
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
                //}

                if (textTransferredAmount.Text != MULTIPLE_MARKER)
                {
                    rpt.AmountTransferred = Convert.ToDecimal(textTransferredAmount.Text);
                    rpt.ExcessShortAmount = rpt.AmountToPay - rpt.AmountTransferred;
                }


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
                    rpt.Bank = cboBankUsed.Text;
                }
                if (textYearQuarter.Text != MULTIPLE_MARKER)
                {
                    rpt.YearQuarter = textYearQuarter.Text;
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
            parentForm.RefreshListView();

            Close();
        }

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

        private void textAmountToBePaid_Leave(object sender, EventArgs e)
        {
            if (textAmountToBePaid.Text != MULTIPLE_MARKER)
            {
                double amounttobepaid;
                double.TryParse(textAmountToBePaid.Text, out amounttobepaid);
                textAmountToBePaid.Text = amounttobepaid.ToString("N2");
            }         
        }

        private void textTransferredAmount_Leave(object sender, EventArgs e)
        {
            if (textTransferredAmount.Text != MULTIPLE_MARKER)
            {
                double TransferredAmount;
                double.TryParse(textTransferredAmount.Text, out TransferredAmount);
                textTransferredAmount.Text = TransferredAmount.ToString("N2");
            }

            CheckUncheckDateOfPayment();
        }

        private void textTransferredAmount_TextChanged(object sender, EventArgs e)
        {
            CheckUncheckDateOfPayment();

        }

        private void UpdateRPTForm_Load(object sender, EventArgs e)
        {
            CheckUncheckDateOfPayment();
        }
    }
}
