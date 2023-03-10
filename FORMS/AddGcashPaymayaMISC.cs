using SampleRPT1.MODEL;
using SampleRPT1.Service;
using SampleRPT1.UTILITIES;
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
    public partial class AddGcashPaymayaMISC : Form
    {
        private RPTUser loginUser = SecurityService.getLoginUser();
        string Misc_Type = null;

        public AddGcashPaymayaMISC()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

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
            //IgnoredColumnList.Add(5);
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

                        //FILTERING ORDER OF PAYMENT NUMBER OCCU PERMIT.
                        string misc = item.SubItems[2].Text;

                        //if (isOPnumberFormat_OccuPermit(misc) || isOPnumberFormat_Ovr_TTMD(misc) || isOPnumberFormat_Ovr_DPOS(misc) ||
                        //    isOPnumberFormat_Market_MDAD(misc) || isOPnumberFormat_Liquor_LLRB(misc))
                        {
                            MISCGcashPaymayaLV.Items.Add(item);
                        }
                    }
                    Retrieve_Name();

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

        //M-2023-02-02-BPLO-A176-000665 SAMPLE FORMAT OF O.P NUMBER OF OCCU PERMIT BPLO.
        private bool isOPnumberFormat_OccuPermit(string misc)
        {
            //format of misc number.
            Regex re = new Regex("^[M]-[0-9]{4}-[0-9]{2}-[0-9]{2}-[B][P][L][O]-[A-Z,0-9]{4}-[0-9]{6}$");
            return re.IsMatch(misc.Trim());
        }

        //M-2023-03-03-TTMD-A176-000745 SAMPLE FORMAT OF O.P NUMBER OF OVR TTMD.
        private bool isOPnumberFormat_Ovr_TTMD(string misc)
        {
            //format of misc number.
            Regex re = new Regex("^[M]-[0-9]{4}-[0-9]{2}-[0-9]{2}-[T][T][M][D]-[A-Z,0-9]{4}-[0-9]{6}$");
            return re.IsMatch(misc.Trim());
        }

        //M-2023-03-03-DPOS-A176-000794 SAMPLE FORMAT OF O.P NUMBER OF OVR DPOS.
        private bool isOPnumberFormat_Ovr_DPOS(string misc)
        {
            //format of misc number.
            Regex re = new Regex("^[M]-[0-9]{4}-[0-9]{2}-[0-9]{2}-[D][P][O][S]-[A-Z,0-9]{4}-[0-9]{6}$");
            return re.IsMatch(misc.Trim());
        }

        //M-2023-03-03-MDAD-A176-000794 SAMPLE FORMAT OF O.P NUMBER OF MARKET MDAD.
        private bool isOPnumberFormat_Market_MDAD(string misc)
        {
            //format of misc number.
            Regex re = new Regex("^[M]-[0-9]{4}-[0-9]{2}-[0-9]{2}-[M][D][A][D]-[A-Z,0-9]{4}-[0-9]{6}$");
            return re.IsMatch(misc.Trim());
        }

        //M-2023-03-03-LLRB-A176-000794 SAMPLE FORMAT OF O.P NUMBER OF LIQUOR.
        private bool isOPnumberFormat_Liquor_LLRB(string misc)
        {
            //format of misc number.
            Regex re = new Regex("^[M]-[0-9]{4}-[0-9]{2}-[0-9]{2}-[L][L][R][B]-[A-Z,0-9]{4}-[0-9]{6}$");
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

                MiscelleneousTax misc = MISCDatabase.SelectByOPAtrackingAndOPNum(OPAtrackingNum, OPaymentNum);

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

        private bool validateForm()
        {
            foreach (ListViewItem item in MISCGcashPaymayaLV.Items)
            {
                string s = item.SubItems[3].Text;

                if (s == string.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                MessageBox.Show("error");
                return;
            }

            string DuplicateRecordRemarks = "DUPLICATE RECORD";

            string refNo = "R" + DateTimeOffset.Now.ToUnixTimeMilliseconds();

            if (MISCGcashPaymayaLV.Items.Count > 0)
            {
                //Isa-isa nilalagay sa variable ang mga values from listview, then from variables to objects.
                for (int i = 0; i < MISCGcashPaymayaLV.Items.Count; i++)
                {
                    string ServiceProvider = MISCGcashPaymayaLV.Items[i].Text;
                    string OPAtrackingNum = MISCGcashPaymayaLV.Items[i].SubItems[1].Text;
                    string OPnumber = MISCGcashPaymayaLV.Items[i].SubItems[2].Text;
                    string TaxpayersName = MISCGcashPaymayaLV.Items[i].SubItems[3].Text;
                    //string RequestingParty = MISCGcashPaymayaLV.Items[i].SubItems[4].Text;
                    decimal AmountDue = Convert.ToDecimal(MISCGcashPaymayaLV.Items[i].SubItems[5].Text);
                    string TransactionDate = MISCGcashPaymayaLV.Items[i].SubItems[6].Text;

                    MiscelleneousTax retrieveMisc = MISCDatabase.SelectByOPAtrackingAndOPNum(OPAtrackingNum, OPnumber);

                    MiscelleneousTax misc = new MiscelleneousTax();

                    misc.OPATrackingNum = OPAtrackingNum;
                    misc.OrderOfPaymentNum = OPnumber;
                    misc.TaxpayersName = TaxpayersName;
                    misc.AmountToBePaid = AmountDue;
                    misc.TransferredAmount = AmountDue;
                    misc.ModeOfPayment = ServiceProvider;
                    misc.Status = RPTStatus.PAYMENT_VERIFICATION;
                    misc.PaymentDate = Convert.ToDateTime(TransactionDate);
                    //misc.RequestingParty = RequestingParty;

                    misc.EncodedBy = loginUser.DisplayName;
                    misc.EncodedDate = DateTime.Now;
                    misc.RefNum = refNo;

                    if (retrieveMisc != null)
                    {
                        misc.Remarks = DuplicateRecordRemarks;
                    }

                    if (OPnumber.Contains("BPLO"))
                    {
                        misc.MiscType = MISCUtil.MISCTYPE_OCCUPATIONAL_PERMIT;
                    }

                    if (OPnumber.Contains("DPOS") || (OPnumber.Contains("TTMD")))
                    {
                        misc.MiscType = MISCUtil.MISCTYPE_OVR;
                    }

                    if (OPnumber.Contains("MDAD"))
                    {
                        misc.MiscType = MISCUtil.MISCTYPE_MARKET;
                    }
                    
                    if (OPnumber.Contains("LLRB"))
                    {
                        misc.MiscType = MISCUtil.MISCTYPE_LIQUOR;
                    }

                    //misc.MiscType = MISCUtil.MISCTYPE_OCCUPATIONAL_PERMIT;
                    //misc.MiscType = Misc_Type;

                    MISCDatabase.Insert(misc);
                }

                MISCGcashPaymayaLV.Items.Clear();
                MessageBox.Show("All records have been successfully saved.");

                MiscelleneousTaxForm.INSTANCE.RefreshOccuPermit();
            }
        }

        private void Retrieve_Name()
        {
            List<string> OPNumber_list = new List<string>();

            foreach (ListViewItem item in MISCGcashPaymayaLV.Items)
            {
                OPNumber_list.Add(item.SubItems[2].Text);
            }

            List<Misc_OccuPermit_TagName> TagNames = MISCDatabase.SelectBy_TaxpayerName_Bulk(OPNumber_list);

            foreach (ListViewItem item in MISCGcashPaymayaLV.Items)
            {
                string TP_Name = null;

                foreach (Misc_OccuPermit_TagName tag in TagNames)
                {
                    if (item.SubItems[2].Text == tag.BillNumber)
                    {
                        TP_Name = tag.TaxpayerLName;
                    }
                }

                if (TP_Name != null)
                {
                    item.SubItems[3].Text = TP_Name.ToUpper();
                }
                else
                {
                    continue;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            object Nothing = System.Reflection.Missing.Value;
            var app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Add(Nothing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets[1];
            worksheet.Name = "WorkSheet";

            int row = 5;
            int counter = 1;

            foreach (ListViewItem item in MISCGcashPaymayaLV.Items)
            {
                worksheet.Cells[row, 1] = counter.ToString(); 
                worksheet.Cells[row, 2] = item.Text; //SProvider
                worksheet.Cells[row, 3] = item.SubItems[1].Text; //OPA num
                worksheet.Cells[row, 4] = item.SubItems[2].Text; //OPnum
                worksheet.Cells[row, 5] = item.SubItems[3].Text; //TPNAme
                worksheet.Cells[row, 6] = item.SubItems[5].Text; //AMOUNT.
                worksheet.Cells[row, 6].NumberFormat = "#,##0.00"; //format AMOUNT.
                worksheet.Cells[row, 7] = item.SubItems[6].Text; //payment date
                row++;
                counter++;
            }

            worksheet.Cells[row, 5] = "Net Amount:";
            worksheet.Cells[row, 6] = $"=sum(F5:F{row - 1})";

            String filename = DateTimeOffset.Now.ToUnixTimeMilliseconds() + "gcashpaymaya.xlsx";
            String folder = FileUtils.GetDownloadFolderPath();
            String fullpath = folder + "\\" + filename;

            worksheet.SaveAs(fullpath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
            workBook.Close(false, Type.Missing, Type.Missing);
            app.Quit();

            System.Diagnostics.Process.Start(fullpath);
        }
    }
}
