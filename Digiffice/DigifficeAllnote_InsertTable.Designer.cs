namespace Digiffice
{
    partial class DigifficeAllnote_InsertTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DigifficeAllnote_InsertTable));
            NumColsLabel = new Label();
            classicNumericUpDown1 = new Digiffice.Resources.Classes.ProgramClasses.CustomControls.ClassicNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)classicNumericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // NumColsLabel
            // 
            NumColsLabel.AutoSize = true;
            NumColsLabel.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NumColsLabel.Location = new Point(12, 9);
            NumColsLabel.Name = "NumColsLabel";
            NumColsLabel.Size = new Size(117, 14);
            NumColsLabel.TabIndex = 0;
            NumColsLabel.Text = "Number of Columns";
            NumColsLabel.Paint += NumColsLabel_Paint;
            // 
            // classicNumericUpDown1
            // 
            classicNumericUpDown1.Location = new Point(135, 6);
            classicNumericUpDown1.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            classicNumericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            classicNumericUpDown1.Name = "classicNumericUpDown1";
            classicNumericUpDown1.Size = new Size(33, 23);
            classicNumericUpDown1.TabIndex = 1;
            classicNumericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DigifficeAllnote_InsertTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(180, 207);
            Controls.Add(classicNumericUpDown1);
            Controls.Add(NumColsLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(200, 250);
            MinimizeBox = false;
            Name = "DigifficeAllnote_InsertTable";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Insert Table";
            ((System.ComponentModel.ISupportInitialize)classicNumericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NumColsLabel;
        private Resources.Classes.ProgramClasses.CustomControls.ClassicNumericUpDown classicNumericUpDown1;
    }
}