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
    public partial class Add_UpdateMiscForm : Form
    {
        private RPTUser loginUser = SecurityService.getLoginUser();
        MiscelleneousTax misc;

        private List<Label> dynamicLabelList = new List<Label>();
        private List<TextBox> dynamicTextboxList = new List<TextBox>();

        Dictionary<string, string[]> dynamicPropertyLabelMapping = new Dictionary<string, string[]>();
        Dictionary<string, string[]> dynamicPropertyNameMapping = new Dictionary<string, string[]>();

        private int CONTROL_HEIGHT_INCREMENT = 42;
        private int CONTROL_START_Y = 345;

        private int LABEL_START_X = 40;
        private int TEXTBOX_START_X = 152;

        public Add_UpdateMiscForm()
        {
            InitializeComponent();
            InitializeMiscType();
            InitializeDynamicMapping();
            InitializeBank();
            cboMiscType.SelectedIndex = 0;
            cboStatus.Text = "FOR ASSESSMENT";
            btnUpdate.Enabled = false;
        }

        public Add_UpdateMiscForm(long miscId)
        {
            misc = MISCDatabase.Get(miscId);

            InitializeDynamicMapping();
            InitializeComponent();
            InitializeBank();
            InitializeMiscType();
            InitializeRetrieveMisc();
        }

        public void InitializeBank()
        {
            List<RPTBank> bankList = RPTBankDatabase.SelectAllBank();

            foreach (RPTBank bank in bankList)
            {
                cboBankUsed.Items.Add(bank.BankName);
            }
        }

        public void InitializeMiscType()
        {
            foreach (string miscType in Misc_Type.ALL_MISC_TYPE)
            {
                cboMiscType.Items.Add(miscType);
            }
        }

        public void InitializeStatus()
        {
            //foreach (string status in MISCUtil.ALL_OCCU_PERMIT_STATUS)
            //{
            cboStatus.Items.Add(MISCUtil.FOR_ASSESSMENT);
            cboStatus.Items.Add(MISCUtil.STATUS_PENDING);
            cboStatus.Items.Add(MISCUtil.ACTION_DONE);

            //}
        }

        public void InitializeRetrieveMisc()
        {
            InitializeStatus();

            btnSave.Enabled = false;

            cboMiscType.Text = misc.MiscType;
            //cboMiscType.Enabled = false;

            string misc_type = cboMiscType.Text;

            textTPName.Text = misc.TaxpayersName;
            cboStatus.Text = misc.Status;
            textAmountToBePaid.Text = Convert.ToDecimal(misc.AmountToBePaid).ToString();
            textTotalTransferredAmount.Text = Convert.ToDecimal(misc.TransferredAmount).ToString();
            dtDateOfPayment.Value = misc.PaymentDate.Value;
            cboBankUsed.Text = misc.ModeOfPayment;

            string[] dynamicPropertyNames = dynamicPropertyNameMapping[misc_type];
            PasteDynamicProperties(misc, dynamicPropertyNames);
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

        private void InitializeDynamicMapping()
        {
            //initialize label
            dynamicPropertyLabelMapping.Add(Misc_Type.OCCUPATIONAL_PERMIT, new string[] { "O.P Number:", "OPA Tracking No.:", "Requesting Party:", "Remarks:" });
            dynamicPropertyLabelMapping.Add(Misc_Type.OVR, new string[] { "O.P Number:", "OPA Tracking No.:", "Requesting Party:", "Remarks:" });
            dynamicPropertyLabelMapping.Add(Misc_Type.LIQUOR, new string[] { "O.P Number:", "MP No.:", "Requesting Party:", "Remarks:" });
            dynamicPropertyLabelMapping.Add(Misc_Type.MARKET, new string[] { "O.P Number:", "Reference No.:", "Requesting Party:", "Remarks:" });
            dynamicPropertyLabelMapping.Add(Misc_Type.PTR, new string[] { "Profession:", "Last O.R Date:", "Last O.R No.:", "PRC/IBP No.:", "Requesting Party:", "Remarks:" });
            dynamicPropertyLabelMapping.Add(Misc_Type.HEALTH_CERTIFICATE, new string[] { "Requesting Party:", "Remarks:" });
            dynamicPropertyLabelMapping.Add(Misc_Type.TAX_CLEARANCE, new string[] { "Requesting Party:", "Remarks:" });
            dynamicPropertyLabelMapping.Add(Misc_Type.SIGNBOARD, new string[] { "Requesting Party:", "Remarks:" });
            dynamicPropertyLabelMapping.Add(Misc_Type.CONTRACTORS_TAX, new string[] { "Requesting Party:", "Remarks:" });

            //initialize property
            dynamicPropertyNameMapping.Add(Misc_Type.OCCUPATIONAL_PERMIT, new string[] { "OrderOfPaymentNum", "OPATrackingNum", "RequestingParty", "Remarks" });
            dynamicPropertyNameMapping.Add(Misc_Type.OVR, new string[] { "OrderOfPaymentNum", "OPATrackingNum", "RequestingParty", "Remarks" });
            dynamicPropertyNameMapping.Add(Misc_Type.LIQUOR, new string[] { "OrderOfPaymentNum", "OPATrackingNum", "RequestingParty", "Remarks" });
            dynamicPropertyNameMapping.Add(Misc_Type.MARKET, new string[] { "OrderOfPaymentNum", "OPATrackingNum", "RequestingParty", "Remarks" });
            dynamicPropertyNameMapping.Add(Misc_Type.PTR, new string[] { "Profession", "LastORDate", "LastORNo", "PRC_IBP_No", "RequestingParty", "Remarks" });
            dynamicPropertyNameMapping.Add(Misc_Type.HEALTH_CERTIFICATE, new string[] { "RequestingParty", "Remarks" });
            dynamicPropertyNameMapping.Add(Misc_Type.TAX_CLEARANCE, new string[] { "RequestingParty", "Remarks" });
            dynamicPropertyNameMapping.Add(Misc_Type.SIGNBOARD, new string[] { "RequestingParty", "Remarks" });
            dynamicPropertyNameMapping.Add(Misc_Type.CONTRACTORS_TAX, new string[] { 
                "RequestingParty", "Remarks" });
        }


        private void cboMiscType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveAllDynamicControls();
            string miscType = cboMiscType.Text;
            string[] dynamicPropertyLabels = dynamicPropertyLabelMapping[miscType];
            AddDynamicControls(dynamicPropertyLabels);
        }

        private void RemoveAllDynamicControls()
        {
            foreach (Label label in dynamicLabelList)
            {
                panel1.Controls.Remove(label);
            }
            foreach (TextBox textBox in dynamicTextboxList)
            {
                panel1.Controls.Remove(textBox);
            }
            dynamicLabelList.Clear();
            dynamicTextboxList.Clear();
        }

        private void AddDynamicControls(string[] dynamicPropertyLabels)
        {
            int y = CONTROL_START_Y; // saan ilalagay sa screen vertically

            // for every property, gagawa ka ng pares na label and textbox
            foreach (string propertyLabel in dynamicPropertyLabels)
            {
                // Create the label on the left side
                Label label = new Label();
                label.Top = y;
                label.Left = LABEL_START_X;
                label.Text = propertyLabel;
                label.Width = 100;
                dynamicLabelList.Add(label);
                panel1.Controls.Add(label);

                // textbox sa kanan
                TextBox textBox = new TextBox();
                textBox.Top = y;
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.Left = TEXTBOX_START_X;
                textBox.Width = 260;
                textBox.Height = 28;
                dynamicTextboxList.Add(textBox);
                panel1.Controls.Add(textBox);

                // need sa baba yung susunot na label/textbox
                y = y + CONTROL_HEIGHT_INCREMENT;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MiscelleneousTax misc = new MiscelleneousTax();
            misc.MiscType = cboMiscType.Text;

            misc.TaxpayersName = textTPName.Text.Trim();
            misc.AmountToBePaid = Convert.ToDecimal(textAmountToBePaid.Text);
            misc.TransferredAmount = Convert.ToDecimal(textTotalTransferredAmount.Text);
            misc.PaymentDate = dtDateOfPayment.Value.Date;
            misc.Status = cboStatus.Text;
            misc.ModeOfPayment = cboBankUsed.Text;
            misc.EncodedBy = loginUser.DisplayName;
            misc.EncodedDate = DateTime.Now;
            misc.ExcessShort = misc.TransferredAmount - misc.AmountToBePaid;

            string misc_type = cboMiscType.Text;

            string[] dynamicPropertyNames = dynamicPropertyNameMapping[misc_type];
            CopyDynamicProperties(misc, dynamicPropertyNames);

            //detects if there's existing record in db
            List<MiscelleneousTax> Duplicate_Record = MISCDatabase.SelectBy_OPNumber(misc.OrderOfPaymentNum);

            if (Duplicate_Record.Count > 0)
            {
                MISCDuplicateRecordForm miscDuplicateForm = new MISCDuplicateRecordForm(Duplicate_Record);
                miscDuplicateForm.ShowDialog();
                return;
            }

            MISCDatabase.InsertMisc(misc);
            MessageBox.Show("Record successfully saved.");
            this.Close();

            MiscelleneousTaxForm.INSTANCE.RefreshLV_FromGcashPaymaya(misc.OrderOfPaymentNum);
            Close();
        }

        private void CopyDynamicProperties(MiscelleneousTax misc, string[] dynamicPropertyNames)
        {
            for (int i = 0; i < dynamicPropertyNames.Length; i++)
            {
                string propertyName = dynamicPropertyNames[i];
                string value = dynamicTextboxList[i].Text;
                misc.GetType().GetProperty(propertyName).SetValue(misc, value);
            }
        }

        private void PasteDynamicProperties(MiscelleneousTax misc, string[] dynamicPropertyNames)
        {
            for (int i = 0; i < dynamicPropertyNames.Length; i++)
            {
                string propertyName = dynamicPropertyNames[i];
                Object value = misc.GetType().GetProperty(propertyName).GetValue(misc, null);

                if (value != null)
                {
                    dynamicTextboxList[i].Text = value.ToString();
                }
            }
        }

        private void AddMiscForm_Load(object sender, EventArgs e)
        {
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

        private void validateForm()
        {
            // clear muna natin lahat ng error from previous validation.
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, cboMiscType, "Misc type");

            //Validations.ValidateRequired(errorProvider1, textRequestingParty, "Requesting Party");
            //Validations.ValidateEmailAddressFormat(errorProvider1, textRequestingParty, "Requesting Party");

            if (Convert.ToDecimal(textTotalTransferredAmount.Text) != 0)
            {
                Validations.ValidateRequiredBank(errorProvider1, cboBankUsed, "Bank");
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            misc.MiscType = cboMiscType.Text;

            misc.TaxpayersName = textTPName.Text.Trim();
            misc.AmountToBePaid = Convert.ToDecimal(textAmountToBePaid.Text);
            misc.TransferredAmount = Convert.ToDecimal(textTotalTransferredAmount.Text);
            misc.PaymentDate = dtDateOfPayment.Value.Date;
            misc.Status = cboStatus.Text;
            misc.ModeOfPayment = cboBankUsed.Text;
            misc.ExcessShort = misc.TransferredAmount - misc.AmountToBePaid;

            string misc_type = cboMiscType.Text;

            string[] dynamicPropertyNames = dynamicPropertyNameMapping[misc_type];
            CopyDynamicProperties(misc, dynamicPropertyNames);

            //detects if there's existing record in db
            List<MiscelleneousTax> Duplicate_Record = MISCDatabase.SelectBy_OPNumber_MiscID(misc.OrderOfPaymentNum, misc.MiscID);

            if (Duplicate_Record.Count > 0)
            {
                foreach (var item in Duplicate_Record)
                {
                    if (!Duplicate_Record.Contains(item))
                    {
                        MISCDuplicateRecordForm miscDuplicateForm = new MISCDuplicateRecordForm(Duplicate_Record);
                        miscDuplicateForm.ShowDialog();
                        return;
                    }
                }
            }

            MISCDatabase.UpdateMisc(misc);
            MessageBox.Show("Record successfully saved.");
            this.Close();

            MiscelleneousTaxForm.INSTANCE.RefreshOccuPermit();
            Close();
        }
    }
}
