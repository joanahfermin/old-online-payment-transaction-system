using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SampleRPT1.FORMS;
using SampleRPT1.UTILITIES;
using System.IO;
using SampleRPT1.MODEL;

namespace SampleRPT1
{
    public partial class MainForm : Form
    {
        private const String BANK_TRANSFER = "BANK TRANSFER";
        private const String SEARCH_BY_TAXDEC = "SEARCH_BY_TAXDEC";
        private const String SEARCH_BY_DATE_STATUS = "SEARCH_BY_DATE_STATUS";
        private String lastSearchAction = "";

        private long RptID;
        private Timer AutoRefreshListViewTimer;

        public MainForm()
        {
            InitializeComponent();

            dtDate.Value = DateTime.Now;
            dtDateTo.Value = DateTime.Now;

            RefreshListView();
            ShowPicture();

            WindowState = FormWindowState.Maximized;
            cboStatus.Text = RPTStatus.FOR_ASSESSMENT;
            cboPaymentChannel.Visible = false;
            labelPaymentChannel.Visible = false;

            dtDate.Checked = false;
            dtDateTo.Enabled = false;
            textRemarks.Visible = false;
            LabelRemarks.Visible = false;
            btnDelete.Visible = false;

            labelRepName.Visible = false;
            textRepName.Visible = false;
            labelContactNumber.Visible = false;
            textContactNum.Visible = false;
            checkAutLetter.Visible = false;

            InitializeStatus();
            InitializeAction();
            InitializeEncodedBy();
            InitializeAutoRefreshListViewTimer();
        }

        private void InitializeAutoRefreshListViewTimer()
        {
            AutoRefreshListViewTimer = new Timer();
            AutoRefreshListViewTimer.Tick += new EventHandler(AutoRefreshListViewTimerEvent);
            AutoRefreshListViewTimer.Interval = GlobalConstants.AUTO_REFRESH_LISTVIEW_INTERVAL_SECONDS * 1000; // convert seconds to milliseconds
            AutoRefreshListViewTimer.Start();
        }

        public void InitializeStatus()
        {
            foreach (string status in RPTStatus.ALL_STATUS_VALUES)
            {
                cboStatus.Items.Add(status);
            }
        }

        /// <summary>
        /// Generate names from the RPTUser display names. 
        /// </summary>
        public void InitializeEncodedBy()
        {
            List<string> rptUserDisplayNameList = RPTUserDatabase.GenerateDisplayName();

            foreach (string item in rptUserDisplayNameList)
            {
                cboEncodedBy.Items.Add(item);
            }
        }

        /// <summary>
        /// Initializes acitons depending on the user logged in. 
        /// </summary>
        public void InitializeAction()
        {
            if (GlobalVariables.RPTUSER.isBiller)
            {
                cboAction.Items.Add(RPTAction.BILL_NO_POP);
                cboAction.Items.Add(RPTAction.BILL_WITH_POP);
            }

            if (GlobalVariables.RPTUSER.isEncoder)
            {
                cboAction.Items.Add(RPTAction.MANUAL_SEND_BILL);
            }

            if (GlobalVariables.RPTUSER.isUploader)
            {
                cboAction.Items.Add(RPTAction.MANUAL_SEND_OR);
            }

            if (GlobalVariables.RPTUSER.isVerifier)
            {
                cboAction.Items.Add(RPTAction.VERIFY_PAYMENT);
                cboAction.SelectedIndex = 0;
            }

            if (GlobalVariables.RPTUSER.isValidator)
            {
                cboAction.Items.Add(RPTAction.VALIDATE_PAYMENT);
            }

            if (GlobalVariables.RPTUSER.canDelete)
            {
                btnDelete.Visible = true;
            }
        }

        public void InitializeData()
        {
            List<RealPropertyTax> rptList = RPTDatabase.SelectLatest();

            PopulateListView(rptList);
            ShowPicture();
        }

