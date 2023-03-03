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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.FORMS
{
    public partial class AddMISCrecord : Form
    {
        private RPTUser loginUser = SecurityService.getLoginUser();
        MiscelleneousOccuPermit misc;

        public AddMISCrecord()
        {
            InitializeComponent();
            InitializeBank();
            InitializeMiscType();
            cboBankUsed.SelectedIndex = 0;
            cboStatus.Text = "FOR PAYMENT VERIFICATION";
            cboStatus.Enabled = false;
            btnUpdate.Enabled = false;

            
        }

        public AddMISCrecord(long miscId)
        {
            misc = MISCDatabase.Get(miscId);

            InitializeComponent();
            InitializeBank();
            InitializeMiscType();
            InitializeRetrieveMisc();
        }

        public void InitializeRetrieveMisc()
        {
            InitializeStatus();

            btnSave.Enabled = false;

            cboMiscType.Text = misc.MiscType;
            cboMiscType.Enabled = false;

            textTPName.Text = misc.TaxpayersName;
            textOPNum.Text = misc.OrderOfPaymentNum;
            textOPAtrackingNum.Text = misc.OPATrackingNum;
            textAmountToBePaid.Text = Convert.ToDecimal(misc.AmountToBePaid).ToString();
            textTotalTransferredAmount.Text = Convert.ToDecimal(misc.TransferredAmount).ToString();
            dtDateOfPayment.Value = misc.PaymentDate.Value;
            cboBankUsed.Text = misc.ModeOfPayment;
            cboStatus.Text = misc.Status;
            textRequestingParty.Text = misc.RequestingParty;
            textRemarks.Text = misc.Remarks;
        }

        public void InitializeMiscType()
        {
            foreach (string miscType in MISCUtil.ALL_MISC_TYPE)
            {
                cboMiscType.Items.Add(miscType);
            }
        }

        public void InitializeBank()
        {
            List<RPTBank> bankList = RPTBankDatabase.SelectAllBank();

            foreach (RPTBank bank in bankList)
            {
                cboBankUsed.Items.Add(bank.BankName);
            }
        }

        public void InitializeStatus()
        {
            foreach (string status in MISCUtil.ALL_OCCU_PERMIT_STATUS)
            {
                cboStatus.Items.Add(status);
            }
        }

        private void CheckUncheckDateOfPayment()
        {
            if (textTotalTransferredAmount.Text != "0.00")
            {
                dtDateOfPayment.Format = DateTimePickerFormat.Custom;
                dtDateOfPayment.CustomFormat = "MM/dd/yyyy";

                dtDateOfPayment.Checked = true;
                dtDateOfPayment.Enabled = true;
                cboBankUsed.Enabled = true;
                //checkBankUsedRetain.Enabled = true;
            }
            else if (textTotalTransferredAmount.Text == "0.00")
            {
                cboBankUsed.SelectedIndex = 0;
                dtDateOfPayment.Format = DateTimePickerFormat.Custom;
                dtDateOfPayment.CustomFormat = " ";
                dtDateOfPayment.Checked = false;
                dtDateOfPayment.Enabled = false;
                cboBankUsed.Enabled = false;
                //checkBankUsedRetain.Enabled = false;
            }
        }

        private void validateForm()
        {
            // clear muna natin lahat ng error from previous validation.
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, cboMiscType, "Misc type");
            Validations.ValidateRequired(errorProvider1, textRequestingParty, "Requesting Party");
            Validations.ValidateEmailAddressFormat(errorProvider1, textRequestingParty, "Requesting Party");

            if (Convert.ToDecimal(textTotalTransferredAmount.Text) != 0)
            {
                Validations.ValidateRequiredBank(errorProvider1, cboBankUsed, "Bank");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            decimal ComputeExcessShort;

            MiscelleneousOccuPermit misc = new MiscelleneousOccuPermit();
            misc.MiscType = cboMiscType.Text;

            misc.TaxpayersName = textTPName.Text;
            misc.OrderOfPaymentNum = textOPNum.Text;
            misc.ModeOfPayment = cboBankUsed.Text;
            misc.OPATrackingNum = textOPAtrackingNum.Text;
            misc.AmountToBePaid = Convert.ToDecimal(textAmountToBePaid.Text);
            misc.TransferredAmount = Convert.ToDecimal(textTotalTransferredAmount.Text);
            misc.PaymentDate = dtDateOfPayment.Value.Date;
            misc.Status = cboStatus.Text;
            misc.RequestingParty = textRequestingParty.Text;
            misc.Remarks = textRemarks.Text;
            misc.EncodedBy = loginUser.DisplayName;
            misc.EncodedDate = DateTime.Now;
            
            ComputeExcessShort = Convert.ToDecimal(textTotalTransferredAmount.Text) - Convert.ToDecimal(textAmountToBePaid.Text);
            misc.ExcessShort = ComputeExcessShort;

            MISCDatabase.InsertMisc(misc);
            MessageBox.Show("Record successfully saved.");
            this.Close();

            MiscelleneousTaxForm.INSTANCE.RefreshOccuPermit();
        }

        private void AddMISCrecord_Load(object sender, EventArgs e)
        {
            //cboBankUsed.SelectedIndex = 0;
            CheckUncheckDateOfPayment();
        }

        private void textTotalTransferredAmount_TextChanged(object sender, EventArgs e)
        {
            CheckUncheckDateOfPayment();
        }

        private void textTotalTransferredAmount_Leave(object sender, EventArgs e)
        {
            double TotalTransferredAmount;
            double.TryParse(textTotalTransferredAmount.Text, out TotalTransferredAmount);
            textTotalTransferredAmount.Text = TotalTransferredAmount.ToString("N2");

            CheckUncheckDateOfPayment();
        }

        private void textAmountToBePaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHelperUtil.OneDecimalPointOnly(sender, e);
        }

        private void textTotalTransferredAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHelperUtil.OneDecimalPointOnly(sender, e);
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

        private bool textOPNumJustEntered = false;
        private void textOPNum_Enter(object sender, EventArgs e)
        {
            textOPNum.SelectAll();
            textOPNumJustEntered = true;
        }

        private void textOPNum_Click(object sender, EventArgs e)
        {
            if (textOPNumJustEntered)
            {
                textOPNum.SelectAll();
            }
            textOPNumJustEntered = false;
        }

        private bool textOPAtrackingNumJustEntered = false;
        private void textOPAtrackingNum_Enter(object sender, EventArgs e)
        {
            textOPAtrackingNum.SelectAll();
            textOPAtrackingNumJustEntered = true;
        }

        private void textOPAtrackingNum_Click(object sender, EventArgs e)
        {
            if (textOPAtrackingNumJustEntered)
            {
                textOPAtrackingNum.SelectAll();
            }
            textOPAtrackingNumJustEntered = false;
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

        private bool textStatusJustEntered = false;
        private void textStatus_Enter(object sender, EventArgs e)
        {
            cboStatus.SelectAll();
            textStatusJustEntered = true;
        }

        private void textStatus_Click(object sender, EventArgs e)
        {
            if (textStatusJustEntered)
            {
                cboStatus.SelectAll();
            }
            textStatusJustEntered = false;
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

        private void textTPName_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textOPNum_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelperUtil.EnterKeyDown(sender, e, this);
        }

        private void textOPAtrackingNum_KeyDown(object sender, KeyEventArgs e)
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

        private void textStatus_KeyDown(object sender, KeyEventArgs e)
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

        private void textAmountToBePaid_Leave(object sender, EventArgs e)
        {
            double AmountToBePaid;
            double.TryParse(textAmountToBePaid.Text, out AmountToBePaid);
            textAmountToBePaid.Text = AmountToBePaid.ToString("N2");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            decimal ComputeExcessShort;

            misc.TaxpayersName = textTPName.Text;
            misc.OrderOfPaymentNum = textOPNum.Text;
            misc.ModeOfPayment = cboBankUsed.Text;
            misc.OPATrackingNum = textOPAtrackingNum.Text;
            misc.AmountToBePaid = Convert.ToDecimal(textAmountToBePaid.Text);
            misc.TransferredAmount = Convert.ToDecimal(textTotalTransferredAmount.Text);
            misc.PaymentDate = dtDateOfPayment.Value.Date;
            misc.Status = cboStatus.Text;
            misc.RequestingParty = textRequestingParty.Text;
            misc.Remarks = textRemarks.Text;
            misc.EncodedBy = loginUser.DisplayName;
            misc.EncodedDate = DateTime.Now;

            ComputeExcessShort = Convert.ToDecimal(textTotalTransferredAmount.Text) - Convert.ToDecimal(textAmountToBePaid.Text);
            misc.ExcessShort = ComputeExcessShort;

            MISCDatabase.UpdateMisc(misc);
            MessageBox.Show("Record successfully saved.");
            this.Close();

            MiscelleneousTaxForm.INSTANCE.RefreshOccuPermit();
        }
    }
}
