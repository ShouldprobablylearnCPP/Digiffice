using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiffice.Resources.Classes.ProgramClasses;
using Digiffice.Resources.Classes.ProgramClasses.DigifficeAllpad;

namespace Digiffice
{

    public partial class DigifficeAllnote : Form
    {
        // Class Variables
        Image xBtnDefault = Properties.Resources.XbtnDefault;
        Image xBtnHover = Properties.Resources.XbtnHover;
        Control previouslySelectedTab = null;

        public DigifficeAllnote(nonprotected_AccountData nonprotected_AccountData)
        {
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            DigifficeAllpad_NewFile("NewNotebook");
            InitializeComponent();

            // Hide form until fully loaded to prevent flickering
            this.Opacity = 0;
            this.Shown += (s, e) =>
            {
                this.Opacity = 1;
            };
        }

        // Exit Button Events
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.Image = xBtnHover;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Image = xBtnDefault;
        }

        // File Events
        private void DigifficeAllpad_NewFile(string fileName)
        {
            Vector2 defaultPageSize_cm = new Vector2(21.00f, 29.70f);
            DigifficeAllnoteEditorFile editorFile = new DigifficeAllnoteEditorFile();
            editorFile.fileName = fileName;
            DigifficeAllpad_NewChapter("New chapter", editorFile);
            DigifficeAllnoteEditorFile.Chapter? firstChapter = FindChapterByName(editorFile, "New chapter");
            if (firstChapter == null)
            {
                MessageBox.Show("Error creating new notebook: first chapter not found. Closing Digiffice Allpad...");
                this.Close();
            }
#pragma warning disable CS8629 // Nullable value type may be null.
            DigifficeAllpad_NewPage("New page", defaultPageSize_cm, editorFile, (DigifficeAllnoteEditorFile.Chapter)firstChapter);
#pragma warning restore CS8629 // Nullable value type may be null.
            DigifficeAllpad_ShowNote(editorFile.filePages[0]);
        }

        // File Element Events
        private void DigifficeAllpad_NewPage(string pageName, Vector2 Size, DigifficeAllnoteEditorFile parentNotebook, DigifficeAllnoteEditorFile.Chapter parentChapter)
        {
            DigifficeAllnoteEditorFile.Page newPage = new DigifficeAllnoteEditorFile.Page();
            newPage.pageSize = Size;
            newPage.pageTitle = pageName;
            newPage.CreatedDateTime = DateTime.Now;
            newPage.pageNum = parentNotebook.filePages.Count + 1;
            newPage.parentChapter = parentChapter;
            parentNotebook.filePages.Add(newPage);
            parentChapter.chapterPages.Add(newPage);
        }

        private void DigifficeAllpad_NewChapter(string chapterName, DigifficeAllnoteEditorFile parentNotebook)
        {
            DigifficeAllnoteEditorFile.Chapter newChapter = new DigifficeAllnoteEditorFile.Chapter();
            newChapter.chapterName = chapterName;
            newChapter.chapterNum = parentNotebook.chapters.Count + 1;
            parentNotebook.chapters.Add(newChapter);
        }

        // File->Note Events / Editor Events
        private void DigifficeAllpad_ShowNote(DigifficeAllnoteEditorFile.Page currentPage)
        {
            // Editable Page Functions
            DigifficeAllpad_ShowEditablePageBackground(currentPage);
        }

        private void DigifficeAllpad_ShowEditablePageBackground(DigifficeAllnoteEditorFile.Page currentPage)
        {
            Panel notebg = new Panel();
            notebg.BackColor = Color.White;
            int sizex = Convertcm_pixels(currentPage.pageSize.X);
            int sizey = Convertcm_pixels(currentPage.pageSize.Y);
            notebg.Size = new Size(sizex, sizey);
            Point notebgPos = new Point((this.Width / 2) - (notebg.Width / 2), 300);
            notebg.Location = notebgPos;
            this.Controls.Add(notebg);
        }

        // Other File Events

        private DigifficeAllnoteEditorFile.Chapter? FindChapterByName(DigifficeAllnoteEditorFile file, string name)
        {
            foreach (DigifficeAllnoteEditorFile.Chapter chapter in file.chapters)
            {
                if (chapter.chapterName == name)
                {
                    return chapter;
                }
            }
            MessageBox.Show("Chapter " + name + " not found in file " + file.fileName);
            return null;
        }

        // Digiffice Button Events
        private void DigifficeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Allnote Tab Events
        private void Tab_Click(object sender, EventArgs e)
        {
            Control senderCtrl = (Control)sender;
            senderCtrl.BackgroundImage = Properties.Resources.Tab;
            if (previouslySelectedTab != null && previouslySelectedTab != senderCtrl)
            {
                previouslySelectedTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            }
            previouslySelectedTab = senderCtrl;
        }

        // Windowmsg Events
        private void Windowmsg_Paint(object sender, PaintEventArgs e)
        {
            // Center Windowmsg Label
            int centerX = (this.Width - Windowmsg.Width) / 2;
            Windowmsg.Location = new Point(centerX, Windowmsg.Location.Y);
        }

        private void Windowmsg_TextChanged(object sender, EventArgs e)
        {
            // Center Windowmsg Label
            int centerX = (this.Width - Windowmsg.Width) / 2;
            Windowmsg.Location = new Point(centerX, Windowmsg.Location.Y);
        }

        // Other Events

        private int Convertcm_pixels(float centimeters)
        {
            double pixel = 0d;
            using (Graphics g = this.CreateGraphics())
            {
                pixel = centimeters * g.DpiX / 2.54d;
            }
            return (int)pixel;
        }
    }
}
