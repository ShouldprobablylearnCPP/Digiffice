using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficePeercompute
{
    internal class IdentifiableNetworkStream
    {
        public NetworkStream networkStream { get; set; }
        public string associatedUser { get; set; }
    }
}
