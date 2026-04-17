using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiffice.Resources.Classes.ProgramClasses;
using Digiffice.Resources.Classes.ProgramClasses.CustomControls;
using Digiffice.Resources.Classes.ProgramClasses.DigifficePeerspace;
using Digiffice.Resources.Classes.ProgramClasses.DigifficePeerspace.ClientServerNode;
using Digiffice.Resources.Classes.ProgramClasses.DigifficePeerspace.P2PNode;
using DigifficeWPFControls;

namespace Digiffice
{
    public partial class DigifficePeerspace : Form
    {
        // Class Variables
        GlobalVar digifficeGlobalVariables = new GlobalVar();
        PeerspaceManager digifficePeerspaceManager = new PeerspaceManager();
        Image xBtnDefault = Properties.Resources.XbtnDefault;
        Image xBtnHover = Properties.Resources.XbtnHover;
        Panel selectedLeftbarTab;
        Panel selectedPeerspaceEntry;

        // Peersapce variables
        // NOTE: These classes are only initialised if a Peerspace is opened with the corresponding type.
        P2PNode _P2PNode;
        ClientServerClient _ClientServerClient;
        ClientServerServer _ClientServerHost;

        public DigifficePeerspace(nonprotected_AccountData nonprotected_AccountData, DigifficePeerspace_Splashscreen splashscreen)
        {
            // Hide form until fully loaded to prevent flickering
            this.Opacity = 0;
            this.Shown += (s, e) =>
            {
                this.Opacity = 1;
                splashscreen.Close();
            };

            // Set dimensions
            this.ClientSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.Size = ClientSize;

            // Initialize components
            InitializeComponent();

            // Call Custom/Prerequesite Functions
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            DigifficePeerspace_Prerequisite();
        }

