using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.FORMS
{
    class MainFormRPTListViewHelper
    {
        private ListView RPTInfoLV;
        private ListView VerAndValLV;

        public MainFormRPTListViewHelper(ListView RPTInfoLV, ListView VerAndValLV)
        {
            this.RPTInfoLV = RPTInfoLV;
            this.VerAndValLV = VerAndValLV;
        }

        /// <summary>
        /// Given an rptList, populate the top and bottom list views.  Then change the highlight colors according to some rules.
        /// </summary>
        public void PopulateListView(List<RealPropertyTax> rptList)
        {
            // populate top list view
            ListViewUtil.copyFromListToListview<RealPropertyTax>(rptList, RPTInfoLV, new List<string>
            { "RptID", "TaxDec", "TaxPayerName", "AmountToPay", "AmountTransferred", "TotalAmountTransferred", "ExcessShortAmount",
                "Bank", "YearQuarter", "Quarter", "PaymentType", "BillingSelection", "Status",
            "EncodedBy", "EncodedDate", "RefNum", "RequestingParty", "RPTremarks", "SentBy", "SentDate",});

            // populate bottom list view
            ListViewUtil.copyFromListToListview<RealPropertyTax>(rptList, VerAndValLV, new List<string>
            { "RptID", "LocCode", "TaxDec", "BilledBy", "BillCount", "BilledDate", "VerifiedBy", "PaymentDate", "VerifiedDate", "ValidatedBy", "ValidatedDate",
               "UploadedBy", "UploadedDate", "ReleasedBy", "ReleasedDate", "VerRemarks", "ValRemarks", "ReleasedRemarks"});

            // Change highlight color depending on business cases.
            for (int i = 0; i < rptList.Count; i++)
            {
                RealPropertyTax rpt = rptList[i];
                ListViewItem topItem = RPTInfoLV.Items[i];
                ListViewItem bottomItem = VerAndValLV.Items[i];

                //displaying of same reference number that colors the entire row, except for e-tranfer payments.
                if (rpt.RefNum != null && rpt.RefNum.Length > 0 && rpt.TotalAmountTransferred != 0 && RPTGcashPaymaya.isNotElectronicBankName(rpt.Bank))
                {
                    topItem.BackColor = Color.LightYellow;
                    bottomItem.BackColor = Color.LightYellow;
                }

                //displaying of same reference number but doesn't have b.ground color, these are gcash/paymaya and online banking.
                if (rpt.RefNum != null && rpt.RefNum.Length > 0 && RPTGcashPaymaya.isNotElectronicBankName(rpt.Bank))
                {
                    topItem.BackColor = Color.LightYellow;
                    bottomItem.BackColor = Color.LightYellow;
                }

                //if row has balance, b.ground color: red. 
                if (rpt.ExcessShortAmount < 0 && rpt.AmountTransferred != 0)
                {
                    topItem.BackColor = Color.LightCoral;
                    bottomItem.BackColor = Color.LightCoral;
                }
                else if (rpt.ExcessShortAmount > 0 && rpt.AmountTransferred > 0)
                {
                    topItem.BackColor = Color.LightGreen;
                    bottomItem.BackColor = Color.LightGreen;
                }

                //displaying of insufficient payment record.
                if (rpt.TotalAmountTransferred < rpt.AmountToPay && rpt.TotalAmountTransferred != 0)
                {
                    topItem.BackColor = Color.LightCoral;
                    bottomItem.BackColor = Color.LightCoral;
                }
            }
        }

        /// <summary>
        /// Copy the same highlighted items when bottom list view is changed
        /// </summary>
        public void VerAndValLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerAndValLV.SelectedItems.Count == 1)
            {
                for (int i = 0; i < VerAndValLV.Items.Count; i++)
                {
                    RPTInfoLV.Items[i].Selected = VerAndValLV.Items[i].Selected;
                }
            }
        }

        /// <summary>
        /// Copy the same highlighted items when top list view is changed
        /// </summary>
        public void RPTInfoLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RPTInfoLV.SelectedItems.Count == 1)
            {
                for (int i = 0; i < RPTInfoLV.Items.Count; i++)
                {
                    VerAndValLV.Items[i].Selected = RPTInfoLV.Items[i].Selected;
                }
            }
            else
            {
                foreach (ListViewItem item in VerAndValLV.SelectedItems)
                {
                    item.Selected = false;
                }
            }
        }

        /// <summary>
        /// Get the RPT from database, from the first selected record in the list view
        /// </summary>
        public RealPropertyTax getSelectedRpt()
        {
            RealPropertyTax rpt = null;

            if (haveSelectedRow())
            {
                string RptIDString = RPTInfoLV.SelectedItems[0].Text;
                long RptID = Convert.ToInt64(RptIDString);
                rpt = RPTDatabase.Get(RptID);
            }

            return rpt;
        }

        /// <summary>
        /// Check if there is a row selected from the list view.
        /// </summary>
        public bool haveSelectedRow()
        {
            if (RPTInfoLV.SelectedItems.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get the RPTID from the first selected record in the list view
        /// </summary>
        public long getSelectedRptID()
        {
            long RptID = 0;
            if (haveSelectedRow())
            {
                string RptIDString = RPTInfoLV.SelectedItems[0].Text;
                RptID = Convert.ToInt64(RptIDString);
            }
            return RptID;
        }

        /// <summary>
        /// Get the list of RPTID of all the items selected in the list view.
        /// </summary>
        public List<long> getSelectedRptIDList()
        {
            List<long> RptIDList = new List<long>();
            foreach (ListViewItem item in RPTInfoLV.SelectedItems)
            {
                string RptIdString = item.Text;
                long RptID = Convert.ToInt64(RptIdString);
                RptIDList.Add(RptID);
            }
            return RptIDList;
        }

        /// <summary>
        /// Retrieve from the database all the selected items in the list view.
        /// </summary>
        public List<RealPropertyTax> GetSelectedRPTList()
        {
            List<RealPropertyTax> SelectedRPTByStatus = new List<RealPropertyTax>();
            List<long> RptIDList = getSelectedRptIDList();
            foreach (long RptID in RptIDList)
            {
                RealPropertyTax rpt = RPTDatabase.Get(RptID);
                SelectedRPTByStatus.Add(rpt);
            }
            return RPTDatabase.SelectByListRptID(RptIDList);
        }

        /// <summary>
        /// Retrieve from the database all the selected items in the list view, but with the same Status as ExpectedStatus.
        /// </summary>
        public List<RealPropertyTax> GetSelectedRPTByStatus(string ExpectedStatus)
        {
            List<RealPropertyTax> SelectedRPTByStatus = new List<RealPropertyTax>();
            List<RealPropertyTax> SelectedRPTList = GetSelectedRPTList();
            foreach (RealPropertyTax rpt in SelectedRPTList)
            {
                if (rpt.Status == ExpectedStatus)
                {
                    SelectedRPTByStatus.Add(rpt);
                }
            }
            return SelectedRPTByStatus;
        }

        /// <summary>
        /// Check if all the selected items in the list view have the given ExpectedStatus
        /// </summary>
        public bool CheckSameStatus(string ExpectedStatus)
        {
            bool SameStatus = true;
            List<RealPropertyTax> SelectedRPTList = GetSelectedRPTList();
            foreach (RealPropertyTax rpt in SelectedRPTList)
            {
                if (rpt.Status != ExpectedStatus)
                {
                    SameStatus = false;
                }
            }
            return SameStatus;
        }

    }
}
