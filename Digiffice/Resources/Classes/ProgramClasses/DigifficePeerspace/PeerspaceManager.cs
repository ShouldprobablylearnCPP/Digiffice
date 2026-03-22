using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
    }
}
