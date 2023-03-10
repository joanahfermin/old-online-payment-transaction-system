using Microsoft.VisualBasic;
using SampleRPT1.FORMS;
using SampleRPT1.MODEL;
using SampleRPT1.Service;
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

            cboStatus.Text = MISCUtil.FOR_PAYMENT_VERIFICATION;
            cboAction.Text = MISCUtil.VERIFY_PAYMENT;

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


        public void RefreshLV()
        {
            lastSearchAction = SEARCH_BY_DATE_STATUS;

            List<MiscelleneousTax> miscList;

            // If date range is checked, search by date range and status. Otherwise, just search by status.
            if (dtDate.Checked)
            {
                miscList = SearchByDateRangeAndStatus();
            }
            else
            {
                string Status = cboStatus.Text;
                miscList = MISCDatabase.SelectByStatus(Status);
            }

            PopulateLVMISC(miscList);

            MISCinfoLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            MISCinfoLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        public void InitializeMiscType()
        {
            cboMiscType.Items.Clear();

            foreach (string misc in MISCUtil.ALL_MISC_TYPE)
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
            cboMiscType.Text = MISCUtil.OCCUPATIONAL_PERMIT;
            RefreshLV();
        }

        public void SearchOccuPermitRecord()
        {
            string miscRecord = textSearch.Text;
            List<MiscelleneousTax> miscRecordList = MISCDatabase.SearchOccuPermitRecord(miscRecord);

            PopulateLVMISC(miscRecordList);

            //MISCinfoLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //MISCinfoLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        public void Show()
        {
            base.Show();
            WindowState = FormWindowState.Maximized;
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            AddMISCrecord addMISCrecord = new AddMISCrecord();
            addMISCrecord.ShowDialog();
        }

        private void PopulateLVMISC(List<MiscelleneousTax> MiscList)
        {
            ListViewUtil.copyFromListToListview<MiscelleneousTax>(MiscList, MISCinfoLV, MISCUtil.MISC_OCCPERMIT_PROPERTY_NAMES);

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
                if (item.SubItems[3].Text.Contains(miscRecord) || item.SubItems[5].Text.Contains(miscRecord))
                {
                    MISCinfoLV.Focus();
                }
            }
        }

        private void cboMiscType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MISCinfoLV.Columns.Clear();

            if (cboMiscType.Text == MISCUtil.OCCUPATIONAL_PERMIT)
            {
                foreach (string item in MISCUtil.MISC_OCCPERMIT_COLUMN_NAMES)
                {
                    MISCinfoLV.Columns.Add(item);
                }
                RefreshLV();
            }
            MISCinfoLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            MISCinfoLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //AutoResizeLV_Column(MISCinfoLV, -2);
            //AutoResizeLV_ColumnContent(MISCinfoLV, -2);
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

            AddMISCrecord addMISCrecord = new AddMISCrecord(RetrieveMiscID);
            addMISCrecord.ShowDialog();
        }

        private void MISCinfoLV_DoubleClick(object sender, EventArgs e)
        {
            //string MiscIDString = MISCinfoLV.SelectedItems[0].Text;
            //long miscID = Convert.ToInt64(MiscIDString);

            MiscelleneousTax RetrieveMisc = mainFormListViewHelper.getSelectedMisc();

            if (RetrieveMisc.Status == MISCUtil.FOR_PAYMENT_VERIFICATION)
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

        private void textSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchOccuPermitRecord();
                HighlightRecord();

                if (MISCinfoLV.SelectedItems.Count > 0)
                {
                    int index = MISCinfoLV.SelectedItems[0].Index;
                    MISCinfoLV.EnsureVisible(index);
                }
            }
        }

        private void VerifyPayment()
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

        private void ValidatePayment()
        {
            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<MiscelleneousTax> SelectedMISCList = mainFormListViewHelper.GetSelectedMISCByStatus(MISCUtil.FOR_PAYMENT_VALIDATION);

                foreach (var misc in SelectedMISCList)
                {
                    misc.ValidatedBy = loginUser.DisplayName;
                    misc.ValidatedDate = DateTime.Now;
                    misc.Status = MISCUtil.FOR_TRANSMITTAL;

                    MISCDatabase.Update(misc);
                }
                MessageBox.Show("Record/s successfully validated.");
                cboStatus.Text = MISCUtil.FOR_TRANSMITTAL;
                RefreshLV();
            }
        }

        private void TransmitPayment()
        {
            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<MiscelleneousTax> SelectedMISCList = mainFormListViewHelper.GetSelectedMISCByStatus(MISCUtil.FOR_TRANSMITTAL);

                foreach (var misc in SelectedMISCList)
                {
                    misc.TransmittedBy = loginUser.DisplayName;
                    misc.TransmittedDate = DateTime.Now;
                    misc.Status = MISCUtil.TRANSMITTED;

                    MISCDatabase.Update(misc);
                }

                MessageBox.Show("Record/s successfully transmitted.");
                //cboStatus.Text = MISCUtil.FOR_TRANSMITTAL;
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

                if (Status == MISCUtil.FOR_PAYMENT_VERIFICATION)
                {
                    SetAction(MISCUtil.VERIFY_PAYMENT);
                }

                else if (Status == MISCUtil.FOR_PAYMENT_VALIDATION)
                {
                    SetAction(MISCUtil.VALIDATE_PAYMENT);
                }

                else if(Status == MISCUtil.FOR_TRANSMITTAL)
                {
                    SetAction(MISCUtil.TRANSMIT);
                }
            }
        }


        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (cboAction.Text == MISCUtil.VERIFY_PAYMENT)
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
            else if (cboAction.Text == MISCUtil.DELETED_RECORD)
            {
                Delete_Record();
            }
        }

        private void cboAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAction.Text == RPTAction.VERIFY_PAYMENT && cboAction.Text == RPTAction.VALIDATE_PAYMENT)
            {
                //PAYMENT CHANNEL COMBOBOX AND LABEL.
                cboPaymentChannel.Visible = true;
                labelPaymentChannel.Visible = true;
                InitializePaymentChannel();
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

        private List<MiscelleneousTax> SearchByDateRangeAndStatus()
        {
            List<MiscelleneousTax> miscList = new List<MiscelleneousTax>();

            string Status = cboStatus.Text;
            DateTime DateFrom = dtDate.Value;
            DateTime DateTo = dtDateTo.Value;
            string Action = cboAction.Text;

            // filter by verification of payment and payment channel.
            if (Status == MISCUtil.FOR_PAYMENT_VERIFICATION && Action == MISCUtil.VERIFY_PAYMENT)
            {
                List<string> BankList = getBankList();
                miscList = MISCDatabase.SelectByDateFromToAndStatusAndPaymentChannelForVerification(DateFrom, DateTo, Status, BankList);
            }

            else if (Status == MISCUtil.FOR_PAYMENT_VALIDATION && Action == MISCUtil.VALIDATE_PAYMENT)
            {
                List<string> BankList = getBankList();
                miscList = MISCDatabase.SelectByDateFromToAndStatusAndPaymentChannelForValidation(DateFrom, DateTo, Status, BankList);
            }

            else if (Status == MISCUtil.FOR_TRANSMITTAL)
            {
                List<string> BankList = getBankList();
                miscList = MISCDatabase.SelectByDateFromToAndStatusAndForTransmittal(DateFrom, DateTo, Status);
            }

            else if (Status == MISCUtil.TRANSMITTED)
            {
                miscList = MISCDatabase.SelectByDateFromToAndStatusAndTransmitted(DateFrom, DateTo, Status);
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

        private void MISCinfoLV_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ChangeAction();
        }
    }
}
