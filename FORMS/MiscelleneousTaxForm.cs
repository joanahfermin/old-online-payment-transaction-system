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

        public MiscelleneousTaxForm(Form parentForm)
        {
            InitializeComponent();
            InitializeMiscType();
            InitializeStatus();
            InitializeAction();

            cboStatus.Text = MISCUtil.FOR_PAYMENT_VERIFICATION;
            cboAction.Text = MISCUtil.VERIFY_PAYMENT;

            INSTANCE = this;
            MdiParent = parentForm;
            ControlBox = false;
            dtDate.Value = DateTime.Now;
            dtDateTo.Value = DateTime.Now;
        }

        public void InitializeStatus()
        {
            foreach (string status in MISCUtil.ALL_OCCU_PERMIT_STATUS)
            {
                cboStatus.Items.Add(status);
            }
        }

        public void RefreshLV()
        {
            lastSearchAction = SEARCH_BY_DATE_STATUS;

            List<MiscelleneousOccuPermit> miscList;

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

            //if (loginUser.isVerifier || loginUser.isValidator || loginUser.isUploader)
            //{
                cboPaymentChannel.Visible = true;

                foreach (string banks in RPTGcashPaymaya.ALL_PAYMENT_CHANNEL)
                {
                    cboPaymentChannel.Items.Add(banks);
                }
            //}
        }

        public void RefreshOccuPermit()
        {
            cboMiscType.Text = MISCUtil.OCCUPATIONAL_PERMIT;
            RefreshLV();
        }

        public void SearchOccuPermitRecord()
        {
            string miscRecord = textSearch.Text;
            List<MiscelleneousOccuPermit> miscRecordList = MISCDatabase.SearchOccuPermitRecord(miscRecord);

            PopulateLVMISC(miscRecordList);
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

        private void PopulateLVMISC(List<MiscelleneousOccuPermit> MiscList)
        {
            ListViewUtil.copyFromListToListview<MiscelleneousOccuPermit>(MiscList, MISCinfoLV, MISCUtil.MISC_OCCPERMIT_PROPERTY_NAMES);

            for (int i = 0; i < MiscList.Count; i++)
            {
                MiscelleneousOccuPermit misc = MiscList[i];
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
                    //item.Selected = true;
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
        }

        private void MISCinfoLV_DoubleClick(object sender, EventArgs e)
        {
            string MiscIDString = MISCinfoLV.SelectedItems[0].Text;
            long miscID = Convert.ToInt64(MiscIDString);

            AddMISCrecord addMISCrecord = new AddMISCrecord(miscID);
            addMISCrecord.ShowDialog();

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

        private void btnExecute_Click(object sender, EventArgs e)
        {

        }

        private void cboAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAction.Text == RPTAction.VERIFY_PAYMENT)
            {
                //PAYMENT CHANNEL COMBOBOX AND LABEL.
                cboPaymentChannel.Visible = true;
                labelPaymentChannel.Visible = true;
                InitializePaymentChannel();
            }
        }

        private void btnSearchDateStatus_Click(object sender, EventArgs e)
        {
            dtDateTo.Enabled = dtDate.Checked;

            //List<MiscelleneousOccuPermit> miscList;

            //// If date range is checked, search by date range and status. Otherwise, just search by status.
            //if (dtDate.Checked)
            //{
            //    miscList = SearchByDateRangeAndStatus();
            //}
            //else
            //{
            //    string Status = cboStatus.Text;
            //    miscList = MISCDatabase.SelectByStatus(Status);
            //}
            RefreshLV();
        }

        private void btnAddGcashPaymaya_Click(object sender, EventArgs e)
        {
            AddGcashPaymayaOccuPermitForm addGcashPaymayaOccuPermit = new AddGcashPaymayaOccuPermitForm();
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

        private List<MiscelleneousOccuPermit> SearchByDateRangeAndStatus()
        {
            List<MiscelleneousOccuPermit> miscList = new List<MiscelleneousOccuPermit>();

            string Status = cboStatus.Text;
            DateTime paymentDateFrom = dtDate.Value;
            DateTime paymentDateTo = dtDateTo.Value;
            string Action = cboAction.Text;
            //string EncodedBy = cboEncodedBy.Text;
            //string ValidatedBy = cboValidatedBy.Text;

            // filter by verification of payment and payment channel.
            if (Status == MISCUtil.FOR_PAYMENT_VERIFICATION && Action == MISCUtil.VERIFY_PAYMENT)
            {
                List<string> BankList = getBankList();
                miscList = MISCDatabase.SelectByDateFromToAndStatusAndPaymentChannel(paymentDateFrom, paymentDateTo, Status, BankList);
            }
            return miscList;
        }
    }
}
