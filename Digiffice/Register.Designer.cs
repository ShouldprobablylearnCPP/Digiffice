namespace Digiffice
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            LoginHeader = new Label();
            UsernameLabel = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            PasswordLabel = new Label();
            txtConfirmPassword = new TextBox();
            confirmPasswordLabel = new Label();
            ShowPasswordCheckbox = new CheckBox();
            btnRegister = new Button();
            btnClear = new Button();
            labelAlreadyHaveAnAccount = new Label();
            labelBackToLogin = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // LoginHeader
            // 
            LoginHeader.AutoSize = true;
            LoginHeader.BackColor = Color.Transparent;
            LoginHeader.Font = new Font("Arial Black", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginHeader.ForeColor = Color.FromArgb(0, 146, 214);
            LoginHeader.Location = new Point(23, 63);
            LoginHeader.Name = "LoginHeader";
            LoginHeader.Size = new Size(240, 28);
            LoginHeader.TabIndex = 0;
            LoginHeader.Text = "Register for Digiffice";
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.BackColor = Color.Transparent;
            UsernameLabel.Location = new Point(34, 104);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(69, 17);
            UsernameLabel.TabIndex = 1;
            UsernameLabel.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(230, 231, 233);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("MS UI Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(34, 124);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(216, 28);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(230, 231, 233);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("MS UI Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(34, 191);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(216, 28);
            txtPassword.TabIndex = 4;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.BackColor = Color.Transparent;
            PasswordLabel.Location = new Point(34, 171);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(66, 17);
            PasswordLabel.TabIndex = 3;
            PasswordLabel.Text = "Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.FromArgb(230, 231, 233);
            txtConfirmPassword.BorderStyle = BorderStyle.None;
            txtConfirmPassword.Font = new Font("MS UI Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(34, 265);
            txtConfirmPassword.Multiline = true;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(216, 28);
            txtConfirmPassword.TabIndex = 6;
            // 
            // confirmPasswordLabel
            // 
            confirmPasswordLabel.AutoSize = true;
            confirmPasswordLabel.BackColor = Color.Transparent;
            confirmPasswordLabel.Location = new Point(34, 245);
            confirmPasswordLabel.Name = "confirmPasswordLabel";
            confirmPasswordLabel.Size = new Size(120, 17);
            confirmPasswordLabel.TabIndex = 5;
            confirmPasswordLabel.Text = "Confirm Password";
            // 
            // ShowPasswordCheckbox
            // 
            ShowPasswordCheckbox.AutoSize = true;
            ShowPasswordCheckbox.BackColor = Color.Transparent;
            ShowPasswordCheckbox.Cursor = Cursors.Hand;
            ShowPasswordCheckbox.FlatStyle = FlatStyle.Flat;
            ShowPasswordCheckbox.Font = new Font("Arial Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowPasswordCheckbox.Location = new Point(121, 308);
            ShowPasswordCheckbox.Name = "ShowPasswordCheckbox";
            ShowPasswordCheckbox.Size = new Size(137, 22);
            ShowPasswordCheckbox.TabIndex = 7;
            ShowPasswordCheckbox.Text = "Show Password";
            ShowPasswordCheckbox.UseVisualStyleBackColor = false;
            ShowPasswordCheckbox.CheckedChanged += ShowPasswordCheckbox_CheckedChanged;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(0, 146, 214);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Arial Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(34, 345);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(216, 35);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.FromArgb(0, 146, 214);
            btnClear.Location = new Point(34, 386);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(216, 35);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // labelAlreadyHaveAnAccount
            // 
            labelAlreadyHaveAnAccount.AutoSize = true;
            labelAlreadyHaveAnAccount.BackColor = Color.Transparent;
            labelAlreadyHaveAnAccount.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAlreadyHaveAnAccount.Location = new Point(34, 437);
            labelAlreadyHaveAnAccount.Name = "labelAlreadyHaveAnAccount";
            labelAlreadyHaveAnAccount.Size = new Size(176, 16);
            labelAlreadyHaveAnAccount.TabIndex = 10;
            labelAlreadyHaveAnAccount.Text = "Already Have An Account?";
            // 
            // labelBackToLogin
            // 
            labelBackToLogin.AutoSize = true;
            labelBackToLogin.BackColor = Color.Transparent;
            labelBackToLogin.Cursor = Cursors.Hand;
            labelBackToLogin.Font = new Font("Arial Black", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            labelBackToLogin.ForeColor = Color.FromArgb(0, 146, 214);
            labelBackToLogin.Location = new Point(34, 461);
            labelBackToLogin.Name = "labelBackToLogin";
            labelBackToLogin.Size = new Size(101, 17);
            labelBackToLogin.TabIndex = 11;
            labelBackToLogin.Text = "Back To Login";
            labelBackToLogin.Click += labelBackToLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 146, 214);
            label1.Location = new Point(81, 22);
            label1.Name = "label1";
            label1.Size = new Size(124, 30);
            label1.TabIndex = 12;
            label1.Text = "Welcome!";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(285, 508);
            Controls.Add(label1);
            Controls.Add(labelBackToLogin);
            Controls.Add(labelAlreadyHaveAnAccount);
            Controls.Add(btnClear);
            Controls.Add(btnRegister);
            Controls.Add(ShowPasswordCheckbox);
            Controls.Add(txtConfirmPassword);
            Controls.Add(confirmPasswordLabel);
            Controls.Add(txtPassword);
            Controls.Add(PasswordLabel);
            Controls.Add(txtUsername);
            Controls.Add(UsernameLabel);
            Controls.Add(LoginHeader);
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LoginHeader;
        private Label UsernameLabel;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label PasswordLabel;
        private TextBox txtConfirmPassword;
        private Label confirmPasswordLabel;
        private CheckBox ShowPasswordCheckbox;
        private Button btnRegister;
        private Button btnClear;
        private Label labelAlreadyHaveAnAccount;
        private Label labelBackToLogin;
        private Label label1;
    }
}