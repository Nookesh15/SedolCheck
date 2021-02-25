using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SedolCheckerGUI
{
    public partial class SedolChecker : Form, IView
    {
        private View ViewPresenter { get; set; }

        public SedolChecker()
        {
            InitializeComponent();
            ViewPresenter = new View(this);
        }

        public bool Valid
        {
            set { this.checkBoxIsValid.Checked = value; }
        }

        public bool IsUserDefined
        {
            set { this.checkBoxUserDefined.Checked = value; }
        }

        public string Validation
        {
            set { this.textBoxValidationDetails.Text = value; }
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            ViewPresenter.Validate();
        }
    
        public string  SedolNum
        {
	        get { return this.textBoxInput.Text; }
        }
    }
}
