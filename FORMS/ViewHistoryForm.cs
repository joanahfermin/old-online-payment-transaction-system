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
    public partial class ViewHistoryForm : Form
    {
        private long RptID;
        private List<RealPropertyTaxAudit> auditList;

        public ViewHistoryForm()
        {
            InitializeComponent();
        }

        public void setRpdID(long RptID)
        {
            this.RptID = RptID;
            auditList = RPTDatabase.SelectAudits(RptID);

            ListViewUtil.copyFromListToListview<RealPropertyTaxAudit>(auditList, RPTInfoLV, new List<string>
            { "RptID", "TaxDec", "TaxPayerName", "AmountToPay", "AmountTransferred", "TotalAmountTransferred", "ExcessShortAmount",
                "Bank", "YearQuarter", "Status",
            "EncodedBy", "EncodedDate", "RefNum", "RequestingParty", "RPTremarks", "SentBy", "SentDate",});

            ListViewUtil.copyFromListToListview<RealPropertyTaxAudit>(auditList, VerAndValLV, new List<string>
            { "RptID", "LocCode", "TaxDec", "BilledBy", "BillCount", "BilledDate", "VerifiedBy", "PaymentDate", "VerifiedDate", "ValidatedBy", "ValidatedDate",
               "UploadedBy", "UploadedDate", "ReleasedBy", "ReleasedDate", "VerRemarks", "ValRemarks", "ReleasedRemarks", "LastUpdateBy", "LastUpdateDate", "Action"});

        }

        private void RPTInfoLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < VerAndValLV.Items.Count; i++)
            {
                VerAndValLV.Items[i].Selected = RPTInfoLV.Items[i].Selected;
            }
        }

        private void VerAndValLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < VerAndValLV.Items.Count; i++)
            {
                RPTInfoLV.Items[i].Selected = VerAndValLV.Items[i].Selected;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (RPTInfoLV.SelectedItems.Count == 0)
            {
                MessageBox.Show("No record selected");
                return;
            }
            if (RPTInfoLV.Items[0].Selected)
            {
                MessageBox.Show("Selected record is the latest.");
                return;
            }
            int SelectedIndex = RPTInfoLV.SelectedItems[0].Index;
            RealPropertyTaxAudit audit = auditList[SelectedIndex];
            if (audit.Action == "REVERT")
            {
                MessageBox.Show("Selected record is a revert action.");
                return;
            }
            RPTDatabase.Revert(audit);
            MessageBox.Show("Success.");
            GlobalVariables.MAINFORM.RefreshListView();
            GlobalVariables.MAINFORM.Show();
            GlobalVariables.MAINFORM.WindowState = FormWindowState.Maximized;
        }
    }
}
