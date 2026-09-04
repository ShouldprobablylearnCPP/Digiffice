using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote.AllnoteTabClasses
{
    public class DigifficeAllnoteDrawTab
    {
        // Class Variables
        Button enterExitDrawingModeBtn = new Button();

        public void InitialiseUI(Panel rbnPnl, EventHandler EnterExitDrawingModeBtn_Click)
        {
            // Check prerequisites
            if (EnterExitDrawingModeBtn_Click == null)
            {
                // Show user error
                MessageBox.Show("Digiffice Allnote Error - Code 1. Returning from DigifficeAllnoteDrawTab.InitialiseUI()", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // enterExitDrawingModeBtn
            enterExitDrawingModeBtn.Name = "EnterExitDrawingModeBtn";
            enterExitDrawingModeBtn.Enabled = true;

            enterExitDrawingModeBtn.Size = new Size(110, 110);
            enterExitDrawingModeBtn.Location = new Point(20, 20);
            enterExitDrawingModeBtn.Text = "Enter Drawing mode";
            enterExitDrawingModeBtn.TextAlign = ContentAlignment.BottomCenter;
            enterExitDrawingModeBtn.Font = new Font("Roboto", 8, FontStyle.Regular);
            //enterExitDrawingModeBtn.Image = [INSERT IMAGE HERE];
            enterExitDrawingModeBtn.ImageAlign = ContentAlignment.MiddleCenter;
            enterExitDrawingModeBtn.BackgroundImageLayout = ImageLayout.Stretch;
            enterExitDrawingModeBtn.BackColor = Color.Transparent;
            enterExitDrawingModeBtn.Cursor = Cursors.Hand;

            enterExitDrawingModeBtn.FlatStyle = FlatStyle.Flat;
            enterExitDrawingModeBtn.FlatAppearance.BorderSize = 0;
            enterExitDrawingModeBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            enterExitDrawingModeBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            enterExitDrawingModeBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;

            enterExitDrawingModeBtn.Click += EnterExitDrawingModeBtn_Click;

            rbnPnl.Controls.Add(enterExitDrawingModeBtn);
        }
    }
}
