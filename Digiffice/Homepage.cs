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

        // Program Open Button Lists
        EventHandler[] ProgramClickEventHandlers = new EventHandler[1];
        EventHandler[] ProgramMouseEnterEventHandlers = new EventHandler[1];
        EventHandler[] ProgramMouseLeaveEventHandlers = new EventHandler[1];
        Image[] ProgramIcons = new Image[1];
        string[] programNames = new string[1];
        string[] programInfos = new string[1];

        // Program Button Group
        Panel programOpen_Button = new Panel();

        public Homepage(nonprotected_AccountData nonprotected_AccData)
        {
            nonprotected_AccountData transferrable_nonprotectedaccdata = nonprotected_AccData;
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

            // Program Infos
            programInfos[0] = "Digiffice Allpad - A digital note-taking program for organising and editing all your notes.";
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
            programOpen_Button.Cursor = Cursors.Hand;
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
            iconPanel.Name = "IconPanel_" + programToOpen;
            iconPanel.Tag = btn.Tag;
            iconPanel.Size = new Size(60, 60);
            iconPanel.Location = new Point(btn.Location.X + 5, btn.Location.Y + 5);
            iconPanel.BackColor = btn.BackColor;
            iconPanel.BackgroundImage = ProgramIcons[Array.IndexOf(programNames, programToOpen)];
            iconPanel.BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(iconPanel);
            iconPanel.Enabled = false;
            iconPanel.BringToFront();

            // program info label
            Label programInfoLabel = new Label();
            programInfoLabel.Name = "ProgramInfoLabel_" + programToOpen;
            programInfoLabel.Tag = btn.Tag;
            programInfoLabel.Size = new Size(300, 60);
            programInfoLabel.Location = new Point(iconPanel.Location.X + iconPanel.Width + 10, btn.Location.Y + 5);
            programInfoLabel.BackColor = btn.BackColor;
            programInfoLabel.Text = programInfos[Array.IndexOf(programNames, programToOpen)];
            programInfoLabel.Font = new Font("Roboto", 8, FontStyle.Bold);
            programInfoLabel.TextAlign = ContentAlignment.MiddleLeft;
            Controls.Add(programInfoLabel);
            programInfoLabel.Enabled = false;
            programInfoLabel.BringToFront();
        }

        private void ProgramOpenButton_Paint(object sender, EventArgs e)
        {
            Panel currentButton = (Panel)sender;
            string program = sender.GetType().GetProperty("Tag").GetValue(sender, null).ToString();
            ProgramOpen_Button_PaintProperties(program, currentButton);
        }

        // Digiffice Allpad

        private void DigifficeAllpad_Open(object sender, EventArgs e)
        {
            nonprotected_AccountData transfer_npac = new nonprotected_AccountData();
            transfer_npac.ac_username = this.username;
            string username = this.username;
            DigifficeAllpad digifficeAllpad = new DigifficeAllpad(transfer_npac);
            digifficeAllpad.Show();
        }

        private void DigifficeAllpad_MouseEnter(object sender, EventArgs e)
        {
            // sender
            Panel btn = (Panel)sender;

            // set back colour
            btn.BackColor = Color.LightGray;
        }

        private void DigifficeAllpad_MouseLeave(object sender, EventArgs e)
        {
            // sender
            Panel btn = (Panel)sender;

            // set back colour
            btn.BackColor = Color.WhiteSmoke;
        }
    }
}
