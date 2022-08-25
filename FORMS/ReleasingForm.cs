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
    public partial class ReleasingForm : Form
    {
        public ReleasingForm()
        {
            InitializeComponent();
            InitializeStatus();
            InitializeAction();
            cboStatus.Enabled = false;
            cboAction.Enabled = false;

        }
        public void InitializeStatus()
        {
            cboStatus.Items.Add(RPTStatus.OR_PICKUP);
        }

        public void InitializeAction()
        {
            cboAction.Items.Add(RPTAction.RELEASE_OR);
        }
        private void PopulateListView(List<RealPropertyTax> rptList)
        {
            ListViewUtil.copyFromListToListview<RealPropertyTax>(rptList, RPTInfoLV, new List<string>
            { "RptID", "TaxDec", "TaxPayerName", "AmountToPay", "AmountTransferred", "TotalAmountTransferred", "ExcessShortAmount",
                "Bank", "YearQuarter", "Status",
            "EncodedBy", "EncodedDate", "RefNum", "RequestingParty", "RPTremarks", "SentBy", "SentDate",});

            ListViewUtil.copyFromListToListview<RealPropertyTax>(rptList, VerAndValLV, new List<string>
            { "RptID", "LocCode", "TaxDec", "BilledBy", "BillCount", "BilledDate", "VerifiedBy", "PaymentDate", "VerifiedDate", "ValidatedBy", "ValidatedDate",
               "UploadedBy", "UploadedDate", "ReleasedBy", "ReleasedDate", "VerRemarks", "ValRemarks", "ReleasedRemarks"});
        }

        public void RefreshListView()
        {
            List<string> StatusList = new List<string>();

            StatusList.Add(cboStatus.Text);

            List<RealPropertyTax> rptList;

            if (dtDate.Checked)
            {
                dtDateTo.Enabled = true;
                DateTime encodedDateFrom = dtDate.Value;
                DateTime encodedDateTo = dtDateTo.Value;

                //rptList = RPTDatabase.SelectByDateAndStatus(dtDate.Value, StatusList);
                rptList = RPTDatabase.SelectByDateFromToAndStatus(encodedDateFrom, encodedDateTo, StatusList);

            }
            else
            {
                dtDateTo.Enabled = false;
                rptList = RPTDatabase.SelectByStatus(StatusList);
            }
            PopulateListView(rptList);
        }

        private void ReleasingForm_Load(object sender, EventArgs e)
        {
            cboStatus.SelectedIndex = 0;
            cboAction.SelectedIndex = 0;
        }

        private void btnSearchDateStatus_Click(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void textTDN_TextChanged(object sender, EventArgs e)
        {
            List<string> StatusList = new List<string>();

            StatusList.Add(cboStatus.Text);

            string taxdec = textTDN.Text;
            //string status = cboStatus.Text;

            //List<RealPropertyTax> rptList = RPTDatabase.SelectByTaxDec(taxdec);
            List<RealPropertyTax> rptList = RPTDatabase.SelectBySameGroupReleasing(taxdec, StatusList);

            PopulateListView(rptList);
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListView();
        }
    }
}
