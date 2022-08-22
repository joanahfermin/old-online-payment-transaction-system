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
    public partial class ViewImageForm : Form
    {
        public ViewImageForm(Image img)
        {
            InitializeComponent();

            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            panel1.AutoScroll = true;
        }
    }
}
