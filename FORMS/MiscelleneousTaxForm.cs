using Microsoft.VisualBasic;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1
{
    public partial class MiscelleneousTaxForm : Form
    {
        public static MiscelleneousTaxForm INSTANCE;
        private const String SEARCH_BY_DATE_STATUS = "SEARCH_BY_DATE_STATUS";
        private String lastSearchAction = "";

        private RPTUser loginUser = SecurityService.getLoginUser();

        MainFormMISCListViewHelper mainFormListViewHelper;

        public MiscelleneousTaxForm(Form parentForm)
        {
            InitializeComponent();
            InitializeMiscType();
            InitializeStatus();
            InitializeAction();
            InitializePaymentChannel();

            cboStatus.Text = MISCUtil.FOR_ASSESSMENT;
            cboAction.Text = MISCUtil.ASSESS_RECORD;

            //if (loginUser.isVerifier)
            //{
            //    cboStatus.Text = MISCUtil.FOR_PAYMENT_VERIFICATION;
            //    cboAction.Text = MISCUtil.VERIFY_PAYMENT;
            //}

            LabelRepName.Visible = false;
            LabelContactNumber.Visible = false;
            textRepName.Visible = false;
            textContactNumber.Visible = false;

            INSTANCE = this;
            MdiParent = parentForm;
            ControlBox = false;
            dtDate.Value = DateTime.Now;
            dtDateTo.Value = DateTime.Now;

            mainFormListViewHelper = new MainFormMISCListViewHelper(MISCinfoLV);
        }

        public void InitializeStatus()
        {
            foreach (string status in MISCUtil.ALL_OCCU_PERMIT_STATUS)
            {
                cboStatus.Items.Add(status);
            }
        }

        public long getSelectedMiscID()
        {
            return mainFormListViewHelper.getSelectedMiscID();
        }

        public void ChangeMiscType(string miscType)
        {
            cboMiscType.Text = miscType;
        }

        public void RefreshLV()
        {
            lastSearchAction = SEARCH_BY_DATE_STATUS;

            List<MiscelleneousTax> miscList;
            string Misc_Type = cboMiscType.Text;

            // If date range is checked, search by date range and status. Otherwise, just search by status.
            if (dtDate.Checked)
            {
                miscList = SearchByDateRangeAndStatus_PaymentChannel();
            }
            else
            {
                string Status = cboStatus.Text;
                miscList = MISCDatabase.SelectByStatus(Misc_Type, Status);
            }

            if (cboStatus.Text == MISCUtil.FOR_TRANSMITTAL || cboStatus.Text == MISCUtil.TRANSMITTED)
            {
                LabelRepName.Visible = true;
                LabelContactNumber.Visible = true;
                textRepName.Visible = true;
                textContactNumber.Visible = true;
            }
            else
            {
                LabelRepName.Visible = false;
                LabelContactNumber.Visible = false;
                textRepName.Visible = false;
                textContactNumber.Visible = false;
            }

            PopulateLVMISC(miscList);

            MISCinfoLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //MISCinfoLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        public void InitializeMiscType()
        {
            cboMiscType.Items.Clear();

            foreach (string misc in Misc_Type.ALL_MISC_TYPE)
            {
                cboMiscType.Items.Add(misc);
            }
            cboMiscType.SelectedIndex = 0;
        }

        public void InitializeAction()
        {
            foreach (string status in MISCUtil.ALL_ACTIONS)
            {
                cboAction.Items.Add(status);
            }
        }

        private void InitializePaymentChannel()
        {
            cboPaymentChannel.Items.Clear();
            cboPaymentChannel.Visible = true;

            foreach (string banks in RPTGcashPaymaya.ALL_PAYMENT_CHANNEL)
            {
                cboPaymentChannel.Items.Add(banks);
            }
        }

        public void RefreshOccuPermit()
        {
            cboMiscType.Text = Misc_Type.OCCUPATIONAL_PERMIT;
            RefreshLV();
        }

        public void Show()
        {
            base.Show();
            WindowState = FormWindowState.Maximized;
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            //AddMISCrecord addMISCrecord = new AddMISCrecord();
            //addMISCrecord.ShowDialog();

            Add_UpdateMiscForm addMiscForm = new Add_UpdateMiscForm();
            addMiscForm.ShowDialog();
        }

        private void PopulateLVMISC(List<MiscelleneousTax> MiscList)
        {
            string MiscType = cboMiscType.Text;
            List<string> PropertyNames = MISCUtil.LIST_VIEW_PROPERTY_NAMES_MAPPING[MiscType];
            ListViewUtil.copyFromListToListview<MiscelleneousTax>(MiscList, MISCinfoLV, PropertyNames);

            for (int i = 0; i < MiscList.Count; i++)
            {
                MiscelleneousTax misc = MiscList[i];
                ListViewItem topItem = MISCinfoLV.Items[i];

                if (misc.ExcessShort < 0)
                {
                    topItem.BackColor = Color.LightCoral;
                }
                else if (misc.ExcessShort > 0)
                {
                    topItem.BackColor = Color.LightGreen;
                }
            }
        }

        private void HighlightRecord()
        {
            string miscRecord = textSearch.Text;

            foreach (ListViewItem item in MISCinfoLV.Items)
            {
                if (item.SubItems[2].Text.Contains(miscRecord) || item.SubItems[3].Text.Contains(miscRecord) || item.SubItems[4].Text.Contains(miscRecord))
                {
                    item.Selected = true;
                    MISCinfoLV.Focus();
                }
            }
        }

        private void cboMiscType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MISCinfoLV.Columns.Clear();

            string MiscType = cboMiscType.Text;
            List<string> ColumnNames = MISCUtil.LIST_VIEW_COLUMN_NAMES_MAPPING[MiscType];
            foreach (string item in ColumnNames)
            {
                MISCinfoLV.Columns.Add(item);
            }
            RefreshLV();

            MISCinfoLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //MISCinfoLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        static void AutoResizeLV_Column(ListView MISCinfoLV, int width)
        {
            foreach (ColumnHeader col in MISCinfoLV.Columns)
            {
                col.Width = width;
            }
        }

        static void AutoResizeLV_ColumnContent(ListView MISCinfoLV, int width)
        {
            //foreach (ListView item in MISCinfoLV.Columns)
            //{
            //    item.Columns.s= width;
            //}
        }

        private void CallUpdateForm()
        {
            long RetrieveMiscID = mainFormListViewHelper.getSelectedMiscID();

            Add_UpdateMiscForm addMiscForm = new Add_UpdateMiscForm(RetrieveMiscID);
            addMiscForm.ShowDialog();


            //AddMISCrecord addMISCrecord = new AddMISCrecord(RetrieveMiscID);
            //addMISCrecord.ShowDialog();
        }

        private void MISCinfoLV_DoubleClick(object sender, EventArgs e)
        {
            //string MiscIDString = MISCinfoLV.SelectedItems[0].Text;
            //long miscID = Convert.ToInt64(MiscIDString);

            MiscelleneousTax RetrieveMisc = mainFormListViewHelper.getSelectedMisc();

            if (RetrieveMisc.Status == MISCUtil.FOR_PAYMENT_VERIFICATION || RetrieveMisc.Status == MISCUtil.FOR_ASSESSMENT)
            {
                CallUpdateForm();
            }
            else
            {
                string input = Interaction.InputBox("Enter Password:", "Authorize Edit Data", "", 760, 440);

                if (GlobalConstants.AUTHORIZE_EDIT_DATA == input)
                {
                    CallUpdateForm();
                }
                else
                {
                    MessageBox.Show("Invalid password.");
                }

            }
        }

        public void RefreshLV_FromGcashPaymaya(string SearchString)
        {
            string MiscType = cboMiscType.Text;
            textSearch.Text = SearchString;
            string forPaymentValidationOnly = RPTStatus.PAYMENT_VALIDATION;

            if (loginUser.MachNo != null)
            {
                List<MiscelleneousTax> miscRecordListForPaymentValidation = MISCDatabase.SearchAllForPaymentValidationOnly(MiscType, SearchString, forPaymentValidationOnly);
                PopulateLVMISC(miscRecordListForPaymentValidation);
            }
            else
            {
                List<MiscelleneousTax> miscRecordList = MISCDatabase.Search(MiscType, SearchString);
                PopulateLVMISC(miscRecordList);
            }
            //List<MiscelleneousTax> miscRecordList = MISCDatabase.Search(MiscType, SearchString);
            //PopulateLVMISC(miscRecordList);

            HighlightRecord();

            if (MISCinfoLV.SelectedItems.Count > 0)
            {
                int index = MISCinfoLV.SelectedItems[0].Index;
                MISCinfoLV.EnsureVisible(index);
            }
            MISCinfoLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        private void textSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshLV_FromGcashPaymaya(textSearch.Text);

                if (MISCinfoLV.Items.Count == 0)
                {
                    MessageBox.Show("No record status: 'FOR PAYMENT VALIDATION' retrieved. Either the record's status is not FOR PAYMENT VALIDATION status or no record exists.");
                }
            }
        }

        private void AssessRecord()
        {
            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<MiscelleneousTax> SelectedMISCList = mainFormListViewHelper.GetSelectedMISCByStatus(MISCUtil.FOR_ASSESSMENT);

                bool SameStatus = mainFormListViewHelper.CheckSameStatus(MISCUtil.FOR_ASSESSMENT);
                bool AllProcessed = true;

                foreach (MiscelleneousTax misc in SelectedMISCList)
                {
                    //misc. = loginUser.DisplayName;
                    //misc.VerifiedDate = DateTime.Now;
                    misc.Status = MISCUtil.FOR_PAYMENT_VERIFICATION;

                    if (misc.TransferredAmount >= misc.AmountToBePaid)
                    {
                        MISCDatabase.Update(misc);
                    }
                    else
                    {
                        //AllProcessed = false;
                    }
                }

                if (SameStatus == false || AllProcessed == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                    cboStatus.Text = MISCUtil.FOR_PAYMENT_VERIFICATION;
                }
                MessageBox.Show("Record/s successfully assessed.");
                cboStatus.Text = MISCUtil.FOR_PAYMENT_VERIFICATION;
                RefreshLV();
            }
        }

        private void VerifyPayment()
        {
            if (loginUser.isVerifier)
            {
                if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    List<MiscelleneousTax> SelectedMISCList = mainFormListViewHelper.GetSelectedMISCByStatus(MISCUtil.FOR_PAYMENT_VERIFICATION);

                    bool SameStatus = mainFormListViewHelper.CheckSameStatus(MISCUtil.FOR_PAYMENT_VERIFICATION);
                    bool AllProcessed = true;

                    foreach (MiscelleneousTax misc in SelectedMISCList)
                    {
                        misc.VerifiedBy = loginUser.DisplayName;
                        misc.VerifiedDate = DateTime.Now;
                        misc.Status = MISCUtil.FOR_PAYMENT_VALIDATION;

                        if (misc.TransferredAmount >= misc.AmountToBePaid)
                        {
                            MISCDatabase.Update(misc);
                        }
                        else
                        {
                            AllProcessed = false;
                        }
                    }

                    if (SameStatus == false || AllProcessed == false)
                    {
                        MessageBox.Show("Some selected records has not been processed.");
                        cboStatus.Text = MISCUtil.FOR_PAYMENT_VERIFICATION;
                    }
                    MessageBox.Show("Record/s successfully verified.");
                    cboStatus.Text = MISCUtil.FOR_PAYMENT_VALIDATION;
                    RefreshLV();
                }

            }
            else
            {
                MessageBox.Show("You are not allowed to verify record/s.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidatePayment()
        {
            if (loginUser.isValidator || loginUser.DisplayName == "NIKKO")
            {
                if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<MiscelleneousTax> SelectedMISCList = mainFormListViewHelper.GetSelectedMISCByStatus(MISCUtil.FOR_PAYMENT_VALIDATION);

                    bool SameStatus = mainFormListViewHelper.CheckSameStatus(MISCUtil.FOR_PAYMENT_VALIDATION);
                    bool AllProcessed = true;

                    foreach (MiscelleneousTax misc in SelectedMISCList)
                    {
                        misc.ValidatedBy = loginUser.DisplayName;
                        misc.ValidatedDate = DateTime.Now;

                        if (misc.Status == MISCUtil.FOR_PAYMENT_VALIDATION)
                        {
                            misc.Status = MISCUtil.FOR_TRANSMITTAL;
                            MISCDatabase.Update(misc);
                        }
                        else
                        {
                            AllProcessed = false;
                        }
                    }

                    if (SameStatus == false || AllProcessed == false)
                    {
                        MessageBox.Show("Some selected records has not been processed.");
                        return;
                    }

                    MessageBox.Show("Record/s successfully validated.");
                    cboStatus.Text = MISCUtil.FOR_TRANSMITTAL;
                    RefreshLV();
                }
            }
            else
            {
                MessageBox.Show("You are not allowed to validate record/s.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TransmitPayment()
        {
            //if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    List<MiscelleneousTax> SelectedMISCList = mainFormListViewHelper.GetSelectedMISCByStatus(MISCUtil.FOR_TRANSMITTAL);

            //    foreach (var misc in SelectedMISCList)
            //    {
            //        misc.TransmittedBy = loginUser.DisplayName;
            //        misc.TransmittedDate = DateTime.Now;
            //        misc.Status = MISCUtil.TRANSMITTED;

            //        MISCDatabase.Update(misc);
            //    }

            //    MessageBox.Show("Record/s successfully transmitted.");
            //    RefreshLV();
            //}
            if (loginUser.DisplayName == "DAN" || loginUser.DisplayName == "BON" || loginUser.DisplayName == "JOANAH")
            {
                if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<MiscelleneousTax> SelectedMISCList = mainFormListViewHelper.GetSelectedMISCByStatus(MISCUtil.FOR_TRANSMITTAL);

                    bool SameStatus = mainFormListViewHelper.CheckSameStatus(MISCUtil.FOR_TRANSMITTAL);
                    bool AllProcessed = true;

                    foreach (MiscelleneousTax misc in SelectedMISCList)
                    {
                        misc.TransmittedBy = loginUser.DisplayName;
                        misc.TransmittedDate = DateTime.Now;

                        if (misc.Status == MISCUtil.FOR_TRANSMITTAL)
                        {
                            misc.Status = MISCUtil.TRANSMITTED;
                            MISCDatabase.Update(misc);
                        }
                        else
                        {
                            AllProcessed = false;
                        }
                    }

                    if (SameStatus == false || AllProcessed == false)
                    {
                        MessageBox.Show("Some selected records has not been processed.");
                        return;
                    }

                    MessageBox.Show("Record/s successfully transmitted.");
                    //cboStatus.Text = MISCUtil.FOR_TRANSMITTAL;
                    RefreshLV();
                }
            }
            else
            {
                MessageBox.Show("You are not allowed to transmit record/s.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void validateForm()
        {
            // clear muna natin lahat ng error from previous validation.
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textRepName, "Representative name");
            Validations.ValidateRequired(errorProvider1, textContactNumber, "Contact number");
        }

        private void ReleasePayment()
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<MiscelleneousTax> SelectedMISCList = mainFormListViewHelper.GetSelectedMISCList();
                bool AllProcessed = true;

                foreach (MiscelleneousTax misc in SelectedMISCList)
                {
                    misc.ReleasedBy = loginUser.DisplayName;
                    misc.ReleasedDate = DateTime.Now;

                    if (misc.Status == MISCUtil.FOR_TRANSMITTAL || misc.Status == MISCUtil.TRANSMITTED)
                    {
                        misc.RepName = textRepName.Text;
                        misc.ContactNumber = textContactNumber.Text;
                        misc.Status = MISCUtil.RELEASED;
                        MISCDatabase.Update(misc);
                    }
                    else
                    {
                        AllProcessed = false;
                    }
                }

                if (AllProcessed == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                    return ;
                }

                MessageBox.Show("Record/s successfully released.");
                cboStatus.Text = MISCUtil.RELEASED;
                RefreshLV();
            }
        }

        private void Delete_Record()
        {
            if (loginUser.canDelete)
            {
                if (mainFormListViewHelper.haveSelectedRow())
                {
                    var Confirmation = MessageBox.Show("Are you sure you want to delete record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Confirmation == DialogResult.Yes)
                    {
                        MiscelleneousTax Misc_Record = mainFormListViewHelper.getSelectedMisc();
                        MISCDatabase.Delete(Misc_Record);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid action.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshLV();
            }
            else
            {
                MessageBox.Show("You are not allowed to delete a record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Change_isDuplicateRecord()
        {
            if (loginUser.isVerifier && (loginUser.DisplayName == "OGIE" || loginUser.DisplayName == "ARIS" || loginUser.DisplayName == "JOANAH" || loginUser.DisplayName == "EDILYL"))
            {
                if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MiscelleneousTax misc = mainFormListViewHelper.getSelectedMisc();

                    misc.DuplicateRecord = 1;
                    MISCDatabase.Update(misc);

                    MessageBox.Show("Successfully reverted status as non-duplicate record.");
                }
            }
            else
            {
                MessageBox.Show("You are not allowed to execute action.");
            }
        }

        private void Hold_Record()
        {
            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<MiscelleneousTax> SelectedMISCList = mainFormListViewHelper.GetSelectedMISCByStatus(MISCUtil.FOR_ASSESSMENT);

                bool SameStatus = mainFormListViewHelper.CheckSameStatus(MISCUtil.FOR_ASSESSMENT);
                bool AllProcessed = true;

                foreach (MiscelleneousTax misc in SelectedMISCList)
                {
                    misc.Status = MISCUtil.STATUS_PENDING;

                    if (misc.TransferredAmount >= misc.AmountToBePaid)
                    {
                        MISCDatabase.Update(misc);   
                    }
                    else
                    {
                        AllProcessed = false;
                    }
                }

                if (SameStatus == false || AllProcessed == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                    cboStatus.Text = MISCUtil.FOR_PAYMENT_VERIFICATION;
                }
                MessageBox.Show("Record/s on hold.");
                cboStatus.Text = MISCUtil.FOR_ASSESSMENT;
                RefreshLV();
            }
        }

        private void Done_Record()
        {
            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<MiscelleneousTax> SelectedMISCList = mainFormListViewHelper.GetSelectedMISCByStatus(MISCUtil.FOR_ASSESSMENT);

                bool SameStatus = mainFormListViewHelper.CheckSameStatus(MISCUtil.FOR_ASSESSMENT);
                bool AllProcessed = true;

                foreach (MiscelleneousTax misc in SelectedMISCList)
                {
                    misc.Status = MISCUtil.ACTION_DONE;

                    if (misc.TransferredAmount >= misc.AmountToBePaid)
                    {
                        MISCDatabase.Update(misc);
                    }
                    else
                    {
                        AllProcessed = false;
                    }
                }

                if (SameStatus == false || AllProcessed == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                    cboStatus.Text = MISCUtil.FOR_PAYMENT_VERIFICATION;
                }
                MessageBox.Show("Record/s' status successfully changed.");
                cboStatus.Text = MISCUtil.FOR_ASSESSMENT;
                RefreshLV();
            }
        }

        private void SetAction(string NewAction)
        {
            if (cboAction.Items.Contains(NewAction))
            {
                cboAction.Text = NewAction;
            }
        }

        private void ChangeAction()
        {
            if (mainFormListViewHelper.haveSelectedRow())
            {
                MiscelleneousTax misc = mainFormListViewHelper.getSelectedMisc();
                string Status = misc.Status;

                if (Status == MISCUtil.FOR_ASSESSMENT)
                {
                    SetAction(MISCUtil.ASSESS_RECORD);
                }

                else if(Status == MISCUtil.FOR_PAYMENT_VERIFICATION)
                {
                    SetAction(MISCUtil.VERIFY_PAYMENT);
                }

                else if (Status == MISCUtil.FOR_PAYMENT_VALIDATION)
                {
                    SetAction(MISCUtil.VALIDATE_PAYMENT);
                }

                else if (Status == MISCUtil.FOR_TRANSMITTAL)
                {
                    SetAction(MISCUtil.TRANSMIT);

                }
                else if (Status == MISCUtil.TRANSMITTED)
                {
                    SetAction(MISCUtil.RELEASE);

                }
            }
        }


        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (cboAction.Text == MISCUtil.ASSESS_RECORD)
            {
                AssessRecord();
            }

            else if(cboAction.Text == MISCUtil.VERIFY_PAYMENT)
            {
                VerifyPayment();
            }

            else if (cboAction.Text == MISCUtil.VALIDATE_PAYMENT)
            {
                ValidatePayment();
            }

            else if (cboAction.Text == MISCUtil.TRANSMIT)
            {
                TransmitPayment();
            }

            else if (cboAction.Text == MISCUtil.RELEASE)
            {
                ReleasePayment();
            }

            else if (cboAction.Text == MISCUtil.DELETED_RECORD)
            {
                Delete_Record();
            }

            else if (cboAction.Text == MISCUtil.TAG_DUPLICATE_RECORD)
            {
                Change_isDuplicateRecord();
            }

            else if (cboAction.Text == MISCUtil.ACTION_PENDING)
            {
                Hold_Record();
            }

            else if (cboAction.Text == MISCUtil.ACTION_DONE)
            {
                Done_Record();
            }
        }

        private void cboAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (loginUser.isVerifier && (loginUser.DisplayName == "OGIE") || (loginUser.DisplayName == "EDILYL"))
            //{
                //cboAction.Items.Clear();
                //cboAction.Items.Add(MISCUtil.VERIFY_PAYMENT);
                //cboAction.Items.Add(MISCUtil.TAG_DUPLICATE_RECORD);

                //cboAction.Text = MISCUtil.VERIFY_PAYMENT;
                //cboAction.Enabled = false;
            //}

            if (loginUser.isValidator && loginUser.MachNo != null)
            {
                cboAction.Text = MISCUtil.VALIDATE_PAYMENT;
                cboAction.Enabled = false;
            }

            if (cboAction.Text == RPTAction.VERIFY_PAYMENT && cboAction.Text == RPTAction.VALIDATE_PAYMENT)
            {
                //PAYMENT CHANNEL COMBOBOX AND LABEL.
                cboPaymentChannel.Visible = true;
                labelPaymentChannel.Visible = true;

                InitializePaymentChannel();
            }

            if (cboAction.Text == MISCUtil.RELEASE)
            {
                LabelRepName.Visible = true;
                textRepName.Visible = true;
                LabelContactNumber.Visible = true;
                textContactNumber.Visible = true;
            }
        }

        private void btnSearchDateStatus_Click(object sender, EventArgs e)
        {
            if (dtDateTo.Enabled = dtDate.Checked)
            {
                labelPaymentChannel.Enabled = true;
                cboPaymentChannel.Enabled = true;
            }
            else
            {
                labelPaymentChannel.Enabled = false;
                cboPaymentChannel.Enabled = false;
            }

            RefreshLV();
        }

        private void btnAddGcashPaymaya_Click(object sender, EventArgs e)
        {
            AddGcashPaymayaMISC addGcashPaymayaOccuPermit = new AddGcashPaymayaMISC();
            addGcashPaymayaOccuPermit.ShowDialog();
        }

        private List<string> getBankList()
        {
            List<string> BankList = new List<string>();
            string PaymentChannel = cboPaymentChannel.Text;

            if (PaymentChannel == RPTGcashPaymaya.BANK_TRANSFER)
            {
                List<RPTBank> bankList = RPTBankDatabase.SelectAllNot_E_Banks();
                foreach (RPTBank bank in bankList)
                {
                    BankList.Add(bank.BankName);
                }
            }
            else
            {
                BankList.Add(PaymentChannel);
            }
            return BankList;
        }

        private List<MiscelleneousTax> SearchByDateRangeAndStatus_PaymentChannel()
        {
            List<MiscelleneousTax> miscList = new List<MiscelleneousTax>();

            string Misc_Type = cboMiscType.Text;
            string Status = cboStatus.Text;
            DateTime DateFrom = dtDate.Value;
            DateTime DateTo = dtDateTo.Value;
            string Action = cboAction.Text;

            if (Status == MISCUtil.FOR_ASSESSMENT /*&& Action == MISCUtil.ASSESS_RECORD*/)
            {
                List<string> BankList = getBankList();
                miscList = MISCDatabase.SelectByDateFromToAndStatusAndPaymentChannelForAssessment(DateFrom, DateTo, Misc_Type, Status, BankList);
            }

            // filter by verification of payment and payment channel.
            else if (Status == MISCUtil.FOR_PAYMENT_VERIFICATION /*&& Action == MISCUtil.VERIFY_PAYMENT*/)
            {
                List<string> BankList = getBankList();
                miscList = MISCDatabase.SelectByDateFromToAndStatusAndPaymentChannelForVerification(DateFrom, DateTo, Misc_Type, Status, BankList);
            }

            else if (Status == MISCUtil.FOR_PAYMENT_VALIDATION /*&& Action == MISCUtil.VALIDATE_PAYMENT*/)
            {
                List<string> BankList = getBankList();
                miscList = MISCDatabase.SelectByDateFromToAndStatusAndPaymentChannelForValidation(DateFrom, DateTo, Misc_Type, Status, BankList);
            }

            else if (Status == MISCUtil.FOR_TRANSMITTAL)
            {
                List<string> BankList = getBankList();
                miscList = MISCDatabase.SelectByDateFromToAndStatusAndPaymentChannelAndForTransmittal(DateFrom, DateTo, Misc_Type, Status, BankList);
            }

            else if (Status == MISCUtil.RELEASED)
            {
                List<string> BankList = getBankList();
                miscList = MISCDatabase.SelectByDateFromToAndStatusAndPaymentChannelAndReleased(DateFrom, DateTo, Misc_Type, Status, BankList);
            }

            else if (Status == MISCUtil.TRANSMITTED)
            {
                List<string> BankList = getBankList();
                miscList = MISCDatabase.SelectByDateFromToAndStatusAndPaymentChannelAndTransmitted(DateFrom, DateTo, Misc_Type, Status, BankList);
            }

            return miscList;
        }

        private void cboPaymentChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshLV();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshLV();
        }

        //START: MOUSE DRAG DOWN SELECTS RECORDS IN LISTVIEW
        Int32 firstClickItemIndex = 0;
        public Boolean numInRange(Int32 num, Int32 first, Int32 last)
        {
            return first <= num && num <= last;
        }
        private void MISCinfoLV_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left && MISCinfoLV.HitTest(e.Location).Item != null)
                firstClickItemIndex = MISCinfoLV.HitTest(e.Location).Item.Index;
        }
        private void MISCinfoLV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                foreach (ListViewItem lvItem in MISCinfoLV.Items)
                    lvItem.Selected = true;
            }
        }
        private void MISCinfoLV_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left)
            {
                ListViewItem lvItem = MISCinfoLV.HitTest(e.Location).Item;
                if (lvItem != null)
                {
                    lvItem.Selected = true;
                    if (MISCinfoLV.SelectedItems.Count > 1)
                    {
                        Int32 firstSelected = MISCinfoLV.SelectedItems[0].Index;
                        Int32 lastSelected = MISCinfoLV.SelectedItems[MISCinfoLV.SelectedItems.Count - 1].Index;
                        foreach (ListViewItem tempLvItem in MISCinfoLV.Items)
                        {
                            if (numInRange(tempLvItem.Index, firstSelected, lastSelected) && (numInRange(tempLvItem.Index, lvItem.Index, firstClickItemIndex) || numInRange(tempLvItem.Index, firstClickItemIndex, lvItem.Index)))
                            {
                                tempLvItem.Selected = true;
                            }
                            else
                            {
                                tempLvItem.Selected = false;
                            }
                        }
                    }
                }
            }
        }
        //END: MOUSE DRAG DOWN SELECTS RECORDS IN LISTVIEW

        private static decimal totalAmount2Pay = 0;
        private static decimal totalAmountTrans = 0;

        private void MISCinfoLV_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int index = e.ItemIndex;

            textRecSelected.Text = MISCinfoLV.SelectedItems.Count.ToString();

            if (MISCinfoLV.SelectedItems.Count == 0)
            {
                totalAmount2Pay = 0;
                totalAmountTrans = 0;
            }

            if (MISCinfoLV.SelectedItems.Count == 1)
            {
                //string MiscIDString = MISCinfoLV.Items[index].Text;
                string MiscIDString = MISCinfoLV.SelectedItems[0].Text;
                long MiscID = Convert.ToInt64(MiscIDString);

                MiscelleneousTax misc = MISCDatabase.Get(MiscID);
                totalAmount2Pay = misc.AmountToBePaid;
                totalAmountTrans = misc.TransferredAmount;

                ChangeAction();
            }

            if (MISCinfoLV.SelectedItems.Count > 1)
            {
                string MiscIDString = MISCinfoLV.Items[index].Text;
                long MiscID = Convert.ToInt64(MiscIDString);

                MiscelleneousTax misc = MISCDatabase.Get(MiscID);
                if (e.IsSelected)
                {
                    totalAmount2Pay += misc.AmountToBePaid;
                    totalAmountTrans += misc.TransferredAmount;
                }
                else
                {
                    totalAmount2Pay -= misc.AmountToBePaid;
                    totalAmountTrans -= misc.TransferredAmount;
                }

            }
            textTotalAmount2Pay.Text = totalAmount2Pay.ToString();
            textTotalAmountTransferred.Text = totalAmountTrans.ToString();
        }

        private void textTotalAmount2Pay_TextChanged(object sender, EventArgs e)
        {
            decimal ConvertedTotalAmountToPay = decimal.Parse(textTotalAmount2Pay.Text, System.Globalization.NumberStyles.Currency);
            textTotalAmount2Pay.Text = ConvertedTotalAmountToPay.ToString("N2");
        }

        private void textTotalAmountTransferred_TextChanged(object sender, EventArgs e)
        {
            decimal ConvertedTotalAmountTransferred = decimal.Parse(textTotalAmountTransferred.Text, System.Globalization.NumberStyles.Currency);
            textTotalAmountTransferred.Text = ConvertedTotalAmountTransferred.ToString("N2");
        }

        private void MISCinfoLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainFormListViewHelper.haveSelectedRow())
            {
                MiscelleneousTax misc = mainFormListViewHelper.getSelectedMisc();

                //Clipboard.SetText(misc.OPATrackingNum);
                Clipboard.SetText(misc.OrderOfPaymentNum);


                if (misc.MiscType == Misc_Type.MARKET)
                {
                    //string[] market_TaxpayersName = misc.TaxpayersName.Split(' ');
                    //Clipboard.SetText(market_TaxpayersName[0].Trim());

                    if ((loginUser.DisplayName == "NIKKO" | loginUser.DisplayName == "RAYMOND") & misc.Status == MISCUtil.FOR_TRANSMITTAL)
                    {
                        Clipboard.SetText(misc.RequestingParty);
                    }
                    else
                    {
                        Clipboard.SetText(misc.OrderOfPaymentNum);
                    }
                }
                if (misc.MiscType == Misc_Type.LIQUOR)
                {
                    if (loginUser.isValidator)
                    {
                        Clipboard.SetText(misc.OrderOfPaymentNum);
                    }
                    else
                    {
                        //copy MP NUMBER under OPATRACKINGNUMBER column.
                        Clipboard.SetText(misc.OPATrackingNum);
                    }
                }
            }
        }

        private void MiscelleneousTaxForm_Load(object sender, EventArgs e)
        {
            if (loginUser.isVerifier && (loginUser.DisplayName == "OGIE" /*|| loginUser.DisplayName == "EDILYL"*/))
            {
                cboAction.Items.Clear();
                cboAction.Items.Add(MISCUtil.VERIFY_PAYMENT);
                cboAction.Items.Add(MISCUtil.TAG_DUPLICATE_RECORD);
                cboAction.Items.Add(MISCUtil.DELETED_RECORD);

                cboAction.Text = MISCUtil.VERIFY_PAYMENT;
                //cboAction.Enabled = false;
            }

            if (loginUser.isValidator && (loginUser.MachNo != null))
            {
                cboStatus.Text = MISCUtil.FOR_PAYMENT_VALIDATION;
                cboStatus.Enabled = false;
            }
        }
    }
}