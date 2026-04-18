namespace Digiffice
{
    partial class DigifficePeercompute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DigifficePeercompute));
            Homepanel = new Panel();
            ExitButton = new Button();
            Windowmsg = new Label();
            DigifficeButton = new Button();
            PeercomputeLeftBarContainerPanel = new Panel();
            PeercomputeLeftBarPanel = new Panel();
            PeercomputesPanelBorder = new Panel();
            PeercomputesTab = new Panel();
            PeercomputesTabLabel = new Label();
            CurrentPeercomputeContainerPanel = new Panel();
            CurrentPeercomputeBorderPanel = new Panel();
            CurrentPeercomputeBackgroundPanel = new Panel();
            CurrentPeercomputeDataPanel = new Panel();
            Homepanel.SuspendLayout();
            PeercomputeLeftBarContainerPanel.SuspendLayout();
            PeercomputesTab.SuspendLayout();
            CurrentPeercomputeContainerPanel.SuspendLayout();
            CurrentPeercomputeBorderPanel.SuspendLayout();
            CurrentPeercomputeBackgroundPanel.SuspendLayout();
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
            Windowmsg.Text = "Digiffice Peercompute";
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
            // PeercomputeLeftBarContainerPanel
            // 
            PeercomputeLeftBarContainerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            PeercomputeLeftBarContainerPanel.BackColor = Color.Transparent;
            PeercomputeLeftBarContainerPanel.Controls.Add(PeercomputeLeftBarPanel);
            PeercomputeLeftBarContainerPanel.Controls.Add(PeercomputesPanelBorder);
            PeercomputeLeftBarContainerPanel.Controls.Add(PeercomputesTab);
            PeercomputeLeftBarContainerPanel.Location = new Point(12, 99);
            PeercomputeLeftBarContainerPanel.Name = "PeercomputeLeftBarContainerPanel";
            PeercomputeLeftBarContainerPanel.Size = new Size(370, 969);
            PeercomputeLeftBarContainerPanel.TabIndex = 5;
            // 
            // PeercomputeLeftBarPanel
            // 
            PeercomputeLeftBarPanel.BackColor = SystemColors.Control;
            PeercomputeLeftBarPanel.Location = new Point(1, 41);
            PeercomputeLeftBarPanel.Name = "PeercomputeLeftBarPanel";
            PeercomputeLeftBarPanel.Size = new Size(369, 927);
            PeercomputeLeftBarPanel.TabIndex = 0;
            // 
            // PeercomputesPanelBorder
            // 
            PeercomputesPanelBorder.BackColor = Color.Navy;
            PeercomputesPanelBorder.Location = new Point(0, 40);
            PeercomputesPanelBorder.Name = "PeercomputesPanelBorder";
            PeercomputesPanelBorder.Size = new Size(370, 929);
            PeercomputesPanelBorder.TabIndex = 1;
            // 
            // PeercomputesTab
            // 
            PeercomputesTab.BackColor = Color.Transparent;
            PeercomputesTab.BackgroundImage = Properties.Resources.NavyTab_100x40_1080p;
            PeercomputesTab.Controls.Add(PeercomputesTabLabel);
            PeercomputesTab.Cursor = Cursors.Hand;
            PeercomputesTab.Location = new Point(0, 10);
            PeercomputesTab.Name = "PeercomputesTab";
            PeercomputesTab.Size = new Size(100, 40);
            PeercomputesTab.TabIndex = 2;
            PeercomputesTab.Click += PeercomputesTab_Click;
            // 
            // PeercomputesTabLabel
            // 
            PeercomputesTabLabel.AutoSize = true;
            PeercomputesTabLabel.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PeercomputesTabLabel.ForeColor = Color.White;
            PeercomputesTabLabel.Location = new Point(10, 2);
            PeercomputesTabLabel.Name = "PeercomputesTabLabel";
            PeercomputesTabLabel.Size = new Size(79, 14);
            PeercomputesTabLabel.TabIndex = 0;
            PeercomputesTabLabel.Text = "Peercomputes";
            PeercomputesTabLabel.Click += PeercomputesTab_Click;
            PeercomputesTabLabel.Paint += PeercomputesTabLabel_Paint;
            // 
            // CurrentPeercomputeContainerPanel
            // 
            CurrentPeercomputeContainerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            CurrentPeercomputeContainerPanel.BackColor = Color.Transparent;
            CurrentPeercomputeContainerPanel.Controls.Add(CurrentPeercomputeBorderPanel);
            CurrentPeercomputeContainerPanel.Location = new Point(425, 139);
            CurrentPeercomputeContainerPanel.Name = "CurrentPeercomputeContainerPanel";
            CurrentPeercomputeContainerPanel.RightToLeft = RightToLeft.No;
            CurrentPeercomputeContainerPanel.Size = new Size(1483, 669);
            CurrentPeercomputeContainerPanel.TabIndex = 6;
            // 
            // CurrentPeercomputeBorderPanel
            // 
            CurrentPeercomputeBorderPanel.BackColor = Color.Navy;
            CurrentPeercomputeBorderPanel.Controls.Add(CurrentPeercomputeBackgroundPanel);
            CurrentPeercomputeBorderPanel.Dock = DockStyle.Fill;
            CurrentPeercomputeBorderPanel.Location = new Point(0, 0);
            CurrentPeercomputeBorderPanel.Name = "CurrentPeercomputeBorderPanel";
            CurrentPeercomputeBorderPanel.Size = new Size(1483, 669);
            CurrentPeercomputeBorderPanel.TabIndex = 0;
            // 
            // CurrentPeercomputeBackgroundPanel
            // 
            CurrentPeercomputeBackgroundPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CurrentPeercomputeBackgroundPanel.BackColor = SystemColors.Control;
            CurrentPeercomputeBackgroundPanel.Controls.Add(CurrentPeercomputeDataPanel);
            CurrentPeercomputeBackgroundPanel.Location = new Point(1, 1);
            CurrentPeercomputeBackgroundPanel.Name = "CurrentPeercomputeBackgroundPanel";
            CurrentPeercomputeBackgroundPanel.Size = new Size(1481, 667);
            CurrentPeercomputeBackgroundPanel.TabIndex = 0;
            // 
            // CurrentPeercomputeDataPanel
            // 
            CurrentPeercomputeDataPanel.Location = new Point(12, 54);
            CurrentPeercomputeDataPanel.Name = "CurrentPeercomputeDataPanel";
            CurrentPeercomputeDataPanel.Size = new Size(1457, 601);
            CurrentPeercomputeDataPanel.TabIndex = 0;
            // 
            // DigifficePeercompute
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.DigifficeAppBG;
            ClientSize = new Size(1920, 1080);
            Controls.Add(CurrentPeercomputeContainerPanel);
            Controls.Add(PeercomputeLeftBarContainerPanel);
            Controls.Add(DigifficeButton);
            Controls.Add(Homepanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DigifficePeercompute";
            Text = "DigifficePeercompute";
            Resize += DigifficePeercompute_Resize;
            Homepanel.ResumeLayout(false);
            Homepanel.PerformLayout();
            PeercomputeLeftBarContainerPanel.ResumeLayout(false);
            PeercomputesTab.ResumeLayout(false);
            PeercomputesTab.PerformLayout();
            CurrentPeercomputeContainerPanel.ResumeLayout(false);
            CurrentPeercomputeBorderPanel.ResumeLayout(false);
            CurrentPeercomputeBackgroundPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Homepanel;
        private Button ExitButton;
        private Label Windowmsg;
        private Button DigifficeButton;
        private Panel PeercomputeLeftBarContainerPanel;
        private Panel PeercomputeLeftBarPanel;
        private Panel PeercomputesPanelBorder;
        private Panel PeercomputesTab;
        private Label PeercomputesTabLabel;
        private Panel CurrentPeercomputeContainerPanel;
        private Panel CurrentPeercomputeBorderPanel;
        private Panel CurrentPeercomputeBackgroundPanel;
        private Panel CurrentPeercomputeDataPanel;
    }
}