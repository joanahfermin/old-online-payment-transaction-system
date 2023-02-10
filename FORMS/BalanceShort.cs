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

namespace SampleRPT1.FORMS
{
    public partial class BalanceShort : Form
    {
        long RptId;
        string RPTremarks;
        decimal ComputedTotalAmountTransferred;
        List<RealPropertyTax> RptList = new List<RealPropertyTax>();

        public BalanceShort()
        {
            InitializeComponent();
            InitializeBank();
        }

        /// <summary>
        /// Retrieves the selected data based on passed RptId from the main form.
        /// </summary>
        public void setRptId(long RptId)
        {
            this.RptId = RptId;
            RealPropertyTax RetrieveRpt = RPTDatabase.Get(RptId);
            textRefNum.Text = RetrieveRpt.RefNum;
            RPTremarks = RetrieveRpt.RPTremarks;

            if (RetrieveRpt.ExcessShortAmount < 0)
            {
                decimal test = RetrieveRpt.ExcessShortAmount * (-1);

                textTotalAmountDeposited.Text = Convert.ToDecimal(test).ToString();
            }
            textYearQuarter.Text = RetrieveRpt.YearQuarter;
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

        /// <summary>
        /// Required fields.
        /// </summary>
        private void validateForm()
        {
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textTotalAmountDeposited, " Total amount deposited");
            //Validations.ValidateRequired(errorProvider1, textRefNum, "Reference Num.");
            Validations.ValidateRequiredBank(errorProvider1, cboBankUsed, "Bank");
        }

        /// <summary>
        /// Updates the insufficient payment of record. 
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            RealPropertyTax RetrieveRpt = RPTDatabase.Get(RptId);
            decimal TotalAmountTransferredUser = Convert.ToDecimal(textTotalAmountDeposited.Text);

            //Single record: completion of payment and/or still short of payment. 
            if (RetrieveRpt.RefNum == null)
            {
                RetrieveRpt.ExcessShortAmount += TotalAmountTransferredUser;
                RetrieveRpt.TotalAmountTransferred += TotalAmountTransferredUser;
                RetrieveRpt.AmountTransferred += TotalAmountTransferredUser;

                if (RetrieveRpt.AmountTransferred > RetrieveRpt.AmountToPay)
                {
                    RetrieveRpt.AmountTransferred = RetrieveRpt.AmountToPay;
                }

                if (RetrieveRpt.PaymentDate == null)
                {
                    RetrieveRpt.PaymentDate = dtDateOfPayment.Value.Date;
                }

                RetrieveRpt.Bank = cboBankUsed.Text.Trim();

                RetrieveRpt.Status = RPTStatus.PAYMENT_VERIFICATION;

                RetrieveRpt.RPTremarks = RPTremarks + " " + RetrieveRpt.RPTremarks + " Added payment of " + TotalAmountTransferredUser + " on " + dtDateOfPayment.Value.Date.ToShortDateString() + " using " + RetrieveRpt.Bank + ". ";

                MessageBox.Show("Payment successfully saved.");

                RPTDatabase.Update(RetrieveRpt);

                if (RetrieveRpt.ExcessShortAmount > 0)
                {
                    RetrieveRpt.RefNum = BusinessUtil.GenerateRefNo();
                    RPTDatabase.Update(RetrieveRpt);
                }
            }

            else
            {
                //IF MULITPLE RECORD IS SHORT, UPDATE THE LAST RECORD.
                List<RealPropertyTax> rptList = RPTDatabase.SelectByRefNum(textRefNum.Text);

                bool firstRecord = true;
                bool forVerification = false;

                // ididistribute natin yung pera. Initially, yung bagong pinasok ng user ang natitira nating pera.
                decimal remainingMoney = TotalAmountTransferredUser;

                foreach (RealPropertyTax rpt in rptList)
                {
                    // sa unang record tayo nag uupdate ng excess short and remarks.
                    if (firstRecord)
                    {
                        // Idadagdag lang natin yung binayad ng taxpayer sa excess short and sa remarks.
                        rpt.ExcessShortAmount = rpt.ExcessShortAmount + TotalAmountTransferredUser;
                        rpt.TotalAmountTransferred = rpt.TotalAmountTransferred + TotalAmountTransferredUser;
                        rpt.Bank = cboBankUsed.Text;
                        rpt.RPTremarks = rpt.RPTremarks + " Added payment of " + TotalAmountTransferredUser + " on " + 
                            dtDateOfPayment.Value.Date.ToShortDateString();

                        if (rpt.ExcessShortAmount >= 0)
                        {
                            forVerification = true;
                        }

                        if (forVerification)
                        {
                            rpt.Status = RPTStatus.PAYMENT_VERIFICATION;
                        }

                        RPTDatabase.Update(rpt);
                    }

                    // magkano pa kulang sa specific na RPT na ito.
                    decimal balance = rpt.AmountToPay - rpt.AmountTransferred;
                    if (balance > 0 && remainingMoney > 0) // may kulang na bayad at may pera pa tayo
                    {
                        if (remainingMoney >= balance ) // kasya pa pera natin
                        {
                            // bayaran mo na yung balance
                            rpt.AmountTransferred = rpt.AmountTransferred + balance;
                            remainingMoney = remainingMoney - balance;
                        }
                        else // huhu dina kasya
                        {
                            // edi dagdag mo na lang yung natirang pera na hindi kasya.
                            rpt.AmountTransferred = rpt.AmountTransferred + remainingMoney;
                            remainingMoney = 0;
                        }

                        if (forVerification)
                        {
                            rpt.Status = RPTStatus.PAYMENT_VERIFICATION;
                        }

                        if (rpt.Bank == null || rpt.Bank.Trim().Length == 0)
                        {
                            rpt.Bank = cboBankUsed.Text;
                        }

                        RPTDatabase.Update(rpt);
                    }
                    firstRecord = false;
                }
            }
            MainForm.INSTANCE.RefreshListView();
            this.Close();
        }



        // TEXTFIELDS BEHAVIOR FROM THIS POINT TO END USING KEYPRESS AND CLICK OF TAB OR CLICK IN THE MOUSE.
        /// <summary>
        /// Numeric value and one decimal point only.
        /// </summary>
        private void textAmountTransferred_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHelperUtil.OneDecimalPointOnly(sender, e);
        }

        private bool textAmountTransferredJustEntered = false;
        private void textAmountTransferred_Enter(object sender, EventArgs e)
        {
            textTotalAmountDeposited.SelectAll();
            textAmountTransferredJustEntered = true;
        }

        private void textAmountTransferred_Click(object sender, EventArgs e)
        {
            if (textAmountTransferredJustEntered)
            {
                textTotalAmountDeposited.SelectAll();
            }

            textAmountTransferredJustEntered = false;
        }

        //TEXTFIELDS BEHAVIOR FROM THIS POINT TO END USING KEYPRESS ENTER.
        private void textAmountTransferred_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textRefNum_TextChanged(object sender, EventArgs e)
        {
            if (textRefNum.Text.Length > 0)
            {
                labelBank.Visible = true;
                cboBankUsed.Visible = true;
            }
        }
    }
}
