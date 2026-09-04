using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiffice
{
    public partial class EnterTextValueForm : Form
    {
        public string prompt = string.Empty;
        public string value = string.Empty;

        //
        //
        // Form Constructor
        //
        //

        public EnterTextValueForm(string _prompt)
        {
            prompt = _prompt;
            InitializeComponent();
        }

        //
        //
        // View
        //
        //

        private void EnterTextValueForm_Load(object sender, EventArgs e)
        {
            Label.Text = prompt;
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            value = enterTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
