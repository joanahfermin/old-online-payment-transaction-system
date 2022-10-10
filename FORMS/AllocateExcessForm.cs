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
    public partial class AllocateExcessForm : Form
    {
        MainForm parentForm;
        long RptId;

        public AllocateExcessForm()
        {
            InitializeComponent();
            parentForm = GlobalVariables.MAINFORM;
        }

        /// <summary>
        /// Retrieves the selected data based on passed RptId from the main form.
        /// </summary>
        public void setRptId(long RptId)
        {
            this.RptId = RptId;
            RealPropertyTax RetrieveRpt = RPTDatabase.Get(RptId);
            textRefNum.Text = RetrieveRpt.RefNum;
            textTDN.Text = RetrieveRpt.TaxDec;
            textAmount2Pay.Text = RetrieveRpt.ExcessShortAmount.ToString();
        }

        /// <summary>
        /// Required fields.
        /// </summary>
        private void validateForm()
        {
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textTDN, "Tax dec. num.");
            Validations.ValidateRequired(errorProvider1, textYearQuarter, "Year/Quarter");
            Validations.ValidateRequired(errorProvider1, textAmount2Pay, "Amount to pay");
        }

        /// <summary>
        /// Updates the ExcessShort to 0 then inserts a new record in the same group(reference number).
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            RealPropertyTax RetrieveRpt = RPTDatabase.Get(RptId);

            decimal ExcessShortAmount = RetrieveRpt.ExcessShortAmount;
            RetrieveRpt.ExcessShortAmount = 0;
            RetrieveRpt.TotalAmountTransferred = RetrieveRpt.TotalAmountTransferred - Convert.ToDecimal(textAmount2Pay.Text);

            RPTDatabase.Update(RetrieveRpt);

            RetrieveRpt.TaxDec = textTDN.Text;
            RetrieveRpt.YearQuarter = textYearQuarter.Text;
            RetrieveRpt.AmountToPay = Convert.ToDecimal(textAmount2Pay.Text);
            RetrieveRpt.AmountTransferred = ExcessShortAmount;
            RetrieveRpt.ExcessShortAmount = ExcessShortAmount - RetrieveRpt.AmountToPay;
            RetrieveRpt.TotalAmountTransferred = Convert.ToDecimal(textAmount2Pay.Text);
            RetrieveRpt.Status = RPTStatus.PAYMENT_VERIFICATION;
            RetrieveRpt.EncodedBy = GlobalVariables.RPTUSER.DisplayName;
            RetrieveRpt.EncodedDate = DateTime.Now;

            RPTDatabase.Insert(RetrieveRpt);

            textYearQuarter.Clear();
            textAmount2Pay.Clear();
            textTDN.Clear();

            parentForm.RefreshListView();

            this.Close();    
        }

        // TEXTFIELDS BEHAVIOR FROM THIS POINT TO END USING KEYPRESS AND CLICK OF TAB OR CLICK IN THE MOUSE.
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

        private bool textAmount2PayJustEntered = false;
        private void textAmount2Pay_Enter(object sender, EventArgs e)
        {
            textAmount2Pay.SelectAll();
            textAmount2PayJustEntered = true;
        }

        private void textAmount2Pay_Click(object sender, EventArgs e)
        {
            if (textAmount2PayJustEntered)
            {
                textAmount2Pay.SelectAll();
            }

            textAmount2PayJustEntered = false;
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

        private void textTDN_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }

        private void textYearQuarter_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }

        private void textAmount2Pay_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }

        //Numeric value and one decimal point only. 
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

        private void textAmount2Pay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OneDecimalPointOnly(sender, e);
        }
    }
}
