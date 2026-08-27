using System.Diagnostics;
using System.Drawing.Text;
using System.Media;
using Digiffice.Resources.Classes.ProgramClasses;

namespace Digiffice
{
    public partial class Homepage : Form
    {
        // Class Variables
        Image xBtnDefault = Properties.Resources.XbtnDefault;
        Image xBtnHover = Properties.Resources.XbtnHover;
        GlobalVar globalVar = new GlobalVar();
        nonprotected_AccountData np_AC = new nonprotected_AccountData();

        // Program Open Button Lists
        EventHandler[] ProgramClickEventHandlers = new EventHandler[2];
        EventHandler[] ProgramMouseEnterEventHandlers = new EventHandler[2];
        EventHandler[] ProgramMouseLeaveEventHandlers = new EventHandler[2];
        Image[] ProgramIcons = new Image[2];
        string[] programNames = new string[2];
        string[] programInfos = new string[2];
        string[] programVersions = new string[2];

        // Program Button Group
        Panel programOpen_Button = new Panel();

        public Homepage(nonprotected_AccountData nonprotected_AccData)
        {
            // Hide form until fully loaded to prevent flickering
            this.Opacity = 0;
            this.Shown += (s, e) =>
            {
                this.Opacity = 1;
            };

            // Initialise form dimensions
            np_AC = nonprotected_AccData;
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            // Initialize components
            InitializeComponent();

            // Declare variable values
            if (np_AC.ac_offline)
            {
                Welcomemsg.Text = "Welcome to Digiffice!";
                Offlinemsg.Text = "You are currently in offline mode. Certain features may be unavailable.";

                // Set offline pfp image
                PfpFramePfpPanel.BackgroundImage = Properties.Resources._150x150OfflinePfp;

                // Visualise other profile information
                ProfileNameLabel.Text = "Offline User";
            }
            else
            {
                Welcomemsg.Text = "Welcome to Digiffice, " + np_AC.ac_username + "!";
                Offlinemsg.Text = "";

                // Set to user pfp (stored in nonprotected_AccData)
                PfpFramePfpPanel.BackgroundImage = nonprotected_AccData.ac_profilepicture;

                ProfileNameLabel.Text = np_AC.ac_username;
            }
            Offlinemsg.Location = new Point(0, Screen.PrimaryScreen.Bounds.Height - Offlinemsg.Height);
            VersionLabel.Text = "Version: " + globalVar.DigifficeVer;

            // Call Custom Prerequesite Functions
            Fill_Lists();
            Homepage_ProgramButtons_Setup(programNames.Length);
            Homepage_PlayStartupSound();
        }

        // Fill Event Handler List
        private void Fill_Lists()
        {
            // Event Handlers
            ProgramClickEventHandlers[0] = new EventHandler(DigifficeAllnote_Open);
            ProgramMouseEnterEventHandlers[0] = new EventHandler(DigifficeAllnote_MouseEnter);
            ProgramMouseLeaveEventHandlers[0] = new EventHandler(DigifficeAllnote_MouseLeave);
            ProgramClickEventHandlers[1] = new EventHandler(DigifficePeercompute_Open);
            ProgramMouseEnterEventHandlers[1] = new EventHandler(DigifficePeercompute_MouseEnter);
            ProgramMouseLeaveEventHandlers[1] = new EventHandler(DigifficePeercompute_MouseLeave);

            // Program Icons
            ProgramIcons[0] = Properties.Resources.DigifficeAllnoteLogo;
            ProgramIcons[1] = Properties.Resources.DigifficePeercomputeLogo;

            // Program Names
            programNames[0] = "DigifficeAllnote";
            programNames[1] = "DigifficePeercompute";

            // Program Infos
            programInfos[0] = "Digiffice Allnote - A digital note-taking program for organising and editing all your notes.";
            programInfos[1] = "Digiffice Peercompute - A collaborative workspace for team projects and communication.";

            // Program Versions
            programVersions[0] = "0.3.0";
            programVersions[1] = "0.1.2";
        }

        private void Homepanel_Paint(object sender, PaintEventArgs e)
        {
            Homepanel.Size = new Size(Screen.PrimaryScreen.Bounds.Width, 59);
        }

        // Exit Button Events
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.BackgroundImage = xBtnHover;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.BackgroundImage = xBtnDefault;
        }

        // Homepage Setup Functions
        private void Homepage_ProgramButtons_Setup(int btns)
        {
            for (int i = 0; i < btns; i++)
            {
                ProgramOpen_Button_PrepaintProperties(i);
            }
        }

        private void Homepage_PlayStartupSound()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.DigifficeStartup);
            player.Play();
        }

        // Button Events
        private void TourDigifficeBtn_Click(object sender, EventArgs e)
        {

        }

        private void MoreProgramsBtn_Click(object sender, EventArgs e)
        {
            MoreProgramsForm moreProgramsForm = new MoreProgramsForm();
            moreProgramsForm.ShowDialog();
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            SettingsMenuForm settingsMenuForm = new SettingsMenuForm();
            settingsMenuForm.Show();
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

        // Digiffice Allnote Events

        private void DigifficeAllnote_Open(object sender, EventArgs e)
        {
            DigifficeAllnote_Splashscreen splashscreen = new DigifficeAllnote_Splashscreen(programVersions[0]);
            splashscreen.BringToFront();
            splashscreen.Show();

            DigifficeAllnote DigifficeAllnote = new DigifficeAllnote(np_AC, splashscreen);
            DigifficeAllnote.SuspendLayout(); // Suspend layout to prevent rendering issues during load
            DigifficeAllnote.Show();
        }

        private void DigifficeAllnote_MouseEnter(object sender, EventArgs e)
        {
            // sender
            Panel btn = (Panel)sender;

            // set back colour
            btn.BackColor = Color.LightGray;
        }

        private void DigifficeAllnote_MouseLeave(object sender, EventArgs e)
        {
            // sender
            Panel btn = (Panel)sender;

            // set back colour
            btn.BackColor = Color.WhiteSmoke;
        }

        // Digiffice Peerspace Events

        private void DigifficePeercompute_Open(object sender, EventArgs e)
        {
            DigifficePeercompute_Splashscreen splashscreen = new DigifficePeercompute_Splashscreen(programVersions[1]);
            splashscreen.BringToFront();
            splashscreen.Show();

            DigifficePeercompute DigifficePeercompute = new DigifficePeercompute(np_AC, splashscreen);
            DigifficePeercompute.SuspendLayout(); // Suspend layout to prevent rendering issues during load
            DigifficePeercompute.Show();
        }

        private void DigifficePeercompute_MouseEnter(object sender, EventArgs e)
        {
            // sender
            Panel btn = (Panel)sender;

            // set back colour
            btn.BackColor = Color.LightGray;
        }

        private void DigifficePeercompute_MouseLeave(object sender, EventArgs e)
        {
            // sender
            Panel btn = (Panel)sender;

            // set back colour
            btn.BackColor = Color.WhiteSmoke;
        }
    }
}
