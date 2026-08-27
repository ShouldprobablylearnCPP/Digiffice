using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.UserPrefs
{
    public class DigifficeFileReaderDGUP
    {
        public string readIdlebarInfo(string directory)
        {
            using (StreamReader file = new StreamReader(directory))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("|"))
                    {
                        if (line.Substring(1).StartsWith("IDLEBAR: "))
                        {
                            line = line.Substring(10);
                            return line;
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid DGPU file format: Line does not start with '|'");
                    }
                }
            }

            return string.Empty;
        }
    }
}
