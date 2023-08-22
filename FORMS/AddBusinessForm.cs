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
    public partial class AddBusinessForm : Form
    {
        private RPTUser loginUser = SecurityService.getLoginUser();
        
        private long buss_id = 0;

        public AddBusinessForm()
        {
            InitializeComponent();
            InitializeBank();
            InitializePaymentType();
            InitializeQuarter();
            InitializeBusinessType();
        }

        public void InitializeBank()
        {
            List<RPTBank> bankList = RPTBankDatabase.SelectAllBank();

            foreach (RPTBank bank in bankList)
            {
                cboPaymentType.Items.Add(bank.BankName);
            }
        }

        public void InitializePaymentType()
        {
            foreach (string type in RPTPaymentTypeUtil.ALL_PAYMENT_TYPE)
            {
                cboPaymentType.Items.Add(type);
            }
            cboPaymentType.SelectedIndex = 3;
        }

        public void InitializeQuarter()
        {
            foreach (string quarter in GlobalVariables.ALL_QUARTER)
            {
                cboQuarter.Items.Add(quarter);
            }
            cboQuarter.SelectedIndex = 3;
        }

        private void AddBusinessForm_Load(object sender, EventArgs e)
        {
            cboPaymentType.SelectedIndex = 0;
            cboPaymentType.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboPaymentType.AutoCompleteSource = AutoCompleteSource.ListItems;
            textYear.Text = DateTime.Now.Year.ToString();
        }

        public void InitializeBusinessType()
        {
            foreach (string quarter in GlobalVariables.BUSINESS_TYPE)
            {
                cboBusType.Items.Add(quarter);
            }
            cboBusType.SelectedIndex = 0;
        }

        public long Generate_BusinessID()
        {
            buss_id++;
            return buss_id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BusinessTaxObj business = new BusinessTaxObj();

            business.BusinessID = Generate_BusinessID();
            business.Business_Type = cboBusType.Text;
            business.MP_Number = textMP_Num.Text;
            business.TaxpayersName = tbTaxpayersName.Text;
            business.BusinessName = tbBusinessName.Text;
            business.BillNumber = tbBillNumber.Text;
            business.BillAmount = Convert.ToDecimal(textAmountToBePaid.Text);
            business.MiscFees = Convert.ToDecimal(tbMisc_Fees.Text);
            business.TotalAmount = Convert.ToDecimal(textTotalTransferredAmount.Text);
            business.Year = textYear.Text;
            business.Qtrs = cboQuarter.Text;
            business.Status = textStatForAssessment.Text;
            business.PaymentChannel = cboPaymentType.Text;
            business.DateOfPayment = dtDateOfPayment.Value;
            business.RequestingParty = textRequestingParty.Text;
            business.ContactNumber = tbContactNumber.Text;
            business.BussinessRemarks = textRemarks.Text;
            business.EncodedBy = loginUser.DisplayName;
            business.EncodedDate = DateTime.Now;

            BUSINESSDatabase.Insert_BusinessRecord(business);
            MessageBox.Show("Successfully saved record.");
            ResetForm();
        }

        public void ResetForm()
        {
            textMP_Num.Clear();
            tbTaxpayersName.Clear();
            tbBusinessName.Clear();
            tbBillNumber.Clear();
            textAmountToBePaid.Text = "0.00";
            tbMisc_Fees.Text = "0.00";
            textTotalTransferredAmount.Text = "0.00";
            textYear.Clear();
            cboQuarter.SelectedIndex = 3;
            cboPaymentType.SelectedIndex = 3;
            textRequestingParty.Clear();
            tbContactNumber.Clear();
            textRemarks.Clear();
        }
    }
}
