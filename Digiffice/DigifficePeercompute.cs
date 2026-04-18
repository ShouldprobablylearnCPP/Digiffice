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
using Digiffice.Resources.Classes.ProgramClasses.DigifficePeercompute;
using Digiffice.Resources.Classes.ProgramClasses.DigifficePeercompute.ClientServerNode;
using Digiffice.Resources.Classes.ProgramClasses.DigifficePeercompute.P2PNode;
using DigifficeWPFControls;

namespace Digiffice
{
    public partial class DigifficePeercompute : Form
    {
        // Class Variables
        GlobalVar digifficeGlobalVariables = new GlobalVar();
        PeercomputeManager DigifficePeercomputeManager = new PeercomputeManager();
        Image xBtnDefault = Properties.Resources.XbtnDefault;
        Image xBtnHover = Properties.Resources.XbtnHover;
        Panel selectedLeftbarTab;
        Panel selectedPeercomputeEntry;

        // Peersapce variables
        // NOTE: These classes are only initialised if a Peercompute is opened with the corresponding type.
        P2PNode _P2PNode;
        ClientServerClient _ClientServerClient;
        ClientServerServer _ClientServerHost;

        public DigifficePeercompute(nonprotected_AccountData nonprotected_AccountData, DigifficePeercompute_Splashscreen splashscreen)
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
            DigifficePeercompute_Prerequisite();
        }

