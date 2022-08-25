﻿using System;
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


namespace SampleRPT1
{
    public partial class MainForm : Form
    {
        long RptID;

        public MainForm()
        {
            InitializeComponent();
            dtDate.Value = DateTime.Now;
            dtDateTo.Value = DateTime.Now;

            checkRoles();
            RefreshListView();
            ShowPicture();

            WindowState = FormWindowState.Maximized;
            cboStatus.Text = RPTStatus.FOR_ASSESSMENT;

            dtDate.Checked = false;
            dtDateTo.Enabled = false;
            //btnSendBill.Visible = false;
            //btnUploaded.Visible = false;
            textNumOfBills.Visible = false;
            LabelNumBills.Visible = false;
            textRemarks.Visible = false;
            LabelRemarks.Visible = false;
            btnSeachDate.Visible = false;

            InitializeStatus();
            InitializeAction();
        }

        public void InitializeStatus()
        {
            cboStatus.Items.Add(RPTStatus.FOR_ASSESSMENT);
            cboStatus.Items.Add(RPTStatus.ASSESSMENT_PRINTED);
            cboStatus.Items.Add(RPTStatus.BILL_SENT);
            cboStatus.Items.Add(RPTStatus.PAYMENT_VERIFICATION);
            cboStatus.Items.Add(RPTStatus.PAYMENT_VALIDATION);
            cboStatus.Items.Add(RPTStatus.OR_UPLOAD);
            cboStatus.Items.Add(RPTStatus.OR_PICKUP);
            cboStatus.Items.Add(RPTStatus.RELEASED);
        }

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
            }

            if (GlobalVariables.RPTUSER.isValidator)
            {
                cboAction.Items.Add(RPTAction.VALIDATE_PAYMENT);
            }

