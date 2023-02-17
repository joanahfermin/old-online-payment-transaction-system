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

namespace SampleRPT1
{
    public partial class AddRecordGCASHPAYMAYAForm : Form
    {
        private RPTUser loginUser = SecurityService.getLoginUser();

        public static AddRecordGCASHPAYMAYAForm INSTANCE;

        string Remarks;
        public const string DUPLICATE_RECORD = "DUPLICATE RECORD";

        public AddRecordGCASHPAYMAYAForm(Form parentForm)
        {
            InitializeComponent();

            INSTANCE = this;
            MdiParent = parentForm;
            ControlBox = false;

            //This is essential to the FirstLVGcashPaymaya_KeyDown method.
            //Dagdag ng event Keyup.
            FirstLVGcashPaymaya.KeyUp += FirstLVGcashPaymaya_KeyDown;

            labelRPTID.Visible = false;
            textRPTID.Visible = false;
        }

        /// <summary>
        /// Copy from GCASH and PAYMAYA excel to form's listview by keypress (CTRL + C THEN CTRL + V)
        /// </summary>
        private void FirstLVGcashPaymaya_KeyDown(object sender, KeyEventArgs e)
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
                    FirstLVGcashPaymaya.Items.Clear();

                    foreach (string row in rowArray)
                    {
                        //Splits the records through TAB. \t = tab.
                        string[] columnArray = row.Split(new char[] { '\t' });

                        ListViewItem item = new ListViewItem();
                        bool firstColumn = true;
                        int ColumnIndex = 0;

                        if (columnArray.Length < 10)
                        {
                            MessageBox.Show("Invalid COPY/PASTE of records.");
                            return;
                        }

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

                        if (columnArray.Length < 11)
                        {
                            item.SubItems.Add("");

                        }

                        string taxDec = item.SubItems[1].Text;

                        if (isRPTTaxDecFormat(taxDec))
                        {
                            FirstLVGcashPaymaya.Items.Add(item);
                        }
                    }
                }
                PopulateExistingColumn();

