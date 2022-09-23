using SampleRPT1.UTILITIES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.FORMS
{
    public partial class ReviewEmailForm : Form
    {
        private Timer AutoRefreshListViewTimer;

        public ReviewEmailForm()
        {
            InitializeComponent();

            cbType.Items.Add(DocumentType.ASSESSMENT);
            cbType.Items.Add(DocumentType.RECEIPT);
            cbType.Text = DocumentType.ASSESSMENT;
            InitializeAutoRefreshListViewTimer();

        }

        private void InitializeAutoRefreshListViewTimer()
        {
            AutoRefreshListViewTimer = new Timer();
            AutoRefreshListViewTimer.Tick += new EventHandler(AutoRefreshListViewTimerEvent);
            AutoRefreshListViewTimer.Interval = GlobalConstants.AUTO_REFRESH_CONFIRM_SENDEMAIL * 1000; // convert seconds to milliseconds
            AutoRefreshListViewTimer.Start();
        }

        private void AutoRefreshListViewTimerEvent(object sender, EventArgs e)
        {
            if (checkRefreshAll.Checked)
            {
                RefreshReviewListView();
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RefreshReviewListView();
        }

        private void RefreshReviewListView()
        {
            if (rdAssessment.Checked)
            {
                List<RealPropertyTax> rptList = RPTDatabase.SelectReadyAssessmentSendEmail();
                ListViewUtil.copyFromListToListview<RealPropertyTax>(rptList, lvReview, new List<string> { "RptID", "ContactNumber", "TaxDec", "RequestingParty" });
            }
            else if (rdReceipt.Checked)
            {
                List<RealPropertyTax> rptList = RPTDatabase.SelectReadyForORUpload();
                ListViewUtil.copyFromListToListview<RealPropertyTax>(rptList, lvReview, new List<string> { "RptID", "ContactNumber", "TaxDec", "RequestingParty" });
            }
            else
            {
                lvReview.Items.Clear();
            }

            foreach (ListViewItem item in lvReview.Items)
            {
                if (rdAssessment.Checked)
                {
                    item.SubItems[1].Text = "ASSESSMENT";

                }
                else if (rdReceipt.Checked)
                {
                    item.SubItems[1].Text = "RECEIPT";
                }
            }
        }

        private void lvReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            long rptID = getSelectedItemRptID();
            if (rptID > 0)
            {
                String documentType = cbType.Text;
                RPTAttachPicture RetrievePicture = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(rptID, documentType);
                if (RetrievePicture != null)
                {
                    pbAttachedPicture.Image = getImageFromAttachePicture(RetrievePicture);
                }
            }
        }

        private Image getImageFromAttachePicture(RPTAttachPicture AttachPicture)
        {
            if (AttachPicture.FileName.ToLower().EndsWith("pdf"))
            {
                return Properties.Resources.pdf_img;
            }
            else
            {
                return Image.FromStream(new MemoryStream(AttachPicture.FileData));
            }
        }

        private long getSelectedItemRptID()
        {
            if (lvReview.SelectedItems.Count > 0)
            {
                return Convert.ToInt64(lvReview.SelectedItems[0].Text);
            }
            else
            {
                return 0;
            }
        }

        private void pbAttachedPicture_Click(object sender, EventArgs e)
        {
            long rptID = getSelectedItemRptID();
            if (rptID > 0)
            {
                String documentType = cbType.Text;
                RPTAttachPicture RetrievePicture = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(rptID, documentType);
                if (RetrievePicture != null)
                {
                    if (RetrievePicture.FileName.ToLower().EndsWith("pdf"))
                    {
                        String filename = DateTimeOffset.Now.ToUnixTimeMilliseconds() + ".pdf";
                        String savedFileFullPath = FileUtils.SaveFileToDownloadFolder(filename, RetrievePicture.FileData);
                        System.Diagnostics.Process.Start(savedFileFullPath);
                    }
                    else
                    {
                        Image image = Image.FromStream(new MemoryStream(RetrievePicture.FileData));
                        ViewImageForm form = new ViewImageForm(image);
                        form.ShowDialog();
                    }

                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (lvReview.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ChangeSelectedItemStatus();
                    RefreshReviewListView();
                }
            }
        }

        private void ChangeSelectedItemStatus()
        {
            for (int i = 0; i < lvReview.SelectedItems.Count; i++)
            {
                long rptID = Convert.ToInt64(lvReview.SelectedItems[i].Text);
                RealPropertyTax rpt = RPTDatabase.Get(rptID);
                if (cbType.Text == DocumentType.ASSESSMENT)
                {
                    rpt.SendAssessmentReady = true;
                    RPTDatabase.Update(rpt);
                }
                else if (cbType.Text == DocumentType.RECEIPT)
                {
                    rpt.SendReceiptReady = true;
                    RPTDatabase.Update(rpt);
                }
            }
        }

        private void checkRefreshAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRefreshAll.Checked)
            {
                RefreshReviewListView();
            }
        }

        private void rdAssessment_CheckedChanged(object sender, EventArgs e)
        {
            RefreshReviewListView();
        }

        private void rdReceipt_CheckedChanged(object sender, EventArgs e)
        {
            RefreshReviewListView();
        }
    }
}
