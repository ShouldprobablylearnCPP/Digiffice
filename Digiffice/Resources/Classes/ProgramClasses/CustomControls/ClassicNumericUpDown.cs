using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.CustomControls
{
    public class ClassicNumericUpDown : NumericUpDown
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Sunken);
        }
    }
}
