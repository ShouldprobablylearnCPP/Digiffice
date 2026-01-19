using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiffice.Resources.Classes.ProgramClasses;
using Digiffice.Resources.Classes.ProgramClasses.CustomControls;
using Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote.AllnoteTabClasses;
using Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote;
using Digiffice.Resources.Classes.ProgramClasses.DigifficeAllpad;

namespace Digiffice
{

    public partial class DigifficeAllnote : Form
    {

        // Class Variables
        Image xBtnDefault = Properties.Resources.XbtnDefault;
        Image xBtnHover = Properties.Resources.XbtnHover;
        Control previouslySelectedTab = null;

        // Border Panels
        Panel SectionBG_Borderpnl = new Panel();
        Panel nonPageBG_Borderpnl = new Panel();

        // Notebook Variables
        Color notebook_ChapterCol = Color.Red;

        // Editor Variables
        DigifficeAllnoteEditorFile.Chapter? currentChapter = null;
        DigifficeAllnoteEditorFile.Page? currentPage = null;
        Label currentSelectedPage_Lbl = null;

        public DigifficeAllnote(nonprotected_AccountData nonprotected_AccountData, DigifficeAllnote_Splashscreen splashscreen)
        {
            // Set dimensions
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            // Initialize components
            InitializeComponent();

            // Call Custom/Prerequesite Functions
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            SetupBorderPanels();
            DigifficeAllnote_NewFile("NewNotebook");

            // Hide form until fully loaded to prevent flickering
            this.Opacity = 0;
            this.Shown += (s, e) =>
            {
                this.Opacity = 1;
                splashscreen.Close();
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
        // ..._New... Events
        private void DigifficeAllnote_NewFile(string fileName)
        {
            Vector2 defaultPageSize_cm = new Vector2(21.00f, 29.70f);
            DigifficeAllnoteEditorFile editorFile = new DigifficeAllnoteEditorFile();
            editorFile.fileName = fileName;
            DigifficeAllnote_NewChapter("Unnamed Chapter", editorFile);
            DigifficeAllnoteEditorFile.Chapter? firstChapter = FindChapterByName(editorFile, "Unnamed Chapter");
            if (firstChapter == null)
            {
                MessageBox.Show("Error creating new notebook: first chapter not found. Closing Digiffice Allpad...");
                this.Close();
            }
#pragma warning disable CS8629 // Nullable value type may be null.
            DigifficeAllnote_NewPage("Unnamed Page", defaultPageSize_cm, editorFile, (DigifficeAllnoteEditorFile.Chapter)firstChapter);
#pragma warning restore CS8629 // Nullable value type may be null.
            DigifficeAllnote_ShowNote(editorFile.chapters[0], editorFile);
        }

        private void DigifficeAllnote_NewPage(string pageName, Vector2 Size, DigifficeAllnoteEditorFile parentNotebook, DigifficeAllnoteEditorFile.Chapter parentChapter)
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

        private void DigifficeAllnote_NewChapter(string chapterName, DigifficeAllnoteEditorFile parentNotebook)
        {
            DigifficeAllnoteEditorFile.Chapter newChapter = new DigifficeAllnoteEditorFile.Chapter();
            Random rnd = new Random();
            newChapter.chapterNum = parentNotebook.chapters.Count + 1;
            if (newChapter.chapterNum != 1)
            {
                newChapter.chapterCol = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            }
            else
            {
                newChapter.chapterCol = Color.LightPink;
            }
            newChapter.chapterName = chapterName;
            newChapter.chapterNum = parentNotebook.chapters.Count + 1;
            parentNotebook.chapters.Add(newChapter);
        }

        // ..._Show... Events
        private void DigifficeAllnote_ShowChapter(DigifficeAllnoteEditorFile.Chapter chapter)
        {
            // Update current chapter
            currentChapter = chapter;
            notebook_ChapterCol = chapter.chapterCol;
            currentPage = chapter.chapterPages[0];
        }

        private void DigifficeAllnote_ShowNote(DigifficeAllnoteEditorFile.Chapter chapter, DigifficeAllnoteEditorFile editorFile)
        {
            // Show Editable Page
            DigifficeAllnote_ShowChapter(chapter);
            DigifficeAllnote_ShowEditablePageBackground(chapter.chapterPages[0]);
            DigifficeAllnote_ShowChaptersAndPagesInInspectors(editorFile, chapter);

            // Initialise Editor Functions
        }

        private void DigifficeAllnote_ShowEditablePageBackground(DigifficeAllnoteEditorFile.Page currentPage)
        {
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

            // Setup/Reconfigure nonPageBG_Borderpnl
            nonPageBG_Borderpnl.Location = new Point(nonPageBg.Location.X - 1, nonPageBg.Location.Y - 1);
            nonPageBG_Borderpnl.Size = new Size(nonPageBg.Width + pageVScroll.ctrlToAdd.Width + 2, nonPageBg.Height + pageHScroll.ctrlToAdd.Height + 2);
            nonPageBG_Borderpnl.BackColor = Color.Navy;
            nonPageBG_Borderpnl.SendToBack();
            SectionBG.Controls.Add(nonPageBG_Borderpnl);
        }

        private void DigifficeAllnote_ShowChaptersAndPagesInInspectors(DigifficeAllnoteEditorFile file, DigifficeAllnoteEditorFile.Chapter chapter)
        {
            for (int i = 0; i < chapter.chapterPages.Count;)
            {
                // Instantiate Page Panel and add to SectionBG_Pages
                Label inspector_PageLabel = new Label();
                inspector_PageLabel.Name = "Inspector_PageLabel_" + chapter.chapterPages[i].pageNum;
                inspector_PageLabel.Text = chapter.chapterPages[i].pageNum + ". " + chapter.chapterPages[i].pageTitle;
                inspector_PageLabel.TextAlign = ContentAlignment.MiddleCenter;
                inspector_PageLabel.Font = new Font("Roboto", 12, FontStyle.Bold);
                inspector_PageLabel.Size = new Size(SectionBG_Pages.Width - 1, 50);
                inspector_PageLabel.BackColor = Color.White;
                inspector_PageLabel.ForeColor = Color.Black;
                inspector_PageLabel.BorderStyle = BorderStyle.None;
                inspector_PageLabel.Location = new Point(0, 1 + (i * 51));
                inspector_PageLabel.Cursor = Cursors.Hand;
                inspector_PageLabel.Click += (s, e) =>
                {
                    if (currentSelectedPage_Lbl != null)
                    {
                        currentSelectedPage_Lbl.BackColor = Color.White;
                    }
                    currentSelectedPage_Lbl = inspector_PageLabel;
                    inspector_PageLabel.BackColor = Color.Blue;
                    currentPage = chapter.chapterPages[i - 1];
                    DigifficeAllnote_ShowEditablePageBackground(chapter.chapterPages[i - 1]);
                };
                SectionBG_Pages.Controls.Add(inspector_PageLabel);

                // Instantiate Border Panel and add to SectionBG_Pages
                Panel inspector_PageLabel_Border = new Panel();
                inspector_PageLabel_Border.Name = "Inspector_PageLabel_Border_" + chapter.chapterPages[i].pageNum;
                inspector_PageLabel_Border.Size = new Size(inspector_PageLabel.Width + 2, inspector_PageLabel.Height + 2);
                inspector_PageLabel_Border.Location = new Point(inspector_PageLabel.Location.X - 1, inspector_PageLabel.Location.Y - 1);
                inspector_PageLabel_Border.BackColor = Color.Navy;
                SectionBG_Pages.Controls.Add(inspector_PageLabel_Border);

                i++;
            }

            SectionBGPages_BorderCover.SendToBack();
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

        // NewPageBtn Events
        private void NewPage_Click(object sender, EventArgs e)
        {
            // To Be Implemented
            // Todo: Make Image for NewPage button
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
            this.SectionBG.Location = new Point(LeftInfoPanel.Right + 20, LeftInfoPanel.Location.Y + 60);
            this.SectionBG.Size = new Size((this.Width - SectionBG.Location.X) - 20, (this.Height - SectionBG.Location.Y) - 20);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Point fixedClientRectLocation = new Point(SectionBG.ClientRectangle.Location.X - 1, SectionBG.ClientRectangle.Location.Y - 1);
            Size fixedClientRectSize = new Size(SectionBG.ClientRectangle.Size.Width + 1, SectionBG.ClientRectangle.Size.Height + 1);
            Rectangle rect = new(fixedClientRectLocation, fixedClientRectSize);
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, notebook_ChapterCol, Color.FromArgb(255,
                Math.Clamp(notebook_ChapterCol.R + 15, 0, 255),
                Math.Clamp(notebook_ChapterCol.G + 15, 0, 255),
                Math.Clamp(notebook_ChapterCol.B + 15, 0, 255)), LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            // Change NewPageBtn text colour based on notebook_ChapterCol brightness
            double Value_Darkness = (notebook_ChapterCol.R + notebook_ChapterCol.G + notebook_ChapterCol.B) / (255 * 3);
            if (Value_Darkness < 0.33)
            {
                NewPageBtn.ForeColor = Color.Black;
                CosmeticPanel_ButtonSeperator_SectionBG.BackColor = Color.Black;
            }
            else if (Value_Darkness < 0.66)
            {
                NewPageBtn.ForeColor = Color.Gray;
                CosmeticPanel_ButtonSeperator_SectionBG.BackColor = Color.Gray;
            }
            else
            {
                NewPageBtn.ForeColor = Color.White;
                CosmeticPanel_ButtonSeperator_SectionBG.BackColor = Color.White;
            }
        }

        private void CosmeticPanel_BetweenScrollbars_Paint(object sender, PaintEventArgs e)
        {
            // Setup CosmeticPanel_BetweenScrollbars
            CosmeticPanel_BetweenScrollbars.Location = new Point(nonPageBg.Right, nonPageBg.Bottom);
            CosmeticPanel_BetweenScrollbars.Size = new Size(30, 30);
        }

        private void SetupBorderPanels()
        {
            // Setup SectionBG_Borderpnl
            SectionBG_Borderpnl.Location = new Point(SectionBG.Location.X - 1, SectionBG.Location.Y - 1);
            SectionBG_Borderpnl.Size = new Size(SectionBG.Width + 2, SectionBG.Height + 2);
            SectionBG_Borderpnl.BackColor = Color.Navy;
            SectionBG_Borderpnl.SendToBack();
            this.Controls.Add(SectionBG_Borderpnl);
        }
    }
}
