namespace Digiffice
{
    partial class Login
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
            labelCreateAccount = new Label();
            labelDontHaveAnAccount = new Label();
            btnClear = new Button();
            btnLogin = new Button();
            ShowPasswordCheckbox = new CheckBox();
            txtPasswordlogin = new TextBox();
            PasswordLabel = new Label();
            txtUsernamelogin = new TextBox();
            UsernameLabel = new Label();
            LoginHeader = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // labelCreateAccount
            // 
            labelCreateAccount.AutoSize = true;
            labelCreateAccount.BackColor = Color.Transparent;
            labelCreateAccount.Cursor = Cursors.Hand;
            labelCreateAccount.Font = new Font("Arial Black", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            labelCreateAccount.ForeColor = Color.FromArgb(0, 146, 214);
            labelCreateAccount.Location = new Point(33, 445);
            labelCreateAccount.Name = "labelCreateAccount";
            labelCreateAccount.Size = new Size(109, 17);
            labelCreateAccount.TabIndex = 23;
            labelCreateAccount.Text = "Create Account";
            labelCreateAccount.Click += labelCreateAccount_Click;
            // 
            // labelDontHaveAnAccount
            // 
            labelDontHaveAnAccount.AutoSize = true;
            labelDontHaveAnAccount.BackColor = Color.Transparent;
            labelDontHaveAnAccount.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDontHaveAnAccount.Location = new Point(33, 421);
            labelDontHaveAnAccount.Name = "labelDontHaveAnAccount";
            labelDontHaveAnAccount.Size = new Size(173, 16);
            labelDontHaveAnAccount.TabIndex = 22;
            labelDontHaveAnAccount.Text = "Don't Have An Account?";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.FromArgb(0, 146, 214);
            btnClear.Location = new Point(33, 370);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(216, 35);
            btnClear.TabIndex = 21;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 146, 214);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Arial Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(33, 329);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(216, 35);
            btnLogin.TabIndex = 20;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // ShowPasswordCheckbox
            // 
            ShowPasswordCheckbox.AutoSize = true;
            ShowPasswordCheckbox.BackColor = Color.Transparent;
            ShowPasswordCheckbox.Cursor = Cursors.Hand;
            ShowPasswordCheckbox.FlatStyle = FlatStyle.Flat;
            ShowPasswordCheckbox.Font = new Font("Arial Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowPasswordCheckbox.Location = new Point(117, 290);
            ShowPasswordCheckbox.Name = "ShowPasswordCheckbox";
            ShowPasswordCheckbox.Size = new Size(137, 22);
            ShowPasswordCheckbox.TabIndex = 19;
            ShowPasswordCheckbox.Text = "Show Password";
            ShowPasswordCheckbox.UseVisualStyleBackColor = false;
            ShowPasswordCheckbox.CheckedChanged += ShowPasswordCheckbox_CheckedChanged;
            // 
            // txtPasswordlogin
            // 
            txtPasswordlogin.BackColor = Color.FromArgb(230, 231, 233);
            txtPasswordlogin.BorderStyle = BorderStyle.None;
            txtPasswordlogin.Font = new Font("MS UI Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPasswordlogin.Location = new Point(32, 244);
            txtPasswordlogin.Multiline = true;
            txtPasswordlogin.Name = "txtPasswordlogin";
            txtPasswordlogin.PasswordChar = '*';
            txtPasswordlogin.Size = new Size(216, 28);
            txtPasswordlogin.TabIndex = 16;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.BackColor = Color.Transparent;
            PasswordLabel.Location = new Point(32, 224);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(66, 17);
            PasswordLabel.TabIndex = 15;
            PasswordLabel.Text = "Password";
            // 
            // txtUsernamelogin
            // 
            txtUsernamelogin.BackColor = Color.FromArgb(230, 231, 233);
            txtUsernamelogin.BorderStyle = BorderStyle.None;
            txtUsernamelogin.Font = new Font("MS UI Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsernamelogin.Location = new Point(32, 177);
            txtUsernamelogin.Multiline = true;
            txtUsernamelogin.Name = "txtUsernamelogin";
            txtUsernamelogin.Size = new Size(216, 28);
            txtUsernamelogin.TabIndex = 14;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.BackColor = Color.Transparent;
            UsernameLabel.Location = new Point(32, 157);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(69, 17);
            UsernameLabel.TabIndex = 13;
            UsernameLabel.Text = "Username";
            // 
            // LoginHeader
            // 
            LoginHeader.AutoSize = true;
            LoginHeader.BackColor = Color.Transparent;
            LoginHeader.Font = new Font("Arial Black", 16F, FontStyle.Bold);
            LoginHeader.ForeColor = Color.FromArgb(0, 146, 214);
            LoginHeader.Location = new Point(32, 95);
            LoginHeader.Name = "LoginHeader";
            LoginHeader.Size = new Size(222, 31);
            LoginHeader.TabIndex = 12;
            LoginHeader.Text = "Login to Digiffice";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Black", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 146, 214);
            label1.Location = new Point(77, 54);
            label1.Name = "label1";
            label1.Size = new Size(131, 31);
            label1.TabIndex = 24;
            label1.Text = "Welcome!";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.LoginBackground_PNG_resized;
            ClientSize = new Size(285, 508);
            Controls.Add(label1);
            Controls.Add(labelCreateAccount);
            Controls.Add(labelDontHaveAnAccount);
            Controls.Add(btnClear);
            Controls.Add(btnLogin);
            Controls.Add(ShowPasswordCheckbox);
            Controls.Add(txtPasswordlogin);
            Controls.Add(PasswordLabel);
            Controls.Add(txtUsernamelogin);
            Controls.Add(UsernameLabel);
            Controls.Add(LoginHeader);
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCreateAccount;
        private Label labelDontHaveAnAccount;
        private Button btnClear;
        private Button btnLogin;
        private CheckBox ShowPasswordCheckbox;
        private TextBox txtPasswordlogin;
        private Label PasswordLabel;
        private TextBox txtUsernamelogin;
        private Label UsernameLabel;
        private Label LoginHeader;
        private Label label1;
    }
}