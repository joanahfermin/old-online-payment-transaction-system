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
    public partial class AddMiscForm : Form
    {
        private List<Label> dynamicLabelList = new List<Label>();
        private List<TextBox> dynamicTextboxList = new List<TextBox>();

        private string[] PTR_DYNAMIC_PROPERTY_LABELS = { "Profession:", "Last O.R Date:", "Last O.R No.:", "Prc/ibp No.:", "Requesting No.:" };
        private string[] PTR_DYNAMIC_PROPERTY_NAMES = { "SubjectTaught", "School" }; // property sa Person class

        public AddMiscForm()
        {
            InitializeComponent();
        }

        private void AddMiscForm_Load(object sender, EventArgs e)
        {

        }
    }
}
