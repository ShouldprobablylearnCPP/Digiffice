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
using Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote;
using Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote.AllnoteTabClasses;
using Digiffice.Resources.Classes.ProgramClasses.DigifficeAllpad;
using static Digiffice.Resources.Classes.ProgramClasses.DigifficeAllpad.DigifficeAllnoteEditorFile;

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
        DigifficeAllnoteEditorFile editorNotebook;
        DigifficeAllnoteEditorFile.Chapter currentChapter = new DigifficeAllnoteEditorFile.Chapter();
        DigifficeAllnoteEditorFile.Page? currentPage = null;
        Label currentSelectedPage_Lbl = null;
        CustomHScrollBar hScrollBar = null;
        CustomVScrollBar vScrollBar = null;
        bool allowedToCreateTextBoxOnPage = true;

        public DigifficeAllnote(nonprotected_AccountData nonprotected_AccountData, DigifficeAllnote_Splashscreen splashscreen)
        {
            // Set dimensions
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            // Initialize components
            InitializeComponent();

            // Call Custom/Prerequesite Functions
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            SetupBorderPanels();
            DigifficeAllnote_EditorPrerequisite();
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
            DigifficeAllnoteEditorFile editorFile = new DigifficeAllnoteEditorFile();
            editorFile.fileName = fileName;
            DigifficeAllnote_NewChapter("Unnamed Chapter", editorFile);
            DigifficeAllnoteEditorFile.Chapter? firstChapter = FindChapterByName(editorFile, "Unnamed Chapter");
            if (firstChapter == null)
            {
                MessageBox.Show("Error creating new notebook: first chapter not found. Closing Digiffice Allpad...");
                this.Close();
            }
            DigifficeAllnote_ShowNote(editorFile);
        }

        private void DigifficeAllnote_NewPage(string pageName, Vector2 Size, DigifficeAllnoteEditorFile parentNotebook, DigifficeAllnoteEditorFile.Chapter parentChapter, bool isFirstInChapter)
        {

            DigifficeAllnoteEditorFile.Page newPage = new DigifficeAllnoteEditorFile.Page();
            newPage.pageSize = Size;
            newPage.pageNum = parentNotebook.filePages.Count + 1;
            newPage.pageTitle = pageName;
            newPage.CreatedDateTime = DateTime.Now;

            int insertIndex;
            if (isFirstInChapter)
            {
                insertIndex = parentNotebook.filePages.Count;
            }
            else
            {
                insertIndex = parentChapter.chapterPages[parentChapter.chapterPages.Count - 1].pageNum;
            }
            newPage.parentChapter = parentChapter;
            parentNotebook.filePages.Insert(insertIndex, newPage);
            parentChapter.chapterPages.Add(newPage);

            // Update Page numbers (After over a week it finally works)
            foreach (var item in parentNotebook.filePages)
            {
                item.pageNum = parentNotebook.filePages.IndexOf(item) + 1;
            }

            DigifficeAllnote_ShowPagesInInspector(parentChapter);
        }

        private void DigifficeAllnote_NewChapter(string chapterName, DigifficeAllnoteEditorFile parentNotebook)
        {
            // Create Chapter
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

            // Create first page in chapter
            Vector2 defaultPageSize_cm = new Vector2(21.00f, 29.70f);
            DigifficeAllnote_NewPage("Unnamed Page", defaultPageSize_cm, parentNotebook, newChapter, true);

            parentNotebook.chapters.Add(newChapter);
        }

        // ..._Show... Events
        private void DigifficeAllnote_ShowChapter(DigifficeAllnoteEditorFile.Chapter chapter, DigifficeAllnoteEditorFile editorFile)
        {
            // Update current chapter
            currentChapter = chapter;
            notebook_ChapterCol = chapter.chapterCol;
            currentPage = chapter.chapterPages[0];
            SectionBG.Refresh();
            DigifficeAllnote_ShowEditablePageBackground(chapter.chapterPages[0]);
            DigifficeAllnote_ShowPagesInInspector(chapter);
        }

        private void DigifficeAllnote_ShowNote(DigifficeAllnoteEditorFile editorFile)
        {
            // Show Editable Page
            editorNotebook = editorFile;
            DigifficeAllnoteEditorFile.Chapter chapter = editorFile.chapters[0];
            DigifficeAllnote_ShowChapter(chapter, editorFile);

            // Show Chapters and Pages in Inspectors
            DigifficeAllnote_ShowChaptersAndPagesInInspectors(editorFile, chapter);

            // Initialise Editor Functions
        }

        private void DigifficeAllnote_ShowEditablePageBackground(DigifficeAllnoteEditorFile.Page currentPage)
        {
            // Clear previous Page BG and Scrollbars
            nonPageBg.Controls.Clear();

            // Create Page
            Panel pagebg = new Panel();
            pagebg.Name = "PageBG";
            pagebg.BackColor = Color.FromArgb(255, 249, 251, 255);
            int sizex = Convertcm_pixels(currentPage.pageSize.X);
            int sizey = Convertcm_pixels(currentPage.pageSize.Y);
            pagebg.Size = new Size(SectionBG.Width - 20, SectionBG.Height - 70);
            Point pagebgPos = new Point(0, 0);
            pagebg.Location = pagebgPos;
            nonPageBg.Controls.Add(pagebg);

            // Edit Scrollbar Ranges and Sizes
            vScrollBar.setMinMaxRange(0, sizey - pagebg.Height);
            hScrollBar.setMinMaxRange(0, sizex - pagebg.Width);

            // Setup/Reconfigure nonPageBG_Borderpnl
            nonPageBG_Borderpnl.Location = new Point(nonPageBg.Location.X - 1, nonPageBg.Location.Y - 1);
            nonPageBG_Borderpnl.Size = new Size(nonPageBg.Width + vScrollBar.ctrlToAdd.Width + 2, nonPageBg.Height + hScrollBar.ctrlToAdd.Height + 2);
            nonPageBG_Borderpnl.BackColor = Color.Navy;
            nonPageBG_Borderpnl.SendToBack();
            SectionBG.Controls.Add(nonPageBG_Borderpnl);

            // Show Page Title and Created DateTime
            DigifficeAllnote_ShowPageTitleAndDatetime(currentPage);

            // Create a textbox anywhere on the page that is clicked
            pagebg.Click += (s, e) =>
            {
                if (allowedToCreateTextBoxOnPage)
                {
                    // Creates textbox at clicked location
                    Point clickLocation = pagebg.PointToClient(Cursor.Position);
                    TextBox newTextBox = new TextBox();
                    newTextBox.Location = clickLocation;
                    newTextBox.Size = new Size(200, 20);
                    newTextBox.Text = "New Text";
                    newTextBox.BackColor = Color.White;
                    newTextBox.ForeColor = Color.Black;
                    newTextBox.Font = new Font("Roboto", 10, FontStyle.Regular);
                    newTextBox.BorderStyle = BorderStyle.FixedSingle;
                    newTextBox.Multiline = true;
                    pagebg.Controls.Add(newTextBox);
                    newTextBox.Focus();

                    // Prevent creating multiple textboxes on one click by disabling textbox creation until next click after focusing the new textbox
                    allowedToCreateTextBoxOnPage = false;
                }
                else
                {
                    // If any control is focused, unfocus it and allow textbox creation on next click
                    if (this.ActiveControl != null)
                    {
                        this.ActiveControl = null;
                    }

                    // Allow textbox creation on next click
                    allowedToCreateTextBoxOnPage = true;
                }
            };
        }

        private void DigifficeAllnote_ShowPageTitleAndDatetime(DigifficeAllnoteEditorFile.Page page)
        {
            // Create Page Title and Created DateTime Controls
            TextBox pageTitle = new TextBox();
            pageTitle.Location = new Point(20, 20);
            pageTitle.Size = new Size(300, 20);
            pageTitle.BackColor = Color.White;
            pageTitle.ForeColor = Color.Black;
            pageTitle.BorderStyle = BorderStyle.None;
            pageTitle.TextAlign = HorizontalAlignment.Left;
            pageTitle.Font = new Font("Roboto", 14, FontStyle.Bold);
            pageTitle.Text = page.pageTitle;
            pageTitle.TextChanged += (s, e) =>
            {
                SizeF size = TextRenderer.MeasureText(pageTitle.Text, pageTitle.Font);
                pageTitle.Size = new Size((int)size.Width + 10, pageTitle.Height);
                page.pageTitle = pageTitle.Text;
                if (currentSelectedPage_Lbl != null)
                {
                    currentSelectedPage_Lbl.Text = page.pageNum + ". " + page.pageTitle;
                    currentSelectedPage_Lbl.Refresh();
                    PaintEventArgs pe = new PaintEventArgs(currentSelectedPage_Lbl.CreateGraphics(), currentSelectedPage_Lbl.ClientRectangle);
                    SelectedPageLabel_Paint(currentSelectedPage_Lbl, pe);
                }
            };
            pageTitle.GotFocus += (s, e) =>
            {
                allowedToCreateTextBoxOnPage = false;
            };

            Label PageCreatedDateTime = new Label();
            PageCreatedDateTime.Location = new Point(20, 50);
            PageCreatedDateTime.Size = new Size(300, 20);
            //PageCreatedDateTime.BackColor = Color.FromArgb(0, 0, 0, 0);
            PageCreatedDateTime.ForeColor = Color.Black;
            PageCreatedDateTime.Font = new Font("Roboto", 10, FontStyle.Regular);
            PageCreatedDateTime.Text = page.CreatedDateTime.ToString("g");

            // Add controls to PageBg
            Panel pagebg = (Panel)SectionBG.Controls.Find("PageBG", true)[0];
            pagebg.Controls.Add(pageTitle);
            pagebg.Controls.Add(PageCreatedDateTime);
        }

        private void DigifficeAllnote_ShowChaptersAndPagesInInspectors(DigifficeAllnoteEditorFile file, DigifficeAllnoteEditorFile.Chapter chapter)
        {


            DigifficeAllnote_ShowChaptersInInspector(file);
            DigifficeAllnote_ShowPagesInInspector(chapter);
        }

        private void DigifficeAllnote_ShowPagesInInspector(DigifficeAllnoteEditorFile.Chapter chapter)
        {
            // Get Border Cover
            Panel inspector_Pages_BorderCover = SectionBGPages_BorderCover;

            // Clear controls
            SectionBG_Pages.Controls.Clear();

            // Add Border Cover
            SectionBG_Pages.Controls.Add(inspector_Pages_BorderCover);

            // Pages from chapter
            for (int i = 0; i < chapter.chapterPages.Count;)
            {
                // Instantiate Page Panel and add to SectionBG_Pages

                DigifficeAllnoteEditorFile.Page pageToShow = chapter.chapterPages[i];

                Label inspector_PageLabel = new Label();
                inspector_PageLabel.Name = "Inspector_PageLabel_" + pageToShow.pageNum;
                inspector_PageLabel.Text = pageToShow.pageNum + ". " + pageToShow.pageTitle;
                inspector_PageLabel.TextAlign = ContentAlignment.MiddleCenter;
                inspector_PageLabel.Font = new Font("Roboto", 12, FontStyle.Regular);
                inspector_PageLabel.Size = new Size(SectionBG_Pages.Width - 1, 35);
                inspector_PageLabel.BackColor = Color.White;
                inspector_PageLabel.ForeColor = Color.Black;
                inspector_PageLabel.BorderStyle = BorderStyle.None;
                inspector_PageLabel.Location = new Point(0, 1 + (i * 36));
                inspector_PageLabel.Cursor = Cursors.Hand;
                inspector_PageLabel.Click += (s, e) =>
                {
                    // Deselect previous selected page
                    if (currentSelectedPage_Lbl != null)
                    {
                        currentSelectedPage_Lbl.BackColor = Color.White;
                        currentSelectedPage_Lbl.Refresh();
                    }
                    currentSelectedPage_Lbl = inspector_PageLabel;
                    currentPage = pageToShow;

                    // Show selected page
                    DigifficeAllnote_ShowEditablePageBackground(pageToShow);

                    // Paint selected page label
                    PaintEventArgs pe = new PaintEventArgs(inspector_PageLabel.CreateGraphics(), inspector_PageLabel.ClientRectangle);
                    SelectedPageLabel_Paint(inspector_PageLabel, pe);
                    // Todo: Paint when selected but not clicked (eg. when chapter is selected, first page is automatically selected but not clicked so it doesn't get painted) (Also applies to chapter labels in chapter inspector)
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
        }

        private void DigifficeAllnote_ShowChaptersInInspector(DigifficeAllnoteEditorFile file)
        {
            SectionBG_Chapters.Controls.Clear();
            // Chapters from file
            for (int i = 0; i < file.chapters.Count;)
            {
                // Instantiate Chapter Panel and add to SectionBG_Chapters
                DigifficeAllnoteEditorFile.Chapter chapter = file.chapters[i];
                Label inspector_ChapterLabel = new Label();
                inspector_ChapterLabel.Name = "Inspector_ChapterLabel_" + chapter.chapterNum;
                inspector_ChapterLabel.Text = chapter.chapterNum + ". " + chapter.chapterName;
                inspector_ChapterLabel.TextAlign = ContentAlignment.MiddleCenter;
                inspector_ChapterLabel.Font = new Font("Roboto", 12, FontStyle.Regular);
                inspector_ChapterLabel.Size = new Size(SectionBG_Chapters.Width / file.chapters.Count, 30);
                inspector_ChapterLabel.BackColor = file.chapters[i].chapterCol;
                inspector_ChapterLabel.ForeColor = Color.Black;
                inspector_ChapterLabel.BorderStyle = BorderStyle.None;
                inspector_ChapterLabel.Location = new Point(i * (SectionBG_Chapters.Width / file.chapters.Count), 0);
                inspector_ChapterLabel.Cursor = Cursors.Hand;
                inspector_ChapterLabel.Click += (s, e) =>
                {
                    DigifficeAllnote_ShowChapter(chapter, file);
                };
                SectionBG_Chapters.Controls.Add(inspector_ChapterLabel);
                i++;
            }
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
            DigifficeAllnote_NewPage("Unnamed Page", new Vector2(21.00f, 29.70f), editorNotebook, currentChapter, false);
        }

        // NewChapterBtn Events
        private void NewChapterBtn_Click(object sender, EventArgs e)
        {
            DigifficeAllnote_NewChapter("Unnamed Chapter", editorNotebook);
            DigifficeAllnote_ShowChapter(editorNotebook.chapters[editorNotebook.chapters.Count - 1], editorNotebook);
            DigifficeAllnoteEditorFile.Chapter newChapter = editorNotebook.chapters[editorNotebook.chapters.Count - 1];
            DigifficeAllnote_ShowChaptersAndPagesInInspectors(editorNotebook, newChapter);
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
                Math.Clamp(notebook_ChapterCol.R + 30, 0, 255),
                Math.Clamp(notebook_ChapterCol.G + 30, 0, 255),
                Math.Clamp(notebook_ChapterCol.B + 30, 0, 255)), LinearGradientMode.Vertical))
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

        private void SelectedPageLabel_Paint(object sender, PaintEventArgs e)
        {
            Label inspector_PageLabel = (Label)sender;

            // Paint selected page label
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Point fixedClientRectLocation = new Point(inspector_PageLabel.ClientRectangle.Location.X - 1, inspector_PageLabel.ClientRectangle.Location.Y - 1);
            Size fixedClientRectSize = new Size(inspector_PageLabel.Width + 2, inspector_PageLabel.Height + 2);
            Rectangle rect = new(fixedClientRectLocation, fixedClientRectSize);
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.White, Color.LightBlue, LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            // Render Text above gradient
            TextRenderer.DrawText(e.Graphics, inspector_PageLabel.Text, inspector_PageLabel.Font, inspector_PageLabel.ClientRectangle, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
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

        // Prerequisite Functions

        private void DigifficeAllnote_EditorPrerequisite()
        {
            // Setup nonPageBg
            nonPageBg.Location = new Point(20, 20);
            nonPageBg.Size = new Size(SectionBG.Width - 290, SectionBG.Height - 70);

            // Create Scrollbars
            CustomVScrollBar pageVScroll = new CustomVScrollBar(new Point(nonPageBg.Right, nonPageBg.Top), new Size(30, nonPageBg.Height),
                Color.LightGray, Color.LightGray, Color.LightGray, Color.Transparent,
                null, Properties.Resources.VScrollBar_UpScrollBtn, Properties.Resources.VScrollBar_DownScrollBtn, Properties.Resources.CustomVScrollBar_1);
            pageVScroll.setMinMaxRange(0, 0);
            pageVScroll.addControlstoControl(SectionBG);

            CustomHScrollBar pageHScroll = new CustomHScrollBar(new Point(nonPageBg.Left, nonPageBg.Bottom), new Size(nonPageBg.Width, 30),
                Color.LightGray, Color.LightGray, Color.LightGray, Color.Transparent,
                null, Properties.Resources.VScrollBar_LeftScrollBtn, Properties.Resources.VScrollBar_RightScrollBtn, Properties.Resources.CustomHScrollBar_1);
            pageHScroll.setMinMaxRange(0, 0);
            pageHScroll.addControlstoControl(SectionBG);

            // Add scrollbars to class variables for later use
            hScrollBar = pageHScroll;
            vScrollBar = pageVScroll;
        }
    }
}
