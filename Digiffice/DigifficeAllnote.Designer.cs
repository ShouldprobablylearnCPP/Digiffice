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
            Homepanel.SuspendLayout();
            TabSelectionPanel.SuspendLayout();
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
            HelpTab.FlatAppearance.BorderSize = 0;
            HelpTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            HelpTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HelpTab.FlatStyle = FlatStyle.Flat;
            HelpTab.Font = new Font("Segoe UI", 12F);
            HelpTab.Location = new Point(667, 10);
            HelpTab.Name = "HelpTab";
            HelpTab.Size = new Size(75, 30);
            HelpTab.TabIndex = 10;
            HelpTab.Text = "Help";
            HelpTab.UseVisualStyleBackColor = false;
            HelpTab.Click += Tab_Click;
            // 
            // ViewTab
            // 
            ViewTab.BackColor = Color.Transparent;
            ViewTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            ViewTab.BackgroundImageLayout = ImageLayout.Stretch;
            ViewTab.FlatAppearance.BorderSize = 0;
            ViewTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ViewTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ViewTab.FlatStyle = FlatStyle.Flat;
            ViewTab.Font = new Font("Segoe UI", 12F);
            ViewTab.Location = new Point(586, 10);
            ViewTab.Name = "ViewTab";
            ViewTab.Size = new Size(75, 30);
            ViewTab.TabIndex = 9;
            ViewTab.Text = "View";
            ViewTab.UseVisualStyleBackColor = false;
            ViewTab.Click += Tab_Click;
            // 
            // ReviewTab
            // 
            ReviewTab.BackColor = Color.Transparent;
            ReviewTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            ReviewTab.BackgroundImageLayout = ImageLayout.Stretch;
            ReviewTab.FlatAppearance.BorderSize = 0;
            ReviewTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ReviewTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ReviewTab.FlatStyle = FlatStyle.Flat;
            ReviewTab.Font = new Font("Segoe UI", 12F);
            ReviewTab.Location = new Point(505, 10);
            ReviewTab.Name = "ReviewTab";
            ReviewTab.Size = new Size(75, 30);
            ReviewTab.TabIndex = 8;
            ReviewTab.Text = "Review";
            ReviewTab.UseVisualStyleBackColor = false;
            ReviewTab.Click += Tab_Click;
            // 
            // HistoryTab
            // 
            HistoryTab.BackColor = Color.Transparent;
            HistoryTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            HistoryTab.BackgroundImageLayout = ImageLayout.Stretch;
            HistoryTab.FlatAppearance.BorderSize = 0;
            HistoryTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            HistoryTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HistoryTab.FlatStyle = FlatStyle.Flat;
            HistoryTab.Font = new Font("Segoe UI", 12F);
            HistoryTab.Location = new Point(424, 10);
            HistoryTab.Name = "HistoryTab";
            HistoryTab.Size = new Size(75, 30);
            HistoryTab.TabIndex = 7;
            HistoryTab.Text = "History";
            HistoryTab.UseVisualStyleBackColor = false;
            HistoryTab.Click += Tab_Click;
            // 
            // DrawTab
            // 
            DrawTab.BackColor = Color.Transparent;
            DrawTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            DrawTab.BackgroundImageLayout = ImageLayout.Stretch;
            DrawTab.FlatAppearance.BorderSize = 0;
            DrawTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            DrawTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            DrawTab.FlatStyle = FlatStyle.Flat;
            DrawTab.Font = new Font("Segoe UI", 12F);
            DrawTab.Location = new Point(343, 10);
            DrawTab.Name = "DrawTab";
            DrawTab.Size = new Size(75, 30);
            DrawTab.TabIndex = 6;
            DrawTab.Text = "Draw";
            DrawTab.UseVisualStyleBackColor = false;
            DrawTab.Click += Tab_Click;
            // 
            // InsertTab
            // 
            InsertTab.BackColor = Color.Transparent;
            InsertTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            InsertTab.BackgroundImageLayout = ImageLayout.Stretch;
            InsertTab.FlatAppearance.BorderSize = 0;
            InsertTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            InsertTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            InsertTab.FlatStyle = FlatStyle.Flat;
            InsertTab.Font = new Font("Segoe UI", 12F);
            InsertTab.Location = new Point(262, 10);
            InsertTab.Name = "InsertTab";
            InsertTab.Size = new Size(75, 30);
            InsertTab.TabIndex = 5;
            InsertTab.Text = "Insert";
            InsertTab.UseVisualStyleBackColor = false;
            InsertTab.Click += Tab_Click;
            // 
            // HomeTab
            // 
            HomeTab.BackColor = Color.Transparent;
            HomeTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            HomeTab.BackgroundImageLayout = ImageLayout.Stretch;
            HomeTab.FlatAppearance.BorderSize = 0;
            HomeTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            HomeTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HomeTab.FlatStyle = FlatStyle.Flat;
            HomeTab.Font = new Font("Segoe UI", 12F);
            HomeTab.Location = new Point(181, 10);
            HomeTab.Name = "HomeTab";
            HomeTab.Size = new Size(75, 30);
            HomeTab.TabIndex = 1;
            HomeTab.Text = "Home";
            HomeTab.UseVisualStyleBackColor = false;
            HomeTab.Click += Tab_Click;
            // 
            // FileTab
            // 
            FileTab.BackColor = Color.Transparent;
            FileTab.BackgroundImage = Properties.Resources.DeselectedRibbontab;
            FileTab.BackgroundImageLayout = ImageLayout.Stretch;
            FileTab.FlatAppearance.BorderSize = 0;
            FileTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            FileTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            FileTab.FlatStyle = FlatStyle.Flat;
            FileTab.Font = new Font("Segoe UI", 12F);
            FileTab.Location = new Point(100, 10);
            FileTab.Name = "FileTab";
            FileTab.Size = new Size(75, 30);
            FileTab.TabIndex = 0;
            FileTab.Text = "File";
            FileTab.UseVisualStyleBackColor = false;
            FileTab.Click += Tab_Click;
            // 
            // RibbonPanel
            // 
            RibbonPanel.BackColor = SystemColors.ActiveCaption;
            RibbonPanel.BackgroundImage = Properties.Resources.FullRibbon;
            RibbonPanel.BackgroundImageLayout = ImageLayout.Stretch;
            RibbonPanel.ForeColor = SystemColors.ControlText;
            RibbonPanel.Location = new Point(10, 38);
            RibbonPanel.Name = "RibbonPanel";
            RibbonPanel.Size = new Size(1900, 150);
            RibbonPanel.TabIndex = 4;
            // 
            // DigifficeAllnote
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.DigifficeAppBG;
            ClientSize = new Size(1920, 1080);
            Controls.Add(DigifficeButton);
            Controls.Add(TabSelectionPanel);
            Controls.Add(Homepanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DigifficeAllnote";
            Text = "DigifficeAllpad";
            Homepanel.ResumeLayout(false);
            Homepanel.PerformLayout();
            TabSelectionPanel.ResumeLayout(false);
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
    }
}