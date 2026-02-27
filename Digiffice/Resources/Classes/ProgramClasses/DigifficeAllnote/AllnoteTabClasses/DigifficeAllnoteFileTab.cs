using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote.AllnoteTabClasses
{
    public class DigifficeAllnoteFileTab
    {
        // Class Elements
        Button NewAllnoteFileBtn = new Button();
        Button OpenAllnoteFileBtn = new Button();
        Button SaveFileBtn = new Button();

        // Prerequisite variables
        public EventHandler NewAllnoteFileBtn_Click;
        public EventHandler SaveFileBtn_Click;

        public void InitialiseUI(Panel rbnPnl)
        {
            // Check prerequisites
            if (NewAllnoteFileBtn_Click == null || SaveFileBtn_Click == null)
            {
                // Show user error
                MessageBox.Show("Digiffice Allnote Error - Code 1. Returning from DigifficeAllnoteFileTab.InitialiseUI()", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // NewFileBtn
            NewAllnoteFileBtn.Name = "NewAllnoteFileButton";
            NewAllnoteFileBtn.Enabled = true;

            NewAllnoteFileBtn.Size = new Size(110, 110);
            NewAllnoteFileBtn.Location = new Point(20, 20);
            NewAllnoteFileBtn.Text = "New Notebook";
            NewAllnoteFileBtn.TextAlign = ContentAlignment.BottomCenter;
            NewAllnoteFileBtn.Font = new Font("Roboto", 8, FontStyle.Regular);
            NewAllnoteFileBtn.Image = Properties.Resources.NewNotebookBtn;
            NewAllnoteFileBtn.ImageAlign = ContentAlignment.MiddleCenter;
            NewAllnoteFileBtn.BackgroundImageLayout = ImageLayout.Stretch;
            NewAllnoteFileBtn.BackColor = Color.Transparent;
            NewAllnoteFileBtn.Cursor = Cursors.Hand;

            NewAllnoteFileBtn.FlatStyle = FlatStyle.Flat;
            NewAllnoteFileBtn.FlatAppearance.BorderSize = 0;
            NewAllnoteFileBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            NewAllnoteFileBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            NewAllnoteFileBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;

            NewAllnoteFileBtn.Click += NewAllnoteFileBtn_Click;

            rbnPnl.Controls.Add(NewAllnoteFileBtn);

            // OpenFileBtn
            OpenAllnoteFileBtn.Name = "OpenAllnoteFileButton";
            OpenAllnoteFileBtn.Enabled = true;

            OpenAllnoteFileBtn.Size = new Size(110, 110);
            OpenAllnoteFileBtn.Location = new Point(150, 20);
            OpenAllnoteFileBtn.Text = "Open Notebook";
            OpenAllnoteFileBtn.TextAlign = ContentAlignment.BottomCenter;
            OpenAllnoteFileBtn.Font = new Font("Roboto", 8, FontStyle.Regular);
            OpenAllnoteFileBtn.Image = Properties.Resources.OpenNotebookBtn;
            OpenAllnoteFileBtn.ImageAlign = ContentAlignment.MiddleCenter;
            OpenAllnoteFileBtn.BackgroundImageLayout = ImageLayout.Stretch;
            OpenAllnoteFileBtn.BackColor = Color.Transparent;
            OpenAllnoteFileBtn.Cursor = Cursors.Hand;

            OpenAllnoteFileBtn.FlatStyle = FlatStyle.Flat;
            OpenAllnoteFileBtn.FlatAppearance.BorderSize = 0;
            OpenAllnoteFileBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            OpenAllnoteFileBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            OpenAllnoteFileBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;

            OpenAllnoteFileBtn.Click += new EventHandler(OpenAllnoteFileButton_Click);

            rbnPnl.Controls.Add(OpenAllnoteFileBtn);

            // SaveFileBtn
            SaveFileBtn.Name = "SaveFileButton";
            SaveFileBtn.Enabled = true;

            SaveFileBtn.Size = new Size(130, 45);
            SaveFileBtn.Location = new Point(280, 20);
            SaveFileBtn.Text = "Save Notebook";
            SaveFileBtn.TextAlign = ContentAlignment.MiddleRight;
            SaveFileBtn.Font = new Font("Roboto", 8, FontStyle.Regular);
            SaveFileBtn.Image = Properties.Resources.SaveNotebookBtn;
            SaveFileBtn.ImageAlign = ContentAlignment.MiddleLeft;
            SaveFileBtn.BackgroundImageLayout = ImageLayout.Stretch;
            SaveFileBtn.BackColor = Color.Transparent;
            SaveFileBtn.Cursor = Cursors.Hand;

            SaveFileBtn.FlatStyle = FlatStyle.Flat;
            SaveFileBtn.FlatAppearance.BorderSize = 0;
            SaveFileBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            SaveFileBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            SaveFileBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;

            SaveFileBtn.Click += new EventHandler(SaveFileBtn_Click);

            rbnPnl.Controls.Add(SaveFileBtn);
        }

        public void Prerequisites_InitialiseUI(EventHandler NewAllnoteFileBtn_ClickEventHandler, EventHandler SaveFileBtn_ClickEventHandler)
        {
            NewAllnoteFileBtn_Click = NewAllnoteFileBtn_ClickEventHandler;
            SaveFileBtn_Click = SaveFileBtn_ClickEventHandler;
        }

        public void OpenAllnoteFileButton_Click(object sender, EventArgs e)
        {
            // insert functionality here
            MessageBox.Show("Open Notebook button clicked!", "", MessageBoxButtons.OK);
        }
    }
}