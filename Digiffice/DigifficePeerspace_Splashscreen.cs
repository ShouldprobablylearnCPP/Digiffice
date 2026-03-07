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
    public partial class DigifficePeerspace_Splashscreen : Form
    {
        string versionGLB;
        public DigifficePeerspace_Splashscreen(string version)
        {
            versionGLB = version;
            InitializeComponent();
        }
    }
}
