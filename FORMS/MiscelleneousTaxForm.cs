using SampleRPT1.FORMS;
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

        public MiscelleneousTaxForm(Form parentForm)
        {
            InitializeComponent();
            InitializeMiscType();
            InitializeStatus();

            INSTANCE = this;
            MdiParent = parentForm;
            ControlBox = false;
            dtDate.Value = DateTime.Now;
            dtDateTo.Value = DateTime.Now;
        }

        public void InitializeStatus()
        {
            foreach (string status in MISCtypeUtil.ALL_OCCU_PERMIT_STATUS)
            {
                cboStatus.Items.Add(status);
            }
        }

        public void InitializeData()
        {
            List<MiscelleneousOccuPermit> miscList;

            string miscType = cboMiscType.Text;
            miscList = MISCDatabase.SelectLatest(miscType);
            PopulateLVMISC(miscList);
        }

        public void InitializeMiscType()
        {
            cboMiscType.Items.Clear();

            foreach (string misc in MISCtypeUtil.ALL_MISC_TYPE)
            {
                cboMiscType.Items.Add(misc);
            }
            cboMiscType.SelectedIndex = 0;
        }

        public void RefreshOccuPermit()
        {
            cboMiscType.Text = MISCtypeUtil.OCCUPATIONAL_PERMIT;
            InitializeData();
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
            ListViewUtil.copyFromListToListview<MiscelleneousOccuPermit>(MiscList, MISCinfoLV, MISCtypeUtil.MISC_OCCPERMIT_PROPERTY_NAMES);

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

            if (cboMiscType.Text == MISCtypeUtil.OCCUPATIONAL_PERMIT)
            {
                foreach (string item in MISCtypeUtil.MISC_OCCPERMIT_COLUMN_NAMES)
                {
                    MISCinfoLV.Columns.Add(item);
                }
                InitializeData();
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

        }

        private void btnSearchDateStatus_Click(object sender, EventArgs e)
        {

        }

        private void btnAddGcashPaymaya_Click(object sender, EventArgs e)
        {
            AddGcashPaymayaOccuPermitForm addGcashPaymayaOccuPermit = new AddGcashPaymayaOccuPermitForm();
            addGcashPaymayaOccuPermit.ShowDialog();
        }
    }
}
