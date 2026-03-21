using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiffice.Resources.Classes.ProgramClasses;
using Digiffice.Resources.Classes.ProgramClasses.CustomControls;

namespace Digiffice
{
    public partial class DigifficePeerspace : Form
    {
        // Class Variables
        Image xBtnDefault = Properties.Resources.XbtnDefault;
        Image xBtnHover = Properties.Resources.XbtnHover;
        Panel selectedLeftbarTab;
         
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
