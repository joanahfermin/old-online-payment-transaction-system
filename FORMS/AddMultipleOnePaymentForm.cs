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
    public partial class AddMultipleOnePaymentForm : Form
    {
        private RPTUser loginUser = SecurityService.getLoginUser();

        public AddMultipleOnePaymentForm()
        {
            InitializeComponent();
            InitializeBank();
            InitializeQuarter();
            InitializePaymentType();
            InitializeBillingSelection();
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

        public void InitializePaymentType()
        {
            foreach (string type in RPTPaymentTypeUtil.ALL_PAYMENT_TYPE)
            {
                cboPaymentType.Items.Add(type);
            }
            cboPaymentType.SelectedIndex = 3;
        }

        public void InitializeBillingSelection()
        {
            foreach (string type in RPTBillingSelection.ALL_BILLING_SELECTION)
            {
                cboBillingSelection.Items.Add(type);
            }
            cboBillingSelection.SelectedIndex = 0;
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
            btnUpdate.Enabled = false;

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
            item.SubItems.Add(cboPaymentType.Text.Trim());
            item.SubItems.Add(cboBillingSelection.Text.Trim());
            item.SubItems.Add(textRemarks.Text.Trim());

            lvMultipleRecord.Items.Insert(0, item);

            lvMultipleRecord.SelectedItems.Clear();
            lvMultipleRecord.Items[0].Selected = true;

            ComputeTotalAmountToPay();

            textAmount2Pay.Clear();

            if (checkTaxDecRetain.Checked == true)
            {
                int yearQuarter = Convert.ToInt32(textYearQuarter.Text);
                textYearQuarter.Text = (yearQuarter + 1).ToString();
                textAmount2Pay.Focus(); 
            }
            else
            {
                textTDN.Focus();
            }

            textRequestingParty.Clear();
            textRemarks.Clear();
            //lvMultipleRecord.Focus();

            checkTaxDecRetain_CheckedChanged(sender, e);
            checkTaxNameRetain_CheckedChanged(sender, e);
        }

        private void ComputeTotalAmountToPay()
        {
            decimal TotalAmountToPay = 0;
            foreach (ListViewItem Record in lvMultipleRecord.Items)
            {
                TotalAmountToPay += decimal.Parse(Record.SubItems[2].Text);
            }

            textTotalAmountToPay.Text = Convert.ToString(TotalAmountToPay);

            decimal ConvertedTotalAmountToPay = decimal.Parse(textTotalAmountToPay.Text, System.Globalization.NumberStyles.Currency);
            textTotalAmountToPay.Text = ConvertedTotalAmountToPay.ToString("N2");
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

            List<ListViewItem> TempList = new List<ListViewItem>();

            foreach (ListViewItem item in lvMultipleRecord.Items)
            {
                TempList.Add(item);
            }
            TempList.Reverse();

            HashSet<string> taxdecList = new HashSet<string>();

            foreach (ListViewItem item in TempList)
            {
                taxdecList.Add(item.Text);
            }

            List<ListViewItem> rptListToInsert = new List<ListViewItem>();

            SortedSet<string> YearSet = new SortedSet<string>();

            foreach (ListViewItem item in lvMultipleRecord.Items)
            {
                YearSet.Add(item.SubItems[3].Text);
            }

            foreach (string taxdec in taxdecList)
            {
                foreach (string year in YearSet)
                {
                    foreach (ListViewItem item in TempList)
                    {
                        if (year == item.SubItems[3].Text && taxdec == item.Text)
                        {
                            rptListToInsert.Add(item);
                        }
                    }
                }
            }

            //DETECT IF ONE OF THE RECORDS IS DUPLICATE.
            foreach (ListViewItem item in rptListToInsert)
            {
                string TaxDec = item.Text;
                string Year = item.SubItems[3].Text;
                string Quarter = item.SubItems[4].Text;
                string B_Selection = item.SubItems[6].Text;

                List<RealPropertyTax> Duplicate_Record = RPTDatabase.SelectBy_TaxDec_Year_Quarter_BSelection(TaxDec, Year, Quarter, B_Selection);

                if (Duplicate_Record.Count > 0)
                {
                    RPTDuplicateRecordForm rptDuplicateForm = new RPTDuplicateRecordForm(Duplicate_Record);
                    rptDuplicateForm.ShowDialog();
                    return;
                }
            }

            foreach (ListViewItem item in rptListToInsert)
            {
                string TaxDec = item.Text;
                string TaxPayerName = item.SubItems[1].Text;
                
                string Amount2Pay = item.SubItems[2].Text;
                string YearQuarter = item.SubItems[3].Text;
                string Quarter = item.SubItems[4].Text;
                string P_Type = item.SubItems[5].Text;
                string B_Selection = item.SubItems[6].Text;
                string Remarks = item.SubItems[7].Text;

                RealPropertyTax rpt = new RealPropertyTax();

                rpt.TaxDec = TaxDec;
                rpt.TaxPayerName = TaxPayerName;
                rpt.AmountToPay = Convert.ToDecimal(Amount2Pay);
                rpt.Quarter = Quarter;
                rpt.PaymentType = P_Type;
                rpt.BillingSelection = B_Selection;

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

                rpt.EncodedBy = loginUser.DisplayName;
                rpt.EncodedDate = DateTime.Now;
                rpt.RefNum = refNo;
                rpt.RPTremarks = Remarks;

                //detects if there's existing record in db
                List<RealPropertyTax> Duplicate_Record = RPTDatabase.SelectBy_TaxDec_Year_Quarter_BSelection(TaxDec, YearQuarter, Quarter, B_Selection);

                if (Duplicate_Record.Count > 0)
                {
                    RPTDuplicateRecordForm rptDuplicateForm = new RPTDuplicateRecordForm(Duplicate_Record);
                    rptDuplicateForm.ShowDialog();
                    return;
                }

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

            MainForm.INSTANCE.RefreshListView();
            this.Close();
        }

        /// <summary>
        /// Required fields.
        /// </summary>
        private void validateForm()
        {
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textTDN, "Tax dec. number");
            Validations.ValidateRequired(errorProvider1, textTPName, "Taxpayer name");
            Validations.ValidateRequired(errorProvider1, textYearQuarter, "Year");
            Validations.ValidateYearFormat(errorProvider1, textYearQuarter, "Year");

            Validations.ValidateRequiredAmountToPay(errorProvider1, textAmount2Pay, "Amount to pay");
            Validations.ValidateTaxDecFormat(errorProvider1, textTDN, "Tax dec num. ");
        }

        /// <summary>
        /// Required fields.
        /// </summary>
        private void validateFormSaveToMainLV()
        {
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textTotalAmountDeposited, "Total Amount Deposited");
            Validations.ValidateRequired(errorProvider1, textRequestingParty, "Requesting Party");
            Validations.ValidateEmailAddressFormat(errorProvider1, textRequestingParty, "Requesting Party");

            if (Convert.ToDecimal(textTotalAmountDeposited.Text) > 0)
            {
                Validations.ValidateRequiredBank(errorProvider1, cboBankUsed, "Bank");
            }
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

            //if (lvMultipleRecord.SelectedItems.Count == 0 && lvMultipleRecord.Items.Count > 0)
            //{
            //    textTDN.Text = string.Empty;
            //    textTPName.Text = string.Empty;
            //    textAmount2Pay.Text = string.Empty;
            //    //textYearQuarter.Text = string.Empty;
            //    cboQuarter.SelectedItem = 3;
            //    cboPaymentType.SelectedItem = 3;
            //    cboBillingSelection.SelectedItem = 0;
            //    textRemarks.Text = string.Empty;
            //}

            btnUpdate.Enabled = false;

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
            if (e.KeyData == Keys.Enter)
            {
                textTPName.Text = RPTDatabase.SelectByPropertyName(textTDN.Text);
            }
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

        private void textTDN_Leave(object sender, EventArgs e)
        {
            textTPName.Text = RPTDatabase.SelectByPropertyName(textTDN.Text);

        }

        private bool isRPTTaxDecFormat(string taxDec)
        {
            //format of taxdec number.
            Regex re = new Regex("^[A|B|C|D|E|F|G]-[0-9]{3}-[0-9]{5}$");
            return re.IsMatch(taxDec.Trim());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvMultipleRecord.SelectedIndices.Count > 0)
            {
                var Confirmation = MessageBox.Show("Are you sure you want to delete record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Confirmation == DialogResult.Yes)
                {
                    for (int i = lvMultipleRecord.SelectedIndices.Count - 1; i >= 0; i--)
                    {
                        lvMultipleRecord.Items.RemoveAt(lvMultipleRecord.SelectedIndices[i]);
                    }
                    lvMultipleRecord.Items[0].Selected = true;
                    textYearQuarter.Focus();

                }
            }
            else
            {
                MessageBox.Show("Invalid deletion of record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ComputeTotalAmountToPay();
        }

        private void textTDN_TextChanged(object sender, EventArgs e)
        {
            //textTPName.Text = RPTDatabase.SelectByPropertyName(textTDN.Text);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvMultipleRecord.SelectedItems.Count > 0)
            {
                var selectedRecord = lvMultipleRecord.SelectedItems[0];

                selectedRecord.SubItems[0].Text = textTDN.Text;
                selectedRecord.SubItems[1].Text = textTPName.Text;
                selectedRecord.SubItems[2].Text = textAmount2Pay.Text;
                selectedRecord.SubItems[3].Text = textYearQuarter.Text;
                selectedRecord.SubItems[4].Text = cboQuarter.Text;
                selectedRecord.SubItems[5].Text = cboPaymentType.Text;
                selectedRecord.SubItems[6].Text = cboBillingSelection.Text;
                selectedRecord.SubItems[7].Text = textRemarks.Text;

                MessageBox.Show("Record successfully updated.");
            }

            ClearAll();
        }

        private void lvMultipleRecord_DoubleClick(object sender, EventArgs e)
        {
            if (lvMultipleRecord.SelectedItems.Count > 0)
            {
                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;

                var selectedRecord = lvMultipleRecord.SelectedItems[0];

                textTDN.Text = selectedRecord.SubItems[0].Text;
                textTPName.Text = selectedRecord.SubItems[1].Text;
                textAmount2Pay.Text = selectedRecord.SubItems[2].Text;
                textYearQuarter.Text = selectedRecord.SubItems[3].Text;
                cboQuarter.Text = selectedRecord.SubItems[4].Text;
                cboPaymentType.Text = selectedRecord.SubItems[5].Text;
                cboBillingSelection.Text = selectedRecord.SubItems[6].Text;

                textRemarks.Text = selectedRecord.SubItems[7].Text;

            }
        }

        private void lvMultipleRecord_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvMultipleRecord.SelectedItems.Count < 1)
            {
                btnUpdate.Enabled = false;
                btnAdd.Enabled = true;

                //textTDN.Text = string.Empty;
                //textTPName.Text = string.Empty;
                //textAmount2Pay.Text = string.Empty;
                ////textYearQuarter.Text = string.Empty;
                //cboQuarter.SelectedItem = 3;
                //cboPaymentType.SelectedItem = 3;
                //cboBillingSelection.SelectedItem = 0;
                //textRemarks.Text = string.Empty;
            }
        }

        private void ClearAll()
        {
            textTDN.Text = string.Empty;
            textTPName.Text = string.Empty;
            textAmount2Pay.Text = string.Empty;
            textYearQuarter.Text = string.Empty;
            cboQuarter.SelectedItem = 3;
            cboPaymentType.SelectedItem = 3;
            cboBillingSelection.SelectedItem = 0;
            textRemarks.Text = string.Empty;
        }
    }
}
