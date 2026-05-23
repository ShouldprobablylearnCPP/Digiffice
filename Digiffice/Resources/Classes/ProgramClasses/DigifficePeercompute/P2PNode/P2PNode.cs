using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digiffice.Resources.Classes.ProgramClasses.DigifficePeercompute._File;
using Microsoft.MixedReality.WebRTC;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficePeercompute.P2PNode
{
    public class P2PNode
    {
        // Class Variables
        private List<string> userList = new List<string>();
        private List<string> onlineUserList = new List<string>();
        private List<string> offlineUserList = new List<string>();

        List<PeerConnection> peerConnections = new List<PeerConnection>();
        PeerConnectionConfiguration peerConnectionConfig = new PeerConnectionConfiguration();

        public void initP2PNode(string directory, string username)
        {
            // Todo: Implement. Implementation should include: Attempt to connect to P2P network. If successful, store necessary information for future use. If unsuccessful, handle the error - let them retry, exit, and let them know to check if anyone in the network is online.
            DigifficeFileReaderDGPU fileReader = new DigifficeFileReaderDGPU();
            userList = fileReader.ReadDGPUFile(directory + "\\PEERCOMPUTE_USERS.dgpu");

            foreach (string user in userList)
            {
                if (user != username)
                {
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\suzan\\OneDrive\\Documents\\DigifficeDatabase.accdb");
                    OleDbCommand cmd = new OleDbCommand();

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM Digiffice_Accounts WHERE username = '" + user + "'";
                    OleDbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read() == true)
                    {
                        dr.Close();
                        cmd.CommandText = "SELECT user_online FROM Digiffice_Accounts WHERE username = '" + user + "'";
                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            bool isOnline = Convert.ToBoolean(result);
                            if (isOnline)
                            {
                                onlineUserList.Add(user);
                            }
                            else
                            {
                                offlineUserList.Add(user);
                            }
                        }
                    }

                    con.Close();
                }
            }

            // Attempt to connect to users on the network
            foreach (var user in onlineUserList)
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\suzan\\OneDrive\\Documents\\DigifficeDatabase.accdb");
                OleDbCommand cmd = new OleDbCommand();

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT user_ipv4 FROM Digiffice_Accounts WHERE username = '" + user + "'"; // Todo: add ipv6 support
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    dr.Close();
                    cmd.CommandText = "SELECT user_port FROM Digiffice_Accounts WHERE username = '" + user + "'";
                    dr = cmd.ExecuteReader();

                    if (dr.Read() == true)
                    {
                        
                    }
                }
            }
        }

        public List<string> getOnlineUserList()
        {
            return onlineUserList;
        }

        public List<string> getOfflineUserList()
        {
            return offlineUserList;
        }

        public void disconnectP2PNode()
        {

        }
    }
}
