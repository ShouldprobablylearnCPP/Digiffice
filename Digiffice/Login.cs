using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;
using Digiffice.Resources.Classes.ProgramClasses;

namespace Digiffice
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\suzan\\OneDrive\\Documents\\DigifficeDatabase.accdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "SELECT * FROM Digiffice_Accounts WHERE username= '" + txtUsernamelogin.Text + "' and password= '" + txtPasswordlogin.Text + "'";
            Debug.WriteLine(login);
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                con.Close();
                nonprotected_AccountData nonprotected_Account = new nonprotected_AccountData();
                nonprotected_Account.ac_username = txtUsernamelogin.Text;
                new Homepage(nonprotected_Account).Show();
                this.Hide();
            }
            else
            {
                con.Close();
                MessageBox.Show("Invalid username or password; Please try again", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPasswordlogin.Text = "";
                txtUsernamelogin.Text = "";
                txtUsernamelogin.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPasswordlogin.Text = "";
            txtUsernamelogin.Text = "";
            txtUsernamelogin.Focus();
        }

        private void ShowPasswordCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPasswordCheckbox.Checked)
            {
                txtPasswordlogin.PasswordChar = '\0';
            }
            else
            {
                txtPasswordlogin.PasswordChar = '*';
            }
        }

        private void labelCreateAccount_Click(object sender, EventArgs e)
        {
            con.Close();
            new Register().Show();
            this.Hide();
        }
    }
}
