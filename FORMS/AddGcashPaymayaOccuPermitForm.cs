using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.FORMS
{
    public partial class AddGcashPaymayaOccuPermitForm : Form
    {
        public AddGcashPaymayaOccuPermitForm()
        {
            InitializeComponent();

            //This is essential to the FirstLVGcashPaymaya_KeyDown method.
            //Dagdag ng event Keyup.
            MISCGcashPaymayaLV.KeyUp += MISCGcashPaymayaLV_KeyDown;
        }

        /// <summary>
        /// Copy from GCASH and PAYMAYA excel to form's listview by keypress (CTRL + C THEN CTRL + V)
        /// </summary>
        private void MISCGcashPaymayaLV_KeyDown(object sender, KeyEventArgs e)
        {
            List<int> IgnoredColumnList = new List<int>();
            IgnoredColumnList.Add(6);
            IgnoredColumnList.Add(8);
            IgnoredColumnList.Add(9);

            //If user presses CTRL + V, papasok sya sa if condition.
            if (e.KeyData == (Keys.V | Keys.Control))
            {
                //Yung data na nasa clipboard, ilalagay lahat sa dataAsString.
                string dataAsString = Clipboard.GetText();
                //For every record copied, .split splits strings into several lines.
                //r and n = new line,
                //RemoveEmptyEnries, kapag walang laman ang row, iignore lang nya.
                string[] rowArray = dataAsString.Split(new Char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                if (rowArray.Length > 0)
                {
                    MISCGcashPaymayaLV.Items.Clear();

                    foreach (string row in rowArray)
                    {
                        //Splits the records through TAB. \t = tab.
                        string[] columnArray = row.Split(new char[] { '\t' });

                        ListViewItem item = new ListViewItem();
                        bool firstColumn = true;
                        int ColumnIndex = 0;

                        foreach (string column in columnArray)
                        {   //kung pang-ilang column ka na.
                            ColumnIndex++;
                            if (firstColumn)
                            {
                                //ListViewItem item = new ListViewItem(p.firstName);
                                item.Text = column;
                                firstColumn = false;
                            }
                            else
                            {
                                if (!IgnoredColumnList.Contains(ColumnIndex))
                                {
                                    item.SubItems.Add(column);
                                }
                            }
                        }

                        string misc = item.SubItems[1].Text;

                        if (isRPTTaxDecFormat(misc))
                        {
                            MISCGcashPaymayaLV.Items.Add(item);
                        }
                    }
                }
                PopulateExistingColumn();

                //AUTO-COMPUTE TOTAL AMOUNT UPON PASTING DATA.
                if (MISCGcashPaymayaLV.SelectedItems.Count == 0)
                {
                    decimal ComputeTotalAmount = 0;

                    foreach (ListViewItem item in MISCGcashPaymayaLV.Items)
                    {
                        ComputeTotalAmount += decimal.Parse(item.SubItems[5].Text);
                    }
                    textTotalAmount.Text = ComputeTotalAmount.ToString("N2");
                    textNumRec.Text = MISCGcashPaymayaLV.Items.Count.ToString();
                }
                textNumRec.Text = MISCGcashPaymayaLV.Items.Count.ToString();
            }

            //CTRL + A to select all the rows.
            if (e.KeyCode == Keys.A && e.Control)
            {
                MISCGcashPaymayaLV.MultiSelect = true;

                foreach (ListViewItem item in MISCGcashPaymayaLV.Items)
                {
                    item.Selected = true;
                }
            }
        }

        private bool isRPTTaxDecFormat(string misc)
        {
            //format of misc number.
            Regex re = new Regex("^[O][P][A]-[0-9]{8}-[0-9]{6}$");
            return re.IsMatch(misc.Trim());
        }

        private void PopulateExistingColumn()
        {
            List<string> ProcessedList = new List<string>();

            bool duplicateDetected = false;

            for (int i = 0; i < MISCGcashPaymayaLV.Items.Count; i++)
            {
                ListViewItem item = MISCGcashPaymayaLV.Items[i];
                string OPAtrackingNum = item.SubItems[1].Text;
                string OPaymentNum = item.SubItems[2].Text;

                MiscelleneousOccuPermit misc = MISCDatabase.SelectByOPAtrackingAndOPNum(OPAtrackingNum, OPaymentNum);

                //if selected record is existing in the database with same Tax Dec and same Year/quarter.
                if (misc != null)
                {
                    item.SubItems.Add("YES");
                    item.BackColor = Color.LightBlue;
                    duplicateDetected = true;
                }
                else
                {
                    item.SubItems.Add("NO");
                }

                string OPAtrackingAndOPNum = OPAtrackingNum + OPaymentNum;

                //if selected record has duplicate in the form's listview with same Tax Dec and same Year/quarter.
                if (ProcessedList.Contains(OPAtrackingAndOPNum))
                {
                    item.SubItems.Add("YES");
                    item.BackColor = Color.LightCoral;
                    duplicateDetected = true;
                }
                else
                {
                    item.SubItems.Add("NO");

                }
                ProcessedList.Add(OPAtrackingAndOPNum);
            }

            if (duplicateDetected)
            {
                MessageBox.Show("There is a DUPLICATE RECORD detected!");
            }
        }

        private static decimal totalAmount = 0;

        private void FirstLVGcashPaymaya_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            textNumRec.Text = MISCGcashPaymayaLV.SelectedItems.Count.ToString();

            if (MISCGcashPaymayaLV.SelectedItems.Count == 0)
            {
                totalAmount = 0;
            }

            if (MISCGcashPaymayaLV.SelectedItems.Count == 1)
            {
                totalAmount = Convert.ToDecimal(MISCGcashPaymayaLV.SelectedItems[0].SubItems[5].Text);
            }

            else if (MISCGcashPaymayaLV.SelectedItems.Count > 1)
            {
                int index = e.ItemIndex;
                totalAmount += Convert.ToDecimal(MISCGcashPaymayaLV.Items[index].SubItems[5].Text);
            }

            textTotalAmount.Text = totalAmount.ToString("N2");
        }
    }
}