        private void InitializePaymentChannel()
        {
            cboPaymentChannel.Items.Clear();

            if (GlobalVariables.RPTUSER.isVerifier)
            {
                cboPaymentChannel.Visible = true;

                foreach (string banks in RPTGcashPaymaya.ALL_PAYMENT_CHANNEL)
                {
                    cboStatus.Items.Add(banks);
                }
            }
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

            foreach (ListViewItem item in RPTInfoLV.Items)
            {
                //displaying of same reference number that colors the entire row, except for e-tranfer payments.
                if (item.SubItems[12].Text.Length > 0 && Convert.ToDecimal(item.SubItems[4].Text) != 0 
                    && item.SubItems[7].Text != RPTGcashPaymaya.GCASH && item.SubItems[7].Text != RPTGcashPaymaya.PAYMAYA_VISTAMASTERCARD
                    && item.SubItems[7].Text != RPTGcashPaymaya.PAYMAYA_EWALLET && item.SubItems[7].Text != RPTGcashPaymaya.PAYGATE_ONLINE_BANKING)
                {
                    item.BackColor = Color.LightYellow;
                    VerAndValLV.Items[item.Index].BackColor = Color.LightYellow;
                }

                if (item.SubItems[12].Text.Length > 0 && item.SubItems[7].Text != RPTGcashPaymaya.GCASH && item.SubItems[7].Text != RPTGcashPaymaya.PAYMAYA_VISTAMASTERCARD
                    && item.SubItems[7].Text != RPTGcashPaymaya.PAYMAYA_EWALLET && item.SubItems[7].Text != RPTGcashPaymaya.PAYGATE_ONLINE_BANKING)
                {
                    item.BackColor = Color.LightYellow;
                    VerAndValLV.Items[item.Index].BackColor = Color.LightYellow;
                }

                if (Convert.ToDecimal(item.SubItems[5].Text) != 0 && Convert.ToDecimal(item.SubItems[6].Text) < 0)
                {
                    item.BackColor = Color.Red;
                    VerAndValLV.Items[item.Index].BackColor = Color.Red;
                }

                //displaying of insufficient payment record.
                if (Convert.ToDecimal(item.SubItems[4].Text) < Convert.ToDecimal(item.SubItems[3].Text) &&
                    Convert.ToDecimal(item.SubItems[4].Text) != 0)
                {
                    item.BackColor = Color.Red;
                    VerAndValLV.Items[item.Index].BackColor = Color.Red;
                }
            }
        }

        public void SearchByTaxDec(String taxDec)
        {
            textTDN.Text = taxDec;
        }

        private void textTDN_TextChanged(object sender, EventArgs e)
        {
            SearchByTaxDec();
        }

        private void AutoRefreshListViewTimerEvent(object sender, EventArgs e)
        {
            if (cbAutoRefresh.Checked)
            {
                if (lastSearchAction == SEARCH_BY_TAXDEC)
                {
                    SearchByTaxDec();
                } else if (lastSearchAction == SEARCH_BY_DATE_STATUS)
                {
                    RefreshListView();
                }
            }
        }

        /// <summary>
        /// Populate List View based on Text entered in TaxDec textbox.
        /// </summary>
        public void SearchByTaxDec()
        {
            lastSearchAction = SEARCH_BY_TAXDEC;

            string taxdec = textTDN.Text;

            List<RealPropertyTax> rptList = RPTDatabase.SelectBySameGroup(taxdec);

            PopulateListView(rptList);
            ShowPicture();
        }

        /// <summary>
        /// Populate List View based on Date Range and Status.
        /// </summary>
        public void RefreshListView()
        {
            lastSearchAction = SEARCH_BY_DATE_STATUS;

            List<string> StatusList = new List<string>();
            StatusList.Add(cboStatus.Text);

            List<string> PaymentChannelList = new List<string>();

            List<string> EncodedByList = new List<string>();
            EncodedByList.Add(cboEncodedBy.Text);

            if (cboPaymentChannel.Text == BANK_TRANSFER)
            {
                List<RPTBank> bankList = RPTBankDatabase.SelectAllBank();

                foreach (RPTBank bank in bankList)
                {
                    PaymentChannelList.Add(bank.BankName);
                }
            }
            else
            {
                PaymentChannelList.Add(cboPaymentChannel.Text);
            }

            List<RealPropertyTax> rptList;

            if (dtDate.Checked)
            {
                dtDateTo.Enabled = true;
                DateTime encodedDateFrom = dtDate.Value;
                DateTime encodedDateTo = dtDateTo.Value;

                if (cboStatus.Text == RPTStatus.PAYMENT_VERIFICATION && cboAction.Text == RPTAction.VERIFY_PAYMENT)
                {
                    rptList = RPTDatabase.SelectByDateFromToAndStatusAndPaymentChannel(encodedDateFrom, encodedDateTo, StatusList, PaymentChannelList);
                }

                else if (cboStatus.Text == RPTStatus.FOR_ASSESSMENT)
                {
                    rptList = RPTDatabase.SelectByDateFromToAndStatusAndEncodedBy(encodedDateFrom, encodedDateTo, StatusList, EncodedByList);
                }
                else
                {
                    rptList = RPTDatabase.SelectByDateFromToAndStatus(encodedDateFrom, encodedDateTo, StatusList);
                }
            }

            else
            {
                dtDateTo.Enabled = false;

                rptList = RPTDatabase.SelectByStatus(StatusList);

            }

            PopulateListView(rptList);
            ShowPicture();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            AddRPTForm addRPTForm = new AddRPTForm();
            addRPTForm.setParent(this);

            addRPTForm.ShowDialog();
        }

        private void btnSearchDateStatus_Click(object sender, EventArgs e)
        {
            RefreshListView();

            if (cboStatus.Text == RPTStatus.FOR_ASSESSMENT && dtDate.Checked == true)
            {
                labelEncodedBy.Visible = true;
                cboEncodedBy.Visible = true;
            }
            else
            {
                labelEncodedBy.Visible = false;
                cboEncodedBy.Visible = false;
            }

        }

