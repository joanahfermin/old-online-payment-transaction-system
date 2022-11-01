using SampleRPT1.MODEL;
using SampleRPT1.UTILITIES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1
{
    public partial class AddMultipleOnePaymentForm : Form
    {
        MainForm parentForm;

        public AddMultipleOnePaymentForm()
        {
            InitializeComponent();
            InitializeBank();
            InitializeQuarter();
        }
        public void setParent(MainForm mainForm)
        {
            parentForm = mainForm;
        }

        /// <summary>
        /// Initializes Banks.
        /// </summary>
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

        /// <summary>
        /// Auto-suggests word encoded by the user in the bank combobox.
        /// </summary>
        private void AddMultipleOnePaymentForm_Load(object sender, EventArgs e)
        {
            cboBankUsed.SelectedIndex = 0;

            cboBankUsed.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboBankUsed.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        /// <summary>
        /// Auto-suggested word will be diplayed in the bank combobox.
        /// </summary>
        private void cboBankUsed_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboBankUsed.DroppedDown = false;
        }

        /// <summary>
        /// Insert record in the form's listview. 
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            ListViewItem item = new ListViewItem(textTDN.Text.ToString());

            item.SubItems.Add(textTPName.Text.Trim());
            item.SubItems.Add(textAmount2Pay.Text.Trim());
            item.SubItems.Add(textYearQuarter.Text.Trim());
            item.SubItems.Add(cboQuarter.Text.Trim());
            item.SubItems.Add(textRequestingParty.Text.Trim());

            lvMultipleRecord.Items.Add(item);

            if (checkTaxDecRetain.Checked == false)
            {
                textTDN.Clear();
            }

            if (checkTaxNameRetain.Checked == false)
            {
                textTPName.Clear();
            }

            decimal TotalAmountToPay = 0;

            foreach (ListViewItem Record in lvMultipleRecord.Items)
            {
                TotalAmountToPay += decimal.Parse(Record.SubItems[2].Text);
            }

            textTotalAmountToPay.Text = Convert.ToString(TotalAmountToPay);

            decimal ConvertedTotalAmountToPay = decimal.Parse(textTotalAmountToPay.Text, System.Globalization.NumberStyles.Currency);
            textTotalAmountToPay.Text = ConvertedTotalAmountToPay.ToString("N2");

            textAmount2Pay.Clear();
            textYearQuarter.Clear();
            textRequestingParty.Clear();
            textTDN.Focus();
        }

        /// <summary>
        /// Saves the whole list in the main listview. 
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            validateFormSaveToMainLV();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            //Generate a unique reference number based on the current time. 
            string refNo = BusinessUtil.GenerateRefNo();
            string Status = RPTStatus.FOR_ASSESSMENT;

            bool FirstRecord = true;
            decimal TotalAmountDeposited = Convert.ToDecimal(textTotalAmountDeposited.Text);

            decimal TotalAmount2Pay = 0;
            foreach (ListViewItem item in lvMultipleRecord.Items)
            {
                string Amount2Pay = item.SubItems[2].Text;
                TotalAmount2Pay = TotalAmount2Pay + Convert.ToDecimal(Amount2Pay);
            }

            foreach (ListViewItem item in lvMultipleRecord.Items)
            {
                string TaxDec = item.Text;
                string TaxPayerName = item.SubItems[1].Text;
                
                string Amount2Pay = item.SubItems[2].Text;
                string YearQuarter = item.SubItems[3].Text;
                string Quarter = item.SubItems[4].Text;

                RealPropertyTax rpt = new RealPropertyTax();

                rpt.TaxDec = TaxDec;
                rpt.TaxPayerName = TaxPayerName;
                rpt.AmountToPay = Convert.ToDecimal(Amount2Pay);
                rpt.Quarter = Quarter;

                //Babayarn ko total of 100, deposit ako 150... 100 - 150, 50 para sa ExcessShortAmount.
                if (FirstRecord)
                {
                    rpt.TotalAmountTransferred = Convert.ToDecimal(textTotalAmountDeposited.Text);
                    rpt.ExcessShortAmount = rpt.TotalAmountTransferred - TotalAmount2Pay;
                }

                //first record: amount to pay = 50.
                // 150 > 50, so AmountTransferred = 50.
                if (TotalAmountDeposited >= rpt.AmountToPay)
                {
                    rpt.AmountTransferred = rpt.AmountToPay;
                    //150 - 50 = 100. Balik ulit hanggang meron pang excess.
                    TotalAmountDeposited = TotalAmountDeposited - rpt.AmountToPay;
                }
                else
                {
                    rpt.AmountTransferred = TotalAmountDeposited;
                    TotalAmountDeposited = 0;
                }
                rpt.YearQuarter = YearQuarter;
                rpt.Bank = cboBankUsed.Text.Trim();

                rpt.PaymentDate = dtDateOfPayment.Value.Date;
                
                rpt.Status = Status;
                rpt.RequestingParty = textRequestingParty.Text.Trim();

                rpt.EncodedBy = GlobalVariables.RPTUSER.DisplayName;
                rpt.EncodedDate = DateTime.Now;
                rpt.RefNum = refNo;

                RPTDatabase.Insert(rpt);

                FirstRecord = false;
            }

            if (textTotalAmountToPay.Text != textTotalAmountDeposited.Text)
            {
                MessageBox.Show("Please be advised that the record/s have insufficient or excess payment.");
            }

            lvMultipleRecord.Clear();

            cboBankUsed.Text = null;
            textRequestingParty.Clear();
            textTotalAmountDeposited.Clear();

            parentForm.RefreshListView();
            this.Close();
        }

        /// <summary>
        /// Required fields.
        /// </summary>
        private void validateForm()
        {
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textTDN, "Tax dec. number");
            Validations.ValidateRequired(errorProvider1, textYearQuarter, "Year/Quarter");
        }

        /// <summary>
        /// Required fields.
        /// </summary>
        private void validateFormSaveToMainLV()
        {
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textTotalAmountDeposited, "Total Amount Deposited");
            //Validations.ValidateRequiredBank(errorProvider1, cboBankUsed, "Bank");
        }

        private void checkTaxDecRetain_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTaxDecRetain.Checked == false)
            {
                textTDN.Clear();
            }
        }

        private void checkTaxNameRetain_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTaxNameRetain.Checked == false)
            {
                textTPName.Clear();
            }
        }

        /// <summary>
        /// Adding payments.
        /// </summary>
        private void lvMultipleRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal TotalAmountToPay = 0;

            for (int i = 0; i < lvMultipleRecord.SelectedItems.Count; i++)
            {
                decimal AmountToPay = Convert.ToDecimal(lvMultipleRecord.SelectedItems[i].SubItems[2].Text);
                TotalAmountToPay = AmountToPay + TotalAmountToPay;
            }

            textTotalAmountToPay.Text = TotalAmountToPay.ToString();
        }

        //Thousand separator.
        private void textTotalAmountToPay_TextChanged(object sender, EventArgs e)
        {
            decimal ConvertedTotalAmountToPay = decimal.Parse(textTotalAmountToPay.Text, System.Globalization.NumberStyles.Currency);
            textTotalAmountToPay.Text = ConvertedTotalAmountToPay.ToString("N2");
        }

        //Thousand separator.
        private void textTotalAmountDeposited_Leave(object sender, EventArgs e)
        {
            double TotalAmountDeposited;
            double.TryParse(textTotalAmountDeposited.Text, out TotalAmountDeposited);
            textTotalAmountDeposited.Text = TotalAmountDeposited.ToString("N2");
        }

        private void textAmount2Pay_Leave(object sender, EventArgs e)
        {
            double amounttobepaid;
            double.TryParse(textAmount2Pay.Text, out amounttobepaid);
            textAmount2Pay.Text = amounttobepaid.ToString("N2");
        }

        /// <summary>
        /// TEXTFIELDS BEHAVIOR FROM THIS POINT TO END.  

        //Numeric behavior of payment. Only one decimal point allowed.
        private void textAmount2Pay_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHelperUtil.OneDecimalPointOnly(sender, e);
        }

        //Numeric behavior of payment. Only one decimal point allowed.
        private void textTotalAmountDeposited_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHelperUtil.OneDecimalPointOnly(sender, e);
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
                textAmount2Pay.SelectAll();
            }

            textTDNJustEntered = false;
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

        private bool textTotalAmountDepositedJustEntered = false;
        private void textTotalAmountDeposited_Enter(object sender, EventArgs e)
        {
            textTotalAmountDeposited.SelectAll();
            textTotalAmountDepositedJustEntered = true;
        }
        private void textTotalAmountDeposited_Click(object sender, EventArgs e)
        {
            if (textTotalAmountDepositedJustEntered)
            {
                textTotalAmountDeposited.SelectAll();
            }
            textTotalAmountDepositedJustEntered = false;
        }

        //TEXTFIELDS BEHAVIOR FROM THIS POINT TO END USING KEYPRESS ENTER.

        private void textTDN_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textTPName_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textAmount2Pay_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textYearQuarter_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void cboBankUsed_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void dtDateOfPayment_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textRequestingParty_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textTotalAmountDeposited_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }
    }
}
