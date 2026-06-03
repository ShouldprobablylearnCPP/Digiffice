using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote.AllnoteTabClasses
{
    public class DigifficeAllnoteInsertTab
    {
        // Class Elements
        Button InsertImageBtn;
        Button InsertTableBtn;

        // Prerequisite variables
        public EventHandler InsertImageBtn_Click;
        public EventHandler InsertTableBtn_Click;

        public void InitialiseUI(Panel rbnPnl)
        {
            // Check prerequisites
            if (InsertImageBtn_Click == null)
            {
                // Show user error
                MessageBox.Show("Digiffice Allnote Error - Code 1. Returning from DigifficeAllnoteInsertTab.InitialiseUI()", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // InsertTableBtn
            InsertTableBtn = new Button();
            InsertTableBtn.Name = "InsertTableButton";
            InsertTableBtn.Location = new Point(20, 20);
            InsertTableBtn.Size = new Size(110, 110);
            InsertTableBtn.Text = "Table";
            InsertTableBtn.TextAlign = ContentAlignment.BottomCenter;
            InsertTableBtn.Font = new Font("Roboto", 8, FontStyle.Regular);
            InsertTableBtn.BackColor = Color.Transparent;
            InsertTableBtn.Cursor = Cursors.Hand;

            InsertTableBtn.FlatStyle = FlatStyle.Flat;
            InsertTableBtn.FlatAppearance.BorderSize = 0;
            InsertTableBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            InsertTableBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            InsertTableBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;

            InsertTableBtn.Click += InsertTableBtn_Click;

            rbnPnl.Controls.Add(InsertTableBtn);

            // InsertImageBtn
            InsertImageBtn = new Button();
            InsertImageBtn.Name = "InsertImageButton";
            InsertImageBtn.Location = new Point(140, 20);
            InsertImageBtn.Size = new Size(110, 110);
            InsertImageBtn.Text = "Images ⮟";
            InsertImageBtn.TextAlign = ContentAlignment.BottomCenter;
            InsertImageBtn.Font = new Font("Roboto", 8, FontStyle.Regular);
            InsertImageBtn.BackColor = Color.Transparent;
            InsertImageBtn.Cursor = Cursors.Hand;

            InsertImageBtn.FlatStyle = FlatStyle.Flat;
            InsertImageBtn.FlatAppearance.BorderSize = 0;
            InsertImageBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            InsertImageBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            InsertImageBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;

            InsertImageBtn.Click += InsertImageBtn_Click;

            rbnPnl.Controls.Add(InsertImageBtn);
        }

        public void Prerequisities_InitialiseUI(EventHandler insertImgBtnClick, EventHandler insertTableBtnClick)
        {
            InsertImageBtn_Click = insertImgBtnClick;
            InsertTableBtn_Click = insertTableBtnClick;
        }
    }
}
