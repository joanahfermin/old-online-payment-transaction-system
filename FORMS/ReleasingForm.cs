using OpenCvSharp;
using OpenCvSharp.Extensions;
using SampleRPT1.Service;
using SampleRPT1.UTILITIES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleRPT1.FORMS
{
    public partial class ReleasingForm : Form
    {
        public static ReleasingForm INSTANCE;

        private RPTUser loginUser = SecurityService.getLoginUser();

        private long RptID;

        VideoCapture videoCapture;
        private Thread cameraThread;

        bool isCameraRunning = false;
        bool isCapturing = true;

        public ReleasingForm(Form parentForm)
        {
            InitializeComponent();

            INSTANCE = this;
            MdiParent = parentForm;
            ControlBox = false;

            dtDate.Value = DateTime.Now;
            dtDateTo.Value = DateTime.Now;

            InitializeStatus();
            InitializeAction();
            cboStatus.Enabled = false;
            cboAction.Enabled = false;
        }

        public void Show()
        {
            base.Show();
            WindowState = FormWindowState.Maximized;
        }

        public void InitializeStatus()
        {
            //cboStatus.Items.Add(RPTStatus.OR_PICKUP/*, RPTStatus.OR_UPLOAD*/);
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

            string requestingParty = null;
            int count = 0;

            foreach (ListViewItem item in RPTInfoLV.Items)
            {
                item.BackColor = Color.LightYellow;

                if (requestingParty == null)
                {
                    requestingParty = item.SubItems[13].Text;
                }
                else if (requestingParty != item.SubItems[13].Text)
                {
                    count++;
                    requestingParty = item.SubItems[13].Text;
                }

                if (count % 2 == 1)
                {
                    item.BackColor = Color.LightBlue;
                }
            }
        }

        /// <summary>
        /// Filter records based on date and status: FOR OR RELEASE, else, based on status only. 
        /// </summary>
        public void RefreshListView()
        {
            string Status = cboStatus.Text;

            List<RealPropertyTax> rptList;

            //if (dtDate.Checked)
            //{
            //    dtDateTo.Enabled = true;
            //    DateTime UploadedDateFrom = dtDate.Value;
            //    DateTime UploadedDateTo = dtDateTo.Value;

            //    rptList = RPTDatabase.SelectByDateFromToAndStatusUploadedBy(UploadedDateFrom, UploadedDateTo, Status);
            //}
            //else
            //{
                dtDateTo.Enabled = false;
                rptList = RPTDatabase.SelectByStatus(Status);
            //}
            PopulateListView(rptList);

                //RPTInfoLV.Items.Clear();
                //VerAndValLV.Items.Clear();
            }

        private void ReleasingForm_Load(object sender, EventArgs e)
        {
            textTDN.Select();

            //cboStatus.SelectedIndex = 0;
            cboAction.SelectedIndex = 0;
        }

        private void btnSearchDateStatus_Click(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void HighlightRecord()
        {
            string tdn = textTDN.Text;

            foreach (ListViewItem item in RPTInfoLV.Items)
            {
                if (item.SubItems[1].Text == tdn)
                {
                    item.Selected = true;
                    RPTInfoLV.Focus();
                }
            }
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListView();
        }

        /// <summary>
        /// Required fields: Representative name and contact number.
        /// </summary>
        private void validateForm()
        {
            // clear muna natin lahat ng error from previous validation.
            errorProvider1.Clear();

            Validations.ValidateRequired(errorProvider1, textRepName, "Representative name");
            Validations.ValidateRequired(errorProvider1, textRepContactNum, "Contact number");
        }

        /// <summary>
        /// Returns expected status of the multiple selected records. 
        /// </summary>
        private List<RealPropertyTax> GetSelectedRPTByStatus(string ExpectedStatus)
        {
            List<RealPropertyTax> SelectedRPTByStatus = new List<RealPropertyTax>();

            for (int i = 0; i < RPTInfoLV.SelectedItems.Count; i++)
            {
                if (RPTInfoLV.SelectedItems[i].SubItems[9].Text == ExpectedStatus)
                {
                    string RptId = RPTInfoLV.SelectedItems[i].Text;
                    RptID = Convert.ToInt64(RptId);

                    RealPropertyTax rpt = RPTDatabase.Get(RptID);
                    SelectedRPTByStatus.Add(rpt);
                }
            }
            return SelectedRPTByStatus;
        }

        /// <summary>
        /// Updates a record to RELEASED status.
        /// </summary>
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
                SelectedRPTList.AddRange(GetSelectedRPTByStatus(RPTStatus.OR_UPLOAD));

                foreach (var rpt in SelectedRPTList)
                {
                    rpt.ReleasedBy = loginUser.DisplayName;
                    rpt.ReleasedDate = DateTime.Now;
                    rpt.Status = RPTStatus.RELEASED;
                    rpt.RepName = textRepName.Text;
                    rpt.ContactNumber = textRepContactNum.Text;
                    rpt.is_Released = true;

                    if (checkAutLetter.Checked)
                    {
                        rpt.WithAuthorizationLetter = true;
                    }

                    RPTDatabase.Update(rpt);

                    //MessageBox.Show("Receipt successfully released.");
                }
                MessageBox.Show("Receipt successfully released.");

            }
            textRepName.Clear();
            textRepContactNum.Clear();
            checkAutLetter.Checked = false;
            textTDN.Clear();

            //MainForm.INSTANCE.SearchReleased();
            RefreshListView();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            ReleaseReceipt();
        }

        /// <summary>
        /// Camera behavior in the background.
        /// </summary>
        private void CaptureCameraCallback()
        {
            Mat frame = new Mat();
            if (videoCapture.IsOpened())
            {
                // While we are not told to stop the thread, just continue with webcam device
                while (isCameraRunning)
                {
                    if (checkEnableCam.Checked)
                    {
                        // While we are not told to pause, just update the picture box with what we capture from webcam
                        if (isCapturing)
                        {
                            videoCapture.Read(frame);
                            Bitmap image = BitmapConverter.ToBitmap(frame);

                            if (pictureCam.Image != null)
                            {
                                pictureCam.Image.Dispose();
                            }
                            pictureCam.Image = image;
                        }
                    }

                    else
                    {
                        // Camera is paused, let's rest for a 1/10 of a second so we don't consume much CPU.
                        Thread.Sleep(100);
                        pictureCam.Image = null;
                    }
                }
                videoCapture.Release();

                if (pictureCam.Image != null)
                {
                    pictureCam.Image.Dispose();
                }
                pictureCam.Image = null;
            }
        }

        /// <summary>
        /// Signal the camera thread to stop and release the camera device.
        /// </summary>
        private void ReleasingForm_Deactivate(object sender, EventArgs e)
        {
            isCameraRunning = false;
            checkEnableCam.Checked = false;
        }

        /// <summary>
        /// Release the video capture device when the program is stopped. Basically, closes the camera thread when form is closed.
        /// </summary>
        private void ReleasingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isCameraRunning = false;
        }

        private void checkEnableCam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEnableCam.Checked)
            {
                // Set the flag that we want the camera to run
                isCameraRunning = true;

                // Set the pause flag to pause -> meaning camera keeps on updating the picture box
                btnStopStart.Text = "Pause";
                isCapturing = true;

                // Save button is disabled until webcam is paused.
                btnSave.Enabled = false;

                // Prepare the webcam device
                videoCapture = new VideoCapture(0);
                videoCapture.Open(0);

                // Start the thread that will keep on updating the picture box
                cameraThread = new Thread(new ThreadStart(CaptureCameraCallback));
                cameraThread.Start();
            }
            else
            {
                isCameraRunning = false;
            }
        }

        private void btnStopStart_Click(object sender, EventArgs e)
        {
            if (isCapturing)
            {
                // we are told to stop the camera here
                btnStopStart.Text = "Start";
                isCapturing = false;
                btnSave.Enabled = true;
            }
            else
            {
                // we are told to start the camera here
                btnStopStart.Text = "Stop";
                isCapturing = true;
                btnSave.Enabled = false;
            }
        }

        /// <summary>
        /// User will have the option to save the freezed frame from the pictureCam box.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            RPTAttachPicture RetrievePicture = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(RptID, DocumentType.OR_RELEASING);

            bool pictureSaved = false;

            for (int i = 0; i < RPTInfoLV.SelectedItems.Count; i++)
            {
                //if (checkAutLetter.Checked)
                //{
                    string RptId = RPTInfoLV.SelectedItems[i].Text;
                    RptID = Convert.ToInt64(RptId);

                    if (RetrievePicture == null)
                    {
                        RPTAttachPicture rptAttachPicture = new RPTAttachPicture();
                        rptAttachPicture.RptId = RptID;
                        rptAttachPicture.FileName = "ReleaseTaxpayerPicture.jpg";

                        byte[] FileData = ImageUtil.ImageToByteArray(pictureCam.Image);
                        byte[] resizeFileData = ImageUtil.resizeJpg(FileData);
                        rptAttachPicture.FileData = resizeFileData;
                        rptAttachPicture.DocumentType = DocumentType.OR_RELEASING;

                        RPTAttachPictureDatabase.InsertPicture(rptAttachPicture);
                        pictureSaved = true;
                    }
                    else
                    {
                        byte[] FileData = ImageUtil.ImageToByteArray(pictureCam.Image);
                        byte[] resizeFileData = ImageUtil.resizeJpg(FileData);
                        RetrievePicture.FileData = resizeFileData;

                        RPTAttachPictureDatabase.Update(RetrievePicture);
                        pictureSaved = true;
                    }
                //}

            }
            if (pictureSaved)
            {
                MessageBox.Show("Picture successfully saved.");

                //if (!checkAutLetter.Checked)
                //{
                //    MessageBox.Show("Kindly check if the claimant has an authorization letter.");
                //}
            }
        }

        private void textLocCode_TextChanged(object sender, EventArgs e)
        {
            string locCode = textLocCode.Text;

            List<RealPropertyTax> rptList = RPTDatabase.SelectByLocationCode(locCode);

            PopulateListView(rptList);
        }

        private void RPTInfoLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RPTInfoLV.Items.Clear();
            //VerAndValLV.Items.Clear();

            for (int i = 0; i < RPTInfoLV.Items.Count; i++)
            {
                VerAndValLV.Items[i].Selected = RPTInfoLV.Items[i].Selected;
            }

            ShowPicture();
        } 

        private void ShowPicture()
        {
            pictureBoxReceipt.Image = Properties.Resources.no_img;

            if (RPTInfoLV.SelectedItems.Count > 0)
            {
                string RptIDString = RPTInfoLV.SelectedItems[0].Text;
                long RptID = Convert.ToInt64(RptIDString);

                List<RPTAttachPicture> RetrievePictureList = RPTAttachPictureDatabase.SelectByRPT(RptID);

                foreach (RPTAttachPicture RetrievePicture in RetrievePictureList)
                {
                    if (RetrievePicture.DocumentType == DocumentType.RECEIPT)
                    {
                        pictureBoxReceipt.Image = getImageFromAttachePicture(RetrievePicture);
                        TabPicture.SelectTab(Receipt);
                        pictureBoxReceipt.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBoxReceipt.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                }
            }        
        }

        private Image getImageFromAttachePicture(RPTAttachPicture AttachPicture)
        {
            if (FileUtils.isDocument(AttachPicture.FileName))
            {
                return Properties.Resources.pdf_img;
            }
            else
            {
                return Image.FromStream(new MemoryStream(AttachPicture.FileData));
            }
        }

        private void VerAndValLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < VerAndValLV.Items.Count; i++)
            {
                RPTInfoLV.Items[i].Selected = VerAndValLV.Items[i].Selected;
            }
        }

        private void btnAdvancePickUp_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < RPTInfoLV.SelectedItems.Count; i++)
            {
                string RptId = RPTInfoLV.SelectedItems[i].Text;
                RptID = Convert.ToInt64(RptId);

                RealPropertyTax rpt = RPTDatabase.Get(RptID);

                string locCodePrefix = DateTime.Now.ToString("yy-MM ADV");

                //if receipt is for o.r pick up and has existing advance folder
                string locCode = RPTDatabase.GetAdvancePickExistingSequence(locCodePrefix, rpt.RequestingParty);

                if (locCode == null)
                {
                    int nextSequence = RPTDatabase.GetAdvancePickUpLocCodeSequence(locCodePrefix);
                    locCode = locCodePrefix + nextSequence;
                }

                rpt.LocCode = locCode;

                RPTDatabase.Update(rpt);
            }
            RefreshListView();
        }
         
        private void pictureBoxReceipt_Click(object sender, EventArgs e)
        {
            ViewAttachedPicture(DocumentType.RECEIPT);
        }

        private void ViewAttachedPicture(string documentType)
        {
            if (RPTInfoLV.SelectedItems.Count > 0)
            {
                string RptIDString = RPTInfoLV.SelectedItems[0].Text;
                long RptID = Convert.ToInt64(RptIDString);

                RPTAttachPicture RetrievePicture = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(RptID, documentType);

                if (RetrievePicture != null)
                {
                    if (FileUtils.isDocument(RetrievePicture.FileName))
                    {
                        // Download PDF and display

                        // generate random pdf filename
                        String filename = DateTimeOffset.Now.ToUnixTimeMilliseconds() + RetrievePicture.FileName;

                        // Save the file
                        String savedFileFullPath = FileUtils.SaveFileToDownloadFolder(filename, RetrievePicture.FileData);
                        //MessageBox.Show(savedFileFullPath);

                        // Open the file
                        System.Diagnostics.Process.Start(savedFileFullPath);
                    }
                    else
                    {
                        // Display the picture retrieved from DB
                        Image image = Image.FromStream(new MemoryStream(RetrievePicture.FileData));
                        ViewImageForm form = new ViewImageForm(image);
                        form.ShowDialog();
                    }
                }
                else
                {
                    // No image was uploaded to DB, we show Empty image.
                    ViewImageForm form = new ViewImageForm(Properties.Resources.no_img);
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Select a record from the list view.");
            }
        }

        private void RPTInfoLV_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            textRecSelected.Text = RPTInfoLV.SelectedItems.Count.ToString();
        }

        private void textTDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<string> StatusList = new List<string>();

                //StatusList.Add(cboStatus.Text);

                StatusList.Add(RPTStatus.OR_PICKUP);
                StatusList.Add(RPTStatus.OR_UPLOAD);

                string taxdec = textTDN.Text;

                //List<RealPropertyTax> rptList = RPTDatabase.SelectBySameGroupReleasing(taxdec, StatusList);
                List<RealPropertyTax> rptList = RPTDatabase.SelectBySameEmailAddressReleasing(taxdec, StatusList);

                PopulateListView(rptList);
                HighlightRecord();
            }
        }

        private void textRecSelected_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