            if (GlobalVariables.RPTUSER.isReleaser)
            {
                cboAction.Items.Add(RPTAction.RELEASE_OR);
            }
        }

        public void InitializeData()
        {
            List<RealPropertyTax> rptList = RPTDatabase.SelectLatest();

            PopulateListView(rptList);
            ShowPicture();
        }

        private void pictureBox1_Click(object sender, EventArgs e) //ASSESSMENT
        {
            ViewImageForm form = new ViewImageForm(pictureBox1.Image);
            form.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e) //RECEIPT
        {
            ViewImageForm form = new ViewImageForm(pictureBox2.Image);
            form.ShowDialog();
        }

        private void checkRoles()
        {
            //textNumOfBills.Enabled = GlobalVariables.RPTUSER.isBiller;
            //textRemarks.Enabled = GlobalVariables.RPTUSER.isVerifier;
            //textRemarks.Enabled = GlobalVariables.RPTUSER.isValidator;
            //textRemarks.Enabled = GlobalVariables.RPTUSER.isUploader;
            //textRemarks.Enabled = GlobalVariables.RPTUSER.isReleaser;
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
                //if (item.SubItems[12] != null && item.SubItems[12].Text.Length > 0 && Convert.ToDecimal(item.SubItems[4].Text != 0))
                if (item.SubItems[12].Text.Length > 0 && Convert.ToDecimal(item.SubItems[4].Text) != 0)
                {
                    item.BackColor = Color.LightYellow;
                    VerAndValLV.Items[item.Index].BackColor = Color.LightYellow;
                }

                if (Convert.ToDecimal(item.SubItems[4].Text) < Convert.ToDecimal(item.SubItems[3].Text) && 
                    Convert.ToDecimal(item.SubItems[4].Text) != 0)
                {
                    item.BackColor = Color.Red;
                    VerAndValLV.Items[item.Index].BackColor = Color.Red;
                }
            }
        }

        private void textTDN_TextChanged(object sender, EventArgs e)
        {
            string taxdec = textTDN.Text;

            //List<RealPropertyTax> rptList = RPTDatabase.SelectByTaxDec(taxdec);
            List<RealPropertyTax> rptList = RPTDatabase.SelectBySameGroup(taxdec);

            PopulateListView(rptList);
            ShowPicture();
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnSeachDate_Click(object sender, EventArgs e)
        {
            DateTime encodedDateFrom = dtDate.Value;
            DateTime encodedDateTo = dtDateTo.Value;

            //List<RealPropertyTax> rptList = RPTDatabase.SelectByDate(encodedDate);
            List<RealPropertyTax> rptList = RPTDatabase.SelectByDateFromTo(encodedDateFrom, encodedDateTo);

            PopulateListView(rptList);
        }

        private void btnShowLatest_Click(object sender, EventArgs e)
        {
            //InitializeData();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            //string RefNum = string.Empty;

            //if (RPTInfoLV.SelectedItems.Count > 0)
            //{
            //    RefNum = RPTInfoLV.SelectedItems[0].SubItems[12].Text;
            //    MessageBox.Show(RefNum);
            //}

            AddRPTForm addRPTForm = new AddRPTForm();
            addRPTForm.setParent(this);

            addRPTForm.ShowDialog();
        }

        private void btnSearchDateStatus_Click(object sender, EventArgs e)
        {
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

        public void RefreshListView()
        {
            List<string> StatusList = new List<string>();

            StatusList.Add(cboStatus.Text);

            //if (rbForAssessment.Checked)
            //{
            //    StatusList.Add(RPTStatus.FOR_ASSESSMENT);
            //}
            //if (rbAssessmentPrinted.Checked)
            //{
            //    StatusList.Add(RPTStatus.ASSESSMENT_PRINTED);
            //}
            //if (rbBillSent.Checked)
            //{
            //    StatusList.Add(RPTStatus.BILL_SENT);
            //}
            //if (rbPaymentVerification.Checked)
            //{
            //    StatusList.Add(RPTStatus.PAYMENT_VERIFICATION);
            //}
            //if (rbForPaymentValidation.Checked)
            //{
            //    StatusList.Add(RPTStatus.PAYMENT_VALIDATION);
            //}
            //if (rbForORUpload.Checked)
            //{
            //    StatusList.Add(RPTStatus.OR_UPLOAD);
            //}
            //if (rbORPickUp.Checked)
            //{
            //    StatusList.Add(RPTStatus.OR_PICKUP);
            //}
            //if (rbReleased.Checked)
            //{
            //    StatusList.Add(RPTStatus.RELEASED);
            //}

            List<RealPropertyTax> rptList;

            if (dtDate.Checked)
            {
                dtDateTo.Enabled = true;
                DateTime encodedDateFrom = dtDate.Value;
                DateTime encodedDateTo = dtDateTo.Value;

                //rptList = RPTDatabase.SelectByDateAndStatus(dtDate.Value, StatusList);
                rptList = RPTDatabase.SelectByDateFromToAndStatus(encodedDateFrom, encodedDateTo, StatusList);

            }
            else
            {
                dtDateTo.Enabled = false;
                rptList = RPTDatabase.SelectByStatus(StatusList);
            }
            PopulateListView(rptList);
            ShowPicture();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void RPTInfoLV_DoubleClick(object sender, EventArgs e)
        {
            if (RPTInfoLV.SelectedItems.Count > 0 && GlobalVariables.RPTUSER.isBiller &&
                RPTInfoLV.SelectedItems[0].SubItems[9].Text == RPTStatus.FOR_ASSESSMENT ||
                RPTInfoLV.SelectedItems[0].SubItems[9].Text == RPTStatus.ASSESSMENT_PRINTED ||
                RPTInfoLV.SelectedItems[0].SubItems[9].Text == RPTStatus.BILL_SENT ||
                RPTInfoLV.SelectedItems[0].SubItems[9].Text == RPTStatus.PAYMENT_VERIFICATION)
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
                }

                if (Status == RPTStatus.OR_PICKUP)
                {
                    SetAction(RPTAction.RELEASE_OR);
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

        private void RPTInfoLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeAction();

            CalculateTotalAmount();

            ShowPicture();  
        }

        private void ShowPicture()
        {
            pictureBox1.Image = Properties.Resources.no_img;
            pictureBox2.Image = Properties.Resources.no_img;

            if (RPTInfoLV.SelectedItems.Count > 0)
            {
                string AcquiredRptid = RPTInfoLV.SelectedItems[0].Text;
                RptID = Convert.ToInt64(AcquiredRptid);

                List<RPTAttachPicture> RetrievePictureList = RPTAttachPictureDatabase.SelectByRPT(RptID);

                foreach (RPTAttachPicture RetrievePicture in RetrievePictureList)
                {
                    if (RetrievePicture.DocumentType == DocumentType.ASSESSMENT)
                    {
                        pictureBox1.Image = Image.FromStream(new MemoryStream(RetrievePicture.FileData));

                    }
                    else
                    {
                        pictureBox2.Image = Image.FromStream(new MemoryStream(RetrievePicture.FileData));

                    }
                }
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
                textNumOfBills.Visible = true;
                LabelNumBills.Visible = true;

                textRemarks.Visible = false;
                LabelRemarks.Visible = false;
            }
            else
            {
                textNumOfBills.Visible = false;
                LabelNumBills.Visible = false;

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
                    }
                    else
                    {
                        TransferredAmountHaveValue = false;
                    }
                }
                if (CheckSameStatus(RPTStatus.FOR_ASSESSMENT) == false || TransferredAmountHaveValue == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                }

                cboStatus.Text = RPTStatus.PAYMENT_VERIFICATION;
                RefreshListView();
                textNumOfBills.Clear();
            }

            LabelNumBills.Visible = false;
            textNumOfBills.Visible = false;
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
                    }
                    else
                    {
                        TransferredAmountHaveValue = false;
                    }
                }
                if (CheckSameStatus(RPTStatus.ASSESSMENT_PRINTED) == false || TransferredAmountHaveValue == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                }

                cboStatus.Text = RPTStatus.BILL_SENT;

                RefreshListView();
                textNumOfBills.Clear();
            }

            LabelNumBills.Visible = false;
            textNumOfBills.Visible = false;
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
                }

                if (CheckSameStatus(RPTStatus.OR_UPLOAD) == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                }

                cboStatus.Text = RPTStatus.OR_PICKUP;
                RefreshListView();
            }

            LabelNumBills.Visible = false;
            textNumOfBills.Visible = false;
        }

        private void validateForm()
        {
            errorProvider1.Clear(); 

            Validations.ValidateRequired(errorProvider1, textNumOfBills, "Number of bills");
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
                    }
                    else
                    {
                        TransferredAmountHaveNoValue = false;
                    }
                }
                if (CheckSameStatus(RPTStatus.FOR_ASSESSMENT) == false || TransferredAmountHaveNoValue == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                }

                cboStatus.Text = RPTStatus.ASSESSMENT_PRINTED;
                RefreshListView();
                textNumOfBills.Clear();
            }
            LabelNumBills.Visible = false;
            textNumOfBills.Visible = false;
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
                    }
                    else
                    {
                        AllProcessed = false;
                    }
                }

                if (CheckSameStatus(RPTStatus.PAYMENT_VERIFICATION) == false || AllProcessed == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
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
                }

                if (CheckSameStatus(RPTStatus.PAYMENT_VALIDATION) == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                }

                cboStatus.Text = RPTStatus.OR_UPLOAD;
                RefreshListView();
            }
            textRemarks.Visible = false;

        }

        private void ReleaseReceipt()
        {
            if (MessageBox.Show("Are your sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<RealPropertyTax> SelectedRPTList = GetSelectedRPTByStatus(RPTStatus.OR_PICKUP);

                foreach (var rpt in SelectedRPTList)
                {
                    rpt.ReleasedBy = GlobalVariables.RPTUSER.DisplayName;
                    rpt.ReleasedDate = DateTime.Now;
                    rpt.Status = RPTStatus.RELEASED;
                    rpt.ReleasedRemarks = textRemarks.Text;

                    RPTDatabase.Update(rpt);

                    MessageBox.Show("Receipt successfully released.");
                }

                if (CheckSameStatus(RPTStatus.OR_PICKUP) == false)
                {
                    MessageBox.Show("Some selected records has not been processed.");
                }

                cboStatus.Text = RPTStatus.RELEASED;
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

        private void btnUploadAssessment_Click(object sender, EventArgs e)
        {
            if (RPTInfoLV.SelectedItems.Count > 0)
            {
                RealPropertyTax rpt = RPTDatabase.Get(RptID);

                if (rpt.Status == RPTStatus.ASSESSMENT_PRINTED || rpt.Status == RPTStatus.OR_UPLOAD)
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (openFileDialog1.CheckFileExists)
                        {
                            textFileName.Text = openFileDialog1.FileName;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Status of record is not yet ASSESSMENT PRINTED or FOR O.R UPLOAD.");
                }

                //if (openFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    if (openFileDialog1.CheckFileExists)
                //    {
                //        textFileName.Text = openFileDialog1.FileName;
                //    }
                //}
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
                        byte[] resizeFileData = ImageUtil.resizeJpg(FileData);
                        rptAttachPicture.FileData = resizeFileData;
                        rptAttachPicture.DocumentType = documentType;

                        RPTAttachPictureDatabase.InsertPicture(rptAttachPicture);

                    }

                    if (RetrievePicture != null)
                    {
                        RetrievePicture.FileName = Path.GetFileName(textFileName.Text);

                        byte[] FileData = File.ReadAllBytes(textFileName.Text);
                        RetrievePicture.FileData = FileData;

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
            textFileName.Visible = false;
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
                //sendEmailForm.setParent(this);
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

            if (cboAction.Text == RPTAction.RELEASE_OR)
            {
                ReleaseReceipt();
            }
        }
    }
}
