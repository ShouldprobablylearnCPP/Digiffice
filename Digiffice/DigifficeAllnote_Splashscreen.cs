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
    public partial class DigifficeAllnote_Splashscreen : Form
    {
        string versionGLB;
        public DigifficeAllnote_Splashscreen(string version)
        {
            versionGLB = version;
            InitializeComponent();
        }

        private void DigifficeAllnote_Splashscreen_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Size = new Size(600, 400);
        }
    }
}