        private void dtDateTo_ValueChanged(object sender, EventArgs e)
        {
            RefreshListView();
        }

        public void SearchForAssessment()
        {
            cboStatus.Text = RPTStatus.FOR_ASSESSMENT;
            RefreshListView();
        }

        public void SearchBillSent()
        {
            cboStatus.Text = RPTStatus.BILL_SENT;
            RefreshListView();
        }

        public void SearchPaymentVerification()
        {
            cboStatus.Text = RPTStatus.PAYMENT_VERIFICATION;
            RefreshListView();
        }

        public void SearchORPickup()
        {
            cboStatus.Text = RPTStatus.OR_PICKUP;
            RefreshListView();
        }

        public void SearchReleased()
        {
            cboStatus.Text = RPTStatus.RELEASED;
            RefreshListView();
        }

        private void cboEncodedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListView();

            if (cboStatus.Text != RPTStatus.RELEASED)
            {
                labelRepName.Visible = false;
                textRepName.Visible = false;
                checkAutLetter.Visible = false;

                labelContactNumber.Visible = false;
                textContactNum.Visible = false;
            }

            if (cboStatus.Text != RPTStatus.FOR_ASSESSMENT)
            {
                labelEncodedBy.Visible = false;
                cboEncodedBy.Visible = false;

                LabelNumBills.Visible = false;
                textNumOfBills.Visible = false;
            }
            else
            {
                LabelNumBills.Visible = true;
                textNumOfBills.Visible = true;


                labelEncodedBy.Visible = true;
                cboEncodedBy.Visible = true;
            }
        }

        private void RPTInfoLV_DoubleClick(object sender, EventArgs e)
        {
            if (RPTInfoLV.SelectedItems.Count > 0 && GlobalVariables.RPTUSER.isBiller &&
                RPTInfoLV.SelectedItems[0].SubItems[9].Text == RPTStatus.FOR_ASSESSMENT ||
                RPTInfoLV.SelectedItems[0].SubItems[9].Text == RPTStatus.ASSESSMENT_PRINTED ||
                RPTInfoLV.SelectedItems[0].SubItems[9].Text == RPTStatus.BILL_SENT ||
                RPTInfoLV.SelectedItems[0].SubItems[9].Text == RPTStatus.PAYMENT_VERIFICATION)
            {
                if (RPTInfoLV.SelectedItems[0].SubItems[12].Text.Length > 0)
                {
                    string taxDecList = RPTInfoLV.SelectedItems[0].SubItems[1].Text;

                    UpdateMultipleRPTForm updateMultipleRPTForm = new UpdateMultipleRPTForm(taxDecList);
                    updateMultipleRPTForm.setParent(this);
                    updateMultipleRPTForm.ShowDialog();
                }

                else
                {
                    List<long> RptIDList = new List<long>();

                    for (int i = 0; i < RPTInfoLV.SelectedItems.Count; i++)
                    {
                        string RptId = RPTInfoLV.SelectedItems[i].Text;
                        RptID = Convert.ToInt32(RptId);

                        RptIDList.Add(Convert.ToInt32(RptID));
                    }

                    UpdateRPTForm updateRPTForm = new UpdateRPTForm(RptIDList);
                    updateRPTForm.setParent(this);
                    updateRPTForm.ShowDialog();
                }
            }
        }

