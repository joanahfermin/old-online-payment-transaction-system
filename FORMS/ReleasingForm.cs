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
    public partial class ReleasingForm : Form
    {
        private long RptID;

        public ReleasingForm()
        {
            InitializeComponent();
            dtDate.Value = DateTime.Now;
            dtDateTo.Value = DateTime.Now;

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
            textTDN.Select();

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

        private bool CheckSameStatus(string ExpectedStatus)
        {
            bool SameStatus = true;

            for (int i = 0; i < RPTInfoLV.SelectedItems.Count; i++)
            {
                if (RPTInfoLV.SelectedItems[i].SubItems[9].Text != ExpectedStatus)
                {
                    SameStatus = false;
                }
            }
            return SameStatus;
        }

        private List<RealPropertyTax> GetSelectedRPTByStatus(string ExpectedStatus)
        {
            List<RealPropertyTax> SelectedRPTByStatus = new List<RealPropertyTax>();

            for (int i = 0; i < RPTInfoLV.SelectedItems.Count; i++)
            {
                if (RPTInfoLV.SelectedItems[i].SubItems[9].Text == ExpectedStatus)
                {
                    string RptId = RPTInfoLV.SelectedItems[i].Text;
                    RptID = Convert.ToInt32(RptId);

                    RealPropertyTax rpt = RPTDatabase.Get(RptID);
                    SelectedRPTByStatus.Add(rpt);
                }
            }
            return SelectedRPTByStatus;
        }

        private void validateForm()
        {
            // clear muna natin lahat ng error from previous validation.
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textRepName, "Representative name");
            Validations.ValidateRequired(errorProvider1, textRepContactNum, "Contact number");
        }

        private void ReleaseReceipt()
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<RealPropertyTax> SelectedRPTList = GetSelectedRPTByStatus(RPTStatus.OR_PICKUP);

                foreach (var rpt in SelectedRPTList)
                {
                    rpt.ReleasedBy = GlobalVariables.RPTUSER.DisplayName;
                    rpt.ReleasedDate = DateTime.Now;
                    rpt.Status = RPTStatus.RELEASED;
                    rpt.RepName = textRepName.Text;
                    rpt.ContactNumber = textRepContactNum.Text;
                    rpt.is_Released = true;

                    if (checkAutLetter.Checked)
                    {
                        rpt.WithAuthorizationLetter = true;
                    }
                    else
                    {
                        continue;
                    }

                    RPTDatabase.Update(rpt);

                    MessageBox.Show("Receipt successfully released.");
                }

                if (CheckSameStatus(RPTStatus.OR_PICKUP) == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                }
            }
            textRepName.Clear();
            textRepContactNum.Clear();
            checkAutLetter.Checked = false;

            //cboStatus.Text = RPTStatus.RELEASED;
            RefreshListView();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            ReleaseReceipt();
        }
    }
}
