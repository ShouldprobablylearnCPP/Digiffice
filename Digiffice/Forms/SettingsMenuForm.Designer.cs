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
            SidePnl = new Panel();
            pfpPnl = new Panel();
            pfpFramePnl = new Panel();
            pfpImgPnl = new Panel();
            sidePnlBorder = new Panel();
            button1 = new Button();
            SidePnl.SuspendLayout();
            pfpPnl.SuspendLayout();
            pfpFramePnl.SuspendLayout();
            SuspendLayout();
            // 
            // SidePnl
            // 
            SidePnl.BackColor = SystemColors.ControlLightLight;
            SidePnl.Controls.Add(button1);
            SidePnl.Controls.Add(pfpPnl);
            SidePnl.Dock = DockStyle.Left;
            SidePnl.Location = new Point(0, 0);
            SidePnl.Name = "SidePnl";
            SidePnl.Size = new Size(120, 461);
            SidePnl.TabIndex = 0;
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
            sidePnlBorder.BackColor = Color.Navy;
            sidePnlBorder.Location = new Point(0, 0);
            sidePnlBorder.Name = "sidePnlBorder";
            sidePnlBorder.Size = new Size(121, 461);
            sidePnlBorder.TabIndex = 1;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(0, 119);
            button1.Name = "button1";
            button1.Size = new Size(120, 40);
            button1.TabIndex = 1;
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            // 
            // SettingsMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 461);
            Controls.Add(SidePnl);
            Controls.Add(sidePnlBorder);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsMenuForm";
            Text = "Settings";
            SidePnl.ResumeLayout(false);
            pfpPnl.ResumeLayout(false);
            pfpFramePnl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel SidePnl;
        private Panel pfpPnl;
        private Panel sidePnlBorder;
        private Panel pfpFramePnl;
        private Panel pfpImgPnl;
        private Button button1;
    }
}