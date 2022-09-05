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

        public void setRptId(long RptId)
        {
            this.RptId = RptId;
            RealPropertyTax RetrieveRpt = RPTDatabase.Get(RptId);
            textRefNum.Text = RetrieveRpt.RefNum;
            textTDN.Text = RetrieveRpt.TaxDec;
            textAmount2Pay.Text = RetrieveRpt.ExcessShortAmount.ToString();
        }

        private void validateForm()
        {
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textTDN, "Tax dec. num.");
            Validations.ValidateRequired(errorProvider1, textYearQuarter, "Year/Quarter");
            Validations.ValidateRequired(errorProvider1, textAmount2Pay, "Amount to pay");
        }

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

            RPTDatabase.Update(RetrieveRpt);

            RetrieveRpt.TaxDec = textTDN.Text;
            RetrieveRpt.YearQuarter = textYearQuarter.Text;
            RetrieveRpt.AmountToPay = Convert.ToDecimal(textAmount2Pay.Text);
            RetrieveRpt.AmountTransferred = ExcessShortAmount;
            RetrieveRpt.ExcessShortAmount = ExcessShortAmount - RetrieveRpt.AmountToPay;
            //RetrieveRpt.TotalAmountTransferred = RetrieveRpt.AmountTransferred;
            RetrieveRpt.TotalAmountTransferred = 0;
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
    }
}
