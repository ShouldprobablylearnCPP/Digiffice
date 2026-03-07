using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.CustomControls
{
    public class ResizeFrame
    {
        // Parent Container
        public Panel parentControl;
        public Control bindedControl;

        public ResizeFrame()
        {

        }

        public void InitialiseResizeFrame()
        {
            // Parent Control
            parentControl = new Panel();
            parentControl.Name = "ResizeFrame";
            parentControl.Location = new Point(bindedControl.Location.X - 5, bindedControl.Location.Y - 5); // Move 5 pixels up and left
            parentControl.Size = new Size(bindedControl.Size.Width + 10, bindedControl.Size.Height + 10); // Add 10 pixels (5 on each side)
            bindedControl.Parent.Controls.Add(parentControl);
            bindedControl.Parent = parentControl;
            bindedControl.Location = new Point(5, 5); // Move the binded control 5 pixels down and right to be centered within the resize frame

            // Resize buttons

            // resizeTopLeft
            Panel resizeTopLeft = new Panel();
            resizeTopLeft.Name = "resizeTopLeft";
            resizeTopLeft.Size = new Size(10, 10);
            resizeTopLeft.Location = new Point(0, 0);
            resizeTopLeft.Cursor = Cursors.SizeNWSE;
            resizeTopLeft.BackColor = Color.White;
            resizeTopLeft.BorderStyle = BorderStyle.FixedSingle;

            parentControl.Controls.Add(resizeTopLeft);

            // resizeTopMiddle
            Panel resizeTopMiddle = new Panel();
            resizeTopMiddle.Name = "resizeTopMiddle";
            resizeTopMiddle.Size = new Size(10, 10);
            resizeTopMiddle.Location = new Point((parentControl.Width / 2) - 5, 0); // minus 5 on x to account for the size of the resize button
            resizeTopMiddle.Cursor = Cursors.SizeNS;
            resizeTopMiddle.BackColor = Color.White;
            resizeTopMiddle.BorderStyle = BorderStyle.FixedSingle;

            parentControl.Controls.Add(resizeTopMiddle);

            // resizeTopRight
            Panel resizeTopRight = new Panel();
            resizeTopRight.Name = "resizeTopRight";
            resizeTopRight.Size = new Size(10, 10);
            resizeTopRight.Location = new Point(parentControl.Size.Width - 10, 0);
            resizeTopRight.Cursor = Cursors.SizeNESW;
            resizeTopRight.BackColor = Color.White;
            resizeTopRight.BorderStyle = BorderStyle.FixedSingle;

            parentControl.Controls.Add(resizeTopRight);

            // Send the binded control to the back so that the resize frame is on top of it
            bindedControl.SendToBack();
        }

        public void RemoveResizeFrame()
        {
            foreach (Control ctrl in parentControl.Controls)
            {
                parentControl.Controls.Remove(ctrl);
                ctrl.Dispose();
            }
        }
    }
}
