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
    public partial class AddRPTForm : Form
    {
        MainForm parentForm;
        public AddRPTForm()
        {
            InitializeComponent();
            InitializeBank();
        }
        public void InitializeBank()
        {
            cboBankUsed.Items.Add(BankUtil.LBP);
            cboBankUsed.Items.Add(BankUtil.METROBANK);
            cboBankUsed.Items.Add(BankUtil.UNIONBANK);
        }

        public void setParent(MainForm mainForm)
        {
            parentForm = mainForm;
        }

        /// <summary>
        /// Auto-suggests the word being typed in the bank combobox.
        /// </summary>
        private void AddRPTForm_Load(object sender, EventArgs e)
        {
            CheckUncheckDateOfPayment();
            cboBankUsed.SelectedIndex = 0;
            cboBankUsed.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboBankUsed.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        /// <summary>
        /// Auto-suggested word being displayed in the bank combobox.
        /// </summary>
        private void cboBankUsed_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboBankUsed.DroppedDown = false;
        }

        /// <summary>
        /// Saves the record.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            RealPropertyTax rpt = new RealPropertyTax();

            rpt.TaxDec = textTaxDec.Text.Trim();
            rpt.TaxPayerName = textTPName.Text.Trim();
            rpt.AmountToPay = Convert.ToDecimal(textAmountToBePaid.Text);

            rpt.TotalAmountTransferred = Convert.ToDecimal(textTotalTransferredAmount.Text);

            if (rpt.TotalAmountTransferred >= rpt.AmountToPay)
            {
                rpt.AmountTransferred = rpt.AmountToPay;
            }
            else
            {
                rpt.AmountTransferred = rpt.TotalAmountTransferred;
            }

            //rpt.AmountTransferred = Convert.ToDecimal(textTotalTransferredAmount.Text);
            //rpt.TotalAmountTransferred = rpt.AmountTransferred;
            rpt.ExcessShortAmount = rpt.TotalAmountTransferred - rpt.AmountToPay;

            rpt.Bank = cboBankUsed.Text;
            if (dtDateOfPayment.Enabled)
            {
                rpt.PaymentDate = dtDateOfPayment.Value.Date;
            }
            rpt.YearQuarter = textYearQuarter.Text.Trim();
            rpt.Status = textStatForAssessment.Text;
            rpt.RequestingParty = textRequestingParty.Text.Trim();
            rpt.RPTremarks = textRemarks.Text.Trim();

            rpt.EncodedBy = GlobalVariables.RPTUSER.DisplayName;
            rpt.EncodedDate = DateTime.Now;

            //If payment is exceeds the amount to pay, generate a reference number. 
            if (rpt.AmountToPay < rpt.TotalAmountTransferred)
            {
                string refNo = "R" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
                rpt.RefNum = refNo;
            }

            //If payment is short, generate a reference number. 
            if (rpt.TotalAmountTransferred < rpt.AmountToPay && rpt.TotalAmountTransferred != 0)
            {
                string refNo = "R" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
                rpt.RefNum = refNo;
            }

            RPTDatabase.Insert(rpt);

            if (checkTaxDecRetain.Checked == false)
            {
                textTaxDec.Clear();
            }

            if (checkTaxNameRetain.Checked == false)
            {
                textTPName.Clear();
            }

            if (checkBankUsedRetain.Checked == false)
            {
                cboBankUsed.Text = null;
            }

            if (checkRequestingParty.Checked == false)
            {
                textRequestingParty.Clear();
            }

            textAmountToBePaid.Text = "0.00";
            textTotalTransferredAmount.Text = "0.00";
            textYearQuarter.Clear();
            textRemarks.Clear();

            MessageBox.Show("Record successfully saved.");

            CheckUncheckDateOfPayment();

            parentForm.SearchForAssessment();
        }

        /// <summary>
        /// Required textfields. 
        /// </summary>
        private void validateForm()
        {
            // clear muna natin lahat ng error from previous validation.
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textTaxDec, "Tax Dec. Number");
            Validations.ValidateRequired(errorProvider1, textYearQuarter, "Year/Quarter");
        }

        //Thousand separator.
        private void textAmountToBePaid_Leave(object sender, EventArgs e)
        {
            double amounttobepaid;
            double.TryParse(textAmountToBePaid.Text, out amounttobepaid);
            textAmountToBePaid.Text = amounttobepaid.ToString("N2");
        }

        /// <summary>
        /// Date of Payment will be dependent if the user encodes the total transferred amount.
        /// </summary>
        private void CheckUncheckDateOfPayment()
        {
            if (textTotalTransferredAmount.Text != "0.00")
            {
                dtDateOfPayment.Format = DateTimePickerFormat.Custom;
                dtDateOfPayment.CustomFormat = "MM/dd/yyyy";

                dtDateOfPayment.Checked = true;
                dtDateOfPayment.Enabled = true;
                cboBankUsed.Enabled = true;
                checkBankUsedRetain.Enabled = true;
            }
            else if (textTotalTransferredAmount.Text == "0.00")
            {

                dtDateOfPayment.Format = DateTimePickerFormat.Custom;
                dtDateOfPayment.CustomFormat = " ";
                dtDateOfPayment.Checked = false;
                dtDateOfPayment.Enabled = false;
                cboBankUsed.Enabled = false;
                checkBankUsedRetain.Enabled = false;
            }
        }

        private void textTransferredAmount_TextChanged(object sender, EventArgs e)
        {
            CheckUncheckDateOfPayment();
        }

        private void textTransferredAmount_Leave(object sender, EventArgs e)
        {
            double TransferredAmount;
            double.TryParse(textTotalTransferredAmount.Text, out TransferredAmount);
            textTotalTransferredAmount.Text = TransferredAmount.ToString("N2");

            CheckUncheckDateOfPayment();
        }

        private void checkTaxDecRetain_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTaxDecRetain.Checked == false)
            {
                textTaxDec.Clear();
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
            if (checkBankUsedRetain.Checked == false)
            {
                cboBankUsed.Text = null;
            }
        }

        private void checkRequestingParty_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRequestingParty.Checked == false)
            {
                textRequestingParty.Clear();
            }
        }

        private void btnAddClearAll_Click(object sender, EventArgs e)
        {
            checkTaxDecRetain.Checked = false;
            checkTaxNameRetain.Checked = false;
            checkBankUsedRetain.Checked = false;
            checkRequestingParty.Checked = false;

            textTaxDec.Text = string.Empty;
            textAmountToBePaid.Text = String.Empty;
            textTotalTransferredAmount.Text = String.Empty;
            textYearQuarter.Text = String.Empty;
            textTPName.Text = string.Empty;
            cboBankUsed.Text = string.Empty;
            textRequestingParty.Text = string.Empty;
            textRemarks.Text = string.Empty;
        }

        /// <summary>
        /// TEXTFIELDS BEHAVIOR FROM THIS POINT TO END USING KEYPRESS AND CLICK OF TAB OR CLICK IN THE MOUSE.
        /// PUT IN ONE CLASS OR VARIABLE.
        /// One decimal only in textfields that only accepts numbers.
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

        private void textAmountToBePaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            OneDecimalPointOnly(sender, e);
        }

        private void textTotalTransferredAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            OneDecimalPointOnly(sender, e);
        }

        private bool textTaxDecJustEntered = false;
        private void textTaxDec_Enter(object sender, EventArgs e)
        {
            textTaxDec.SelectAll();
            textTaxDecJustEntered = true;
        }

        private void textTaxDec_Click(object sender, EventArgs e)
        {
            if (textTaxDecJustEntered)
            {
                textTaxDec.SelectAll();
            }

            textTaxDecJustEntered = false;
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

        private bool textAmountToBePaidJustEntered = false;
        private void textAmountToBePaid_Enter(object sender, EventArgs e)
        {
            textAmountToBePaid.SelectAll();
            textAmountToBePaidJustEntered = true;
        }

        private void textAmountToBePaid_Click(object sender, EventArgs e)
        {
            if (textAmountToBePaidJustEntered)
            {
                textAmountToBePaid.SelectAll();
            }

            textAmountToBePaidJustEntered = false;
        }

        private bool textTotalTransferredAmountJustEntered = false;
        private void textTotalTransferredAmount_Enter(object sender, EventArgs e)
        {
            textTotalTransferredAmount.SelectAll();
            textTotalTransferredAmountJustEntered = true;
        }

        private void textTotalTransferredAmount_Click(object sender, EventArgs e)
        {
            if (textTotalTransferredAmountJustEntered)
            {
                textTotalTransferredAmount.SelectAll();
            }

            textTotalTransferredAmountJustEntered = false;
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

        private bool textRemarksJustEntered = false;
        private void textRemarks_Enter(object sender, EventArgs e)
        {
            textRemarks.SelectAll();
            textRemarksJustEntered = true;
        }

        private void textRemarks_Click(object sender, EventArgs e)
        {
            if (textRemarksJustEntered)
            {
                textRemarks.SelectAll();
            }

            textRemarksJustEntered = false;
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
        private void textTaxDec_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }

        private void textTPName_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }

        private void textAmountToBePaid_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }

        private void textTotalTransferredAmount_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }

        private void cboBankUsed_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }

        private void textYearQuarter_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }

        private void dtDateOfPayment_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }

        private void textStatForAssessment_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }

        private void textRequestingParty_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }

        private void textRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyDown(sender, e);
        }
    }
}
