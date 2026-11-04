namespace Digiffice
{
    partial class SettingsMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsMenuForm));
            userSettingsBtn = new Button();
            pfpPnl = new Panel();
            pfpFramePnl = new Panel();
            pfpImgPnl = new Panel();
            sidePnlBorder = new Panel();
            SidePnl = new Panel();
            themeSettingsBtn = new Button();
            pfpPnl.SuspendLayout();
            pfpFramePnl.SuspendLayout();
            SidePnl.SuspendLayout();
            SuspendLayout();
            // 
            // userSettingsBtn
            // 
            userSettingsBtn.FlatAppearance.BorderSize = 0;
            userSettingsBtn.FlatStyle = FlatStyle.Flat;
            userSettingsBtn.Location = new Point(0, 119);
            userSettingsBtn.Name = "userSettingsBtn";
            userSettingsBtn.Size = new Size(120, 40);
            userSettingsBtn.TabIndex = 1;
            userSettingsBtn.TextAlign = ContentAlignment.MiddleRight;
            userSettingsBtn.UseVisualStyleBackColor = true;
            userSettingsBtn.Click += userSettingsBtn_Click;
            // 
            // pfpPnl
            // 
            pfpPnl.BackColor = Color.Transparent;
            pfpPnl.BackgroundImage = Properties.Resources.DigifficePfpFrame150x150;
            pfpPnl.BackgroundImageLayout = ImageLayout.Zoom;
            pfpPnl.Controls.Add(pfpFramePnl);
            pfpPnl.Location = new Point(0, 0);
            pfpPnl.Name = "pfpPnl";
            pfpPnl.Size = new Size(120, 120);
            pfpPnl.TabIndex = 0;
            // 
            // pfpFramePnl
            // 
            pfpFramePnl.BackgroundImage = Properties.Resources._150x150PfpFramePfpOutline;
            pfpFramePnl.BackgroundImageLayout = ImageLayout.Stretch;
            pfpFramePnl.Controls.Add(pfpImgPnl);
            pfpFramePnl.Dock = DockStyle.Fill;
            pfpFramePnl.Location = new Point(0, 0);
            pfpFramePnl.Name = "pfpFramePnl";
            pfpFramePnl.Size = new Size(120, 120);
            pfpFramePnl.TabIndex = 0;
            // 
            // pfpImgPnl
            // 
            pfpImgPnl.Location = new Point(12, 12);
            pfpImgPnl.Name = "pfpImgPnl";
            pfpImgPnl.Size = new Size(96, 96);
            pfpImgPnl.TabIndex = 0;
            // 
            // sidePnlBorder
            // 
            sidePnlBorder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            sidePnlBorder.BackColor = Color.Navy;
            sidePnlBorder.Location = new Point(120, 0);
            sidePnlBorder.Name = "sidePnlBorder";
            sidePnlBorder.Size = new Size(1, 461);
            sidePnlBorder.TabIndex = 1;
            // 
            // SidePnl
            // 
            SidePnl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            SidePnl.BackColor = SystemColors.ControlLightLight;
            SidePnl.Controls.Add(themeSettingsBtn);
            SidePnl.Controls.Add(userSettingsBtn);
            SidePnl.Controls.Add(pfpPnl);
            SidePnl.Controls.Add(sidePnlBorder);
            SidePnl.Location = new Point(0, 0);
            SidePnl.Name = "SidePnl";
            SidePnl.Size = new Size(121, 461);
            SidePnl.TabIndex = 0;
            // 
            // themeSettingsBtn
            // 
            themeSettingsBtn.FlatAppearance.BorderSize = 0;
            themeSettingsBtn.FlatStyle = FlatStyle.Flat;
            themeSettingsBtn.Location = new Point(0, 156);
            themeSettingsBtn.Name = "themeSettingsBtn";
            themeSettingsBtn.Size = new Size(120, 40);
            themeSettingsBtn.TabIndex = 2;
            themeSettingsBtn.TextAlign = ContentAlignment.MiddleRight;
            themeSettingsBtn.UseVisualStyleBackColor = true;
            themeSettingsBtn.Click += themeSettingsBtn_Click;
            // 
            // SettingsMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 461);
            Controls.Add(SidePnl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsMenuForm";
            Text = "Settings";
            pfpPnl.ResumeLayout(false);
            pfpFramePnl.ResumeLayout(false);
            SidePnl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pfpPnl;
        private Panel sidePnlBorder;
        private Panel pfpFramePnl;
        private Panel pfpImgPnl;
        private Button userSettingsBtn;
        private Panel SidePnl;
        private Button themeSettingsBtn;
    }
}