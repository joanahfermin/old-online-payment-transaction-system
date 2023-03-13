using SampleRPT1.MODEL;
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
    public partial class MISC_ViewHistoryForm : Form
    {
        public static MISC_ViewHistoryForm INSTANCE;
        private long miscID;
        private List<MiscOccuPermit_Audit> auditList;

        public MISC_ViewHistoryForm(Form parentForm)
        {
            InitializeComponent();

            INSTANCE = this;
            MdiParent = parentForm;
            ControlBox = false;
        }

        public void Show()
        {
            base.Show();
            WindowState = FormWindowState.Maximized;
        }

        public void setMiscID(long MiscID)
        {
            this.miscID = MiscID;
            MiscelleneousTax misc = MISCDatabase.Get(MiscID);
            auditList = MISCDatabase.SelectAudits(MiscID);

            List<string> ColumnNames = MISCUtil.LIST_VIEW_COLUMN_NAMES_MAPPING[misc.MiscType];
            foreach (string item in ColumnNames)
            {
                MISCinfoLV.Columns.Add(item);
            }

            List<string> PropertyNames = MISCUtil.LIST_VIEW_PROPERTY_NAMES_MAPPING[misc.MiscType];
            ListViewUtil.copyFromListToListview<MiscOccuPermit_Audit>(auditList, MISCinfoLV, PropertyNames);

            //if (auditList != null)
            //{
            //    foreach (string item in MISCUtil.MISC_OCCPERMIT_COLUMN_NAMES)
            //    {
            //        MISCinfoLV.Columns.Add(item);
            //    }
            //    //AutoResizeLV_Column(MISCinfoLV, -2);
            //    //AutoResizeLV_ColumnContent(MISCinfoLV, -2);
            //}

            //ListViewUtil.copyFromListToListview<MiscOccuPermit_Audit>(auditList, MISCinfoLV, new List<string>
            //{ "MiscID", "MiscType", "TaxpayersName", "OrderOfPaymentNum", "ModeOfPayment", "OPATrackingNum", "AmountToBePaid",
            //    "TransferredAmount", "ExcessShort", "PaymentDate", "Status",
            //     "RequestingParty", "Remarks", "VerifiedBy", "VerifiedDate", "LBPDate", "ValidatedBy", "ValidatedDate", "RefNum", "TransmittedBy", "TransmittedDate",
            //     "EncodedBy", "EncodedDate", "ReleasedBy", "ReleasedDate"});

            //foreach (MiscOccuPermit_Audit audit in auditList)
            //{
            //    ListViewItem item = new ListViewItem(audit.MiscID.ToString());

            //    item.SubItems.Add(audit.MiscType.ToString());
            //    item.SubItems.Add(audit.TaxpayersName.ToString());
            //    item.SubItems.Add(audit.OrderOfPaymentNum.ToString());
            //    MISCinfoLV.Items.Add(item);
            //}

            MISCinfoLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            MISCinfoLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

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


        private void btnRestore_Click(object sender, EventArgs e)
        {
            int numberOFitems = MISCinfoLV.Items.Count;

            if (MISCinfoLV.SelectedItems.Count == 0)
            {
                MessageBox.Show("No record selected");
                return;
            }

            if (MISCinfoLV.Items[numberOFitems - 1].Selected)
            {
                MessageBox.Show("Cannot restore a latest updated record.");
                return;
            }

            int SelectedIndex = MISCinfoLV.SelectedItems[0].Index;
            MiscOccuPermit_Audit audit = auditList[SelectedIndex];

            if (audit.Action == "REVERT")
            {
                MessageBox.Show("Selected record is a revert action.");
                return;
            }

            MISCDatabase.Revert(audit);
            MessageBox.Show("Success.");

            MiscelleneousTaxForm.INSTANCE.RefreshLV();
            MiscelleneousTaxForm.INSTANCE.Show();
        }
    }
}