        private void VerAndValLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < VerAndValLV.Items.Count; i++)
            {
                RPTInfoLV.Items[i].Selected = VerAndValLV.Items[i].Selected;
            }
        }

        private void SetAction(string NewAction)
        {
            if (cboAction.Items.Contains(NewAction))
            {
                cboAction.Text = NewAction;
            }
        }

        private void ChangeAction()
        {
            if (RPTInfoLV.SelectedItems.Count > 0)
            {
                string Status = RPTInfoLV.SelectedItems[0].SubItems[9].Text;

                if (Status == RPTStatus.FOR_ASSESSMENT)
                {
                    SetAction(RPTAction.BILL_NO_POP);
                }

                if (Status == RPTStatus.ASSESSMENT_PRINTED)
                {
                    SetAction(RPTAction.MANUAL_SEND_BILL);
                    TabPicture.SelectTab(Assessment);
                }

                //SKIP RTPSTATUS.BILLSENT

                if (Status == RPTStatus.PAYMENT_VERIFICATION)
                {
                    SetAction(RPTAction.VERIFY_PAYMENT);
                }

                if (Status == RPTStatus.PAYMENT_VALIDATION)
                {
                    SetAction(RPTAction.VALIDATE_PAYMENT);
                }

                if (Status == RPTStatus.OR_UPLOAD)
                {
                    SetAction(RPTAction.MANUAL_SEND_OR);
                    TabPicture.SelectTab(Receipt);
                }

                if (Status == RPTStatus.OR_PICKUP)
                {
                    SetAction(RPTAction.RELEASE_OR);
                }

                if (Status == RPTStatus.RELEASED)
                {
                    TabPicture.SelectTab(OR_Release);
                }
            }
        }

        private void CalculateTotalAmount()
        {
            for (int i = 0; i < RPTInfoLV.Items.Count; i++)
            {
                VerAndValLV.Items[i].Selected = RPTInfoLV.Items[i].Selected;
            }

            decimal TotalAmountToPay = 0;
            decimal TotalAmountTransferred = 0;

            for (int i = 0; i < RPTInfoLV.SelectedItems.Count; i++)
            {
                decimal AmountToPay = Convert.ToDecimal(RPTInfoLV.SelectedItems[i].SubItems[3].Text);
                TotalAmountToPay = AmountToPay + TotalAmountToPay;

                decimal AmountTransferred = Convert.ToDecimal(RPTInfoLV.SelectedItems[i].SubItems[4].Text);
                TotalAmountTransferred = AmountTransferred + TotalAmountTransferred;
            }

            textTotalAmount2Pay.Text = TotalAmountToPay.ToString();
            textTotalAmountTransferred.Text = TotalAmountTransferred.ToString();
        }

        private void ShowRepsInfo()
        {
            RealPropertyTax retrievedRepsInfo = RPTDatabase.Get(RptID);

            Boolean FirstRecord = true;

            foreach (var rpt in RPTInfoLV.SelectedItems)
            {
                if (FirstRecord == true)
                {
                    if (retrievedRepsInfo.Status == RPTStatus.RELEASED)
                    {
                        labelRepName.Visible = true;
                        textRepName.Visible = true;
                        checkAutLetter.Visible = true;

                        labelContactNumber.Visible = true;
                        textContactNum.Visible = true;

                        textRepName.Text = retrievedRepsInfo.RepName;
                        textContactNum.Text = retrievedRepsInfo.ContactNumber;

                        checkAutLetter.Checked = retrievedRepsInfo.WithAuthorizationLetter;
                    }
                    FirstRecord = false;
                }
                else
                { 
                    textRepName.Text = "***";
                    textContactNum.Text = "***";
                    checkAutLetter.Visible = false;
                }
            }
        }

        private void RPTInfoLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RPTInfoLV.SelectedItems.Count > 0)
            {
                Clipboard.SetText(RPTInfoLV.SelectedItems[0].SubItems[1].Text);

                string Status = RPTInfoLV.SelectedItems[0].SubItems[9].Text;

                if (Status == RPTStatus.FOR_ASSESSMENT)
                {
                    LabelNumBills.Visible = true;
                    textNumOfBills.Visible = true;
                }
                else
                {
                    LabelNumBills.Visible = false;
                    textNumOfBills.Visible = false;
                }
            }

            ChangeAction();

            CalculateTotalAmount();

            ShowPicture();

            ShowRepsInfo();
        }

        private void ShowPicture()
        {
            pictureBoxAssessment.Image = Properties.Resources.no_img;
            pictureBoxReceipt.Image = Properties.Resources.no_img;
            pictureBoxORrelease.Image = Properties.Resources.no_img;

            if (RPTInfoLV.SelectedItems.Count > 0)
            {
                string AcquiredRptid = RPTInfoLV.SelectedItems[0].Text;
                RptID = Convert.ToInt64(AcquiredRptid);

                List<RPTAttachPicture> RetrievePictureList = RPTAttachPictureDatabase.SelectByRPT(RptID);

                foreach (RPTAttachPicture RetrievePicture in RetrievePictureList)
                {
                    if (RetrievePicture.DocumentType == DocumentType.ASSESSMENT)
                    {
                        pictureBoxAssessment.Image = getImageFromAttachePicture(RetrievePicture);
                        TabPicture.SelectTab(Assessment);
                        pictureBoxAssessment.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (RetrievePicture.DocumentType == DocumentType.RECEIPT)
                    {
                        pictureBoxReceipt.Image = getImageFromAttachePicture(RetrievePicture);
                        TabPicture.SelectTab(Receipt);
                        pictureBoxReceipt.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (RetrievePicture.DocumentType == DocumentType.OR_RELEASING)
                    {
                        pictureBoxORrelease.Image = getImageFromAttachePicture(RetrievePicture);
                        TabPicture.SelectTab(OR_Release);
                        pictureBoxORrelease.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            else
            {
                pictureBoxAssessment.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBoxReceipt.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBoxORrelease.SizeMode = PictureBoxSizeMode.CenterImage;
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

        private bool CheckSameStatus(string ExpectedStatus)
        {
            bool SameStatus = true;

            for (int i = 0; i < RPTInfoLV.SelectedItems.Count; i++)
            {
                if (RPTInfoLV.SelectedItems[i].SubItems[9].Text != ExpectedStatus)
                {
                    SameStatus = false;
                }
            }
            return SameStatus;
        }

        private List<RealPropertyTax> GetSelectedRPTByStatus(string ExpectedStatus)
        {
            List<RealPropertyTax> SelectedRPTByStatus = new List<RealPropertyTax>();

            for (int i = 0; i < RPTInfoLV.SelectedItems.Count; i++)
            {
                if (RPTInfoLV.SelectedItems[i].SubItems[9].Text == ExpectedStatus)
                {
                    string RptId = RPTInfoLV.SelectedItems[i].Text;
                    RptID = Convert.ToInt32(RptId);

                    RealPropertyTax rpt = RPTDatabase.Get(RptID);
                    SelectedRPTByStatus.Add(rpt);
                }
            }
            return SelectedRPTByStatus;
        }

        private void cboAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAction.Text == RPTAction.BILL_NO_POP || cboAction.Text == RPTAction.BILL_WITH_POP)
            {
                //BILL QUANTITY
                textNumOfBills.Visible = true;
                LabelNumBills.Visible = true;

                //BILL REMARKS
                textRemarks.Visible = false;
                LabelRemarks.Visible = false;
            }
            else
            {
                textNumOfBills.Visible = false;
                LabelNumBills.Visible = false;
            }

            if (cboAction.Text == RPTAction.VERIFY_PAYMENT)
            {
                //PAYMENT CHANNEL COMBOBOX AND LABEL.
                cboPaymentChannel.Visible = true;
                labelPaymentChannel.Visible = true;
                InitializePaymentChannel();
            }

            if (cboAction.Text != RPTAction.BILL_NO_POP && cboAction.Text != RPTAction.BILL_WITH_POP && cboAction.Text != RPTAction.VERIFY_PAYMENT)
            {
                cboPaymentChannel.Visible = false;
                labelPaymentChannel.Visible = false;

                textRemarks.Visible = true;
                LabelRemarks.Visible = true;
            }
        }

        private void BillWithPayment()
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<RealPropertyTax> SelectedRPTList = GetSelectedRPTByStatus(RPTStatus.FOR_ASSESSMENT);

                bool TransferredAmountHaveValue = true;

                foreach (var rpt in SelectedRPTList)
                {
                    if (rpt.AmountTransferred != 0)
                    {
                        rpt.BilledBy = GlobalVariables.RPTUSER.DisplayName;
                        rpt.BilledDate = DateTime.Now;
                        rpt.Status = RPTStatus.PAYMENT_VERIFICATION;
                        rpt.BillCount = textNumOfBills.Text;

                        RPTDatabase.Update(rpt);
                        cboStatus.Text = RPTStatus.PAYMENT_VERIFICATION;
                    }
                    else
                    {
                        TransferredAmountHaveValue = false;
                    }
                }

                if (CheckSameStatus(RPTStatus.FOR_ASSESSMENT) == false || TransferredAmountHaveValue == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                    cboStatus.Text = RPTStatus.FOR_ASSESSMENT;
                }
                RefreshListView();
                //textNumOfBills.Clear();
            }
        }

        private void BillWithNoPayment()
        {
            validateForm();

            if (Validations.HaveErrors(errorProvider1))
            {
                return;
            }

            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<RealPropertyTax> SelectedRPTList = GetSelectedRPTByStatus(RPTStatus.FOR_ASSESSMENT);

                bool TransferredAmountHaveNoValue = true;

                foreach (var rpt in SelectedRPTList)
                {
                    if (rpt.AmountTransferred == 0)
                    {
                        rpt.BilledBy = GlobalVariables.RPTUSER.DisplayName;
                        rpt.BilledDate = DateTime.Now;
                        rpt.Status = RPTStatus.ASSESSMENT_PRINTED;
                        rpt.BillCount = textNumOfBills.Text;

                        RPTDatabase.Update(rpt);
                        cboStatus.Text = RPTStatus.ASSESSMENT_PRINTED;
                    }
                    else
                    {
                        TransferredAmountHaveNoValue = false;
                    }
                }

                if (CheckSameStatus(RPTStatus.FOR_ASSESSMENT) == false || TransferredAmountHaveNoValue == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                    cboStatus.Text = RPTStatus.FOR_ASSESSMENT;
                }

                RefreshListView();
                //textNumOfBills.Clear();
            }
        }

        private void ManualSendBill()
        {
            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<RealPropertyTax> SelectedRPTList = GetSelectedRPTByStatus(RPTStatus.ASSESSMENT_PRINTED);

                bool TransferredAmountHaveValue = true;

                foreach (var rpt in SelectedRPTList)
                {
                    if (rpt.AmountTransferred == 0)
                    {
                        rpt.BilledBy = GlobalVariables.RPTUSER.DisplayName;
                        rpt.BilledDate = DateTime.Now;
                        rpt.Status = RPTStatus.BILL_SENT;

                        RPTDatabase.Update(rpt);
                        cboStatus.Text = RPTStatus.BILL_SENT;
                    }
                    else
                    {
                        TransferredAmountHaveValue = false;
                    }
                }
                if (CheckSameStatus(RPTStatus.ASSESSMENT_PRINTED) == false || TransferredAmountHaveValue == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                    cboStatus.Text = RPTStatus.ASSESSMENT_PRINTED;
                }

                RefreshListView();
                //textNumOfBills.Clear();
            }
        }

        private void ManualUploadReceipt() 
        {
            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<RealPropertyTax> SelectedRPTList = GetSelectedRPTByStatus(RPTStatus.OR_UPLOAD);

                foreach (var rpt in SelectedRPTList)
                {
                    rpt.UploadedBy = GlobalVariables.RPTUSER.DisplayName;
                    rpt.UploadedDate = DateTime.Now;
                    rpt.Status = RPTStatus.OR_PICKUP;

                    RPTDatabase.Update(rpt);
                    cboStatus.Text = RPTStatus.OR_PICKUP;
                }

                if (CheckSameStatus(RPTStatus.OR_UPLOAD) == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                    cboStatus.Text = RPTStatus.OR_UPLOAD;
                }

                RefreshListView();
            }
        }

        private void validateForm()
        {
            errorProvider1.Clear(); 

            Validations.ValidateRequired(errorProvider1, textNumOfBills, "Number of bills");
        }   

        private void VerifyPayment()
        {
            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<RealPropertyTax> SelectedRPTList = GetSelectedRPTByStatus(RPTStatus.PAYMENT_VERIFICATION);

                bool AllProcessed = true;

                foreach (var rpt in SelectedRPTList)
                {
                    rpt.VerifiedBy = GlobalVariables.RPTUSER.DisplayName;
                    rpt.VerifiedDate = DateTime.Now;
                    rpt.Status = RPTStatus.PAYMENT_VALIDATION;
                    rpt.VerRemarks = textRemarks.Text;

                    if (rpt.AmountTransferred >= rpt.AmountToPay)
                    {
                        RPTDatabase.Update(rpt);
                        cboStatus.Text = RPTStatus.PAYMENT_VALIDATION;
                    }
                    else
                    {
                        AllProcessed = false;
                    }
                }

                if (CheckSameStatus(RPTStatus.PAYMENT_VERIFICATION) == false || AllProcessed == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                    cboStatus.Text = RPTStatus.PAYMENT_VERIFICATION;
                }

                cboStatus.Text = RPTStatus.PAYMENT_VALIDATION;
                RefreshListView();
            }
            textRemarks.Visible = false;
        }

        private void ValidatePayment()
        {
            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<RealPropertyTax> SelectedRPTList = GetSelectedRPTByStatus(RPTStatus.PAYMENT_VALIDATION);

                foreach (var rpt in SelectedRPTList)
                {
                    rpt.ValidatedBy = GlobalVariables.RPTUSER.DisplayName;
                    rpt.ValidatedDate = DateTime.Now;
                    rpt.Status = RPTStatus.OR_UPLOAD;
                    rpt.ValRemarks = textRemarks.Text;

                    RPTDatabase.Update(rpt);
                    cboStatus.Text = RPTStatus.OR_UPLOAD;
                }

                if (CheckSameStatus(RPTStatus.PAYMENT_VALIDATION) == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                    cboStatus.Text = RPTStatus.PAYMENT_VALIDATION;
                }

                RefreshListView();
            }
            textRemarks.Visible = false;

        }

        private void textTotalAmount2Pay_TextChanged(object sender, EventArgs e)
        {
            decimal ConvertedTotalAmountToPay = decimal.Parse(textTotalAmount2Pay.Text, System.Globalization.NumberStyles.Currency);
            textTotalAmount2Pay.Text = ConvertedTotalAmountToPay.ToString("N2");
        }

        private void textTotalAmountTransferred_TextChanged(object sender, EventArgs e)
        {
            decimal ConvertedTotalAmountTransferred = decimal.Parse(textTotalAmountTransferred.Text, System.Globalization.NumberStyles.Currency);
            textTotalAmountTransferred.Text = ConvertedTotalAmountTransferred.ToString("N2");
        }

        private void btnMultipleRecordOnePayment_Click(object sender, EventArgs e)
        {
            AddMultipleOnePaymentForm addMultipleOnePayment = new AddMultipleOnePaymentForm();
            addMultipleOnePayment.setParent(this);
            addMultipleOnePayment.ShowDialog();
        }

        public void AllocateExcess()
        {
            if (RPTInfoLV.SelectedItems.Count > 0)
            {
                string RptId = RPTInfoLV.SelectedItems[0].Text;
                decimal ExcessShortAmountNotNull = Convert.ToDecimal(RPTInfoLV.SelectedItems[0].SubItems[6].Text);
                RptID = Convert.ToInt32(RptId);

                if (ExcessShortAmountNotNull > 0)
                {
                    AllocateExcessForm AllocateExcess = new AllocateExcessForm();
                    //AllocateExcess.setParent(this);
                    AllocateExcess.setRptId(RptID);
                    AllocateExcess.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No Excess/Short Amount.");
                }
            }
        }

        public void AllocateShort()
        {
            if (RPTInfoLV.SelectedItems.Count > 0)
            {
                string RptId = RPTInfoLV.SelectedItems[0].Text;
                decimal ExcessShortAmountNotNull = Convert.ToDecimal(RPTInfoLV.SelectedItems[0].SubItems[6].Text);
                RptID = Convert.ToInt32(RptId);

                if (ExcessShortAmountNotNull < 0)
                {
                    BalanceShort balanceShort = new BalanceShort();

                    //balanceShort.setParent(this);
                    balanceShort.setRptId(RptID);
                    balanceShort.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No Excess/Short Amount.");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (RPTInfoLV.SelectedItems.Count > 0)
            {
                RealPropertyTax rpt = RPTDatabase.Get(RptID);

                if (rpt.Status == RPTStatus.ASSESSMENT_PRINTED && TabPicture.SelectedTab.Text == DocumentType.ASSESSMENT)
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (openFileDialog1.CheckFileExists)
                        {
                            textFileName.Text = openFileDialog1.FileName;

                            //Reads the content of the document into a byte array and stores it to the FileData variable. 
                            byte[] FileData = File.ReadAllBytes(textFileName.Text);

                            //This creates an image from the specified byte array and converts the byte array into a picture and displays in the imagebox.
                            if (textFileName.Text.ToLower().EndsWith("pdf"))
                            {
                                pictureBoxAssessment.Image = Properties.Resources.pdf_img;
                            }
                            else
                            {
                                pictureBoxAssessment.Image = Image.FromStream(new MemoryStream(FileData));
                            }
                        }
                    }
                }

                if (rpt.Status == RPTStatus.OR_UPLOAD && TabPicture.SelectedTab.Text == DocumentType.RECEIPT)
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (openFileDialog1.CheckFileExists)
                        {
                            textFileName.Text = openFileDialog1.FileName;

                            //Reads the content of the document into a byte array and stores it to the FileData variable. 
                            byte[] FileData = File.ReadAllBytes(textFileName.Text);

                            //This creates an image from the specified byte array and converts the byte array into a picture and displays in the imagebox.
                            if (textFileName.Text.ToLower().EndsWith("pdf"))
                            {
                                pictureBoxReceipt.Image = Properties.Resources.pdf_img;
                            }
                            else
                            {
                                pictureBoxReceipt.Image = Image.FromStream(new MemoryStream(FileData));
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Status of record is not yet ASSESSMENT PRINTED or FOR O.R UPLOAD.");
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (RPTInfoLV.SelectedItems.Count > 0)
            {
                RealPropertyTax rpt = RPTDatabase.Get(RptID);

                if (rpt.Status == RPTStatus.ASSESSMENT_PRINTED || rpt.Status == RPTStatus.OR_UPLOAD)
                {
                    string AcquiredRptid = RPTInfoLV.SelectedItems[0].Text;
                    long Rptid = Convert.ToInt64(AcquiredRptid);

                    string documentType;

                    if (TabPicture.SelectedTab.Text == DocumentType.ASSESSMENT)
                    {
                        documentType = DocumentType.ASSESSMENT;
                    }
                    else
                    {
                        documentType = DocumentType.RECEIPT;
                    }

                    RPTAttachPicture RetrievePicture = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(Rptid, documentType);

                    if (RetrievePicture == null)
                    {
                        RPTAttachPicture rptAttachPicture = new RPTAttachPicture();

                        rptAttachPicture.RptId = Convert.ToInt64(AcquiredRptid);
                        rptAttachPicture.FileName = Path.GetFileName(textFileName.Text);

                        byte[] FileData = File.ReadAllBytes(textFileName.Text);
                        if (rptAttachPicture.FileName.ToLower().EndsWith("pdf"))
                        {
                            // If PDF, store the file content as is
                            rptAttachPicture.FileData = FileData;
                        }
                        else
                        {
                            // If JPG, then compress the image
                            byte[] resizeFileData = ImageUtil.resizeJpg(FileData);
                            rptAttachPicture.FileData = resizeFileData;
                        }
                        rptAttachPicture.DocumentType = documentType;

                        RPTAttachPictureDatabase.InsertPicture(rptAttachPicture);

                    }

                    if (RetrievePicture != null)
                    {
                        RetrievePicture.FileName = Path.GetFileName(textFileName.Text);

                        byte[] FileData = File.ReadAllBytes(textFileName.Text);
                        if (RetrievePicture.FileName.ToLower().EndsWith("pdf"))
                        {
                            // If PDF, store the file content as is
                            RetrievePicture.FileData = FileData;
                        }
                        else
                        {
                            // If JPG, then compress the image
                            byte[] resizeFileData = ImageUtil.resizeJpg(FileData);
                            RetrievePicture.FileData = resizeFileData;
                        }

                        RPTAttachPictureDatabase.Update(RetrievePicture);
                    }

                    MessageBox.Show("Photo uploaded.");
                    textFileName.Clear();
                }
                else
                {
                    MessageBox.Show("Cannot upload without attachment.");
                }
            }
            ShowPicture();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textTDN.Select();

            textFileName.Visible = false;

            cboStatus.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboStatus.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboAction.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboAction.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboPaymentChannel.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboPaymentChannel.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void SendEmail()
        {
            if (RPTInfoLV.SelectedItems.Count > 0)

            {
                List<long> RptIDList = new List<long>();

                for (int i = 0; i < RPTInfoLV.SelectedItems.Count; i++)
                {
                    string RptId = RPTInfoLV.SelectedItems[i].Text;
                    RptID = Convert.ToInt32(RptId);

                    RptIDList.Add(Convert.ToInt32(RptID));
                }
                SendEmailForm sendEmailForm = new SendEmailForm(RptIDList);
                sendEmailForm.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (RPTInfoLV.SelectedIndices.Count > 0)
            {
                var Confirmation = MessageBox.Show("Are you sure you want to delete record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Confirmation == DialogResult.Yes)
                {
                    for (int i = RPTInfoLV.SelectedIndices.Count - 1; i >= 0; i--)
                    {
                        RPTInfoLV.Items.RemoveAt(RPTInfoLV.SelectedIndices[i]);
                    }

                    RealPropertyTax RptRecord = RPTDatabase.Get(RptID);
                    RPTDatabase.Delete(RptRecord);
                }
            }

            else
            {
                MessageBox.Show("Invalid deletion of record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            InitializeData();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (cboAction.Text == RPTAction.BILL_NO_POP)
            {
                BillWithNoPayment();
            }

            if (cboAction.Text == RPTAction.BILL_WITH_POP)
            {
                BillWithPayment();
            }

            if (cboAction.Text == RPTAction.MANUAL_SEND_BILL)
            {
                ManualSendBill();
            }

            if (cboAction.Text == RPTAction.MANUAL_SEND_OR)
            {
                ManualUploadReceipt();
            }

            if (cboAction.Text == RPTAction.VERIFY_PAYMENT)
            {
                VerifyPayment();
            }

            if (cboAction.Text == RPTAction.VALIDATE_PAYMENT)
            {
                ValidatePayment();
            }
        }

        private void cboPaymentChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListView();
        }

        //Auto-suggest in a dialog box.
        private void cboEncodedBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboEncodedBy.DroppedDown = false;
        }

        //Auto-suggest in a dialog box.
        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboStatus.DroppedDown = false;
        }

        //Auto-suggest in a dialog box.
        private void cboAction_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboAction.DroppedDown = false;
        }

        //Auto-suggest in a dialog box.
        private void cboPaymentChannel_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboPaymentChannel.DroppedDown = false;
        }

        private void pictureBoxAssessment_Click(object sender, EventArgs e)
        {
            ViewAttachedPicture(DocumentType.ASSESSMENT);
        }


        private void pictureBoxReceipt_Click(object sender, EventArgs e)
        {
            ViewAttachedPicture(DocumentType.RECEIPT);
        }

        private void pictureBoxORrelease_Click(object sender, EventArgs e)
        {
            ViewAttachedPicture(DocumentType.OR_RELEASING);
        }

        private void ViewAttachedPicture(string documentType)
        {
            if (RPTInfoLV.SelectedItems.Count > 0)
            {
                RPTAttachPicture RetrievePicture = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(RptID, documentType);
                if (RetrievePicture != null)
                {
                    if (RetrievePicture.FileName.ToLower().EndsWith("pdf"))
                    {
                        // Download PDF and display

                        // generate random pdf filename
                        String filename = DateTimeOffset.Now.ToUnixTimeMilliseconds() + ".pdf"; 

                        // Save the file
                        String savedFileFullPath = FileUtils.SaveFileToDownloadFolder(filename, RetrievePicture.FileData);
                        //MessageBox.Show(savedFileFullPath);

                        // Open the file
                        System.Diagnostics.Process.Start(savedFileFullPath);
                    }
                    else
                    {
                        // Display the picture retrieved from DB
                        Image image =  Image.FromStream(new MemoryStream(RetrievePicture.FileData));
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

        public long getSelectedRptID()
        {
            if (RPTInfoLV.SelectedItems.Count>0)
            {
                return Convert.ToInt64(RPTInfoLV.SelectedItems[0].Text);
            }
            else
            {
                return 0;
            }
        }
    }
}
