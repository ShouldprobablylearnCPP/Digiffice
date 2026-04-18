using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice
{
    public class GlobalVar
    {
        // Global Variables
        public string globalDigifficeDataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DIGIFFICE_DATA_FOLDER"; // Todo: When the setup project is made, the project will ask for a directory to read/write data to and from.
                                                                                                                                             // It will likely be stored in a registry, which we will need to access to get the file path for the program's data.
                                                                                                                                             // Until then, this variable will be used as a placeholder for the file path.
                                                                                                                                             // We will set it to a default value, being a specific folder in the default documents library, until the setup project is made.
                                                                                                                                             // If testing, recommend creating the directory before running the program.

        public string globalDigifficePeercomputeDataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DIGIFFICE_DATA_FOLDER/Digiffice_Peercompute";
    }
}