        // Show Methods
        private void DigifficePeerspace_ShowPeerspacesList()
        {
            // Access list of peerspace directories from the user's Digiffice folder and display them in the left bar

            // Check if Digiffice Peerspace folder exists
            if (Directory.Exists(digifficeGlobalVariables.globalDigifficePeerspaceDataPath))
            {
                // Clear existing controls in the left bar panel
                PeerspaceLeftBarPanel.Controls.Clear();

                // Get list of peerspace directories
                string[] peerspaceDirectories = Directory.GetDirectories(digifficeGlobalVariables.globalDigifficePeerspaceDataPath);

                // Clear existing controls in the left bar panel
                PeerspaceLeftBarPanel.Controls.Clear();

                // Loop through each directory and create a label for it in the left bar panel
                int yOffset = 0;
                foreach (string directory in peerspaceDirectories)
                {
                    DigifficePeerspace_CreatePeerspaceEntryControl(0, yOffset, directory, PeerspaceLeftBarPanel, true, false);
                    yOffset += 40; // Adjust vertical spacing between labels
                }
            }
            else
            {
                throw new DirectoryNotFoundException("Digiffice data folder not found. Please ensure the directory exists: " + digifficeGlobalVariables.globalDigifficeDataPath);
            }
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

        // Windowmsg Events
        private void Windowmsg_Paint(object sender, PaintEventArgs e)
        {
            // Center Windowmsg Label
            int centerX = (this.Width - Windowmsg.Width) / 2;
            Windowmsg.Location = new Point(centerX, Windowmsg.Location.Y);
        }

        private void Windowmsg_TextChanged(object sender, EventArgs e)
        {
            // Center Windowmsg Label
            int centerX = (this.Width - Windowmsg.Width) / 2;
            Windowmsg.Location = new Point(centerX, Windowmsg.Location.Y);
        }

        // Digiffice Button Events
        private void DigifficeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Form Events
        private void DigifficePeerspace_Resize(object sender, EventArgs e)
        {
            PeerspaceLeftBarPanel.Size = new Size(PeerspaceLeftBarContainerPanel.Width - 1, PeerspaceLeftBarContainerPanel.Height - 42);
        }

        // Peerspace label (Left Bar) Events
        private void DigifficePeerspace_PeerspaceEntryControlClick(object sender, EventArgs e, string peerspaceDirectory)
        {
            Control senderControl = (Control)sender;

            // Show Current Peerspace in Peerspace Panel
            // Delete Current (Now Previous) Peerspace in Peerspace Panel
            foreach (Control item in CurrentPeerspaceBackgroundPanel.Controls)
            {
                if (item == selectedPeerspaceEntry)
                {
                    CurrentPeerspaceBackgroundPanel.Controls.Remove(item);
                    item.Dispose();
                }
            }

            // Create EntryControl and add it to Peerspace Panel
            DigifficePeerspace_CreatePeerspaceEntryControl(7, 12, peerspaceDirectory, CurrentPeerspaceBackgroundPanel, false, true);

            // Initialise Peerspace
            string peerspaceType = senderControl.Tag.ToString();
            if (peerspaceType == "P2P")
            {
                // Remove controls from parent control
                CurrentPeerspaceDataPanel.Controls.Clear();

                // Map P2P Peerspace Data onto a grid using PeerspaceManager
                digifficePeerspaceManager.MapPeerspace(peerspaceDirectory, CurrentPeerspaceDataPanel);

                // Initialise P2P Node
                _P2PNode = new P2PNode();
                _P2PNode.initP2PNode();
            }
            else if (peerspaceType == "CLIENTSERVER")
            {
                // Remove controls from parent control
                CurrentPeerspaceDataPanel.Controls.Clear();
            }
            else
            {
                throw new InvalidDataException("Invalid peerspace type found in label tag: " + peerspaceType);
            }
        }

        // Other Events
        private void PeerspacesTabLabel_Paint(object sender, EventArgs e)
        {
            PeerspacesTabLabel.Size = TextRenderer.MeasureText(PeerspacesTabLabel.Text, PeerspacesTabLabel.Font);
            if (PeerspacesTab == selectedLeftbarTab)
            {
                PeerspacesTabLabel.Location = new Point((PeerspacesTab.Width - PeerspacesTabLabel.Width) / 2, (PeerspacesTab.Height - PeerspacesTabLabel.Height) / 2);
            }
            else
            {
                PeerspacesTabLabel.Location = new Point((PeerspacesTab.Width - PeerspacesTabLabel.Width) / 2, (PeerspacesTab.Height - PeerspacesTabLabel.Height) / 2 - 5); // Add 5px vertical
            }
        }

        private void PeerspacesTab_Click(object sender, EventArgs e)
        {
            if (selectedLeftbarTab != null)
            {
                selectedLeftbarTab.Location = new Point(selectedLeftbarTab.Location.X, selectedLeftbarTab.Location.Y + 10);
            }

            selectedLeftbarTab = PeerspacesTab;
            PeerspacesTab.Location = new Point(PeerspacesTab.Location.X, PeerspacesTab.Location.Y - 10);
            DigifficePeerspace_ShowPeerspacesList();
        }

        // Control Creation Methods
        private void DigifficePeerspace_CreatePeerspaceEntryControl(int _xOffset, int _yOffset, string directory, Control parentControl, bool clickable, bool setAsCurrentlySelected)
        {
            // Create Parent container panel for each peerspace entry (to allow for better formatting and click events)
            Panel peerspaceEntryPanel = new Panel();
            peerspaceEntryPanel.Tag = "PeerspaceEntryParentPanel";
            peerspaceEntryPanel.Location = new Point(_xOffset, _yOffset);
            if (setAsCurrentlySelected)
            {
                selectedPeerspaceEntry = peerspaceEntryPanel;
            }
            peerspaceEntryPanel.Size = new Size(parentControl.Width, 30);
            peerspaceEntryPanel.BackColor = Color.Transparent;
            parentControl.Controls.Add(peerspaceEntryPanel);

            // Create image identifier for peerspace type (p2p/client-server)
            PictureBox peerspacePictureBox = new PictureBox();
            peerspacePictureBox.Location = new Point(5 + _xOffset, 0);
            peerspacePictureBox.Size = new Size(30, 30); // Set size for the picture box
            peerspacePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            peerspacePictureBox.BackColor = Color.Transparent;


            // Create name label
            Label peerspaceNameLabel = new Label();
            peerspaceNameLabel.Font = new Font("Roboto", 10, FontStyle.Bold);
            peerspaceNameLabel.Text = Path.GetFileName(directory);
            peerspaceNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            peerspaceNameLabel.Location = new Point(peerspacePictureBox.Right + 5 + _xOffset, 0);
            peerspaceNameLabel.Size = new Size(parentControl.Width - peerspacePictureBox.Width - 10, 30);
            peerspaceNameLabel.BackColor = SystemColors.Control;
            peerspaceNameLabel.ForeColor = Color.Black;
            peerspaceEntryPanel.Controls.Add(peerspaceNameLabel);

            if (clickable)
            {
                peerspaceEntryPanel.Cursor = Cursors.Hand;
                peerspaceEntryPanel.Click += (s, e) => DigifficePeerspace_PeerspaceEntryControlClick(s, e, directory);
                peerspacePictureBox.Cursor = Cursors.Hand;
                peerspacePictureBox.Click += (s, e) => DigifficePeerspace_PeerspaceEntryControlClick(s, e, directory);
                peerspaceNameLabel.Cursor = Cursors.Hand;
                peerspaceNameLabel.Click += (s, e) => DigifficePeerspace_PeerspaceEntryControlClick(s, e, directory);
            }

            // Get Peerspace Type
            string peerspaceType = digifficePeerspaceManager.GetPeerspaceType(directory);
            if (peerspaceType == "P2P")
            {
                peerspacePictureBox.Image = Properties.Resources.DigifficePeerspace_P2PIcon;
                peerspaceEntryPanel.Tag = "P2P";
                peerspaceNameLabel.Tag = "P2P";
                peerspacePictureBox.Tag = "P2P";
            }
            else if (peerspaceType == "CLIENTSERVER")
            {
                peerspacePictureBox.Image = Properties.Resources.DigifficePeerspace_ClientServerIcon;
                peerspaceEntryPanel.Tag = "CLIENTSERVER";
                peerspaceNameLabel.Tag = "CLIENTSERVER";
                peerspacePictureBox.Tag = "CLIENTSERVER";
            }
            else
            {
                throw new InvalidDataException("Invalid peerspace type found in data file in peerspace directory: " + directory + " Invalid data: " + peerspaceType);
            }

            // Add Picture Box to form
            peerspaceEntryPanel.Controls.Add(peerspacePictureBox);
        }

        // Events For Scrollbar
        private void CustomVScrollBar_Scroll(object sender, EventArgs e)
        {
            
        }

        // Prerequisite Functions
        private void DigifficePeerspace_Prerequisite()
        {
            // Create Scrollbar
            CustomVScrollBar scrollbarV = new CustomVScrollBar(new Point(PeerspaceLeftBarContainerPanel.Right, PeerspaceLeftBarContainerPanel.Top + (PeerspaceLeftBarContainerPanel.Height - PeerspaceLeftBarPanel.Height) - 1), new Size(30, PeerspaceLeftBarPanel.Height),
                Color.LightGray, Color.LightGray, Color.LightGray, Color.Transparent,
                null, Properties.Resources.VScrollBar_UpScrollBtn, Properties.Resources.VScrollBar_DownScrollBtn, Properties.Resources.CustomVScrollBar_1);
            // Todo: Set scrollbar range based on number of peerspaces and their heights
            scrollbarV.setMinMaxRange(0, 0);
            scrollbarV.addControlstoControl(this);

            // Create Scrollbar Border
            Panel scrollbarBorder = new Panel();
            scrollbarBorder.Size = new Size(31, PeerspacesPanelBorder.Height);
            scrollbarBorder.Location = new Point(PeerspaceLeftBarContainerPanel.Right, PeerspaceLeftBarContainerPanel.Top + (PeerspaceLeftBarContainerPanel.Height - PeerspaceLeftBarPanel.Height) - 2);
            scrollbarBorder.BackColor = Color.Navy;
            this.Controls.Add(scrollbarBorder);
            scrollbarBorder.SendToBack();
        }
    }
}
