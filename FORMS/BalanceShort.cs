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

        public void setRptId(long RptId)
        {
            this.RptId = RptId;
            RealPropertyTax RetrieveRpt = RPTDatabase.Get(RptId);
            textRefNum.Text = RetrieveRpt.RefNum;
        }

        private void validateForm()
        {
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textAmountTransferred, "Amount Transferred");
            Validations.ValidateRequired(errorProvider1, textRefNum, "Reference Num.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            RealPropertyTax RetrieveRpt = RPTDatabase.Get(RptId);

            decimal AmountTransferred = Convert.ToDecimal(textAmountTransferred.Text);

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
    }
}
