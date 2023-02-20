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
    public partial class RPTDuplicateRecordForm : Form
    {
        public static List<string> COLUMN_NAMES = new List<string>
        { "RPTid", "TDN", "Tax Payer Name", "Amount To Pay", "Amount Transferred", "Total Amount Deposited", "Excess Short", "Payment Channel",
            "Year", "Quarter", "Status", "Encoded By", "Encoded Date", "Ref. Num", "Requesting Party", "Verified Date", "Payment Date", "Validated By", "Validated Date" };

        public RPTDuplicateRecordForm(List<RealPropertyTax> duplicateRecordList)
        {
            InitializeComponent();

            foreach (string item in COLUMN_NAMES)
            {
                RPTDuplicateLV.Columns.Add(item);
            }

            InitializeDuplicateRecordLV(duplicateRecordList);

            RPTDuplicateLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            RPTDuplicateLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void InitializeDuplicateRecordLV(List<RealPropertyTax> duplicateRecordList)
        {
            ListViewUtil.copyFromListToListview(duplicateRecordList, RPTDuplicateLV, new List<string>
                {"RptID", "TaxDec", "TaxPayerName", "AmountToPay", "AmountTransferred", "TotalAmountTransferred", "ExcessShortAmount",
                "Bank", "YearQuarter", "Quarter", "Status",
            "EncodedBy", "EncodedDate", "RefNum", "RequestingParty", "VerifiedDate", "PaymentDate", "ValidatedBy", "ValidatedDate",});
        }

        private void RPTDuplicateRecordForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("You are adding a DUPLICATE/EXISTING record. Please go to Sir Ogie for verification.");
        }

        private void RPTDuplicateLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPicture();
        }

        private void ShowPicture()
        {
            pictureBoxReceipt.Image = Properties.Resources.no_img;

            if (RPTDuplicateLV.SelectedItems.Count > 0)
            {
                long RptID = Convert.ToInt64(RPTDuplicateLV.SelectedItems[0].Text);

                List<RPTAttachPicture> RetrievePictureList = RPTAttachPictureDatabase.SelectByRPT(RptID);

                foreach (RPTAttachPicture RetrievePicture in RetrievePictureList)
                {
                    if (RetrievePicture.DocumentType == DocumentType.RECEIPT)
                    {
                        pictureBoxReceipt.Image = getImageFromAttachePicture(RetrievePicture);
                        pictureBoxReceipt.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            else
            {
                pictureBoxReceipt.SizeMode = PictureBoxSizeMode.CenterImage;
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
    }
}
