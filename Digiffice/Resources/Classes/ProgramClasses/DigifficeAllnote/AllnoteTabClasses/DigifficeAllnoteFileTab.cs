using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote.AllnoteTabClasses
{
    public class DigifficeAllnoteFileTab
    {
        // Class Elements
        public Button NewAllnoteFileBtn = new Button();
        public Button OpenAllnoteFileBtn = new Button();

        public void InitialiseUI(Panel rbnPnl)
        {
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

            NewAllnoteFileBtn.FlatStyle = FlatStyle.Flat;
            NewAllnoteFileBtn.FlatAppearance.BorderSize = 0;
            NewAllnoteFileBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            NewAllnoteFileBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            NewAllnoteFileBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;

            NewAllnoteFileBtn.Cursor = Cursors.Hand;

            NewAllnoteFileBtn.Click += new EventHandler(NewAllnoteFileButton_Click);

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

            OpenAllnoteFileBtn.FlatStyle = FlatStyle.Flat;
            OpenAllnoteFileBtn.FlatAppearance.BorderSize = 0;
            OpenAllnoteFileBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            OpenAllnoteFileBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            OpenAllnoteFileBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;

            OpenAllnoteFileBtn.Cursor = Cursors.Hand;

            OpenAllnoteFileBtn.Click += new EventHandler(OpenAllnoteFileButton_Click);

            rbnPnl.Controls.Add(OpenAllnoteFileBtn);
        }

        public void NewAllnoteFileButton_Click(object sender, EventArgs e)
        {
            // insert functionality here
            MessageBox.Show("New Notebook button clicked!", "", MessageBoxButtons.OK);
        }

        public void OpenAllnoteFileButton_Click(object sender, EventArgs e)
        {
            // insert functionality here
            MessageBox.Show("Open Notebook button clicked!", "", MessageBoxButtons.OK);
        }
    }
}