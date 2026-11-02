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

namespace Digiffice
{
    public partial class SettingsMenuForm : Form
    {
        public SettingsMenuForm(nonprotected_AccountData np_AC)
        {
            InitializeComponent();
            DigifficeSettings_SetupSettings(np_AC);
        }

        public void DigifficeSettings_SetupSettings(nonprotected_AccountData np_AC)
        {
            if (np_AC.ac_offline)
            {
                pfpImgPnl.BackgroundImage = Properties.Resources._150x150OfflinePfp;
            }
            else
            {
                pfpImgPnl.BackgroundImage = np_AC.ac_profilepicture;
            }
            pfpImgPnl.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
