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
using SampleRPT1.Service;
using SampleRPT1.DATABASE;

namespace SampleRPT1
{
    public partial class MainForm : Form
    {
        public static MainForm INSTANCE;

        private RPTUser loginUser = SecurityService.getLoginUser();

        private const String BANK_TRANSFER = "BANK TRANSFER";
        private const String SEARCH_BY_TAXDEC = "SEARCH_BY_TAXDEC";
        private const String SEARCH_BY_DATE_STATUS = "SEARCH_BY_DATE_STATUS";
        private String lastSearchAction = "";

        private Timer AutoRefreshListViewTimer;

        MainFormListViewHelper mainFormListViewHelper;
        public MainForm(Form parentForm)
        {
            InitializeComponent();
            mainFormListViewHelper = new MainFormListViewHelper(RPTInfoLV, VerAndValLV);

            // Set instance and mdi related properties
            INSTANCE = this;
            WindowState = FormWindowState.Maximized;
            MdiParent = parentForm;
            ControlBox = false;

            // default from and to date
            dtDate.Value = DateTime.Now;
            dtDateTo.Value = DateTime.Now;
            dtDate.Checked = false;
            dtDateTo.Enabled = false;

            // Default Status to show
            cboStatus.Text = RPTStatus.FOR_ASSESSMENT;

            // Initialize Invisible Controls
            cboPaymentChannel.Visible = false;
            labelPaymentChannel.Visible = false;
            cboValidator.Visible = false;
            labelValidatedBy.Visible = false;
            btnDelete.Visible = false;

            textRemarks.Visible = false;
            LabelRemarks.Visible = false;
            btnDelete.Visible = false;

            labelRepName.Visible = false;
            textRepName.Visible = false;
            labelContactNumber.Visible = false;
            textContactNum.Visible = false;
            checkAutLetter.Visible = false;

            // Load various supporting data
            InitializeStatus();
            InitializeAction();
            InitializeEncodedBy();
            InitializeAutoRefreshListViewTimer();
            InitializeValidator();

            // Show content of list view
            RefreshListView();
            ShowPicture();
        }

        public void Show()
        {
            base.Show();
            WindowState = FormWindowState.Maximized;
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
            List<string> AllowedRptActions = SecurityService.getLoginUserAllowedRptActions();
            foreach (string rptAction in AllowedRptActions)
            {
                cboAction.Items.Add(rptAction);
            }
            cboAction.SelectedIndex = 0;

            if (loginUser.canDelete)
            {
                btnDelete.Visible = true;
            }
        }

        public void InitializeData()
        {
            List<RealPropertyTax> rptList = RPTDatabase.SelectLatest();

            mainFormListViewHelper.PopulateListView(rptList);
            ShowPicture();
        }

        private void InitializePaymentChannel()
        {
            cboPaymentChannel.Items.Clear();

            if (loginUser.isVerifier || loginUser.isValidator)
            {
                cboPaymentChannel.Visible = true;

                foreach (string banks in RPTGcashPaymaya.ALL_PAYMENT_CHANNEL)
                {
                    cboPaymentChannel.Items.Add(banks);
                }
            }
        }

        private void InitializeValidator()
        {
            cboValidator.Items.Clear();

            List<string> rptUserDisplayNameList = RPTUserDatabase.GenerateDisplayNameofValidator();

            foreach (string item in rptUserDisplayNameList)
            {
                cboValidator.Items.Add(item);
            }
        }

        private void cboValidator_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboValidator.DroppedDown = false;
        }


        public void SearchByTaxDec(String taxDec)
        {
            textTDN.Text = taxDec;
        }

        private void textTDN_TextChanged(object sender, EventArgs e)
        {
            SearchByTaxDec();
            HighlightRecord();
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
            List<RealPropertyTax> rptList = null;

            if (loginUser.isValidator && SecurityService.getLoginUser().MachNo != null)
            {
                rptList = RPTDatabase.SelectByVerifiedDate(taxdec);
            }
            else

            if (loginUser.isVerifier)
            {
                rptList = RPTDatabase.SelectByEncodedDate(taxdec);
            }
            //else
            //if (loginUser.isValidator)
            //{
            //    rptList = RPTDatabase.SelectByDateFromToAndStatusAndVerifiedDate(taxdec);
            //}
            else
            {
                rptList = RPTDatabase.SelectBySameGroup(taxdec);
            }
            mainFormListViewHelper.PopulateListView(rptList);
            ShowPicture();
        }

