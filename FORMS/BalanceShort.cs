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

                RetrieveRpt.Bank = cboBankUsed.Text;

                RetrieveRpt.Status = RPTStatus.PAYMENT_VERIFICATION;

                RetrieveRpt.RPTremarks = RetrieveRpt.RPTremarks + " Added payment of " + TotalAmountTransferredUser + " on " + dtDateOfPayment.Value.Date.ToShortDateString() + " using " + RetrieveRpt.Bank + ". ";
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
                // ididistribute natin yung pera. Initially, yung bagong pinasok ng user ang natitira nating pera.
                decimal remainingMoney = TotalAmountTransferredUser;

                foreach (RealPropertyTax rpt in rptList)
                {
                    // sa unang record tayo nag uupdate ng excess short and remarks.
                    if (firstRecord)
                    {
                        // Idadagdag lang natin yung binayad ng taxpayer sa excess short and sa remarks.
                        rpt.ExcessShortAmount = rpt.ExcessShortAmount + TotalAmountTransferredUser;
                        rpt.RPTremarks = rpt.RPTremarks + " Added payment of " + TotalAmountTransferredUser + " on " + dtDateOfPayment.Value.Date.ToShortDateString();
                    }

                    // magkano pa kulang sa specific na RPT na ito.
                    decimal balance = rpt.AmountToPay - rpt.AmountTransferred;
                    if (balance > 0 && remainingMoney >0) // may kulang na bayad at may pera pa tayo
                    {
                        if (remainingMoney >= balance ) // kasya pa pera natin
                        {
                            // bayaran mo na yung balance
                            rpt.AmountTransferred = rpt.AmountTransferred + balance;
                        }
                        else // huhu dina kasya
                        {
                            // edi dagdag mo na lang yung natirang pera na hindi kasya.
                            rpt.AmountTransferred = rpt.AmountTransferred + remainingMoney;
                        }
                    }
                    RPTDatabase.Update(rpt);
                    firstRecord = false;
                }


                /*
                foreach (RealPropertyTax rpt in rptList)
                {
                    if (firstRecord)
                    {
                        if (rpt.TotalAmountTransferred == 0 && rpt.RptID == RetrieveRpt.RptID)
                        {
                            //EXCESS AMOUNT = PREVIOUS PAYMENT + CURRENT PAYMENT - AMOUNT TO PAY.
                            rpt.ExcessShortAmount = rpt.AmountTransferred + rpt.AmountToPay - TotalAmountTransferredUser;

                            rpt.AmountTransferred = rpt.AmountToPay;
                            rpt.TotalAmountTransferred = TotalAmountTransferredUser;

                            if (rpt.PaymentDate == null)
                            {
                                rpt.PaymentDate = dtDateOfPayment.Value.Date;
                            }

                            RPTDatabase.Update(rpt);
                        }
                        firstRecord = false;

                        /////////////////////////////
                        if (rpt.AmountTransferred < rpt.AmountToPay && rpt.RptID != RetrieveRpt.RptID)
                        {
                            //EXCESS AMOUNT = PREVIOUS PAYMENT + CURRENT PAYMENT - AMOUNT TO PAY.
                            rpt.ExcessShortAmount = rpt.AmountTransferred + TotalAmountTransferredUser - rpt.AmountToPay;

                            rpt.AmountTransferred = rpt.AmountToPay;
                            rpt.TotalAmountTransferred = TotalAmountTransferredUser;

                            if (rpt.PaymentDate == null)
                            {
                                rpt.PaymentDate = dtDateOfPayment.Value.Date;
                            }

                            rpt.RPTremarks = rpt.RPTremarks + "Added payment of " + TotalAmountTransferredUser + " on " + dtDateOfPayment.Value.Date.ToShortDateString();

                            RPTDatabase.Update(rpt);
                            break;
                        }
                    }
                }
                */
            }
            GlobalVariables.MAINFORM.RefreshListView();
            this.Close();
        }

        /// <summary>
        /// Numeric value and one decimal point only.
        /// </summary>
        private void OneDecimalPointOnly(object sender, KeyPressEventArgs e)
        {
            //numeric value only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        // TEXTFIELDS BEHAVIOR FROM THIS POINT TO END USING KEYPRESS AND CLICK OF TAB OR CLICK IN THE MOUSE.
        private void textAmountTransferred_KeyPress(object sender, KeyPressEventArgs e)
        {
            OneDecimalPointOnly(sender, e);
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
        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void textAmountTransferred_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
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
