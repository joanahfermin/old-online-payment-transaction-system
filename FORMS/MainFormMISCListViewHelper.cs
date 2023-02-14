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
        /// Retrieve from the database all the selected items in the list view, but with the same Status as ExpectedStatus.
        /// </summary>
        public List<MiscelleneousOccuPermit> GetSelectedMISCByStatus(string ExpectedStatus)
        {
            List<MiscelleneousOccuPermit> SelectedMISCByStatus = new List<MiscelleneousOccuPermit>();
            List<MiscelleneousOccuPermit> SelectedMISCList = GetSelectedMISCList();

            foreach (MiscelleneousOccuPermit misc in SelectedMISCList)
            {
                if (misc.Status == ExpectedStatus)
                {
                    SelectedMISCByStatus.Add(misc);
                }
            }
            return SelectedMISCByStatus;
        }

        public List<MiscelleneousOccuPermit> GetSelectedMISCList()
        {
            List<MiscelleneousOccuPermit> SelectedMISCByStatus = new List<MiscelleneousOccuPermit>();
            List<long> MiscIDList = getSelectedMiscIDList();
            foreach (long MiscID in MiscIDList)
            {
                MiscelleneousOccuPermit misc = MISCDatabase.Get(MiscID);
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

        public bool CheckSameStatus(string ExpectedStatus)
        {
            bool SameStatus = true;
            List<MiscelleneousOccuPermit> SelectedMISCList = GetSelectedMISCList();
            foreach (MiscelleneousOccuPermit misc in SelectedMISCList)
            {
                if (misc.Status != ExpectedStatus)
                {
                    SameStatus = false;
                }
            }
            return SameStatus;
        }
    }
}
