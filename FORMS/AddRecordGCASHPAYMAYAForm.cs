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
    public partial class AddRecordGCASHPAYMAYAForm : Form
    {
        MainForm parentForm;
        public AddRecordGCASHPAYMAYAForm()
        {
            InitializeComponent();
            //This is essential to the FirstLVGcashPaymaya_KeyDown method.
            FirstLVGcashPaymaya.KeyUp += FirstLVGcashPaymaya_KeyDown;

            parentForm = GlobalVariables.MAINFORM;
        }

        //Copy from GCASH and PAYMAYA excel to form's listview by keypress. 
        private void FirstLVGcashPaymaya_KeyDown(object sender, KeyEventArgs e)
        {
            List<int> IgnoredColumnList = new List<int>();
            IgnoredColumnList.Add(4);
            IgnoredColumnList.Add(6);
            IgnoredColumnList.Add(7);
            IgnoredColumnList.Add(8);

            if (e.KeyData == (Keys.V | Keys.Control))
            {
                string dataAsString = Clipboard.GetText();
                string[] rowArray = dataAsString.Split(new Char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (rowArray.Length > 0)
                {
                    FirstLVGcashPaymaya.Items.Clear();

                    foreach (string row in rowArray)
                    {
                        string[] columnArray = row.Split(new char[] { '\t' });
                        
                            ListViewItem item = new ListViewItem();
                            bool firstColumn = true;
                            int ColumnIndex = 0;

                            foreach (string column in columnArray)
                            {
                                ColumnIndex++;
                                if (firstColumn)
                                {
                                    item.Text = column;
                                    firstColumn = false;
                                }
                                else
                                {
                                    if (!IgnoredColumnList.Contains(ColumnIndex))
                                    {
                                        item.SubItems.Add(column);
                                    }
                                }
                            }
                            FirstLVGcashPaymaya.Items.Add(item);
                    }
                }
                PopulateExistingColumn();
            }
        }

        private void PopulateExistingColumn()
        {
            List<string> ProcessedList = new List<string>();

            for (int i = 0; i < FirstLVGcashPaymaya.Items.Count; i++)
            {
                ListViewItem item = FirstLVGcashPaymaya.Items[i];
                string TaxDec = item.SubItems[1].Text;
                string YearQuarter = item.SubItems[2].Text;

                RealPropertyTax rpt = RPTDatabase.SelectByTaxDecAndYear(TaxDec, YearQuarter);

                if (rpt != null)
                {
                    item.SubItems.Add("YES");
                }
                else
                {
                    item.SubItems.Add("NO");
                }

                string TaxDecAndYearQuarter = TaxDec + YearQuarter;

                if (ProcessedList.Contains(TaxDecAndYearQuarter))
                {
                    item.SubItems.Add("YES");
                }
                else
                {
                    item.SubItems.Add("NO");

                }
                ProcessedList.Add(TaxDecAndYearQuarter);
            }
        }

        private string SearchExistingTaxpayerName(string TaxDec)
        {
            string TaxPayerName = "";

            List<RealPropertyTax> rptList = RPTDatabase.SelectByTaxDec(TaxDec);

            foreach (var ExistingRPT in rptList)
            {
                if (ExistingRPT.TaxPayerName.Length > 0)
                {
                    TaxPayerName = ExistingRPT.TaxPayerName;
                }
            }
            return TaxPayerName;
        }

        private void PopulateRPTID()
        {
            RealPropertyTax rpt = RPTDatabase.SelectByTaxDecAndYear(textTaxDec.Text, textYearQuarter.Text);
            if (rpt != null)
            {
                textRPTID.Text = rpt.RptID.ToString();
                textPropertyName.Text = rpt.TaxPayerName;
            }
            else
            {
                textRPTID.Text = "";
                textPropertyName.Text = "";

                textPropertyName.Text = SearchExistingTaxpayerName(textTaxDec.Text);
            }
        }

        private void FirstLVGcashPaymaya_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FirstLVGcashPaymaya.SelectedItems.Count > 0)
            {
                textServiceProvider.Text = FirstLVGcashPaymaya.SelectedItems[0].Text;
                textTaxDec.Text = FirstLVGcashPaymaya.SelectedItems[0].SubItems[1].Text;
                textYearQuarter.Text = FirstLVGcashPaymaya.SelectedItems[0].SubItems[2].Text;
                textEmailAddress.Text = FirstLVGcashPaymaya.SelectedItems[0].SubItems[3].Text;
                textAmountDue.Text = FirstLVGcashPaymaya.SelectedItems[0].SubItems[4].Text;
                textTransactionDate.Text = FirstLVGcashPaymaya.SelectedItems[0].SubItems[5].Text;

                textYearQuarter.SelectAll();

                PopulateRPTID();

                RefreshMainListviewTaxDec();
            }
        }

        private void FirstLVGcashPaymaya_MouseClick(object sender, MouseEventArgs e)
        {
            textYearQuarter.Focus();
        }

        private void textYearQuarter_TextChanged(object sender, EventArgs e)
        {
            PopulateRPTID();
        }

        private void RefreshMainListviewTaxDec()
        {
            parentForm.textTDN.Text = textTaxDec.Text;
            parentForm.btnSearch_Click(null, null);
        }

        private void RefreshMainListviewStatus()
        {
            parentForm.SearchPaymentVerification();
        }

        private void validateForm()
        {
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textYearQuarter, "Year/Quarter");
            Validations.ValidateRequired(errorProvider1, textBillQuantity, "Bill quantity");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (textRPTID.Text.Length > 0)
                {
                    long RPTid = Convert.ToInt64(textRPTID.Text);
                    string DuplicateRecordRemarks = "DUPLICATE RECORD";

                    RealPropertyTax RetrievedRpt = RPTDatabase.Get(RPTid);

                    RetrievedRpt.TaxPayerName = textPropertyName.Text.Trim();
                    RetrievedRpt.AmountToPay = Convert.ToDecimal(textAmountDue.Text);
                    //RetrievedRpt.PaymentDate = DateTime.Parse(textTransactionDate.Text).Date;
                    RetrievedRpt.AmountTransferred = Convert.ToDecimal(textAmountDue.Text);
                    RetrievedRpt.Bank = textServiceProvider.Text;
                    RetrievedRpt.BillCount = textBillQuantity.Text.Trim();
                    RetrievedRpt.Status = RPTStatus.PAYMENT_VERIFICATION;

                    RetrievedRpt.BilledBy = GlobalVariables.RPTUSER.DisplayName;
                    RetrievedRpt.BilledDate = DateTime.Now;
                    RetrievedRpt.RPTremarks = DuplicateRecordRemarks;
                    RetrievedRpt.YearQuarter = RetrievedRpt.YearQuarter + " (" + DateTime.Now.ToString("MM/dd/yyyy-HH:mm:ss") + ")".Trim();

                    RPTDatabase.Insert(RetrievedRpt);
                }
                else
                {
                    RealPropertyTax rpt = new RealPropertyTax();

                    rpt.TaxDec = textTaxDec.Text;
                    rpt.TaxPayerName = textPropertyName.Text.Trim();
                    rpt.AmountToPay = Convert.ToDecimal(textAmountDue.Text);
                    //rpt.PaymentDate = DateTime.Parse(textTransactionDate.Text).Date;
                    rpt.AmountTransferred = Convert.ToDecimal(textAmountDue.Text);
                    rpt.Bank = textServiceProvider.Text;
                    rpt.YearQuarter = textYearQuarter.Text.Trim();
                    rpt.BillCount = textBillQuantity.Text.Trim();
                    rpt.Status = RPTStatus.PAYMENT_VERIFICATION;
                    rpt.RequestingParty = textEmailAddress.Text;

                    rpt.EncodedBy = GlobalVariables.RPTUSER.DisplayName;
                    rpt.EncodedDate = DateTime.Now;

                    rpt.BilledBy = GlobalVariables.RPTUSER.DisplayName;
                    rpt.BilledDate = DateTime.Now;

                    RPTDatabase.Insert(rpt);
                }

                RefreshMainListviewTaxDec();

                if (FirstLVGcashPaymaya.SelectedItems.Count > 0)
                {
                    int Index = FirstLVGcashPaymaya.SelectedIndices[0];
                    FirstLVGcashPaymaya.Items.RemoveAt(Index);
                }
            } 
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            string DuplicateRecordRemarks = "DUPLICATE RECORD";

            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            if (FirstLVGcashPaymaya.SelectedItems.Count > 0)
            {
                for (int i = 0; i < FirstLVGcashPaymaya.SelectedItems.Count; i++)
                {
                    string ServiceProvider = FirstLVGcashPaymaya.SelectedItems[i].Text;
                    string TaxDec = FirstLVGcashPaymaya.SelectedItems[i].SubItems[1].Text;
                    string YearQuarter = FirstLVGcashPaymaya.SelectedItems[i].SubItems[2].Text;
                    string RequestingParty = FirstLVGcashPaymaya.SelectedItems[i].SubItems[3].Text;
                    decimal AmountDue = Convert.ToDecimal(FirstLVGcashPaymaya.SelectedItems[i].SubItems[4].Text);
                    string TransactionDate = FirstLVGcashPaymaya.SelectedItems[i].SubItems[5].Text;

                    RealPropertyTax RetrievedRpt = RPTDatabase.SelectByTaxDecAndYear(TaxDec, YearQuarter);

                    if (RetrievedRpt != null)
                    {
                        RetrievedRpt.AmountToPay = AmountDue;
                        //RetrievedRpt.PaymentDate = DateTime.Parse(TransactionDate).Date;
                        RetrievedRpt.AmountTransferred = AmountDue;
                        RetrievedRpt.Bank = ServiceProvider;
                        RetrievedRpt.BillCount = textBillQuantity.Text;
                        RetrievedRpt.Status = RPTStatus.PAYMENT_VERIFICATION;

                        RetrievedRpt.BilledBy = GlobalVariables.RPTUSER.DisplayName;
                        RetrievedRpt.BilledDate = DateTime.Now;
                        RetrievedRpt.RPTremarks = DuplicateRecordRemarks;
                        RetrievedRpt.YearQuarter = RetrievedRpt.YearQuarter + " (" + DateTime.Now.ToString("MM/dd/yyyy-HH:mm:ss") + ")";

                        RPTDatabase.Insert(RetrievedRpt);
                    }
                    else
                    {
                        RealPropertyTax rpt = new RealPropertyTax();

                        rpt.TaxDec = TaxDec;
                        rpt.TaxPayerName = SearchExistingTaxpayerName(TaxDec);
                        rpt.AmountToPay = AmountDue;
                        rpt.AmountTransferred = AmountDue;
                        //rpt.PaymentDate = DateTime.Parse(TransactionDate).Date;
                        rpt.Bank = ServiceProvider;
                        rpt.YearQuarter = YearQuarter;
                        rpt.BillCount = textBillQuantity.Text;
                        rpt.Status = RPTStatus.PAYMENT_VERIFICATION;
                        rpt.RequestingParty = textEmailAddress.Text;

                        rpt.EncodedBy = GlobalVariables.RPTUSER.DisplayName;
                        rpt.EncodedDate = DateTime.Now;

                        rpt.BilledBy = GlobalVariables.RPTUSER.DisplayName;
                        rpt.BilledDate = DateTime.Now;

                        RPTDatabase.Insert(rpt);
                    }
                }

                for (int i = FirstLVGcashPaymaya.SelectedItems.Count - 1; i >= 0; i--)
                {
                    int Index = FirstLVGcashPaymaya.SelectedIndices[i];
                    FirstLVGcashPaymaya.Items.RemoveAt(Index);
                }
                RefreshMainListviewStatus();
            }
        }
    }
} 