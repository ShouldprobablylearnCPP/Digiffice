using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficePeercompute._File
{
    internal class DigifficeFileReaderDGPD
    {
        public int readDGPDLocalPort(string directory)
        {
            using (StreamReader file = new StreamReader(directory))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("|"))
                    {
                        if (line.Substring(1).StartsWith("LOCALPORT: "))
                        {
                            line = line.Substring(12);
                            return int.Parse(line);
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid DGPD file format: Line does not start with '|'");
                    }
                }
            }

            return -1;
        }
    }
}
