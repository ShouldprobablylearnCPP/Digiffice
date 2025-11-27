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
            Welcomemsg = new Label();
            Homepanel = new Panel();
            ExitButton = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            Homepanel.SuspendLayout();
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
            Homepanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Homepanel.AutoSize = true;
            Homepanel.BackColor = SystemColors.ControlLight;
            Homepanel.BackgroundImage = Properties.Resources.Panel;
            Homepanel.BackgroundImageLayout = ImageLayout.Stretch;
            Homepanel.Controls.Add(ExitButton);
            Homepanel.Controls.Add(Welcomemsg);
            Homepanel.Location = new Point(0, 0);
            Homepanel.Name = "Homepanel";
            Homepanel.Size = new Size(1978, 59);
            Homepanel.TabIndex = 0;
            // 
            // ExitButton
            // 
            ExitButton.BackgroundImageLayout = ImageLayout.Stretch;
            ExitButton.FlatAppearance.BorderSize = 0;
            ExitButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 0, 0);
            ExitButton.FlatStyle = FlatStyle.Flat;
            ExitButton.Font = new Font("Roboto", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExitButton.ForeColor = SystemColors.ControlText;
            ExitButton.Image = Properties.Resources.Xbtn;
            ExitButton.Location = new Point(1825, 0);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(74, 24);
            ExitButton.TabIndex = 1;
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            ExitButton.MouseEnter += ExitButton_MouseEnter;
            ExitButton.MouseLeave += ExitButton_MouseLeave;
            // 
            // Homepage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(1904, 1041);
            Controls.Add(Homepanel);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "Homepage";
            Text = "Digiffice Homepage - Version 0.1";
            WindowState = FormWindowState.Maximized;
            Homepanel.ResumeLayout(false);
            Homepanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Welcomemsg;
        private Panel Homepanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button ExitButton;
    }
}
