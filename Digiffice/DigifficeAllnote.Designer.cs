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
            SectionSelectionPanel = new Panel();
            FileTab = new Button();
            Homepanel.SuspendLayout();
            SectionSelectionPanel.SuspendLayout();
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
            Windowmsg.Font = new Font("Roboto", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Windowmsg.Location = new Point(852, 12);
            Windowmsg.Name = "Windowmsg";
            Windowmsg.Size = new Size(216, 35);
            Windowmsg.TabIndex = 0;
            Windowmsg.Text = "Digiffice Allnote";
            Windowmsg.TextAlign = ContentAlignment.MiddleCenter;
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
            // SectionSelectionPanel
            // 
            SectionSelectionPanel.BackColor = SystemColors.GradientActiveCaption;
            SectionSelectionPanel.Controls.Add(FileTab);
            SectionSelectionPanel.ForeColor = SystemColors.ActiveCaptionText;
            SectionSelectionPanel.Location = new Point(0, 59);
            SectionSelectionPanel.Name = "SectionSelectionPanel";
            SectionSelectionPanel.Size = new Size(1920, 40);
            SectionSelectionPanel.TabIndex = 2;
            // 
            // FileTab
            // 
            FileTab.BackColor = Color.Transparent;
            FileTab.FlatAppearance.BorderSize = 0;
            FileTab.FlatAppearance.MouseDownBackColor = Color.Transparent;
            FileTab.FlatAppearance.MouseOverBackColor = Color.Transparent;
            FileTab.FlatStyle = FlatStyle.Flat;
            FileTab.Font = new Font("Roboto", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FileTab.Location = new Point(100, 8);
            FileTab.Name = "FileTab";
            FileTab.Size = new Size(75, 30);
            FileTab.TabIndex = 0;
            FileTab.Text = "File";
            FileTab.UseVisualStyleBackColor = false;
            // 
            // DigifficeAllnote
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.DigifficeAppBG;
            ClientSize = new Size(1920, 1080);
            Controls.Add(DigifficeButton);
            Controls.Add(SectionSelectionPanel);
            Controls.Add(Homepanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DigifficeAllnote";
            Text = "DigifficeAllpad";
            Homepanel.ResumeLayout(false);
            Homepanel.PerformLayout();
            SectionSelectionPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Homepanel;
        private Button ExitButton;
        private Label Windowmsg;
        private Panel SectionSelectionPanel;
        private Button DigifficeButton;
        private Button FileTab;
    }
}