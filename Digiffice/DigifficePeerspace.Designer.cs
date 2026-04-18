namespace Digiffice
{
    partial class DigifficePeerspace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DigifficePeerspace));
            Homepanel = new Panel();
            ExitButton = new Button();
            Windowmsg = new Label();
            DigifficeButton = new Button();
            PeerspaceLeftBarContainerPanel = new Panel();
            PeerspaceLeftBarPanel = new Panel();
            PeerspacesPanelBorder = new Panel();
            PeerspacesTab = new Panel();
            PeerspacesTabLabel = new Label();
            CurrentPeerspaceContainerPanel = new Panel();
            CurrentPeerspaceBorderPanel = new Panel();
            CurrentPeerspaceBackgroundPanel = new Panel();
            CurrentPeerspaceDataPanel = new Panel();
            Homepanel.SuspendLayout();
            PeerspaceLeftBarContainerPanel.SuspendLayout();
            PeerspacesTab.SuspendLayout();
            CurrentPeerspaceContainerPanel.SuspendLayout();
            CurrentPeerspaceBorderPanel.SuspendLayout();
            CurrentPeerspaceBackgroundPanel.SuspendLayout();
            SuspendLayout();
            // 
            // Homepanel
            // 
            Homepanel.BackColor = SystemColors.ControlLight;
            Homepanel.BackgroundImage = Properties.Resources.Panel;
            Homepanel.BackgroundImageLayout = ImageLayout.Stretch;
            Homepanel.Controls.Add(ExitButton);
            Homepanel.Controls.Add(Windowmsg);
            Homepanel.Dock = DockStyle.Top;
            Homepanel.Location = new Point(0, 0);
            Homepanel.Name = "Homepanel";
            Homepanel.Size = new Size(1920, 59);
            Homepanel.TabIndex = 2;
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
            // Windowmsg
            // 
            Windowmsg.AutoSize = true;
            Windowmsg.BackColor = Color.Transparent;
            Windowmsg.Font = new Font("Roboto", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Windowmsg.Location = new Point(852, 15);
            Windowmsg.Name = "Windowmsg";
            Windowmsg.Size = new Size(219, 29);
            Windowmsg.TabIndex = 0;
            Windowmsg.Text = "Digiffice Peerspace";
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
            DigifficeButton.TabIndex = 4;
            DigifficeButton.Text = "Return to Digiffice";
            DigifficeButton.UseVisualStyleBackColor = true;
            DigifficeButton.Click += DigifficeButton_Click;
            // 
            // PeerspaceLeftBarContainerPanel
            // 
            PeerspaceLeftBarContainerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            PeerspaceLeftBarContainerPanel.BackColor = Color.Transparent;
            PeerspaceLeftBarContainerPanel.Controls.Add(PeerspaceLeftBarPanel);
            PeerspaceLeftBarContainerPanel.Controls.Add(PeerspacesPanelBorder);
            PeerspaceLeftBarContainerPanel.Controls.Add(PeerspacesTab);
            PeerspaceLeftBarContainerPanel.Location = new Point(12, 99);
            PeerspaceLeftBarContainerPanel.Name = "PeerspaceLeftBarContainerPanel";
            PeerspaceLeftBarContainerPanel.Size = new Size(370, 969);
            PeerspaceLeftBarContainerPanel.TabIndex = 5;
            // 
            // PeerspaceLeftBarPanel
            // 
            PeerspaceLeftBarPanel.BackColor = SystemColors.Control;
            PeerspaceLeftBarPanel.Location = new Point(1, 41);
            PeerspaceLeftBarPanel.Name = "PeerspaceLeftBarPanel";
            PeerspaceLeftBarPanel.Size = new Size(369, 927);
            PeerspaceLeftBarPanel.TabIndex = 0;
            // 
            // PeerspacesPanelBorder
            // 
            PeerspacesPanelBorder.BackColor = Color.Navy;
            PeerspacesPanelBorder.Location = new Point(0, 40);
            PeerspacesPanelBorder.Name = "PeerspacesPanelBorder";
            PeerspacesPanelBorder.Size = new Size(370, 929);
            PeerspacesPanelBorder.TabIndex = 1;
            // 
            // PeerspacesTab
            // 
            PeerspacesTab.BackColor = Color.Transparent;
            PeerspacesTab.BackgroundImage = Properties.Resources.NavyTab_100x40_1080p;
            PeerspacesTab.Controls.Add(PeerspacesTabLabel);
            PeerspacesTab.Cursor = Cursors.Hand;
            PeerspacesTab.Location = new Point(0, 10);
            PeerspacesTab.Name = "PeerspacesTab";
            PeerspacesTab.Size = new Size(100, 40);
            PeerspacesTab.TabIndex = 2;
            PeerspacesTab.Click += PeerspacesTab_Click;
            // 
            // PeerspacesTabLabel
            // 
            PeerspacesTabLabel.AutoSize = true;
            PeerspacesTabLabel.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PeerspacesTabLabel.ForeColor = Color.White;
            PeerspacesTabLabel.Location = new Point(10, 2);
            PeerspacesTabLabel.Name = "PeerspacesTabLabel";
            PeerspacesTabLabel.Size = new Size(79, 14);
            PeerspacesTabLabel.TabIndex = 0;
            PeerspacesTabLabel.Text = "Peerspaces";
            PeerspacesTabLabel.Click += PeerspacesTab_Click;
            PeerspacesTabLabel.Paint += PeerspacesTabLabel_Paint;
            // 
            // CurrentPeerspaceContainerPanel
            // 
            CurrentPeerspaceContainerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            CurrentPeerspaceContainerPanel.BackColor = Color.Transparent;
            CurrentPeerspaceContainerPanel.Controls.Add(CurrentPeerspaceBorderPanel);
            CurrentPeerspaceContainerPanel.Location = new Point(425, 139);
            CurrentPeerspaceContainerPanel.Name = "CurrentPeerspaceContainerPanel";
            CurrentPeerspaceContainerPanel.RightToLeft = RightToLeft.No;
            CurrentPeerspaceContainerPanel.Size = new Size(1483, 669);
            CurrentPeerspaceContainerPanel.TabIndex = 6;
            // 
            // CurrentPeerspaceBorderPanel
            // 
            CurrentPeerspaceBorderPanel.BackColor = Color.Navy;
            CurrentPeerspaceBorderPanel.Controls.Add(CurrentPeerspaceBackgroundPanel);
            CurrentPeerspaceBorderPanel.Dock = DockStyle.Fill;
            CurrentPeerspaceBorderPanel.Location = new Point(0, 0);
            CurrentPeerspaceBorderPanel.Name = "CurrentPeerspaceBorderPanel";
            CurrentPeerspaceBorderPanel.Size = new Size(1483, 669);
            CurrentPeerspaceBorderPanel.TabIndex = 0;
            // 
            // CurrentPeerspaceBackgroundPanel
            // 
            CurrentPeerspaceBackgroundPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CurrentPeerspaceBackgroundPanel.BackColor = SystemColors.Control;
            CurrentPeerspaceBackgroundPanel.Controls.Add(CurrentPeerspaceDataPanel);
            CurrentPeerspaceBackgroundPanel.Location = new Point(1, 1);
            CurrentPeerspaceBackgroundPanel.Name = "CurrentPeerspaceBackgroundPanel";
            CurrentPeerspaceBackgroundPanel.Size = new Size(1481, 667);
            CurrentPeerspaceBackgroundPanel.TabIndex = 0;
            // 
            // CurrentPeerspaceDataPanel
            // 
            CurrentPeerspaceDataPanel.Location = new Point(12, 54);
            CurrentPeerspaceDataPanel.Name = "CurrentPeerspaceDataPanel";
            CurrentPeerspaceDataPanel.Size = new Size(1457, 601);
            CurrentPeerspaceDataPanel.TabIndex = 0;
            // 
            // DigifficePeerspace
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.DigifficeAppBG;
            ClientSize = new Size(1920, 1080);
            Controls.Add(CurrentPeerspaceContainerPanel);
            Controls.Add(PeerspaceLeftBarContainerPanel);
            Controls.Add(DigifficeButton);
            Controls.Add(Homepanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DigifficePeerspace";
            Text = "DigifficePeerspace";
            Resize += DigifficePeerspace_Resize;
            Homepanel.ResumeLayout(false);
            Homepanel.PerformLayout();
            PeerspaceLeftBarContainerPanel.ResumeLayout(false);
            PeerspacesTab.ResumeLayout(false);
            PeerspacesTab.PerformLayout();
            CurrentPeerspaceContainerPanel.ResumeLayout(false);
            CurrentPeerspaceBorderPanel.ResumeLayout(false);
            CurrentPeerspaceBackgroundPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Homepanel;
        private Button ExitButton;
        private Label Windowmsg;
        private Button DigifficeButton;
        private Panel PeerspaceLeftBarContainerPanel;
        private Panel PeerspaceLeftBarPanel;
        private Panel PeerspacesPanelBorder;
        private Panel PeerspacesTab;
        private Label PeerspacesTabLabel;
        private Panel CurrentPeerspaceContainerPanel;
        private Panel CurrentPeerspaceBorderPanel;
        private Panel CurrentPeerspaceBackgroundPanel;
        private Panel CurrentPeerspaceDataPanel;
    }
}