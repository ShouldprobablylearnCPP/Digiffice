using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficePeercompute._File
{
    public class DigifficeFileReaderDGPU
    {
        // Class Variables
        public List<string> userList;

        public List<string> ReadDGPUFile(string directory)
        {
            using (StreamReader file = new StreamReader(directory))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("|"))
                    {
                        string user = line.Substring(1); // Remove the leading '|'
                        userList.Add(user);
                    }
                    else
                    {
                        throw new Exception("Invalid DGPU file format: Line does not start with '|'");
                    }
                }

                return userList;
            }
        }
    }
}
