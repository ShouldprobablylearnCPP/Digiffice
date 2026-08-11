namespace Digiffice
{
    partial class EnterTextValueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterTextValueForm));
            enterTextBox = new TextBox();
            Label = new Label();
            enterBtn = new Button();
            SuspendLayout();
            // 
            // enterTextBox
            // 
            enterTextBox.Location = new Point(2, 35);
            enterTextBox.Name = "enterTextBox";
            enterTextBox.Size = new Size(300, 23);
            enterTextBox.TabIndex = 0;
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label.Location = new Point(2, 9);
            Label.Name = "Label";
            Label.Size = new Size(55, 14);
            Label.TabIndex = 1;
            Label.Text = "PROMPT";
            // 
            // enterBtn
            // 
            enterBtn.Location = new Point(2, 64);
            enterBtn.Name = "enterBtn";
            enterBtn.Size = new Size(75, 23);
            enterBtn.TabIndex = 2;
            enterBtn.Text = "Enter";
            enterBtn.UseVisualStyleBackColor = true;
            enterBtn.Click += enterBtn_Click;
            // 
            // EnterTextValueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 91);
            Controls.Add(enterBtn);
            Controls.Add(Label);
            Controls.Add(enterTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EnterTextValueForm";
            Text = "Enter Text";
            Load += EnterTextValueForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox enterTextBox;
        private Label Label;
        private Button enterBtn;
    }
}