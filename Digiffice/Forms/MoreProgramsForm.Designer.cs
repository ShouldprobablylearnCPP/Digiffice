namespace Digiffice
{
    partial class MoreProgramsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoreProgramsForm));
            label1 = new Label();
            PostItsOpenBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Roboto", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(179, 29);
            label1.TabIndex = 0;
            label1.Text = "More Programs";
            // 
            // PostItsOpenBtn
            // 
            PostItsOpenBtn.BackColor = Color.FromArgb(60, 255, 255, 255);
            PostItsOpenBtn.BackgroundImage = Properties.Resources.Post_itsButton1;
            PostItsOpenBtn.Cursor = Cursors.Hand;
            PostItsOpenBtn.FlatAppearance.BorderSize = 0;
            PostItsOpenBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 255, 255, 255);
            PostItsOpenBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 255, 255, 255);
            PostItsOpenBtn.FlatStyle = FlatStyle.Flat;
            PostItsOpenBtn.Location = new Point(12, 41);
            PostItsOpenBtn.Name = "PostItsOpenBtn";
            PostItsOpenBtn.Size = new Size(250, 40);
            PostItsOpenBtn.TabIndex = 1;
            PostItsOpenBtn.UseVisualStyleBackColor = false;
            PostItsOpenBtn.Click += PostItsOpenBtn_Click;
            // 
            // MoreProgramsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.SimpleBG400x600;
            ClientSize = new Size(384, 561);
            Controls.Add(PostItsOpenBtn);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MoreProgramsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "More Programs";
            Load += MoreProgramsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button PostItsOpenBtn;
    }
}