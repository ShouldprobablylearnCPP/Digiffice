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
    public partial class NewPeercomputeCreationForm : Form
    {
        public NewPeercomputeCreationForm()
        {

            InitializeComponent();
        }

        private void p2pPeercomputeTypeBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (p2pPeercomputeTypeBtn.Checked)
            {
                clientServerTypeBtn.Checked = false;
            }
            else
            {
                clientServerTypeBtn.Checked |= true;
            }
        }

        private void clientServerTypeBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (p2pPeercomputeTypeBtn.Checked)
            {
                clientServerTypeBtn.Checked = false;
            }
            else
            {
                clientServerTypeBtn.Checked |= true;
            }
        }
    }
}
