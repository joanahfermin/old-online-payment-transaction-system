using SampleRPT1.DATABASE;
using SampleRPT1.MODEL;
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

        private static string REPORT_USER_ACTIVITY = "User Activity";

        private static object[] REPORT_USER_ACTIVITY_COLUMN_NAMES = {
            new { Name="User", Width=200}, new { Name="Encoded", Width=100},
            new { Name="Billed", Width=100}, new { Name="Validated", Width=100},new { Name="Uploaded", Width=100}};

        public ReportForm(Form parentForm)
        {
            InitializeComponent();

            INSTANCE = this;
            MdiParent = parentForm;
            ControlBox = false;

            cboReportName.Items.Add(REPORT_USER_ACTIVITY);
            cboReportName.SelectedIndex = 0;
        }

        public void Show()
        {
            base.Show();
            WindowState = FormWindowState.Maximized;
        }

        private void cboReportName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboReportName.Text == REPORT_USER_ACTIVITY)
            {
                ShowReportUserActivity();
            }
        }

        private void ShowReportUserActivity()
        {
            LVreport.Columns.Clear();

            foreach (dynamic column in REPORT_USER_ACTIVITY_COLUMN_NAMES)
            {
                LVreport.Columns.Add(column.Name);
                int lastHeaderIndex = LVreport.Columns.Count - 1;
                ColumnHeader lastHeader = LVreport.Columns[lastHeaderIndex];
                lastHeader.Width = column.Width;
            }
            List<ReportUserActivity> userActivityList = ReportDatabase.SelectUserActivity();
            ListViewUtil.copyFromListToListview<ReportUserActivity>(userActivityList, LVreport, new List<string>
            { "DisplayName", "EncodedCount", "BilledCount", "ValidatedCount", "UploadCount"});
        }
    }
}