        // Show Methods
        private void DigifficePeercompute_ShowPeercomputesList()
        {
            // Access list of Peercompute directories from the user's Digiffice folder and display them in the left bar

            // Check if Digiffice Peercompute folder exists
            if (Directory.Exists(digifficeGlobalVariables.globalDigifficePeercomputeDataPath))
            {
                // Clear existing controls in the left bar panel
                PeercomputeLeftBarPanel.Controls.Clear();

                // Get list of Peercompute directories
                string[] PeercomputeDirectories = Directory.GetDirectories(digifficeGlobalVariables.globalDigifficePeercomputeDataPath);

                // Clear existing controls in the left bar panel
                PeercomputeLeftBarPanel.Controls.Clear();

                // Loop through each directory and create a label for it in the left bar panel
                int yOffset = 0;
                foreach (string directory in PeercomputeDirectories)
                {
                    DigifficePeercompute_CreatePeercomputeEntryControl(0, yOffset, directory, PeercomputeLeftBarPanel, true, false);
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
        private void DigifficePeercompute_Resize(object sender, EventArgs e)
        {
            PeercomputeLeftBarPanel.Size = new Size(PeercomputeLeftBarContainerPanel.Width - 1, PeercomputeLeftBarContainerPanel.Height - 42);
        }

        // Peercompute label (Left Bar) Events
        private void DigifficePeercompute_PeercomputeEntryControlClick(object sender, EventArgs e, string PeercomputeDirectory)
        {
            Control senderControl = (Control)sender;

            // Show Current Peercompute in Peercompute Panel
            // Delete Current (Now Previous) Peercompute in Peercompute Panel
            foreach (Control item in CurrentPeercomputeBackgroundPanel.Controls)
            {
                if (item == selectedPeercomputeEntry)
                {
                    CurrentPeercomputeBackgroundPanel.Controls.Remove(item);
                    item.Dispose();
                }
            }

            // Create EntryControl and add it to Peercompute Panel
            DigifficePeercompute_CreatePeercomputeEntryControl(7, 12, PeercomputeDirectory, CurrentPeercomputeBackgroundPanel, false, true);

            // Initialise Peercompute
            string PeercomputeType = senderControl.Tag.ToString();
            if (PeercomputeType == "P2P")
            {
                // Remove controls from parent control
                CurrentPeercomputeDataPanel.Controls.Clear();

                // Map P2P Peercompute Data onto a grid using PeercomputeManager
                DigifficePeercomputeManager.MapPeercompute(PeercomputeDirectory, CurrentPeercomputeDataPanel);

                // Initialise P2P Node
                _P2PNode = new P2PNode();
                _P2PNode.initP2PNode();
            }
            else if (PeercomputeType == "CLIENTSERVER")
            {
                // Remove controls from parent control
                CurrentPeercomputeDataPanel.Controls.Clear();
            }
            else
            {
                throw new InvalidDataException("Invalid Peercompute type found in label tag: " + PeercomputeType);
            }
        }

        // Other Events
        private void PeercomputesTabLabel_Paint(object sender, EventArgs e)
        {
            PeercomputesTabLabel.Size = TextRenderer.MeasureText(PeercomputesTabLabel.Text, PeercomputesTabLabel.Font);
            if (PeercomputesTab == selectedLeftbarTab)
            {
                PeercomputesTabLabel.Location = new Point((PeercomputesTab.Width - PeercomputesTabLabel.Width) / 2, (PeercomputesTab.Height - PeercomputesTabLabel.Height) / 2);
            }
            else
            {
                PeercomputesTabLabel.Location = new Point((PeercomputesTab.Width - PeercomputesTabLabel.Width) / 2, (PeercomputesTab.Height - PeercomputesTabLabel.Height) / 2 - 5); // Add 5px vertical
            }
        }

        private void PeercomputesTab_Click(object sender, EventArgs e)
        {
            if (selectedLeftbarTab != null)
            {
                selectedLeftbarTab.Location = new Point(selectedLeftbarTab.Location.X, selectedLeftbarTab.Location.Y + 10);
            }

            selectedLeftbarTab = PeercomputesTab;
            PeercomputesTab.Location = new Point(PeercomputesTab.Location.X, PeercomputesTab.Location.Y - 10);
            DigifficePeercompute_ShowPeercomputesList();
        }

        // Control Creation Methods
        private void DigifficePeercompute_CreatePeercomputeEntryControl(int _xOffset, int _yOffset, string directory, Control parentControl, bool clickable, bool setAsCurrentlySelected)
        {
            // Create Parent container panel for each Peercompute entry (to allow for better formatting and click events)
            Panel PeercomputeEntryPanel = new Panel();
            PeercomputeEntryPanel.Tag = "PeercomputeEntryParentPanel";
            PeercomputeEntryPanel.Location = new Point(_xOffset, _yOffset);
            if (setAsCurrentlySelected)
            {
                selectedPeercomputeEntry = PeercomputeEntryPanel;
            }
            PeercomputeEntryPanel.Size = new Size(parentControl.Width, 30);
            PeercomputeEntryPanel.BackColor = Color.Transparent;
            parentControl.Controls.Add(PeercomputeEntryPanel);

            // Create image identifier for Peercompute type (p2p/client-server)
            PictureBox PeercomputePictureBox = new PictureBox();
            PeercomputePictureBox.Location = new Point(5 + _xOffset, 0);
            PeercomputePictureBox.Size = new Size(30, 30); // Set size for the picture box
            PeercomputePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PeercomputePictureBox.BackColor = Color.Transparent;


            // Create name label
            Label PeercomputeNameLabel = new Label();
            PeercomputeNameLabel.Font = new Font("Roboto", 10, FontStyle.Bold);
            PeercomputeNameLabel.Text = Path.GetFileName(directory);
            PeercomputeNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            PeercomputeNameLabel.Location = new Point(PeercomputePictureBox.Right + 5 + _xOffset, 0);
            PeercomputeNameLabel.Size = new Size(parentControl.Width - PeercomputePictureBox.Width - 10, 30);
            PeercomputeNameLabel.BackColor = SystemColors.Control;
            PeercomputeNameLabel.ForeColor = Color.Black;
            PeercomputeEntryPanel.Controls.Add(PeercomputeNameLabel);

            if (clickable)
            {
                PeercomputeEntryPanel.Cursor = Cursors.Hand;
                PeercomputeEntryPanel.Click += (s, e) => DigifficePeercompute_PeercomputeEntryControlClick(s, e, directory);
                PeercomputePictureBox.Cursor = Cursors.Hand;
                PeercomputePictureBox.Click += (s, e) => DigifficePeercompute_PeercomputeEntryControlClick(s, e, directory);
                PeercomputeNameLabel.Cursor = Cursors.Hand;
                PeercomputeNameLabel.Click += (s, e) => DigifficePeercompute_PeercomputeEntryControlClick(s, e, directory);
            }

            // Get Peercompute Type
            string PeercomputeType = DigifficePeercomputeManager.GetPeercomputeType(directory);
            if (PeercomputeType == "P2P")
            {
                PeercomputePictureBox.Image = Properties.Resources.DigifficePeercompute_P2PIcon;
                PeercomputeEntryPanel.Tag = "P2P";
                PeercomputeNameLabel.Tag = "P2P";
                PeercomputePictureBox.Tag = "P2P";
            }
            else if (PeercomputeType == "CLIENTSERVER")
            {
                PeercomputePictureBox.Image = Properties.Resources.DigifficePeercompute_ClientServerIcon;
                PeercomputeEntryPanel.Tag = "CLIENTSERVER";
                PeercomputeNameLabel.Tag = "CLIENTSERVER";
                PeercomputePictureBox.Tag = "CLIENTSERVER";
            }
            else
            {
                throw new InvalidDataException("Invalid Peercompute type found in data file in Peercompute directory: " + directory + " Invalid data: " + PeercomputeType);
            }

            // Add Picture Box to form
            PeercomputeEntryPanel.Controls.Add(PeercomputePictureBox);
        }

        // Events For Scrollbar
        private void CustomVScrollBar_Scroll(object sender, EventArgs e)
        {
            
        }

        // Prerequisite Functions
        private void DigifficePeercompute_Prerequisite()
        {
            // Create Scrollbar
            CustomVScrollBar scrollbarV = new CustomVScrollBar(new Point(PeercomputeLeftBarContainerPanel.Right, PeercomputeLeftBarContainerPanel.Top + (PeercomputeLeftBarContainerPanel.Height - PeercomputeLeftBarPanel.Height) - 1), new Size(30, PeercomputeLeftBarPanel.Height),
                Color.LightGray, Color.LightGray, Color.LightGray, Color.Transparent,
                null, Properties.Resources.VScrollBar_UpScrollBtn, Properties.Resources.VScrollBar_DownScrollBtn, Properties.Resources.CustomVScrollBar_1);
            // Todo: Set scrollbar range based on number of Peercomputes and their heights
            scrollbarV.setMinMaxRange(0, 0);
            scrollbarV.addControlstoControl(this);

            // Create Scrollbar Border
            Panel scrollbarBorder = new Panel();
            scrollbarBorder.Size = new Size(31, PeercomputesPanelBorder.Height);
            scrollbarBorder.Location = new Point(PeercomputeLeftBarContainerPanel.Right, PeercomputeLeftBarContainerPanel.Top + (PeercomputeLeftBarContainerPanel.Height - PeercomputeLeftBarPanel.Height) - 2);
            scrollbarBorder.BackColor = Color.Navy;
            this.Controls.Add(scrollbarBorder);
            scrollbarBorder.SendToBack();
        }
    }
}
