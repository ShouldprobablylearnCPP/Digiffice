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
using Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote.AllnoteTabClasses;
using System.Reflection;
using Digiffice.Resources.Classes.ProgramClasses.CustomControls;

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
            InitializeComponent();
            DigifficeAllpad_NewFile("NewNotebook");

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
            // Setup SectionBg
            SectionBG.Location = new Point(LeftInfoPanel.Right + 20, LeftInfoPanel.Location.Y + 20);
            SectionBG.Size = new Size((this.Width - SectionBG.Location.X) - 20, (this.Height - SectionBG.Location.Y) - 20);

            // Setup nonPageBg
            nonPageBg.Location = new Point(20, 20);
            nonPageBg.Size = new Size(SectionBG.Width - 290, SectionBG.Height - 70);

            // Create Page
            Panel pagebg = new Panel();
            pagebg.BackColor = Color.FromArgb(255, 249, 251, 255);
            int sizex = Convertcm_pixels(currentPage.pageSize.X);
            int sizey = Convertcm_pixels(currentPage.pageSize.Y);
            pagebg.Size = new Size(SectionBG.Width - 20, SectionBG.Height - 70);
            Point pagebgPos = new Point(0, 0);
            pagebg.Location = pagebgPos;
            nonPageBg.Controls.Add(pagebg);

            // Create Scrollbars
            CustomVScrollBar pageVScroll = new CustomVScrollBar(new Point(nonPageBg.Right, nonPageBg.Top), new Size(30, nonPageBg.Height),
                Color.LightGray, Color.LightGray, Color.LightGray, Color.Transparent,
                null, Properties.Resources.VScrollBar_UpScrollBtn, Properties.Resources.VScrollBar_DownScrollBtn, Properties.Resources.CustomVScrollBar_1);
            pageVScroll.setMinMaxRange(0, sizey - pagebg.Height);
            pageVScroll.addControlstoControl(SectionBG);

            CustomHScrollBar pageHScroll = new CustomHScrollBar(new Point(nonPageBg.Left, nonPageBg.Bottom), new Size(nonPageBg.Width, 30),
                Color.LightGray, Color.LightGray, Color.LightGray, Color.Transparent,
                null, Properties.Resources.VScrollBar_LeftScrollBtn, Properties.Resources.VScrollBar_RightScrollBtn, Properties.Resources.CustomHScrollBar_1);
            pageHScroll.setMinMaxRange(0, sizex - pagebg.Width);
            pageHScroll.addControlstoControl(SectionBG);
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
        private void FileTab_Click(object sender, EventArgs e)
        {
            // Change ribbon tab image
            if (previouslySelectedTab != null)
            {
                previouslySelectedTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            }
            FileTab.BackgroundImage = Properties.Resources.Tab;

            // Instantiate File Tab Contents
            RibbonPanel.Controls.Clear();
            DigifficeAllnoteFileTab fileTabContents = new DigifficeAllnoteFileTab();
            fileTabContents.InitialiseUI(RibbonPanel);
            previouslySelectedTab = FileTab;
        }

        private void HomeTab_Click(object sender, EventArgs e)
        {
            // Change ribbon tab image
            if (previouslySelectedTab != null)
            {
                previouslySelectedTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            }
            HomeTab.BackgroundImage = Properties.Resources.Tab;

            // Instantiate Home Tab Contents
            RibbonPanel.Controls.Clear();
            DigifficeAllnoteHomeTab homeTabContents = new DigifficeAllnoteHomeTab();
            homeTabContents.InitialiseUI(RibbonPanel);
            previouslySelectedTab = HomeTab;
        }
        private void InsertTab_Click(object sender, EventArgs e)
        {
            // Change ribbon tab image
            if (previouslySelectedTab != null)
            {
                previouslySelectedTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            }
            InsertTab.BackgroundImage = Properties.Resources.Tab;

            // Instantiate Insert Tab Contents
            RibbonPanel.Controls.Clear();
            DigifficeAllnoteInsertTab insertTabContents = new DigifficeAllnoteInsertTab();
            insertTabContents.InitialiseUI(RibbonPanel);
            previouslySelectedTab = InsertTab;
        }
        private void DrawTab_Click(object sender, EventArgs e)
        {
            // Change ribbon tab image
            if (previouslySelectedTab != null)
            {
                previouslySelectedTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            }
            DrawTab.BackgroundImage = Properties.Resources.Tab;

            // Instantiate Draw Tab Contents
            RibbonPanel.Controls.Clear();
            DigifficeAllnoteDrawTab drawTabContents = new DigifficeAllnoteDrawTab();
            drawTabContents.InitialiseUI(RibbonPanel);
            previouslySelectedTab = DrawTab;
        }
        private void HistoryTab_Click(object sender, EventArgs e)
        {
            // Change ribbon tab image
            if (previouslySelectedTab != null)
            {
                previouslySelectedTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            }
            HistoryTab.BackgroundImage = Properties.Resources.Tab;

            // Instantiate History Tab Contents
            RibbonPanel.Controls.Clear();
            DigifficeAllnoteHistoryTab historyTabContents = new DigifficeAllnoteHistoryTab();
            historyTabContents.InitialiseUI(RibbonPanel);
            previouslySelectedTab = HistoryTab;
        }
        private void ReviewTab_Click(object sender, EventArgs e)
        {
            // Change ribbon tab image
            if (previouslySelectedTab != null)
            {
                previouslySelectedTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            }
            ReviewTab.BackgroundImage = Properties.Resources.Tab;

            // Instantiate Review Tab Contents
            RibbonPanel.Controls.Clear();
            DigifficeAllnoteReviewTab reviewTabContents = new DigifficeAllnoteReviewTab();
            reviewTabContents.InitialiseUI(RibbonPanel);
            previouslySelectedTab = ReviewTab;
        }
        private void ViewTab_Click(object sender, EventArgs e)
        {
            // Change ribbon tab image
            if (previouslySelectedTab != null)
            {
                previouslySelectedTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            }
            ViewTab.BackgroundImage = Properties.Resources.Tab;

            // Instantiate View Tab Contents
            RibbonPanel.Controls.Clear();
            DigifficeAllnoteViewTab viewTabContents = new DigifficeAllnoteViewTab();
            viewTabContents.InitialiseUI(RibbonPanel);
            previouslySelectedTab = ViewTab;
        }
        private void HelpTab_Click(object sender, EventArgs e)
        {
            // Change ribbon tab image
            if (previouslySelectedTab != null)
            {
                previouslySelectedTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            }
            HelpTab.BackgroundImage = Properties.Resources.Tab;

            // Instantiate Help Tab Contents
            RibbonPanel.Controls.Clear();
            DigifficeAllnoteHelpTab helpTabContents = new DigifficeAllnoteHelpTab();
            helpTabContents.InitialiseUI(RibbonPanel);
            previouslySelectedTab = HelpTab;
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

        private void SectionBG_Paint(object sender, PaintEventArgs e)
        {
            this.SectionBG.Location = new Point(LeftInfoPanel.Right + 20, LeftInfoPanel.Location.Y + 20);
            this.SectionBG.Size = new Size((this.Width - SectionBG.Location.X) - 20, (this.Height - SectionBG.Location.Y) - 20);
        }
    }
}
