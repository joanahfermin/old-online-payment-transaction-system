using SampleRPT1.FORMS;
using SampleRPT1.MODEL;
using SampleRPT1.Service;
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
    public partial class AddRPTForm : Form
    {
        private RPTUser loginUser = SecurityService.getLoginUser();

        public AddRPTForm()
        {
            InitializeComponent();
            InitializeBank();
            InitializeQuarter();
        }

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
        /// Auto-suggests the word being typed in the bank combobox.
        /// </summary>
        private void AddRPTForm_Load(object sender, EventArgs e)
        {
            CheckUncheckDateOfPayment();
            cboBankUsed.SelectedIndex = 0;
            cboBankUsed.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboBankUsed.AutoCompleteSource = AutoCompleteSource.ListItems;
            textYear.Text = DateTime.Now.Year.ToString();
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
            string TdNumber = textTaxDec.Text.Trim();
            string RPTyear = textYear.Text.Trim();
            string RPTquarter = cboQuarter.Text;

            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            RealPropertyTax rpt = new RealPropertyTax();

            if (isRPTTaxDecFormat(textTaxDec.Text) == true)
            {
                rpt.TaxDec = textTaxDec.Text.Trim();
            }

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

            rpt.ExcessShortAmount = rpt.TotalAmountTransferred - rpt.AmountToPay;

            rpt.Bank = cboBankUsed.Text.Trim();
            if (dtDateOfPayment.Enabled)
            {
                rpt.PaymentDate = dtDateOfPayment.Value.Date;
            }

            RPTyear = textYear.Text.Trim();
            rpt.YearQuarter = RPTyear;

            RPTquarter = cboQuarter.Text.Trim();
            rpt.Quarter = RPTquarter;

            rpt.Status = textStatForAssessment.Text;
            rpt.RequestingParty = textRequestingParty.Text.Trim();
            rpt.RPTremarks = textRemarks.Text.Trim();

            rpt.EncodedBy = loginUser.DisplayName;
            rpt.EncodedDate = DateTime.Now;

            //If payment exceeds the amount to pay, generate a reference number. 
            if (rpt.AmountToPay < rpt.TotalAmountTransferred)
            {
                string refNo = "R" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
                rpt.RefNum = refNo;
            }

            List<RealPropertyTax> Duplicate_Record = RPTDatabase.SelectBy_TaxDec_Year_Quarter(TdNumber, RPTyear, RPTquarter);

            if (Duplicate_Record.Count > 0)
            {
                RPTDuplicateRecordForm rptDuplicateForm = new RPTDuplicateRecordForm(Duplicate_Record);
                rptDuplicateForm.ShowDialog();
                return;
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

            if (checkRequestingParty.Checked == false)
            {
                textRequestingParty.Clear();
            }

            textAmountToBePaid.Text = "0.00";
            textTotalTransferredAmount.Text = "0.00";
            textYear.Clear();
            cboQuarter.SelectedIndex = 3;
            textRemarks.Clear();

            MessageBox.Show("Record successfully saved.");

            CheckUncheckDateOfPayment();

            MainForm.INSTANCE.SearchForAssessment();
        }

        /// <summary>
        /// Required textfields. 
        /// </summary>
        private void validateForm()
        {
            // clear muna natin lahat ng error from previous validation.
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textTaxDec, "Tax Dec. Number");
            Validations.ValidateRequired(errorProvider1, textYear, "Year");
            Validations.ValidateYearFormat(errorProvider1, textYear, "Year");

            Validations.ValidateTaxDecFormat(errorProvider1, textTaxDec, "Tax declaration number");
            Validations.ValidateRequired(errorProvider1, textRequestingParty, "Requesting Party");
            Validations.ValidateEmailAddressFormat(errorProvider1, textRequestingParty, "Requesting Party");
        }

        //Thousand separator.
        private void textAmountToBePaid_Leave(object sender, EventArgs e)
        {
            double amounttobepaid;
            double.TryParse(textAmountToBePaid.Text, out amounttobepaid);
            textAmountToBePaid.Text = amounttobepaid.ToString("N2");
            textTotalTransferredAmount.Text = textAmountToBePaid.Text;
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
                cboBankUsed.SelectedIndex = 0;
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
            textYear.Text = String.Empty;
            textTPName.Text = string.Empty;
            cboBankUsed.Text = string.Empty;
            textRequestingParty.Text = string.Empty;
            textRemarks.Text = string.Empty;
        }

        /// <summary>
        /// TEXTFIELDS BEHAVIOR FROM THIS POINT TO END USING KEYPRESS AND CLICK OF TAB OR CLICK IN THE MOUSE.
        /// PUT IN ONE CLASS OR VARIABLE.

        private void textAmountToBePaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHelperUtil.OneDecimalPointOnly(sender, e);
        }

        private void textTotalTransferredAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHelperUtil.OneDecimalPointOnly(sender, e);
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
            textYear.SelectAll();
            textYearQuarterJustEntered = true;
        }

        private void textYearQuarter_Click(object sender, EventArgs e)
        {
            if (textYearQuarterJustEntered)
            {
                textYear.SelectAll();
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

        private void textTaxDec_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textTPName_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textAmountToBePaid_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textTotalTransferredAmount_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void cboBankUsed_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textYearQuarter_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void dtDateOfPayment_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textStatForAssessment_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textRequestingParty_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private bool isRPTTaxDecFormat(string taxDec)
        {
            //format of taxdec number.
            Regex re = new Regex("^[A|B|C|D|E|F|G]-[0-9]{3}-[0-9]{5}( / [A|B|C|D|E|F|G]-[0-9]{3}-[0-9]{5})*$");
            return re.IsMatch(taxDec.Trim());
        }

        private void textTaxDec_Leave(object sender, EventArgs e)
        {
            //if (isRPTTaxDecFormat(textTaxDec.Text) == false)
            //{
            //    MessageBox.Show("Invalid input of Tax Dec. Number.");
            //    textTaxDec.Focus();
            //    textTaxDec.SelectAll();
            //}
            Validations.ValidateTaxDecFormat(errorProvider1, textTaxDec, "Tax declation number ");
        }

        private void textTaxDec_TextChanged(object sender, EventArgs e)
        {
            textTPName.Text = RPTDatabase.SelectByPropertyName(textTaxDec.Text);
        }
    }
}
