using System.Diagnostics;
using System.Drawing.Text;
using Digiffice.Resources.Classes.ProgramClasses;

namespace Digiffice
{
    public partial class Homepage : Form
    {
        string username = "";

        public Homepage(nonprotected_AccountData nonprotected_AccData)
        {
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            InitializeComponent();
            username = nonprotected_AccData.ac_username;
            Welcomemsg.Text = "Welcome to Digiffice, " + username + "!";
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            Debug.WriteLine("Mouse Entered");
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            Debug.WriteLine("Mouse leaving");
        }
    }
}
