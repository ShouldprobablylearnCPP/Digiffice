using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiffice.Resources.Classes.ProgramClasses.Idlebars
{
    public partial class NewsIdlebar : UserControl
    {
        public Control idlebar;

        public NewsIdlebar()
        {
            InitializeComponent();
        }

        private void NewsIdlebar_Load(object sender, EventArgs e)
        {
            this.Size = new Size(idlebar.Width, idlebar.Height);
        }
    }
}
