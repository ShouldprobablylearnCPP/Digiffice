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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // Welcomemsg
            // 
            Welcomemsg.AutoSize = true;
            Welcomemsg.Font = new Font("Roboto", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Welcomemsg.Location = new Point(12, 9);
            Welcomemsg.Name = "Welcomemsg";
            Welcomemsg.Size = new Size(297, 35);
            Welcomemsg.TabIndex = 0;
            Welcomemsg.Text = "Welcome to Digiffice";
            // 
            // Homepanel
            // 
            Homepanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Homepanel.AutoSize = true;
            Homepanel.BackColor = SystemColors.ControlLight;
            Homepanel.Location = new Point(0, 0);
            Homepanel.Name = "Homepanel";
            Homepanel.Size = new Size(800, 75);
            Homepanel.TabIndex = 0;
            // 
            // Homepage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(800, 450);
            Controls.Add(Homepanel);
            Controls.Add(Welcomemsg);
            ForeColor = SystemColors.ControlText;
            Name = "Homepage";
            Text = "Digiffice Homepage - Version 0.1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Welcomemsg;
        private Panel Homepanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
