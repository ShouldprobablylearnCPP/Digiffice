using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiffice.Resources.Classes.ProgramClasses;

namespace Digiffice
{
    public partial class Register : Form
    {
        public Register()
        {
            // Enable visual styles for the application
            Application.EnableVisualStyles();

            // Initialize Form
            InitializeComponent();

            // Hide form until fully loaded to prevent flickering
            this.Opacity = 0;
            this.Shown += (s, e) =>
            {
                this.Opacity = 1;
            };
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\suzan\\OneDrive\\Documents\\DigifficeDatabase.accdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand checkCMD = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "" && txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == txtConfirmPassword.Text)
            {
                // Open Database
                con.Open();

                string checkUsername = "SELECT * FROM Digiffice_Accounts WHERE username= '" + txtUsername.Text + "'";
                checkCMD = new OleDbCommand(checkUsername, con);
                OleDbDataReader checkDR = checkCMD.ExecuteReader();

                if (checkDR.HasRows)
                {
                    MessageBox.Show("Username already exists, Please choose a different username", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtUsername.Focus();
                    con.Close();
                    return;
                }

                // Execute Insert Command to add new account to database
                string register = "INSERT INTO Digiffice_Accounts VALUES ('" + txtUsername.Text + "', '" + txtPassword.Text + "')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";

                MessageBox.Show("Your account has been successfully registered", "Registration complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Passwords do not match, Please Re-enter", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void ShowPasswordCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPasswordCheckbox.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtUsername.Focus();
        }

        private void labelBackToLogin_Click(object sender, EventArgs e)
        {
            con.Close();
            new Login().Show();
            this.Hide();
        }
    }
}
