using SampleRPT1.Service;
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
        private RPTUser loginUser = SecurityService.getLoginUser();

        long RptId;

        public AllocateExcessForm()
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
            RetrieveRpt.Status = RPTStatus.FOR_ASSESSMENT;
            RetrieveRpt.EncodedBy = loginUser.DisplayName;
            RetrieveRpt.EncodedDate = DateTime.Now;

            RPTDatabase.Insert(RetrieveRpt);

            textYearQuarter.Clear();
            textAmount2Pay.Clear();
            textTDN.Clear();

            MainForm.INSTANCE.RefreshListView();

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
        private void textTDN_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textYearQuarter_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textAmount2Pay_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        //Numeric value and one decimal point only. 
        private void textAmount2Pay_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHelperUtil.OneDecimalPointOnly(sender, e);
        }

        private void AllocateExcessForm_Load(object sender, EventArgs e)
        {
            textYearQuarter.Text = DateTime.Now.Year.ToString();
        }
    }
}
