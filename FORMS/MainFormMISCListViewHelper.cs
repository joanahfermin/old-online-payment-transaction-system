using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.FORMS
{
    internal class MainFormMISCListViewHelper
    {
        private ListView MISCinfoLV;

        public MainFormMISCListViewHelper(ListView mISCinfoLV)
        {
            this.MISCinfoLV = mISCinfoLV;
        }

        /// <summary>
        /// Get the MiscID from the first selected record in the list view
        /// </summary>
        public long getSelectedMiscID()
        {
            long MiscID = 0;
            if (haveSelectedRow())
            {
                string MiscIDString = MISCinfoLV.SelectedItems[0].Text;
                MiscID = Convert.ToInt64(MiscIDString);
            }
            return MiscID;
        }

        /// <summary>
        /// Retrieve from the database all the selected items in the list view, but with the same Status as ExpectedStatus.
        /// </summary>
        public List<MiscelleneousTax> GetSelectedMISCByStatus(string ExpectedStatus)
        {
            List<MiscelleneousTax> SelectedMISCByStatus = new List<MiscelleneousTax>();
            List<MiscelleneousTax> SelectedMISCList = GetSelectedMISCList();

            foreach (MiscelleneousTax misc in SelectedMISCList)
            {
                if (misc.Status == ExpectedStatus)
                {
                    SelectedMISCByStatus.Add(misc);
                }
            }
            return SelectedMISCByStatus;
        }

        public List<MiscelleneousTax> GetSelectedMISCList()
        {
            List<MiscelleneousTax> SelectedMISCByStatus = new List<MiscelleneousTax>();
            List<long> MiscIDList = getSelectedMiscIDList();
            foreach (long MiscID in MiscIDList)
            {
                MiscelleneousTax misc = MISCDatabase.Get(MiscID);
                SelectedMISCByStatus.Add(misc);
            }
            return SelectedMISCByStatus;
        }

        public List<long> getSelectedMiscIDList()
        {
            List<long> MiscIDList = new List<long>();
            foreach (ListViewItem item in MISCinfoLV.SelectedItems)
            {
                string MiscIdString = item.Text;
                long MiscID = Convert.ToInt64(MiscIdString);
                MiscIDList.Add(MiscID);
            }
            return MiscIDList;
        }

        public MiscelleneousTax getSelectedMisc()
        {
            MiscelleneousTax misc = null;

            if (haveSelectedRow())
            {
                string MiscIDString = MISCinfoLV.SelectedItems[0].Text;
                long MiscID = Convert.ToInt64(MiscIDString);
                misc = MISCDatabase.Get(MiscID);
            }

            return misc;
        }


        public bool CheckSameStatus(string ExpectedStatus)
        {
            bool SameStatus = true;
            List<MiscelleneousTax> SelectedMISCList = GetSelectedMISCList();
            foreach (MiscelleneousTax misc in SelectedMISCList)
            {
                if (misc.Status != ExpectedStatus)
                {
                    SameStatus = false;
                }
            }
            return SameStatus;
        }

        /// <summary>
        /// Check if there is a row selected from the list view.
        /// </summary>
        public bool haveSelectedRow()
        {
            if (MISCinfoLV.SelectedItems.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
