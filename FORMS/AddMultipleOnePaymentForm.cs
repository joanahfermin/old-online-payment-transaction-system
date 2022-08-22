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
    public partial class AddMultipleOnePaymentForm : Form
    {
        MainForm parentForm;

        public AddMultipleOnePaymentForm()
        {
            InitializeComponent();
            InitializeBank();
        }
        public void setParent(MainForm mainForm)
        {
            parentForm = mainForm;
        }

        public void InitializeBank()
        {
            cboBankUsed.Items.Add(BankUtil.LBP);
            cboBankUsed.Items.Add(BankUtil.METROBANK);
            cboBankUsed.Items.Add(BankUtil.UNIONBANK);
        }

        private void AddMultipleOnePaymentForm_Load(object sender, EventArgs e)
        {
            cboBankUsed.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validateFormSaveToMainLV();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            //Generate a unique reference number based on the current time. 
            string refNo = "R" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
            string Status = RPTStatus.FOR_ASSESSMENT;

            bool FirstRecord = true;
            decimal TotalAmountTransferred = Convert.ToDecimal(textTotalAmountDeposited.Text);

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
                string YearQuarter = item.SubItems[3].Text;
                string Amount2Pay = item.SubItems[2].Text;

                RealPropertyTax rpt = new RealPropertyTax();

                rpt.TaxDec = TaxDec;
                rpt.TaxPayerName = TaxPayerName;
                rpt.AmountToPay = Convert.ToDecimal(Amount2Pay);
                if (FirstRecord)
                {
                    rpt.TotalAmountTransferred = Convert.ToDecimal(textTotalAmountDeposited.Text);
                    rpt.ExcessShortAmount = rpt.TotalAmountTransferred - TotalAmount2Pay;
                }

                if (TotalAmountTransferred >= rpt.AmountToPay)
                {
                    rpt.AmountTransferred = rpt.AmountToPay;
                    TotalAmountTransferred = TotalAmountTransferred - rpt.AmountToPay;
                }
                else
                {
                    rpt.AmountTransferred = TotalAmountTransferred;
                    TotalAmountTransferred = 0;
                }
                rpt.YearQuarter = YearQuarter;
                rpt.Bank = cboBankUsed.Text;

                rpt.PaymentDate = dtDateOfPayment.Value.Date;
                
                rpt.Status = Status;
                rpt.RequestingParty = textRequestingParty.Text;

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

            //if (checkBankUsedRetain.Checked == false)
            //{
            //    textBank.Clear();
            //}

            //if (checkRequestingParty.Checked == false)
            //{
            //    textRequestingParty.Clear();
            //}

            lvMultipleRecord.Clear();

            cboBankUsed.Text = null;
            textRequestingParty.Clear();
            textTotalAmountDeposited.Clear();

            parentForm.RefreshListView();

            this.Close();
        }

        private void validateForm()
        {
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textTDN, "Tax dec. number");
            Validations.ValidateRequired(errorProvider1, textYearQuarter, "Year/Quarter");
        }

        private void validateFormSaveToMainLV()
        {
            errorProvider1.Clear();

            //if (comboBox1.SelectedIndex == -1)//Nothing selected
            //{
            //    MessageBox.Show("You must select a conversion type", "Error");
            //}
            //else
            //{
            //    //Do Magic   
            //}

            //Validations.ValidateRequired(errorProvider1, textBank, "Payment channel");
            Validations.ValidateRequiredBank(errorProvider1, cboBankUsed, "Total amount deposited");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            ListViewItem item = new ListViewItem(textTDN.Text);

            item.SubItems.Add(textTPName.Text);
            item.SubItems.Add(textAmount2Pay.Text);
            item.SubItems.Add(textYearQuarter.Text);
            item.SubItems.Add(textRequestingParty.Text);

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

            //textTDN.Clear();
            //textTPName.Clear();
            textAmount2Pay.Clear();
            textYearQuarter.Clear();
            textRequestingParty.Clear();
            textTDN.Focus();
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

        private void checkBankUsedRetain_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBankUsedRetain.Checked == false)
            //{
            //    textBank.Clear();
            //}
        }

        private void checkRequestingParty_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkRequestingParty.Checked == false)
            //{
            //    textRequestingParty.Clear();
            //}
        }

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

        private void textTotalAmountToPay_TextChanged(object sender, EventArgs e)
        {
            decimal ConvertedTotalAmountToPay = decimal.Parse(textTotalAmountToPay.Text, System.Globalization.NumberStyles.Currency);
            textTotalAmountToPay.Text = ConvertedTotalAmountToPay.ToString("N2");
        }

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

        //TEXTFIELDS BEHAVIOR FROM THIS POINT TO END.  
        //PUT IN ONE CLASS OR VARIABLE.
        private void textAmount2Pay_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textTotalAmountDeposited_KeyPress(object sender, KeyPressEventArgs e)
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

        //END.
    }
}
