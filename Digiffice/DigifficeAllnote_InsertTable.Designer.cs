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
            ColsNumericUpDown = new Digiffice.Resources.Classes.ProgramClasses.CustomControls.ClassicNumericUpDown();
            RowsNumericUpDown = new Digiffice.Resources.Classes.ProgramClasses.CustomControls.ClassicNumericUpDown();
            NumRowsLabel = new Label();
            OKBtn = new Button();
            CancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)ColsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RowsNumericUpDown).BeginInit();
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
            // 
            // ColsNumericUpDown
            // 
            ColsNumericUpDown.Location = new Point(135, 6);
            ColsNumericUpDown.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            ColsNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ColsNumericUpDown.Name = "ColsNumericUpDown";
            ColsNumericUpDown.Size = new Size(33, 23);
            ColsNumericUpDown.TabIndex = 1;
            ColsNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // RowsNumericUpDown
            // 
            RowsNumericUpDown.Location = new Point(135, 35);
            RowsNumericUpDown.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            RowsNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RowsNumericUpDown.Name = "RowsNumericUpDown";
            RowsNumericUpDown.Size = new Size(33, 23);
            RowsNumericUpDown.TabIndex = 3;
            RowsNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // NumRowsLabel
            // 
            NumRowsLabel.AutoSize = true;
            NumRowsLabel.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NumRowsLabel.Location = new Point(12, 38);
            NumRowsLabel.Name = "NumRowsLabel";
            NumRowsLabel.Size = new Size(97, 14);
            NumRowsLabel.TabIndex = 2;
            NumRowsLabel.Text = "Number of Rows";
            // 
            // OKBtn
            // 
            OKBtn.FlatStyle = FlatStyle.System;
            OKBtn.Location = new Point(12, 172);
            OKBtn.Name = "OKBtn";
            OKBtn.Size = new Size(75, 23);
            OKBtn.TabIndex = 4;
            OKBtn.Text = "OK";
            OKBtn.UseVisualStyleBackColor = true;
            OKBtn.Click += OKBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.FlatStyle = FlatStyle.System;
            CancelBtn.Location = new Point(93, 172);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(75, 23);
            CancelBtn.TabIndex = 5;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // DigifficeAllnote_InsertTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(180, 207);
            Controls.Add(CancelBtn);
            Controls.Add(OKBtn);
            Controls.Add(RowsNumericUpDown);
            Controls.Add(NumRowsLabel);
            Controls.Add(ColsNumericUpDown);
            Controls.Add(NumColsLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(200, 250);
            MinimizeBox = false;
            Name = "DigifficeAllnote_InsertTable";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Insert Table";
            ((System.ComponentModel.ISupportInitialize)ColsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RowsNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NumColsLabel;
        private Resources.Classes.ProgramClasses.CustomControls.ClassicNumericUpDown ColsNumericUpDown;
        private Resources.Classes.ProgramClasses.CustomControls.ClassicNumericUpDown RowsNumericUpDown;
        private Label NumRowsLabel;
        private Button OKBtn;
        private Button CancelBtn;
    }
}