        private List<string> getBankList()
        {
            List<string> BankList = new List<string>();
            string PaymentChannel = cboPaymentChannel.Text;

            if (PaymentChannel == RPTGcashPaymaya.BANK_TRANSFER)
            {
                List<RPTBank> bankList = RPTBankDatabase.SelectAllNot_E_Banks();
                foreach (RPTBank bank in bankList)
                {
                    BankList.Add(bank.BankName);
                }
            }
            else
            {
                BankList.Add(PaymentChannel);
            }

            return BankList;
        }

        private List<RealPropertyTax> SearchByDateRangeAndStatus()
        {
            List<RealPropertyTax> rptList;

            string Status = cboStatus.Text;
            DateTime encodedDateFrom = dtDate.Value;
            DateTime encodedDateTo = dtDateTo.Value;
            string Action = cboAction.Text;
            string EncodedBy = cboEncodedBy.Text;

            // filter by verification of payment and payment channel.
            if (Status == RPTStatus.PAYMENT_VERIFICATION && Action == RPTAction.VERIFY_PAYMENT)
            {
                List<string> BankList = getBankList();
                rptList = RPTDatabase.SelectByDateFromToAndStatusAndPaymentChannel(encodedDateFrom, encodedDateTo, Status, BankList);
            }

            else if (Status == RPTStatus.PAYMENT_VALIDATION && Action == RPTAction.VALIDATE_PAYMENT)
            {
                List<string> BankList = getBankList();
                rptList = RPTDatabase.SelectByDateFromToAndStatusAndPaymentChannelForValidation(encodedDateFrom, encodedDateTo, Status, BankList);
            }

            // filter by for assessment and date range and encoded by.
            else if (Status == RPTStatus.FOR_ASSESSMENT)
            {
                rptList = RPTDatabase.SelectByDateFromToAndStatusAndEncodedBy(encodedDateFrom, encodedDateTo, Status, EncodedBy);
            }

            // filter by for or upload and date range and validated date.
            else if (Status == RPTStatus.OR_UPLOAD)
            {
                rptList = RPTDatabase.SelectByDateFromToAndStatusAndValidatedDate(encodedDateFrom, encodedDateTo, Status);
            }

            // filter by for or pickup and date range and uploaded date.
            else if (Status == RPTStatus.OR_PICKUP)
            {
                rptList = RPTDatabase.SelectByDateFromToAndStatusAndUploadedDate(encodedDateFrom, encodedDateTo, Status);
            }

            // filter by status and date range.
            else
            {
                rptList = RPTDatabase.SelectByDateFromToAndStatus(encodedDateFrom, encodedDateTo, Status);
            }

            return rptList;
        }

        /// <summary>
        /// Populate List View based on Date Range and Status.
        /// </summary>
        public void RefreshListView()
        {
            lastSearchAction = SEARCH_BY_DATE_STATUS;

            List<RealPropertyTax> rptList;

            // If date range is checked, search by date range and status. Otherwise, just search by status.
            if (dtDate.Checked)
            {
                rptList = SearchByDateRangeAndStatus();
            }
            else
            {
                string Status = cboStatus.Text;
                rptList = RPTDatabase.SelectByStatus(Status);
            }

            mainFormListViewHelper.PopulateListView(rptList);
            ShowPicture();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            AddRPTForm addRPTForm = new AddRPTForm();
            addRPTForm.ShowDialog();
        }

