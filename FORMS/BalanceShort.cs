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
        }

        /// <summary>
        /// Retrieves the selected data based on passed RptId from the main form.
        /// </summary>
        public void setRptId(long RptId)
        {
            this.RptId = RptId;
            RealPropertyTax RetrieveRpt = RPTDatabase.Get(RptId);
            textRefNum.Text = RetrieveRpt.RefNum;
        }

        /// <summary>
        /// Required fields.
        /// </summary>
        private void validateForm()
        {
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textAmountTransferred, "Amount Transferred");
            Validations.ValidateRequired(errorProvider1, textRefNum, "Reference Num.");
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

            decimal AmountTransferred = Convert.ToDecimal(textAmountTransferred.Text);

            //If user inputs short payment, system will not accept. 
            if (RetrieveRpt.ExcessShortAmount + AmountTransferred < 0)
            {
                MessageBox.Show("Amount transferred does not cover the short/excess amount.");
                return;
            }

            RetrieveRpt.ExcessShortAmount = 0;

            RPTDatabase.Update(RetrieveRpt);

            List<RealPropertyTax> rptList = RPTDatabase.SelectByRefNum(textRefNum.Text);

            //IF SINGLE RECORD IS SHORT, UPDATE THE SINGLE RECORD.
            if (rptList.Count == 1)
            {
                RetrieveRpt.ExcessShortAmount = RetrieveRpt.AmountTransferred + AmountTransferred - RetrieveRpt.AmountToPay;

                RetrieveRpt.AmountTransferred = RetrieveRpt.AmountToPay;
                RetrieveRpt.TotalAmountTransferred = RetrieveRpt.TotalAmountTransferred + AmountTransferred;

                if (RetrieveRpt.PaymentDate == null)
                {
                    RetrieveRpt.PaymentDate = dtDateOfPayment.Value.Date;
                }

                RetrieveRpt.RPTremarks = RetrieveRpt.RPTremarks + "Added payment of " + AmountTransferred + " on " + dtDateOfPayment.Value.Date.ToShortDateString();

                RPTDatabase.Update(RetrieveRpt);
            }

            //IF MULITPLE RECORD IS SHORT, UPDATE THE LAST RECORD.
            foreach (RealPropertyTax rpt in rptList)
            {
                if (rpt.AmountTransferred < rpt.AmountToPay && rpt.RptID != RetrieveRpt.RptID)
                {
                    //EXCESS AMOUNT = PREVIOUS PAYMENT + CURRENT PAYMENT - AMOUNT TO PAY.
                    rpt.ExcessShortAmount = rpt.AmountTransferred + AmountTransferred - rpt.AmountToPay;

                    rpt.AmountTransferred = rpt.AmountToPay;
                    rpt.TotalAmountTransferred = AmountTransferred;

                    if (rpt.PaymentDate == null)
                    {
                        rpt.PaymentDate = dtDateOfPayment.Value.Date;
                    }

                    rpt.RPTremarks = rpt.RPTremarks + "Added payment of " + AmountTransferred + " on " + dtDateOfPayment.Value.Date.ToShortDateString();

                    RPTDatabase.Update(rpt);
                    break;
                }
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
            textAmountTransferred.SelectAll();
            textAmountTransferredJustEntered = true;
        }

        private void textAmountTransferred_Click(object sender, EventArgs e)
        {
            if (textAmountTransferredJustEntered)
            {
                textAmountTransferred.SelectAll();
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
    }
}
