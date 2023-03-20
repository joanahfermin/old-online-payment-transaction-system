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
    public partial class MISCDuplicateRecordForm : Form
    {

        public MISCDuplicateRecordForm(List<MiscelleneousTax> duplicateRecordList)
        {
            InitializeComponent();

            InitializeDuplicateRecordLV(duplicateRecordList);

            MiscDuplicateLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            MiscDuplicateLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void InitializeDuplicateRecordLV(List<MiscelleneousTax> duplicateRecordList)
        {
            string Misc_Type = duplicateRecordList[0].MiscType;

            List<string> ColumnNames = MISCUtil.LIST_VIEW_COLUMN_NAMES_MAPPING[Misc_Type];
            foreach (string item in ColumnNames)
            {
                MiscDuplicateLV.Columns.Add(item);
            }

            List<string> PropertyNames = MISCUtil.LIST_VIEW_PROPERTY_NAMES_MAPPING[Misc_Type];
            ListViewUtil.copyFromListToListview<MiscelleneousTax>(duplicateRecordList, MiscDuplicateLV, PropertyNames);
        }

        private void MISCDuplicateRecordForm_Load(object sender, EventArgs e)
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

            if (MiscDuplicateLV.SelectedItems.Count > 0)
            {
                long RptID = Convert.ToInt64(MiscDuplicateLV.SelectedItems[0].Text);

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
