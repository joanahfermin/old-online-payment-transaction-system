using SampleRPT1.DATABASE;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.FORMS
{
    public partial class ReportForm : Form
    {
        public static ReportForm INSTANCE;

        private static string USER_ACTIVITY = "USER ACTIVITY";
        private static string USER_RPT = "RPT";
        private static string USER_BUS = "BUSINESS";
        private static string USER_MISC_OCCPERMIT = "MISCELLANEOUS FEES: OCCUPATIONAL PERMIT";

        private static string[] REPORT_USER_ACTIVITY = { USER_ACTIVITY, USER_RPT, USER_BUS, USER_MISC_OCCPERMIT };

        private static object[] REPORT_USER_ACTIVITY_COLUMN_NAMES = {
            new { Name="User", Width=200}, new { Name="Encoded", Width=100},
            new { Name="Billed", Width=100}, new { Name="Verified", Width=100}, 
            new { Name="Validated", Width=100}, new { Name="Uploaded", Width=100},
            new { Name="Released", Width=100}};

        private static object[] REPORT_USER_RPT_COLUMN_NAMES = {
            new { Name="", Width=50},
            new { Name="TaxDec", Width=200},
            new { Name="TaxPayer Name", Width=200},
            new { Name="Online Collection", Width=200},
            new { Name="Billing", Width=100},
            new { Name="Excess/Short", Width=100},
            new { Name="RPT Remarks", Width=250}};

        private static object[] REPORT_MISC_COLUMN_NAMES = {
            new { Name="", Width=50},
            new { Name="OP Number", Width=200},
            new { Name="OPA Tracking Number", Width=200},
            new { Name="TransferredAmount", Width=200},
            new { Name="Remarks", Width=250}};

        public ReportForm(Form parentForm)
        {
            InitializeComponent();

            INSTANCE = this;
            MdiParent = parentForm;
            ControlBox = false;

            dtDate.Value = DateTime.Now;
            dtDateTo.Value = DateTime.Now;

            cboReportName.Items.AddRange(REPORT_USER_ACTIVITY);
            cboReportName.SelectedIndex = 0;

            btnValidate.Visible = false;
        }

        public void Show()
        {
            base.Show();
            WindowState = FormWindowState.Maximized;
        }

        private void RefreshReport()
        {
            if (cboReportName.Text == USER_ACTIVITY)
            {
                ShowReportUserActivity();
            }

            else if (cboReportName.Text == USER_RPT)
            {
                ShowReportRPT();
            }

            else if (cboReportName.Text == USER_MISC_OCCPERMIT)
            {
                ShowReport_Misc_OccuPermit();
            }
        }

        private void cboReportName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshReport();
            ComputeTotalCollectionAndBilling();
        }

        private void ShowReportUserActivity()
        {
            DateTime DateFrom = dtDate.Value;
            DateTime DateTo = dtDateTo.Value;

            LVreport.Columns.Clear();

            foreach (dynamic column in REPORT_USER_ACTIVITY_COLUMN_NAMES)
            {
                LVreport.Columns.Add(column.Name);
                int lastHeaderIndex = LVreport.Columns.Count - 1;
                ColumnHeader lastHeader = LVreport.Columns[lastHeaderIndex];
                lastHeader.Width = column.Width;
            }
            List<ReportUserActivity> userActivityList = ReportDatabase.SelectUserActivity(DateFrom, DateTo);
            ListViewUtil.copyFromListToListview<ReportUserActivity>(userActivityList, LVreport, new List<string>
            { "DisplayName", "EncodedCount", "BilledCount", "VerifiedCount", "ValidatedCount", "UploadCount", "ReleasedCount"});
        }

        private void ShowReportRPT()
        {
            DateTime DateFrom = dtDate.Value;
            DateTime DateTo = dtDateTo.Value;

            LVreport.Columns.Clear();

            foreach (dynamic column in REPORT_USER_RPT_COLUMN_NAMES)
            {
                LVreport.Columns.Add(column.Name);
                int lastHeaderIndex = LVreport.Columns.Count - 1;
                ColumnHeader lastHeader = LVreport.Columns[lastHeaderIndex];
                lastHeader.Width = column.Width;
            }
            List<ReportCollection> RPTList = ReportDatabase.Select_Collector_RPT(DateFrom, DateTo);
            ListViewUtil.copyFromListToListview_With_Row_Number<ReportCollection>(RPTList, LVreport, new List<string>
            { "TaxDec", "TaxPayerName", "Collection", "Billing", "ExcessShort", "RPTremarks"});

            //ShowExcelReport(RPTList);
        }

        private void ShowReport_Misc_OccuPermit()
        {
            DateTime DateFrom = dtDate.Value;
            DateTime DateTo = dtDateTo.Value;

            LVreport.Columns.Clear();

            foreach (dynamic column in REPORT_MISC_COLUMN_NAMES)
            {
                LVreport.Columns.Add(column.Name);
                int lastHeaderIndex = LVreport.Columns.Count - 1;
                ColumnHeader lastHeader = LVreport.Columns[lastHeaderIndex];
                lastHeader.Width = column.Width;
            }
            List<ReportCollection_OccuPermit> MiscList_OccuPermit = ReportDatabase.Select_Collector_MISC(DateFrom, DateTo);
            ListViewUtil.copyFromListToListview_With_Row_Number<ReportCollection_OccuPermit>(MiscList_OccuPermit, LVreport, new List<string>
            { "OrderOfPaymentNum", "OPATrackingNum", "TransferredAmount", "Remarks"});
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshReport();
        }

        private void dtDateTo_ValueChanged(object sender, EventArgs e)
        {
            RefreshReport();
        }

        private void ShowExcelReport(List<ReportCollection> rptList)
        {
            object Nothing = System.Reflection.Missing.Value;
            var app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Add(Nothing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets[1];
            worksheet.Name = "WorkSheet";

            worksheet.Cells[1, 2] = "REAL PROPERTY TAX";
            worksheet.Cells[2, 2] = "TOTAL COLLECTION";
            worksheet.Cells[2, 3] = "TOTAL BILLING";
            worksheet.Cells[2, 4] = "EXCESS/SHORT";


            worksheet.Cells[3, 5] = SecurityService.getLoginUser().FullName;
            worksheet.Cells[4, 2] = "with shttc";
            worksheet.Cells[5, 2] = textShttc.Text;

            worksheet.Cells[6, 2] = "COLLECTION";
            worksheet.Cells[6, 3] = "BILLING";
            worksheet.Cells[6, 4] = "EXCESS/SHORT";
            worksheet.Cells[6, 5] = "RPT REMARKS";

            worksheet.Cells[4, 5] = "POS-" + SecurityService.getLoginUser().MachNo;
            worksheet.Cells[5, 5] = DateTime.Now.ToString();

            int row = 7;
            int counter = 1;

            decimal totalCollection = 0;
            decimal totalBilling = 0;
            decimal totalExcessShort = 0;

            foreach (ReportCollection item in rptList)
            {
                worksheet.Cells[row, 1] = counter.ToString();
                worksheet.Cells[row, 2] = item.Collection.ToString();
                worksheet.Cells[row, 3] = item.Billing.ToString();
                worksheet.Cells[row, 4] = item.ExcessShort.ToString();
                worksheet.Cells[row, 5] = item.RPTremarks;

                totalCollection += item.Collection;
                totalBilling += item.Billing;
                totalExcessShort += item.ExcessShort;

                row++;
                counter++;
            }
            decimal shttc = 0;
            decimal.TryParse(textShttc.Text, out shttc);

            worksheet.Cells[3, 2] = $"=sum(B7:B{row-1})";
            worksheet.Cells[3, 3] = $"=sum(C7:C{row - 1}) + B5";
            worksheet.Cells[3, 4] = $"=sum(D7:D{row - 1})";

            String filename = DateTimeOffset.Now.ToUnixTimeMilliseconds() + "Collections.xlsx";
            String folder = FileUtils.GetDownloadFolderPath();
            String fullpath = folder + "\\" + filename;

            worksheet.SaveAs(fullpath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
            workBook.Close(false, Type.Missing, Type.Missing);
            app.Quit();

            System.Diagnostics.Process.Start(fullpath);
        }

        private decimal totalBilling = 0;

        private void ComputeTotalCollectionAndBilling()
        {
            decimal totalCollection = 0;
            totalBilling = 0;
            decimal collection = 0;

            foreach (ListViewItem lstItem in LVreport.Items)
            {
                //totalCollection += Convert.ToDecimal(lstItem.SubItems[0].Text);
                decimal.TryParse(lstItem.SubItems[2].Text,out collection);
                totalCollection += collection;
                //MessageBox.Show(totalCollection.ToString());
                totalBilling += Convert.ToDecimal(lstItem.SubItems[3].Text);
            }

            decimal shttc = 0;

            decimal.TryParse(textShttc.Text, out shttc);

            textTotalCollection.Text = totalCollection.ToString("N2");
            textTotalBilling.Text = (totalBilling + shttc).ToString("N2");
        }

        private void textTotalCollection_TextChanged(object sender, EventArgs e)
        {
            //ComputeTotalCollectionAndBilling();
        }

        private void btnReportCollector_Click(object sender, EventArgs e)
        {
            DateTime DateFrom = dtDate.Value;
            DateTime DateTo = dtDateTo.Value;
            List<ReportCollection> RPTList = ReportDatabase.Select_Collector_RPT(DateFrom, DateTo);

            ShowExcelReport(RPTList);
        }

        private void textShttc_TextChanged(object sender, EventArgs e)
        {
            decimal shttc = 0;

            decimal.TryParse(textShttc.Text, out shttc);

            textTotalBilling.Text = (totalBilling + shttc).ToString("N2");
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            RPTUser loginUser = SecurityService.getLoginUser();

            List<TagReceipt> tagReceiptList = TagReceiptDatabase.SelectByMachNo(loginUser.MachNo);

            foreach (TagReceipt tagReceipt in tagReceiptList)
            {
                RealPropertyTax rpt = RPTDatabase.SearchByTagReceipt(tagReceipt);

                if (rpt != null)
                {
                    rpt.ValidatedBy = loginUser.DisplayName;
                    rpt.ValidatedDate = DateTime.Now;
                    rpt.Status = RPTStatus.OR_UPLOAD;

                    RPTDatabase.Update(rpt);
                }
            }
        }
    }
}
