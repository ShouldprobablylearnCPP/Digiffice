using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.Utility
{
    public class Utility
    {
        public void RecursiveSuspendLayout(Control control)
        {
            control.SuspendLayout();
            foreach (Control child in control.Controls)
            {
                RecursiveSuspendLayout(child);
            }
        }

        public void RecursiveResumeLayout(Control control, bool performLayout)
        {
            control.ResumeLayout(performLayout);
            foreach (Control child in control.Controls)
            {
                RecursiveResumeLayout(child, performLayout);
            }
        }
    }
}
