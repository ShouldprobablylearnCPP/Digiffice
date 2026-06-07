using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiffice.Resources.Classes.ProgramClasses.CustomControls;

namespace Digiffice
{
    public partial class DigifficeAllnote_InsertTable : Form
    {
        public int Cols { get; private set; }
        public int Rows { get; private set; }

        public DigifficeAllnote_InsertTable()
        {
            InitializeComponent();

            this.AcceptButton = OKBtn;
            this.CancelButton = CancelBtn;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            Cols = (int)ColsNumericUpDown.Value;
            Rows = (int)RowsNumericUpDown.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
