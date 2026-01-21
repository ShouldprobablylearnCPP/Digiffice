namespace Digiffice
{
    partial class DigifficeAllnote
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Homepanel = new Panel();
            ExitButton = new Button();
            Windowmsg = new Label();
            DigifficeButton = new Button();
            TabSelectionPanel = new Panel();
            HelpTab = new Button();
            ViewTab = new Button();
            ReviewTab = new Button();
            HistoryTab = new Button();
            DrawTab = new Button();
            InsertTab = new Button();
            HomeTab = new Button();
            FileTab = new Button();
            RibbonPanel = new Panel();
            LeftInfoPanel = new Panel();
            SectionBG = new Panel();
            CosmeticPanel_ButtonSeperator_SectionBG = new Panel();
            CloseOpenSectionBGPagesBtn = new Button();
            NewPageBtn = new Button();
            SectionBG_Pages = new Panel();
            SectionBGPages_BorderCover = new Panel();
            CosmeticPanel_BetweenScrollbars = new Panel();
            nonPageBg = new Panel();
            Homepanel.SuspendLayout();
            TabSelectionPanel.SuspendLayout();
            SectionBG.SuspendLayout();
            SectionBG_Pages.SuspendLayout();
            SuspendLayout();
            // 
            // Homepanel
            // 
            Homepanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Homepanel.BackColor = SystemColors.ControlLight;
            Homepanel.BackgroundImage = Properties.Resources.Panel;
            Homepanel.BackgroundImageLayout = ImageLayout.Stretch;
            Homepanel.Controls.Add(ExitButton);
            Homepanel.Controls.Add(Windowmsg);
            Homepanel.Location = new Point(0, 0);
            Homepanel.Name = "Homepanel";
            Homepanel.Size = new Size(2010, 59);
            Homepanel.TabIndex = 1;
            // 
            // ExitButton
            // 
            ExitButton.BackColor = Color.Transparent;
            ExitButton.BackgroundImageLayout = ImageLayout.Stretch;
            ExitButton.FlatAppearance.BorderSize = 0;
            ExitButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 0, 0);
            ExitButton.FlatStyle = FlatStyle.Flat;
            ExitButton.Font = new Font("Roboto", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExitButton.ForeColor = SystemColors.ControlText;
            ExitButton.Image = Properties.Resources.XbtnDefault;
            ExitButton.Location = new Point(1825, 0);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(74, 24);
            ExitButton.TabIndex = 1;
            ExitButton.UseVisualStyleBackColor = false;
            ExitButton.Click += ExitButton_Click;
            ExitButton.MouseEnter += ExitButton_MouseEnter;
            ExitButton.MouseLeave += ExitButton_MouseLeave;
            // 
            // Windowmsg
            // 
            Windowmsg.AutoSize = true;
            Windowmsg.BackColor = Color.Transparent;
            Windowmsg.Font = new Font("Roboto", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Windowmsg.Location = new Point(852, 15);
            Windowmsg.Name = "Windowmsg";
            Windowmsg.Size = new Size(182, 29);
            Windowmsg.TabIndex = 0;
            Windowmsg.Text = "Digiffice Allnote";
            Windowmsg.TextAlign = ContentAlignment.MiddleCenter;
            Windowmsg.TextChanged += Windowmsg_TextChanged;
            Windowmsg.Paint += Windowmsg_Paint;
            // 
            // DigifficeButton
            // 
            DigifficeButton.Cursor = Cursors.Hand;
            DigifficeButton.FlatAppearance.BorderSize = 0;
            DigifficeButton.FlatStyle = FlatStyle.Flat;
            DigifficeButton.Location = new Point(12, 12);
            DigifficeButton.Name = "DigifficeButton";
            DigifficeButton.Size = new Size(75, 75);
            DigifficeButton.TabIndex = 3;
            DigifficeButton.Text = "Return to Digiffice";
            DigifficeButton.UseVisualStyleBackColor = true;
            DigifficeButton.Click += DigifficeButton_Click;
            // 
            // TabSelectionPanel
            // 
            TabSelectionPanel.BackColor = SystemColors.GradientActiveCaption;
            TabSelectionPanel.Controls.Add(HelpTab);
            TabSelectionPanel.Controls.Add(ViewTab);
            TabSelectionPanel.Controls.Add(ReviewTab);
            TabSelectionPanel.Controls.Add(HistoryTab);
            TabSelectionPanel.Controls.Add(DrawTab);
            TabSelectionPanel.Controls.Add(InsertTab);
            TabSelectionPanel.Controls.Add(HomeTab);
            TabSelectionPanel.Controls.Add(FileTab);
            TabSelectionPanel.Controls.Add(RibbonPanel);
            TabSelectionPanel.ForeColor = SystemColors.ActiveCaptionText;
            TabSelectionPanel.Location = new Point(0, 59);
            TabSelectionPanel.Name = "TabSelectionPanel";
            TabSelectionPanel.Size = new Size(1920, 198);
            TabSelectionPanel.TabIndex = 2;
            // 
            // HelpTab
            // 
            HelpTab.BackColor = Color.Transparent;
            HelpTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            HelpTab.BackgroundImageLayout = ImageLayout.Stretch;
            HelpTab.Cursor = Cursors.Hand;
            HelpTab.FlatAppearance.BorderSize = 0;
            HelpTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            HelpTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HelpTab.FlatStyle = FlatStyle.Flat;
            HelpTab.Font = new Font("Roboto", 12F);
            HelpTab.Location = new Point(667, 10);
            HelpTab.Name = "HelpTab";
            HelpTab.Size = new Size(75, 30);
            HelpTab.TabIndex = 10;
            HelpTab.Text = "Help";
            HelpTab.UseVisualStyleBackColor = false;
            HelpTab.Click += HelpTab_Click;
            // 
            // ViewTab
            // 
            ViewTab.BackColor = Color.Transparent;
            ViewTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            ViewTab.BackgroundImageLayout = ImageLayout.Stretch;
            ViewTab.Cursor = Cursors.Hand;
            ViewTab.FlatAppearance.BorderSize = 0;
            ViewTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ViewTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ViewTab.FlatStyle = FlatStyle.Flat;
            ViewTab.Font = new Font("Roboto", 12F);
            ViewTab.Location = new Point(586, 10);
            ViewTab.Name = "ViewTab";
            ViewTab.Size = new Size(75, 30);
            ViewTab.TabIndex = 9;
            ViewTab.Text = "View";
            ViewTab.UseVisualStyleBackColor = false;
            ViewTab.Click += ViewTab_Click;
            // 
            // ReviewTab
            // 
            ReviewTab.BackColor = Color.Transparent;
            ReviewTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            ReviewTab.BackgroundImageLayout = ImageLayout.Stretch;
            ReviewTab.Cursor = Cursors.Hand;
            ReviewTab.FlatAppearance.BorderSize = 0;
            ReviewTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ReviewTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ReviewTab.FlatStyle = FlatStyle.Flat;
            ReviewTab.Font = new Font("Roboto", 12F);
            ReviewTab.Location = new Point(505, 10);
            ReviewTab.Name = "ReviewTab";
            ReviewTab.Size = new Size(75, 30);
            ReviewTab.TabIndex = 8;
            ReviewTab.Text = "Review";
            ReviewTab.UseVisualStyleBackColor = false;
            ReviewTab.Click += ReviewTab_Click;
            // 
            // HistoryTab
            // 
            HistoryTab.BackColor = Color.Transparent;
            HistoryTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            HistoryTab.BackgroundImageLayout = ImageLayout.Stretch;
            HistoryTab.Cursor = Cursors.Hand;
            HistoryTab.FlatAppearance.BorderSize = 0;
            HistoryTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            HistoryTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HistoryTab.FlatStyle = FlatStyle.Flat;
            HistoryTab.Font = new Font("Roboto", 12F);
            HistoryTab.Location = new Point(424, 10);
            HistoryTab.Name = "HistoryTab";
            HistoryTab.Size = new Size(75, 30);
            HistoryTab.TabIndex = 7;
            HistoryTab.Text = "History";
            HistoryTab.UseVisualStyleBackColor = false;
            HistoryTab.Click += HistoryTab_Click;
            // 
            // DrawTab
            // 
            DrawTab.BackColor = Color.Transparent;
            DrawTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            DrawTab.BackgroundImageLayout = ImageLayout.Stretch;
            DrawTab.Cursor = Cursors.Hand;
            DrawTab.FlatAppearance.BorderSize = 0;
            DrawTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            DrawTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            DrawTab.FlatStyle = FlatStyle.Flat;
            DrawTab.Font = new Font("Roboto", 12F);
            DrawTab.Location = new Point(343, 10);
            DrawTab.Name = "DrawTab";
            DrawTab.Size = new Size(75, 30);
            DrawTab.TabIndex = 6;
            DrawTab.Text = "Draw";
            DrawTab.UseVisualStyleBackColor = false;
            DrawTab.Click += DrawTab_Click;
            // 
            // InsertTab
            // 
            InsertTab.BackColor = Color.Transparent;
            InsertTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            InsertTab.BackgroundImageLayout = ImageLayout.Stretch;
            InsertTab.Cursor = Cursors.Hand;
            InsertTab.FlatAppearance.BorderSize = 0;
            InsertTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            InsertTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            InsertTab.FlatStyle = FlatStyle.Flat;
            InsertTab.Font = new Font("Roboto", 12F);
            InsertTab.Location = new Point(262, 10);
            InsertTab.Name = "InsertTab";
            InsertTab.Size = new Size(75, 30);
            InsertTab.TabIndex = 5;
            InsertTab.Text = "Insert";
            InsertTab.UseVisualStyleBackColor = false;
            InsertTab.Click += InsertTab_Click;
            // 
            // HomeTab
            // 
            HomeTab.BackColor = Color.Transparent;
            HomeTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            HomeTab.BackgroundImageLayout = ImageLayout.Stretch;
            HomeTab.Cursor = Cursors.Hand;
            HomeTab.FlatAppearance.BorderSize = 0;
            HomeTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            HomeTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HomeTab.FlatStyle = FlatStyle.Flat;
            HomeTab.Font = new Font("Roboto", 12F);
            HomeTab.Location = new Point(181, 10);
            HomeTab.Name = "HomeTab";
            HomeTab.Size = new Size(75, 30);
            HomeTab.TabIndex = 1;
            HomeTab.Text = "Home";
            HomeTab.UseVisualStyleBackColor = false;
            HomeTab.Click += HomeTab_Click;
            // 
            // FileTab
            // 
            FileTab.BackColor = Color.Transparent;
            FileTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            FileTab.BackgroundImageLayout = ImageLayout.Stretch;
            FileTab.Cursor = Cursors.Hand;
            FileTab.FlatAppearance.BorderSize = 0;
            FileTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            FileTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            FileTab.FlatStyle = FlatStyle.Flat;
            FileTab.Font = new Font("Roboto", 12F);
            FileTab.Location = new Point(100, 10);
            FileTab.Name = "FileTab";
            FileTab.Size = new Size(75, 30);
            FileTab.TabIndex = 0;
            FileTab.Text = "File";
            FileTab.UseVisualStyleBackColor = false;
            FileTab.Click += FileTab_Click;
            // 
            // RibbonPanel
            // 
            RibbonPanel.BackColor = Color.Transparent;
            RibbonPanel.BackgroundImage = Properties.Resources.FullRibbon;
            RibbonPanel.BackgroundImageLayout = ImageLayout.Stretch;
            RibbonPanel.ForeColor = SystemColors.ControlText;
            RibbonPanel.Location = new Point(10, 38);
            RibbonPanel.Name = "RibbonPanel";
            RibbonPanel.Size = new Size(1900, 150);
            RibbonPanel.TabIndex = 4;
            // 
            // LeftInfoPanel
            // 
            LeftInfoPanel.BackColor = SystemColors.GradientActiveCaption;
            LeftInfoPanel.Location = new Point(0, 257);
            LeftInfoPanel.Name = "LeftInfoPanel";
            LeftInfoPanel.Size = new Size(250, 823);
            LeftInfoPanel.TabIndex = 5;
            // 
            // SectionBG
            // 
            SectionBG.BackColor = Color.DarkRed;
            SectionBG.Controls.Add(CosmeticPanel_ButtonSeperator_SectionBG);
            SectionBG.Controls.Add(CloseOpenSectionBGPagesBtn);
            SectionBG.Controls.Add(NewPageBtn);
            SectionBG.Controls.Add(SectionBG_Pages);
            SectionBG.Controls.Add(CosmeticPanel_BetweenScrollbars);
            SectionBG.Controls.Add(nonPageBg);
            SectionBG.Location = new Point(270, 317);
            SectionBG.Name = "SectionBG";
            SectionBG.Size = new Size(1630, 743);
            SectionBG.TabIndex = 6;
            SectionBG.Paint += SectionBG_Paint;
            // 
            // CosmeticPanel_ButtonSeperator_SectionBG
            // 
            CosmeticPanel_ButtonSeperator_SectionBG.BackColor = Color.Black;
            CosmeticPanel_ButtonSeperator_SectionBG.Location = new Point(1568, 24);
            CosmeticPanel_ButtonSeperator_SectionBG.Name = "CosmeticPanel_ButtonSeperator_SectionBG";
            CosmeticPanel_ButtonSeperator_SectionBG.Size = new Size(1, 30);
            CosmeticPanel_ButtonSeperator_SectionBG.TabIndex = 5;
            // 
            // CloseOpenSectionBGPagesBtn
            // 
            CloseOpenSectionBGPagesBtn.BackColor = Color.Transparent;
            CloseOpenSectionBGPagesBtn.Cursor = Cursors.Hand;
            CloseOpenSectionBGPagesBtn.FlatAppearance.BorderSize = 0;
            CloseOpenSectionBGPagesBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            CloseOpenSectionBGPagesBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            CloseOpenSectionBGPagesBtn.FlatStyle = FlatStyle.Flat;
            CloseOpenSectionBGPagesBtn.Font = new Font("Roboto", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CloseOpenSectionBGPagesBtn.Location = new Point(1569, 19);
            CloseOpenSectionBGPagesBtn.Name = "CloseOpenSectionBGPagesBtn";
            CloseOpenSectionBGPagesBtn.Size = new Size(40, 40);
            CloseOpenSectionBGPagesBtn.TabIndex = 4;
            CloseOpenSectionBGPagesBtn.TextAlign = ContentAlignment.MiddleRight;
            CloseOpenSectionBGPagesBtn.UseVisualStyleBackColor = false;
            // 
            // NewPageBtn
            // 
            NewPageBtn.BackColor = Color.Transparent;
            NewPageBtn.Cursor = Cursors.Hand;
            NewPageBtn.FlatAppearance.BorderSize = 0;
            NewPageBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            NewPageBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            NewPageBtn.FlatStyle = FlatStyle.Flat;
            NewPageBtn.Font = new Font("Roboto", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NewPageBtn.Location = new Point(1391, 19);
            NewPageBtn.Name = "NewPageBtn";
            NewPageBtn.Size = new Size(177, 40);
            NewPageBtn.TabIndex = 3;
            NewPageBtn.Text = "New Page";
            NewPageBtn.TextAlign = ContentAlignment.MiddleRight;
            NewPageBtn.UseVisualStyleBackColor = false;
            NewPageBtn.Click += NewPage_Click;
            // 
            // SectionBG_Pages
            // 
            SectionBG_Pages.BackColor = Color.Transparent;
            SectionBG_Pages.Controls.Add(SectionBGPages_BorderCover);
            SectionBG_Pages.Location = new Point(1390, 59);
            SectionBG_Pages.Name = "SectionBG_Pages";
            SectionBG_Pages.Size = new Size(219, 635);
            SectionBG_Pages.TabIndex = 2;
            // 
            // SectionBGPages_BorderCover
            // 
            SectionBGPages_BorderCover.BackColor = Color.Navy;
            SectionBGPages_BorderCover.Location = new Point(0, 0);
            SectionBGPages_BorderCover.Name = "SectionBGPages_BorderCover";
            SectionBGPages_BorderCover.Size = new Size(1, 635);
            SectionBGPages_BorderCover.TabIndex = 0;
            // 
            // CosmeticPanel_BetweenScrollbars
            // 
            CosmeticPanel_BetweenScrollbars.BackColor = Color.LightGray;
            CosmeticPanel_BetweenScrollbars.Location = new Point(1360, 693);
            CosmeticPanel_BetweenScrollbars.Name = "CosmeticPanel_BetweenScrollbars";
            CosmeticPanel_BetweenScrollbars.Size = new Size(30, 30);
            CosmeticPanel_BetweenScrollbars.TabIndex = 1;
            CosmeticPanel_BetweenScrollbars.Paint += CosmeticPanel_BetweenScrollbars_Paint;
            // 
            // nonPageBg
            // 
            nonPageBg.BackColor = Color.Silver;
            nonPageBg.Location = new Point(20, 20);
            nonPageBg.Name = "nonPageBg";
            nonPageBg.Size = new Size(1340, 673);
            nonPageBg.TabIndex = 0;
            // 
            // DigifficeAllnote
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.DigifficeAppBG;
            ClientSize = new Size(1920, 1080);
            Controls.Add(SectionBG);
            Controls.Add(LeftInfoPanel);
            Controls.Add(DigifficeButton);
            Controls.Add(TabSelectionPanel);
            Controls.Add(Homepanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DigifficeAllnote";
            Text = "DigifficeAllnote";
            Homepanel.ResumeLayout(false);
            Homepanel.PerformLayout();
            TabSelectionPanel.ResumeLayout(false);
            SectionBG.ResumeLayout(false);
            SectionBG_Pages.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Homepanel;
        private Button ExitButton;
        private Label Windowmsg;
        private Panel TabSelectionPanel;
        private Button DigifficeButton;
        private Button FileTab;
        private Button HomeTab;
        private Panel RibbonPanel;
        private Button HistoryTab;
        private Button DrawTab;
        private Button InsertTab;
        private Button ViewTab;
        private Button ReviewTab;
        private Button HelpTab;
        private Panel LeftInfoPanel;
        private Panel SectionBG;
        private Panel nonPageBg;
        private Panel CosmeticPanel_BetweenScrollbars;
        private Panel SectionBG_Pages;
        private Panel SectionBGPages_BorderCover;
        private Button NewPageBtn;
        private Button CloseOpenSectionBGPagesBtn;
        private Panel CosmeticPanel_ButtonSeperator_SectionBG;
    }
}