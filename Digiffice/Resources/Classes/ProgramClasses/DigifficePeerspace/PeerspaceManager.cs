using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;
using DigifficeWPFControls;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficePeerspace
{
    public class PeerspaceManager
    {
        public string GetPeerspaceType(string peerspaceDirPath)
        {
            // Find data file in directory
            string dataFilePath = @$"{peerspaceDirPath}/PEERSPACE_DATA.dgpd";
            using (FileStream fs = File.OpenRead(dataFilePath))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    // Find |PEERSPACE_TYPE: ... in data file and get the value after the colon
                    string dataLine = File.ReadLines(dataFilePath).FirstOrDefault(line => line.StartsWith("|PEERSPACE_TYPE:"));
                    if (dataLine == null)
                    {
                        throw new InvalidDataException("PEERSPACE_TYPE not found in data file in peerspace directory: " + peerspaceDirPath);
                    }
                    else
                    {
                        return dataLine["|PEERSPACE_TYPE:".Length..].Trim();
                    }
                }
            }
        }

        public void MapPeerspace(string peerspaceDirectory, Control parentControl)
        {
            string peerspaceType = GetPeerspaceType(peerspaceDirectory);
            if (peerspaceType == "P2P")
            {
                MapP2PPeerspace(peerspaceDirectory, parentControl);
            }
        }

        public void MapP2PPeerspace(string peerspaceDirectory, Control parentControl)
        {
            // Get List of Files and Directories in the peerspace directory
            string[] files = Directory.GetFiles(peerspaceDirectory);
            string[] directories = Directory.GetDirectories(peerspaceDirectory);

            // Map data onto a grid control (WPF Grid using ElementHost)
            // Todo: Finish this method to actually read the data and map it onto the grid control
            ElementHost elementHost = new ElementHost();
            WPFDataGrid dataGrid = new WPFDataGrid();
            elementHost.Child = dataGrid;
            parentControl.Controls.Add(elementHost);
        }
    }
}