        private void btnSearchDateStatus_Click(object sender, EventArgs e)
        {
            // copy enabled property of date from to date to.
            dtDateTo.Enabled = dtDate.Checked;

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
            RefreshListView();
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

            if (cboStatus.Text == RPTStatus.OR_UPLOAD)
            {
                labelValidatedBy.Visible = true;
                cboValidator.Visible = true;
            }
            else
            {
                labelValidatedBy.Visible = false;
                cboValidator.Visible = false;
            }

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
            RealPropertyTax RetrieveRPT = mainFormListViewHelper.getSelectedRpt();

            if (loginUser.isBiller && RetrieveRPT.Status == RPTStatus.FOR_ASSESSMENT ||
                RetrieveRPT.Status == RPTStatus.ASSESSMENT_PRINTED || RetrieveRPT.Status == RPTStatus.BILL_SENT || RetrieveRPT.Status == RPTStatus.PAYMENT_VERIFICATION)
            {
                if (RetrieveRPT.RefNum != null)
                {
                    string TaxDec = RetrieveRPT.TaxDec;
                    UpdateMultipleRPTForm updateMultipleRPTForm = new UpdateMultipleRPTForm(TaxDec);
                    updateMultipleRPTForm.ShowDialog();
                }
                else
                {
                    List<long> RptIDList = mainFormListViewHelper.getSelectedRptIDList();
                    UpdateRPTForm updateRPTForm = new UpdateRPTForm(RptIDList);
                    updateRPTForm.ShowDialog();
                }
            }

            if (loginUser.isVerifier && RetrieveRPT.Status == RPTStatus.PAYMENT_VALIDATION)
            {
                UpdateValidationRemarksForm updateRemarksVal = new UpdateValidationRemarksForm(RetrieveRPT.RptID);
                updateRemarksVal.ShowDialog();
            }
        }

        private void VerAndValLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainFormListViewHelper.VerAndValLV_SelectedIndexChanged(sender, e);
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
            if (mainFormListViewHelper.haveSelectedRow())
            {
                RealPropertyTax rpt = mainFormListViewHelper.getSelectedRpt();
                string Status = rpt.Status;

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
            decimal TotalAmountToPay = 0;
            decimal TotalAmountTransferred = 0;

            List<RealPropertyTax> rptList = mainFormListViewHelper.GetSelectedRPTList();

            foreach (RealPropertyTax rpt in rptList)
            {
                TotalAmountToPay = TotalAmountToPay + rpt.AmountToPay;
                TotalAmountTransferred = TotalAmountTransferred + rpt.AmountTransferred;
            }

            textTotalAmount2Pay.Text = TotalAmountToPay.ToString();
            textTotalAmountTransferred.Text = TotalAmountTransferred.ToString();
        }

