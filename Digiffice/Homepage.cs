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
        EventHandler[] ProgramMouseEnterEventHandlers = new EventHandler[1];
        EventHandler[] ProgramMouseLeaveEventHandlers = new EventHandler[1];
        Image[] ProgramIcons = new Image[1];
        string[] programNames = new string[1];

        // Program Button Group
        Panel programOpen_Button = new Panel();

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
            ProgramMouseEnterEventHandlers[0] = new EventHandler(DigifficeAllpad_MouseEnter);
            ProgramMouseLeaveEventHandlers[0] = new EventHandler(DigifficeAllpad_MouseLeave);

            // Program Icons
            ProgramIcons[0] = Properties.Resources.DigifficeAllpadIcon;

            // Program Names
            programNames[0] = "DigifficeAllpad";
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
            programOpen_Button.Tag = programNames[idx];
            programOpen_Button.Size = new Size(400, 70);
            programOpen_Button.Text = "";
            programOpen_Button.BackColor = Color.WhiteSmoke;
            programOpen_Button.BorderStyle = BorderStyle.FixedSingle;
            int yLocation = (ProgramsPanel.Location.Y + (ProgramsPanel.Height + 6)) + ((programOpen_Button.Size.Height + 6) * idx);
            programOpen_Button.Location = new Point(ProgramsPanel.Location.X, yLocation);
            programOpen_Button.Paint += ProgramOpenButton_Paint;
            programOpen_Button.Click += ProgramClickEventHandlers[idx];
            programOpen_Button.MouseEnter += ProgramMouseEnterEventHandlers[idx];
            programOpen_Button.MouseLeave += ProgramMouseLeaveEventHandlers[idx];
            this.Controls.Add(programOpen_Button);
            programOpen_Button = new Panel();
        }

        private void ProgramOpen_Button_PaintProperties(string programToOpen, Panel btn)
        {
            // icon panel
            Panel iconPanel = new Panel();
            iconPanel.Size = new Size(60, 60);
            iconPanel.Location = new Point(btn.Location.X + 5, btn.Location.Y + 5);
            iconPanel.BackgroundImage = ProgramIcons[Array.IndexOf(programNames, programToOpen)];
            iconPanel.BackColor = Color.WhiteSmoke;
            iconPanel.BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(iconPanel);
            iconPanel.BringToFront();
        }

        private void ProgramOpenButton_Paint(object sender, EventArgs e)
        {
            Panel currentButton = (Panel)sender;
            string program = sender.GetType().GetProperty("Tag").GetValue(sender, null).ToString();
            ProgramOpen_Button_PaintProperties(program, currentButton);
        }

        private void DigifficeAllpad_Open(object sender, EventArgs e)
        {
            MessageBox.Show("HEHEHEHA");
        }

        private void DigifficeAllpad_MouseEnter(object sender, EventArgs e)
        {
            Panel btn = (Panel)sender;
            btn.BackColor = Color.LightGray;
        }

        private void DigifficeAllpad_MouseLeave(object sender, EventArgs e)
        {
            Panel btn = (Panel)sender;
            btn.BackColor = Color.WhiteSmoke;
        }
    }
}
