using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote.AllnoteTabClasses
{
    public class DigifficeAllnoteFileTab
    {
        // Class Elements
        Button NewAllnoteFileBtn = new Button();

        public void InitialiseUI(Panel ribbonPnl)
        {
            // NewFileBtn
            NewAllnoteFileBtn.Enabled = true;

            NewAllnoteFileBtn.Size = new Size(110,110);
            NewAllnoteFileBtn.Location = new Point(20, 20);
            NewAllnoteFileBtn.Text = "New";
            NewAllnoteFileBtn.TextAlign = ContentAlignment.BottomCenter;
            NewAllnoteFileBtn.Font = new Font("Roboto", 8, FontStyle.Regular);
            // insert background image here

            NewAllnoteFileBtn.FlatStyle = FlatStyle.Flat;
            NewAllnoteFileBtn.FlatAppearance.BorderSize = 0;

            ribbonPnl.Controls.Add(NewAllnoteFileBtn);
        }
    }
}
