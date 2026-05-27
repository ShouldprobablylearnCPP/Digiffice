namespace Digiffice
{
    partial class Homepage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Homepage));
            Welcomemsg = new Label();
            Homepanel = new Panel();
            ExitButton = new Button();
            Offlinemsg = new Label();
            ProgramsPanel = new Panel();
            ProgramsLabel = new Label();
            PfpFramePanel = new Panel();
            PfpFramePfpOutlinePanel = new Panel();
            PfpFramePfpPanel = new Panel();
            ProfileNameLabel = new Label();
            VersionLabel = new Label();
            TourDigifficeBtn = new Button();
            Homepanel.SuspendLayout();
            ProgramsPanel.SuspendLayout();
            PfpFramePanel.SuspendLayout();
            PfpFramePfpOutlinePanel.SuspendLayout();
            SuspendLayout();
            // 
            // Welcomemsg
            // 
            Welcomemsg.AutoSize = true;
            Welcomemsg.BackColor = Color.Transparent;
            Welcomemsg.Font = new Font("Roboto", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Welcomemsg.Location = new Point(12, 12);
            Welcomemsg.Name = "Welcomemsg";
            Welcomemsg.Size = new Size(279, 35);
            Welcomemsg.TabIndex = 0;
            Welcomemsg.Text = "Welcome to Digiffice";
            // 
            // Homepanel
            // 
            Homepanel.AutoSize = true;
            Homepanel.BackColor = SystemColors.ControlLight;
            Homepanel.BackgroundImage = Properties.Resources.Panel;
            Homepanel.BackgroundImageLayout = ImageLayout.Stretch;
            Homepanel.Controls.Add(ExitButton);
            Homepanel.Controls.Add(Welcomemsg);
            Homepanel.Location = new Point(0, 0);
            Homepanel.Name = "Homepanel";
            Homepanel.Size = new Size(1904, 59);
            Homepanel.TabIndex = 0;
            Homepanel.Paint += Homepanel_Paint;
            // 
            // ExitButton
            // 
            ExitButton.BackColor = Color.Transparent;
            ExitButton.BackgroundImageLayout = ImageLayout.Stretch;
            ExitButton.Cursor = Cursors.Hand;
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
            // Offlinemsg
            // 
            Offlinemsg.AutoSize = true;
            Offlinemsg.BackColor = Color.Transparent;
            Offlinemsg.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Offlinemsg.ForeColor = SystemColors.ControlLight;
            Offlinemsg.Location = new Point(0, 1024);
            Offlinemsg.Name = "Offlinemsg";
            Offlinemsg.Size = new Size(459, 17);
            Offlinemsg.TabIndex = 2;
            Offlinemsg.Text = "You are currently using offline mode. Some features may be unavailable.";
            // 
            // ProgramsPanel
            // 
            ProgramsPanel.BackColor = SystemColors.ControlLight;
            ProgramsPanel.BackgroundImage = Properties.Resources.Panel400x30;
            ProgramsPanel.BackgroundImageLayout = ImageLayout.Stretch;
            ProgramsPanel.Controls.Add(ProgramsLabel);
            ProgramsPanel.Location = new Point(1450, 126);
            ProgramsPanel.Name = "ProgramsPanel";
            ProgramsPanel.Size = new Size(400, 30);
            ProgramsPanel.TabIndex = 1;
            // 
            // ProgramsLabel
            // 
            ProgramsLabel.AutoSize = true;
            ProgramsLabel.BackColor = Color.Transparent;
            ProgramsLabel.Font = new Font("Roboto", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            ProgramsLabel.ForeColor = Color.FromArgb(0, 0, 64);
            ProgramsLabel.Location = new Point(4, 4);
            ProgramsLabel.Name = "ProgramsLabel";
            ProgramsLabel.Size = new Size(93, 23);
            ProgramsLabel.TabIndex = 0;
            ProgramsLabel.Text = "Programs";
            // 
            // PfpFramePanel
            // 
            PfpFramePanel.BackColor = Color.Transparent;
            PfpFramePanel.BackgroundImage = Properties.Resources.DigifficePfpFrame150x150;
            PfpFramePanel.BackgroundImageLayout = ImageLayout.Stretch;
            PfpFramePanel.Controls.Add(PfpFramePfpOutlinePanel);
            PfpFramePanel.Location = new Point(20, 78);
            PfpFramePanel.Name = "PfpFramePanel";
            PfpFramePanel.Size = new Size(150, 150);
            PfpFramePanel.TabIndex = 3;
            // 
            // PfpFramePfpOutlinePanel
            // 
            PfpFramePfpOutlinePanel.BackgroundImage = Properties.Resources._150x150PfpFramePfpOutline;
            PfpFramePfpOutlinePanel.BackgroundImageLayout = ImageLayout.Stretch;
            PfpFramePfpOutlinePanel.Controls.Add(PfpFramePfpPanel);
            PfpFramePfpOutlinePanel.Dock = DockStyle.Fill;
            PfpFramePfpOutlinePanel.Location = new Point(0, 0);
            PfpFramePfpOutlinePanel.Name = "PfpFramePfpOutlinePanel";
            PfpFramePfpOutlinePanel.Size = new Size(150, 150);
            PfpFramePfpOutlinePanel.TabIndex = 0;
            // 
            // PfpFramePfpPanel
            // 
            PfpFramePfpPanel.BackgroundImageLayout = ImageLayout.Stretch;
            PfpFramePfpPanel.Location = new Point(15, 15);
            PfpFramePfpPanel.Name = "PfpFramePfpPanel";
            PfpFramePfpPanel.Size = new Size(120, 120);
            PfpFramePfpPanel.TabIndex = 0;
            // 
            // ProfileNameLabel
            // 
            ProfileNameLabel.AutoSize = true;
            ProfileNameLabel.Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProfileNameLabel.ForeColor = Color.White;
            ProfileNameLabel.Location = new Point(175, 83);
            ProfileNameLabel.Name = "ProfileNameLabel";
            ProfileNameLabel.Size = new Size(43, 15);
            ProfileNameLabel.TabIndex = 4;
            ProfileNameLabel.Text = "name";
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            VersionLabel.ForeColor = Color.White;
            VersionLabel.Location = new Point(176, 98);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(57, 15);
            VersionLabel.TabIndex = 5;
            VersionLabel.Text = "Version";
            // 
            // TourDigifficeBtn
            // 
            TourDigifficeBtn.BackColor = Color.FromArgb(10, 255, 255, 255);
            TourDigifficeBtn.FlatAppearance.BorderSize = 0;
            TourDigifficeBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 255, 255, 255);
            TourDigifficeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 255, 255, 255);
            TourDigifficeBtn.FlatStyle = FlatStyle.Flat;
            TourDigifficeBtn.Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TourDigifficeBtn.ForeColor = Color.White;
            TourDigifficeBtn.Location = new Point(175, 200);
            TourDigifficeBtn.Name = "TourDigifficeBtn";
            TourDigifficeBtn.Size = new Size(116, 28);
            TourDigifficeBtn.TabIndex = 6;
            TourDigifficeBtn.Text = "Tour Digiffice";
            TourDigifficeBtn.UseVisualStyleBackColor = false;
            TourDigifficeBtn.Click += TourDigifficeBtn_Click;
            // 
            // Homepage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(1904, 1041);
            Controls.Add(TourDigifficeBtn);
            Controls.Add(VersionLabel);
            Controls.Add(ProfileNameLabel);
            Controls.Add(PfpFramePanel);
            Controls.Add(Offlinemsg);
            Controls.Add(ProgramsPanel);
            Controls.Add(Homepanel);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Homepage";
            Text = "Digiffice Homepage - Version 0.1";
            WindowState = FormWindowState.Maximized;
            Homepanel.ResumeLayout(false);
            Homepanel.PerformLayout();
            ProgramsPanel.ResumeLayout(false);
            ProgramsPanel.PerformLayout();
            PfpFramePanel.ResumeLayout(false);
            PfpFramePfpOutlinePanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Welcomemsg;
        private Panel Homepanel;
        private Button ExitButton;
        private Panel ProgramsPanel;
        private Label ProgramsLabel;
        private Label Offlinemsg;
        private Panel PfpFramePanel;
        private Panel PfpFramePfpOutlinePanel;
        private Panel PfpFramePfpPanel;
        private Label ProfileNameLabel;
        private Label VersionLabel;
        private Button TourDigifficeBtn;
    }
}