        private void ShowRepsInfo()
        {
            List<RealPropertyTax> rptList = mainFormListViewHelper.GetSelectedRPTList();

            Boolean FirstRecord = true;

            foreach (RealPropertyTax rpt in rptList)
            {
                if (FirstRecord == true)
                {
                    if (rpt.Status == RPTStatus.RELEASED)
                    {
                        labelRepName.Visible = true;
                        textRepName.Visible = true;
                        checkAutLetter.Visible = true;

                        labelContactNumber.Visible = true;
                        textContactNum.Visible = true;

                        textRepName.Text = rpt.RepName;
                        textContactNum.Text = rpt.ContactNumber;

                        checkAutLetter.Checked = rpt.WithAuthorizationLetter;
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

        private static decimal totalAmount2Pay = 0;
        private static decimal totalAmountTrans = 0;

        private void RPTInfoLV_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int index = e.ItemIndex;
            VerAndValLV.Items[index].Selected = e.IsSelected;

            textRecSelected.Text = RPTInfoLV.SelectedItems.Count.ToString();

            if (RPTInfoLV.SelectedItems.Count == 0)
            {
                totalAmount2Pay = 0;
                totalAmountTrans = 0;
            }

            if (RPTInfoLV.SelectedItems.Count == 1)
            {
                string RptIDString = RPTInfoLV.Items[index].Text;
                long RptID = Convert.ToInt64(RptIDString);

                RealPropertyTax rpt = RPTDatabase.Get(RptID);
                totalAmount2Pay = rpt.AmountToPay;
                totalAmountTrans = rpt.TotalAmountTransferred;

                //Clipboard.SetText(rpt.TaxDec);
                string Status = rpt.Status;

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

                ChangeAction();

                ShowPicture();

                ShowRepsInfo();

            }

            if (RPTInfoLV.SelectedItems.Count > 1)
            {
                string RptIDString = RPTInfoLV.Items[index].Text;
                long RptID = Convert.ToInt64(RptIDString);

                RealPropertyTax rpt = RPTDatabase.Get(RptID);
                totalAmount2Pay += rpt.AmountToPay;
                totalAmountTrans += rpt.TotalAmountTransferred;

                textRepName.Text = "***";
                textContactNum.Text = "***";
                checkAutLetter.Visible = false;

            }
            textTotalAmount2Pay.Text = totalAmount2Pay.ToString();
            textTotalAmountTransferred.Text = totalAmountTrans.ToString();

        }

        private void RPTInfoLV_SelectedIndexChanged(object sender, EventArgs e)
        { /*
            mainFormListViewHelper.RPTInfoLV_SelectedIndexChanged(sender, e);

            if (mainFormListViewHelper.haveSelectedRow())
            {
                RealPropertyTax rpt = mainFormListViewHelper.getSelectedRpt();

                Clipboard.SetText(rpt.TaxDec);
                string Status = rpt.Status;

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
             */

            //Console.WriteLine("joanah");
        }

        private void ShowPicture()
        {
            pictureBoxAssessment.Image = Properties.Resources.no_img;
            pictureBoxReceipt.Image = Properties.Resources.no_img;
            pictureBoxORrelease.Image = Properties.Resources.no_img;

            if (mainFormListViewHelper.haveSelectedRow())
            {
                long RptID = mainFormListViewHelper.getSelectedRptID();

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
            if (FileUtils.isDocument(AttachPicture.FileName))
            {
                return Properties.Resources.pdf_img;
            }
            else
            {
                return Image.FromStream(new MemoryStream(AttachPicture.FileData));
            }
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
                LabelRemarks.Visible = true;
                textRemarks.Visible = true;
            }

            if (cboAction.Text == RPTAction.VALIDATE_PAYMENT)
            {
                //PAYMENT CHANNEL COMBOBOX AND LABEL.
                cboPaymentChannel.Visible = true;
                labelPaymentChannel.Visible = true;
                InitializePaymentChannel();
                LabelRemarks.Visible = true;
                textRemarks.Visible = true;
            }

            if (cboAction.Text != RPTAction.BILL_NO_POP && cboAction.Text != RPTAction.BILL_WITH_POP && cboAction.Text != RPTAction.VERIFY_PAYMENT && cboAction.Text != RPTAction.VALIDATE_PAYMENT)
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
                List<RealPropertyTax> SelectedRPTList = mainFormListViewHelper.GetSelectedRPTByStatus(RPTStatus.FOR_ASSESSMENT);

                bool TransferredAmountHaveValue = true;

                foreach (var rpt in SelectedRPTList)
                {
                    if (rpt.AmountTransferred != 0)
                    {
                        rpt.BilledBy = loginUser.DisplayName;
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

                if (mainFormListViewHelper.CheckSameStatus(RPTStatus.FOR_ASSESSMENT) == false || TransferredAmountHaveValue == false)
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
                List<RealPropertyTax> SelectedRPTList = mainFormListViewHelper.GetSelectedRPTByStatus(RPTStatus.FOR_ASSESSMENT);

                bool TransferredAmountHaveNoValue = true;

                foreach (var rpt in SelectedRPTList)
                {
                    if (rpt.AmountTransferred == 0)
                    {
                        rpt.BilledBy = loginUser.DisplayName;
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

                if (mainFormListViewHelper.CheckSameStatus(RPTStatus.FOR_ASSESSMENT) == false || TransferredAmountHaveNoValue == false)
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
                List<RealPropertyTax> SelectedRPTList = mainFormListViewHelper.GetSelectedRPTByStatus(RPTStatus.ASSESSMENT_PRINTED);

                bool TransferredAmountHaveValue = true;

                foreach (var rpt in SelectedRPTList)
                {
                    if (rpt.AmountTransferred == 0)
                    {
                        rpt.BilledBy = loginUser.DisplayName;
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
                if (mainFormListViewHelper.CheckSameStatus(RPTStatus.ASSESSMENT_PRINTED) == false || TransferredAmountHaveValue == false)
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
                List<RealPropertyTax> SelectedRPTList = mainFormListViewHelper.GetSelectedRPTByStatus(RPTStatus.OR_UPLOAD);

                foreach (RealPropertyTax rpt in SelectedRPTList)
                {
                    RPTDatabase.ChangeStatusForORPickUp(rpt); 
                    cboStatus.Text = RPTStatus.OR_PICKUP;
                }

                if (mainFormListViewHelper.CheckSameStatus(RPTStatus.OR_UPLOAD) == false)
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
                List<RealPropertyTax> SelectedRPTList = mainFormListViewHelper.GetSelectedRPTByStatus(RPTStatus.PAYMENT_VERIFICATION);

                bool AllProcessed = true;

                foreach (var rpt in SelectedRPTList)
                {
                    rpt.VerifiedBy = loginUser.DisplayName;
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

                if (mainFormListViewHelper.CheckSameStatus(RPTStatus.PAYMENT_VERIFICATION) == false || AllProcessed == false)
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
                List<RealPropertyTax> SelectedRPTList = mainFormListViewHelper.GetSelectedRPTByStatus(RPTStatus.PAYMENT_VALIDATION);

                foreach (var rpt in SelectedRPTList)
                {
                    rpt.ValidatedBy = loginUser.DisplayName;
                    rpt.ValidatedDate = DateTime.Now;
                    rpt.Status = RPTStatus.OR_UPLOAD;
                    rpt.ValRemarks = textRemarks.Text;

                    RPTDatabase.Update(rpt);
                    cboStatus.Text = RPTStatus.OR_UPLOAD;
                }

                //if (mainFormListViewHelper.CheckSameStatus(RPTStatus.PAYMENT_VALIDATION) == false)
                //{
                //    MessageBox.Show("Some selected records has not been processed.");
                //    cboStatus.Text = RPTStatus.PAYMENT_VALIDATION;
                //}
                MessageBox.Show("Successfully Validated.");

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
            addMultipleOnePayment.ShowDialog();
        }

        public void AllocateExcess()
        {
            if (mainFormListViewHelper.haveSelectedRow())
            {
                RealPropertyTax rpt = mainFormListViewHelper.getSelectedRpt();

                if (rpt.ExcessShortAmount > 0)
                {
                    AllocateExcessForm AllocateExcess = new AllocateExcessForm();
                    AllocateExcess.setRptId(rpt.RptID);
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
            if (mainFormListViewHelper.haveSelectedRow())
            {
                RealPropertyTax rpt = mainFormListViewHelper.getSelectedRpt();
                if (rpt.ExcessShortAmount < 0)
                {
                    BalanceShort balanceShort = new BalanceShort();
                    balanceShort.setRptId(rpt.RptID);
                    balanceShort.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No Excess/Short Amount.");
                }
            }
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (TabPicture.SelectedTab.Text == DocumentType.ASSESSMENT)
            {
                pictureBoxAssessment.Image = ImageUtil.RotateImage(pictureBoxAssessment.Image);
            }

            if (TabPicture.SelectedTab.Text == DocumentType.RECEIPT)
            {
                pictureBoxReceipt.Image = ImageUtil.RotateImage(pictureBoxReceipt.Image);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (mainFormListViewHelper.haveSelectedRow())
            {
                RealPropertyTax rpt = mainFormListViewHelper.getSelectedRpt();

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
                            if (FileUtils.isDocument(textFileName.Text))
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
                            if (FileUtils.isDocument(textFileName.Text))
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
                    //MessageBox.Show("Status of record is not yet ASSESSMENT PRINTED or FOR O.R UPLOAD.");
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (mainFormListViewHelper.haveSelectedRow())
            {
                RealPropertyTax rpt = mainFormListViewHelper.getSelectedRpt();

                if (rpt.Status == RPTStatus.ASSESSMENT_PRINTED || rpt.Status == RPTStatus.OR_UPLOAD)
                {
                    string documentType;

                    byte[] FileData;

                    if (TabPicture.SelectedTab.Text == DocumentType.ASSESSMENT)
                    {
                        documentType = DocumentType.ASSESSMENT;
                        FileData = ImageUtil.ImageToByteArray(pictureBoxAssessment.Image);
                    }
                    else
                    {
                        documentType = DocumentType.RECEIPT;
                        rpt.UploadedBy = loginUser.DisplayName;

                        FileData = ImageUtil.ImageToByteArray(pictureBoxReceipt.Image);

                        //todo optional to refactor this later
                        VerAndValLV.SelectedItems[0].SubItems[11].Text = rpt.UploadedBy;

                        RPTDatabase.Update(rpt);
                    }

                    RPTAttachPicture RetrievePicture = RPTAttachPictureDatabase.SelectByRPTAndDocumentType(rpt.RptID, documentType);

                    if (RetrievePicture == null)
                    {
                        RPTAttachPicture rptAttachPicture = new RPTAttachPicture();

                        rptAttachPicture.RptId = rpt.RptID;
                        rptAttachPicture.FileName = Path.GetFileName(textFileName.Text);

                        if (FileUtils.isDocument(rptAttachPicture.FileName))
                        {
                            FileData = File.ReadAllBytes(textFileName.Text);

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
                        //rptAttachPicture.UploadedByUser = GlobalVariables.RPTUSER.DisplayName;
                        RPTAttachPictureDatabase.InsertPicture(rptAttachPicture);
                    }

                    if (RetrievePicture != null)
                    {
                        RetrievePicture.FileName = Path.GetFileName(textFileName.Text);

                        //byte[] FileData = File.ReadAllBytes(textFileName.Text);

                        if (FileUtils.isDocument(RetrievePicture.FileName))
                        {
                            FileData = File.ReadAllBytes(textFileName.Text);

                            // If PDF, store the file content as is
                            RetrievePicture.FileData = FileData;
                        }

                        else
                        {
                            // If JPG, then compress the image
                            byte[] resizeFileData = ImageUtil.resizeJpg(FileData);
                            RetrievePicture.FileData = resizeFileData;
                        }

                        //RetrievePicture.UploadedByUser = GlobalVariables.RPTUSER.DisplayName;
                        //VerAndValLV.SelectedItems[0].SubItems[11].Text = RetrievePicture.UploadedByUser;
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
            if (mainFormListViewHelper.haveSelectedRow())
            {
                List<long> RptIDList = mainFormListViewHelper.getSelectedRptIDList();
                SendEmailForm sendEmailForm = new SendEmailForm(RptIDList);
                sendEmailForm.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (mainFormListViewHelper.haveSelectedRow())
            {
                var Confirmation = MessageBox.Show("Are you sure you want to delete record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Confirmation == DialogResult.Yes)
                {
                    RealPropertyTax RptRecord = mainFormListViewHelper.getSelectedRpt();
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
            if (mainFormListViewHelper.haveSelectedRow())
            {
                long RptID = mainFormListViewHelper.getSelectedRptID();
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
            return mainFormListViewHelper.getSelectedRptID();
        }

        private void cboValidator_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void RPTInfoLV_MouseClick(object sender, MouseEventArgs e)
        {
            RealPropertyTax RetrieveRPT = mainFormListViewHelper.getSelectedRpt();

            if (RetrieveRPT.ExcessShortAmount < 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    AllocateShort();
                }
            }

            else if (RetrieveRPT.RefNum != null && RPTGcashPaymaya.E_PAYMENT_CHANNEL.Contains(RetrieveRPT.Bank))
            {
                if (e.Button == MouseButtons.Right)
                {
                    SplitPaymentForm splitPayment = new SplitPaymentForm(RetrieveRPT.RptID);
                    splitPayment.ShowDialog();
                }
            }
        }
        
        //Press CTRL + O for Browse button.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);

            if (e.Control && e.KeyCode == Keys.O)
            {
                btnSearch.PerformClick();
                return true;
            }

            else if (e.Control && e.KeyCode == Keys.U)
            {
                btnUpload.PerformClick();
                return true;
            }

            else if (e.Control && e.KeyCode == Keys.R)
            {
                btnRotate.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
