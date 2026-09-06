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
    public partial class DigifficePeercompute_Splashscreen : Form
    {
        string versionGLB;
        public DigifficePeercompute_Splashscreen(string version)
        {
            versionGLB = version;
            InitializeComponent();
        }
    }
}
