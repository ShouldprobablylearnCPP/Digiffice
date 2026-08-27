namespace Digiffice.Resources.Classes.ProgramClasses.Idlebars
{
    partial class NewsIdlebar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TopStoryPnl = new Panel();
            TopStoryLbl = new Label();
            TopStoryPnlBorder = new Panel();
            TopStoryPnl.SuspendLayout();
            TopStoryPnlBorder.SuspendLayout();
            SuspendLayout();
            // 
            // TopStoryPnl
            // 
            TopStoryPnl.BackColor = Color.Transparent;
            TopStoryPnl.BackgroundImageLayout = ImageLayout.Stretch;
            TopStoryPnl.Controls.Add(TopStoryLbl);
            TopStoryPnl.Location = new Point(1, 1);
            TopStoryPnl.Name = "TopStoryPnl";
            TopStoryPnl.Size = new Size(188, 148);
            TopStoryPnl.TabIndex = 0;
            // 
            // TopStoryLbl
            // 
            TopStoryLbl.AutoSize = true;
            TopStoryLbl.Dock = DockStyle.Bottom;
            TopStoryLbl.Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TopStoryLbl.ForeColor = Color.White;
            TopStoryLbl.Location = new Point(0, 133);
            TopStoryLbl.Name = "TopStoryLbl";
            TopStoryLbl.Size = new Size(127, 15);
            TopStoryLbl.TabIndex = 0;
            TopStoryLbl.Text = "Top Digiffice Story";
            // 
            // TopStoryPnlBorder
            // 
            TopStoryPnlBorder.BackColor = Color.Navy;
            TopStoryPnlBorder.Controls.Add(TopStoryPnl);
            TopStoryPnlBorder.Location = new Point(5, 5);
            TopStoryPnlBorder.Name = "TopStoryPnlBorder";
            TopStoryPnlBorder.Size = new Size(190, 150);
            TopStoryPnlBorder.TabIndex = 1;
            // 
            // NewsIdlebar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(TopStoryPnlBorder);
            Name = "NewsIdlebar";
            Size = new Size(200, 823);
            Load += NewsIdlebar_Load;
            TopStoryPnl.ResumeLayout(false);
            TopStoryPnl.PerformLayout();
            TopStoryPnlBorder.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel TopStoryPnl;
        private Label TopStoryLbl;
        private Panel TopStoryPnlBorder;
    }
}
