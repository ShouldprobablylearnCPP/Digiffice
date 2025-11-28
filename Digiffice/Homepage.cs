using System.Diagnostics;
using System.Drawing.Text;
using Digiffice.Resources.Classes.ProgramClasses;

namespace Digiffice
{
    public partial class Homepage : Form
    {
        // Class Variables
        Image xBtnDefault = Properties.Resources.XbtnDefault;
        Image xBtnHover = Properties.Resources.XbtnHover;
        string username = "";
        int DigifficeProgramsNum = 1;
        
        // Class Lists
        EventHandler[] ProgramClickEventHandlers = new EventHandler[1];
        Icon[] ProgramIcons = new Icon[1];

        // Program Button Group
        Button programOpen_Button = new Button();

        public Homepage(nonprotected_AccountData nonprotected_AccData)
        {
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            InitializeComponent();
            username = nonprotected_AccData.ac_username;
            Welcomemsg.Text = "Welcome to Digiffice, " + username + "!";
            Fill_Lists();
            Homepage_ProgramButtons_Setup(DigifficeProgramsNum);
        }

        // Fill Event Handler List
        private void Fill_Lists()
        {
            // Event Handlers
            ProgramClickEventHandlers[0] = new EventHandler(DigifficeAllpad_Open);

            // Program Icons
        }

        // Exit Button Events
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.Image = xBtnHover;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Image = xBtnDefault;
        }

        // Homepage Setup Functions
        private void Homepage_ProgramButtons_Setup(int btns)
        {
            for (int i = 0; i < btns; i++)
            {
                ProgramOpen_Button_PrepaintProperties(i);
            }
        }

        // Program Button Group Functions
        private void ProgramOpen_Button_PrepaintProperties(int idx)
        {
            programOpen_Button.Name = "ProgramOpen_Button_" + idx;
            programOpen_Button.Size = new Size(400, 70);
            programOpen_Button.Text = "Open Program";
            programOpen_Button.FlatStyle = FlatStyle.Flat;
            programOpen_Button.BackColor = Color.White;
            programOpen_Button.FlatAppearance.BorderSize = 0;
            int yLocation = (ProgramsPanel.Location.Y + (ProgramsPanel.Height + 6)) + ((programOpen_Button.Size.Height + 6) * idx);
            programOpen_Button.Location = new Point(ProgramsPanel.Location.X, yLocation);
            programOpen_Button.Paint += ProgramOpenButton_Paint;
            programOpen_Button.Click += ProgramClickEventHandlers[idx];
            Console.WriteLine(idx);
            this.Controls.Add(programOpen_Button);
            programOpen_Button = new Button();
        }

        private void ProgramOpen_Button_PaintProperties(string programToOpen)
        {

        }

        private void ProgramOpenButton_Paint(object sender, EventArgs e)
        {
            string program = "";
            ProgramOpen_Button_PaintProperties(program);
        }

        private void DigifficeAllpad_Open(object sender, EventArgs e)
        {
            MessageBox.Show("HEHEHEHA");
        }
    }
}
