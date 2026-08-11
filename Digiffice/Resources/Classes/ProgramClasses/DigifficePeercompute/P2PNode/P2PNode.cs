using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using Digiffice.Resources.Classes.ProgramClasses.DigifficePeercompute._File;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficePeercompute.P2PNode
{
    public class P2PNode
    {
        // Class Variables
        private List<string> userList = new List<string>();
        private List<string> onlineUserList = new List<string>();
        private List<string> offlineUserList = new List<string>();

        // Peercompute variables
        string directory;

        // Connection Variables
        public TcpListener localNodeTcpListener;
        public List<TcpClient> outClients = new List<TcpClient>();
        public List<TcpClient> inNodes = new List<TcpClient>();
        public List<NetworkStream> inStreams = new List<NetworkStream>();
        public List<NetworkStream> outStreams = new List<NetworkStream>();

        public int localConnectionPort;

        public CancellationTokenSource localNodeTcpListenerCTokenSource;

        public void initP2PNode(string localDirectory, string username)
        {
            // Todo: Implement. Implementation should include: Attempt to connect to P2P network. If successful, store necessary information for future use. If unsuccessful, handle the error - let them retry, exit, and let them know to check if anyone in the network is online.
            directory = localDirectory;

            DigifficeFileReaderDGPD digifficeFileReaderDGPD = new DigifficeFileReaderDGPD();
            localConnectionPort = digifficeFileReaderDGPD.readDGPDLocalPort(directory + "\\PEERCOMPUTE_DATA.dgpd");

            DigifficeFileReaderDGPU digifficeFileReaderDGPU = new DigifficeFileReaderDGPU();
            userList = digifficeFileReaderDGPU.ReadDGPUFile(directory + "\\PEERCOMPUTE_USERS.dgpu");

            localNodeTcpListener = new TcpListener(IPAddress.Any, localConnectionPort);
            localNodeTcpListener.Start();

            localNodeTcpListenerCTokenSource = new CancellationTokenSource();


            // TESTING P2P

            beginListeningForP2PNodes();

            string testIpv4 = string.Empty;
            string testIpv6 = string.Empty;
            string testPort = string.Empty;

            EnterTextValueForm enterIPV4 = new EnterTextValueForm("Enter an ipv4 address:");
            DialogResult enterIPV4Result = enterIPV4.ShowDialog();

            if (enterIPV4Result == DialogResult.OK)
            {
                testIpv4 = enterIPV4.value;
            }

            EnterTextValueForm enterIPV6 = new EnterTextValueForm("Enter an ipv6 address:");
            DialogResult enterIPV6Result = enterIPV6.ShowDialog();

            if (enterIPV6Result == DialogResult.OK)
            {
                testIpv6 = enterIPV6.value;
            }

            EnterTextValueForm enterPort = new EnterTextValueForm("Enter a port:");
            DialogResult enterPortResult = enterPort.ShowDialog();

            if (enterPortResult == DialogResult.OK)
            {
                testPort = enterPort.value;
            }

            connectLocalP2PNodeTo(testIpv4, testIpv6, int.Parse(testPort));

            return;

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
                OleDbDataReader dr = null;

                con.Open();
                cmd.Connection = con;

                // Use this when the database is live.
                string ipv4 = retrieveIPV4Info(user, dr, cmd);
                string ipv6 = retrieveIPV6Info(user, dr, cmd);
                string port = retrievePortInfo(user, dr, cmd);

                if (ipv4 != null || ipv4 != "" || ipv6 != null || ipv6 != "" || port != null)
                {
                    //beginListeningForP2PNodes();
                    connectLocalP2PNodeTo(ipv4, ipv6, int.Parse(port));
                }

                con.Close();
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

        // Connection methods
        public void beginListeningForP2PNodes()
        {
            Task.Run(() => listenForP2PNodes(localNodeTcpListenerCTokenSource.Token));
        }

        public void connectLocalP2PNodeTo(string ipv4, string ipv6, int port)
        {
            TcpClient client = new TcpClient();
            outClients.Add(client);

            Task.Run(() => connectToNode(localNodeTcpListenerCTokenSource.Token, ipv4, ipv6, port, client));
        }

        public void disconnectLocalP2PNode()
        {
            // Todo: Disconnect from the network by severing the connection.

            localNodeTcpListenerCTokenSource.Cancel();

            if (localNodeTcpListener != null)
            {
                localNodeTcpListener.Stop();
                localNodeTcpListener.Dispose();
            }

            foreach (TcpClient client in outClients)
            {
                if (client != null)
                {
                    try { client.Close(); } catch { }
                    try { client.Dispose(); } catch { }
                }
            }
            outClients.Clear();
        }

        // Connection tasks
        public async Task listenForP2PNodes(CancellationToken cToken)
        {
            while (!cToken.IsCancellationRequested)
            {
                try
                {
                    TcpClient extClient = await localNodeTcpListener.AcceptTcpClientAsync();
                    inNodes.Add(extClient);

                    Task.Run(() => RecieveP2PData(extClient, cToken));
                }
                catch (Exception ex)
                {
                    if (!cToken.IsCancellationRequested)
                    {
                        MessageBox.Show("Error connecting to P2P Node. Source: listenForP2PNodes(). msg: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
            }

            return;
        }

        public async Task connectToNode(CancellationToken cToken, string ipv4, string ipv6, int port, TcpClient client)
        {
            while (!cToken.IsCancellationRequested)
            {
                try
                {
                    await client.ConnectAsync(ipv4, port);
                    outStreams.Add(client.GetStream());
                    break;
                }
                catch (Exception ex)
                {
                    if (!cToken.IsCancellationRequested)
                    {
                        MessageBox.Show("Error connecting to P2P Node. Source: connectToNode(). msg: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
            }

            return;
        }

        public async Task RecieveP2PData(TcpClient node, CancellationToken cToken)
        {
            using (node)
            using (NetworkStream inStream = node.GetStream())
            {
                inStreams.Add(inStream);
                byte[] buffer = new byte[4096];

                while (!cToken.IsCancellationRequested)
                {
                    try
                    {
                        int bytesRead = await inStream.ReadAsync(buffer, 0, buffer.Length);

                        if (bytesRead == 0) // Disconnection
                        {
                            break;
                        }

                        string recievedMsg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        MessageBox.Show("Recieved message: " + recievedMsg);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading p2p stream. Source: RecieveP2PData(). msg: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
        }

        // Communication Methods

        public async Task writeToStream(NetworkStream stream)
        {

        }

        // Other Methods
        public string retrieveIPV4Info(string user, OleDbDataReader dr, OleDbCommand cmd)
        {
            string returnStr;

            cmd.CommandText = "SELECT user_ipv4 FROM Digiffice_Accounts WHERE username = '" + user + "'";
            dr = cmd.ExecuteReader();
            returnStr = dr.Read() ? dr["user_ipv4"].ToString() : "";
            dr.Close();

            return returnStr;
        }

        public string retrieveIPV6Info(string user, OleDbDataReader dr, OleDbCommand cmd)
        {
            string returnStr;

            cmd.CommandText = "SELECT user_ipv6 FROM Digiffice_Accounts WHERE username = '" + user + "'";
            dr = cmd.ExecuteReader();
            returnStr = dr.Read() ? dr["user_ipv6"].ToString() : "";
            dr.Close();

            return returnStr;
        }

        public string retrievePortInfo(string user, OleDbDataReader dr, OleDbCommand cmd)
        {
            string returnStr;

            cmd.CommandText = "SELECT user_port FROM Digiffice_Accounts WHERE username = '" + user + "'";
            dr = cmd.ExecuteReader();
            returnStr = dr.Read() ? dr["user_port"].ToString() : "";
            dr.Close();

            return returnStr;
        }
    }
}