                //AUTO-COMPUTE TOTAL AMOUNT UPON PASTING DATA.
                if (FirstLVGcashPaymaya.SelectedItems.Count == 0)
                {
                    decimal ComputeTotalAmount = 0;

                    foreach (ListViewItem item in FirstLVGcashPaymaya.Items)
                    {
                        ComputeTotalAmount += decimal.Parse(item.SubItems[5].Text);
                    }
                    textTotalAmount.Text = ComputeTotalAmount.ToString("N2");
                    textNumRec.Text = FirstLVGcashPaymaya.Items.Count.ToString();
                }
                textNumRec.Text = FirstLVGcashPaymaya.Items.Count.ToString();
            }

            //CTRL + A to select all the rows.
            if (e.KeyCode == Keys.A && e.Control)
            {
                FirstLVGcashPaymaya.MultiSelect = true;

                foreach (ListViewItem item in FirstLVGcashPaymaya.Items)
                {
                    item.Selected = true;
                }
            }
        }

        private bool isRPTTaxDecFormat(string taxDec)
        {
            //format of taxdec number.
            Regex re = new Regex("^[D|E|F|G]-[0-9]{3}-[0-9]{5}( / [D|E|F|G]-[0-9]{3}-[0-9]{5})*$"); 
            return re.IsMatch(taxDec.Trim());
        }

        /// <summary>
        /// Determines if a record is existing in the database or has a duplicate in the listview.
        /// </summary>
        private void PopulateExistingColumn()
        {
            List<string> ProcessedList = new List<string>();

            bool duplicateDetected = false;

            for (int i = 0; i < FirstLVGcashPaymaya.Items.Count; i++)
            {
                ListViewItem item = FirstLVGcashPaymaya.Items[i];
                string TaxDec = item.SubItems[1].Text;
                string YearQuarter = item.SubItems[2].Text;

                RealPropertyTax rpt = RPTDatabase.SelectByTaxDecAndYear(TaxDec, YearQuarter);

                //if selected record is existing in the database with same Tax Dec and same Year/quarter.
                if (rpt != null)
                {
                    item.SubItems.Add("YES");
                    item.BackColor = Color.LightBlue;
                    duplicateDetected = true;
                }
                else
                {
                    item.SubItems.Add("NO");
                }

                string TaxDecAndYearQuarter = TaxDec + YearQuarter;

                //if selected record has duplicate in the form's listview with same Tax Dec and same Year/quarter.
                if (ProcessedList.Contains(TaxDecAndYearQuarter))
                {
                    item.SubItems.Add("YES");
                    item.BackColor = Color.LightCoral;
                    duplicateDetected = true;
                }
                else
                {
                    item.SubItems.Add("NO");

                }
                ProcessedList.Add(TaxDecAndYearQuarter);
            }

            if (duplicateDetected)
            { 
                MessageBox.Show("There is a DUPLICATE RECORD detected!");
            } 
        }

        private void RefreshMainListviewStatus()
        {
            MainForm.INSTANCE.SearchPaymentVerification();
        }

        /// <summary>
        /// Saves all the records in the listview.
        /// </summary>
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            string DuplicateRecordRemarks = Remarks + DUPLICATE_RECORD;
            string refNo = "R" + DateTimeOffset.Now.ToUnixTimeMilliseconds();

            if (FirstLVGcashPaymaya.Items.Count > 0)
            {
                for (int i = 0; i < FirstLVGcashPaymaya.Items.Count; i++)
                {
                    string YearQuarter = FirstLVGcashPaymaya.Items[i].SubItems[2].Text;

                    if (YearQuarter.Length > 4)
                    {
                        MessageBox.Show("Year must be in correct format.");
                        return;
                    }
                }

                //Isa-isa nilalagay sa variable ang mga values from listview, then from variables to objects.
                for (int i = 0; i < FirstLVGcashPaymaya.Items.Count; i++)
                {
                    string ServiceProvider = FirstLVGcashPaymaya.Items[i].Text;
                    string TaxDec = FirstLVGcashPaymaya.Items[i].SubItems[1].Text;
                    string YearQuarter = FirstLVGcashPaymaya.Items[i].SubItems[2].Text;
                    string TaxpayersName = FirstLVGcashPaymaya.Items[i].SubItems[3].Text;
                    string RequestingParty = FirstLVGcashPaymaya.Items[i].SubItems[4].Text;
                    decimal AmountDue = Convert.ToDecimal(FirstLVGcashPaymaya.Items[i].SubItems[5].Text);
                    string TransactionDate = FirstLVGcashPaymaya.Items[i].SubItems[6].Text;
                    Remarks = FirstLVGcashPaymaya.Items[i].SubItems[7].Text;

                    RealPropertyTax RetrievedRpt = RPTDatabase.SelectByTaxDecAndYear(TaxDec, YearQuarter);

                    RealPropertyTax rpt = new RealPropertyTax();

                    rpt.TaxDec = TaxDec;
                    //rpt.TaxPayerName = SearchExistingTaxpayerName(TaxDec);
                    rpt.TaxPayerName = TaxpayersName;
                    rpt.AmountToPay = AmountDue;
                    rpt.AmountTransferred = AmountDue;
                    rpt.Bank = ServiceProvider;
                    rpt.YearQuarter = YearQuarter;
                    rpt.Quarter = "1-4";
                    rpt.RPTremarks = Remarks;

                    ////TO DO
                    //rpt.Quarter = "1-4";
                    rpt.BillCount = textBillQuantity.Text;
                    rpt.Status = RPTStatus.PAYMENT_VERIFICATION;
                    rpt.RequestingParty = RequestingParty;

                    rpt.PaymentDate = Convert.ToDateTime(TransactionDate);

                    rpt.EncodedBy = loginUser.DisplayName;
                    rpt.EncodedDate = DateTime.Now;

                    rpt.RequestingParty = RequestingParty;
                    rpt.BilledBy = loginUser.DisplayName;
                    rpt.BilledDate = DateTime.Now;
                    rpt.RefNum = refNo;

                    if (RetrievedRpt != null)
                    {
                        rpt.YearQuarter = YearQuarter + " (" + DateTime.Now.ToString("yyyy") + ")";
                        rpt.RPTremarks = Remarks + " " + DuplicateRecordRemarks;
                    }

                    RPTDatabase.Insert(rpt);

                }

                FirstLVGcashPaymaya.Items.Clear();
                MessageBox.Show("All records have been successfully saved.");

                RefreshMainListviewStatus();

                textRPTID.Clear();
                textBillQuantity.Clear();
            }
        }

        public void Show()
        {
            base.Show();
            WindowState = FormWindowState.Maximized;
        }

        //Integer only.
        private void textBillQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

            foreach (ListViewItem item in FirstLVGcashPaymaya.Items)
            {
                worksheet.Cells[row, 1] = item.Text;
                worksheet.Cells[row, 2] = item.SubItems[1].Text;
                worksheet.Cells[row, 3] = item.SubItems[2].Text;
                worksheet.Cells[row, 4] = item.SubItems[3].Text;
                worksheet.Cells[row, 5] = item.SubItems[4].Text;
                worksheet.Cells[row, 6] = item.SubItems[5].Text;
                worksheet.Cells[row, 7] = item.SubItems[6].Text;

                row++;
            }

            String filename = DateTimeOffset.Now.ToUnixTimeMilliseconds() + "gcashpaymaya.xlsx";
            String folder = FileUtils.GetDownloadFolderPath();
            String fullpath = folder + "\\" + filename;

            worksheet.SaveAs(fullpath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
            workBook.Close(false, Type.Missing, Type.Missing);
            app.Quit();

            System.Diagnostics.Process.Start(fullpath);
        }

        private static decimal totalAmount = 0;

        private void FirstLVGcashPaymaya_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            textNumRec.Text = FirstLVGcashPaymaya.SelectedItems.Count.ToString();

            if (FirstLVGcashPaymaya.SelectedItems.Count == 0)
            {
                totalAmount = 0;
            }
            
            if (FirstLVGcashPaymaya.SelectedItems.Count == 1)
            {
                totalAmount = Convert.ToDecimal(FirstLVGcashPaymaya.SelectedItems[0].SubItems[5].Text);
            }

            else if (FirstLVGcashPaymaya.SelectedItems.Count > 1)
            {
                int index = e.ItemIndex;
                totalAmount += Convert.ToDecimal(FirstLVGcashPaymaya.Items[index].SubItems[5].Text);
            }

            textTotalAmount.Text = totalAmount.ToString("N2");

        }
    }
} 