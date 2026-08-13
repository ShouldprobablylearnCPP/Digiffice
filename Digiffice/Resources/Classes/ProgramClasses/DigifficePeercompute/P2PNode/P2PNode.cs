using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
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
        string _username;

        // Connection Variables
        public TcpListener localNodeTcpListener;
        public List<TcpClient> outClients = new List<TcpClient>();
        public List<TcpClient> inNodes = new List<TcpClient>();
        List<IdentifiableNetworkStream> streams = new List<IdentifiableNetworkStream>();

        public int localConnectionPort;

        public CancellationTokenSource localNodeTcpListenerCTokenSource;

        public void initP2PNode(string localDirectory, nonprotected_AccountData nonprotected_ac)
        {
            // Todo: Implement. Implementation should include: Attempt to connect to P2P network. If successful, store necessary information for future use. If unsuccessful, handle the error - let them retry, exit, and let them know to check if anyone in the network is online.
            directory = localDirectory;
            _username = nonprotected_ac.ac_username;

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
                if (user != nonprotected_ac.ac_username)
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
                    connectLocalP2PNodeTo(ipv4, ipv6, int.Parse(port));
                }

                con.Close();
            }

            //beginListeningForP2PNodes();
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

            foreach (IdentifiableNetworkStream stream in streams)
            {
                try { stream.networkStream.Close(); } catch { }
            }
            streams.Clear();
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

                    Task.Run(() => StartP2PSession(extClient, cToken, true));
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
                    Task.Run(() => StartP2PSession(client, cToken, false));
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

        public async Task StartP2PSession(TcpClient node, CancellationToken cToken, bool isLazy)
        {
            using (node)
            using (NetworkStream stream = node.GetStream())
            using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: true))
            {
                string discoveredPeerUsername = string.Empty;

                if (!isLazy)
                {
                    P2PCommandProcessor.P2PCommand outCmd = new P2PCommandProcessor.P2PCommand();
                    outCmd.commandType = P2PCommandProcessor.P2PCommands.P2PConnected;
                    sendCommandToNode(node, outCmd);
                    MessageBox.Show("sent first cmd: " + outCmd.commandType.ToString());
                }

                StringBuilder streamBuffer = new StringBuilder();

                while (!cToken.IsCancellationRequested)
                {
                    try
                    {
                        char ch = reader.ReadChar();
                        streamBuffer.Append(ch);

                        string currentText = streamBuffer.ToString();

                        if (!currentText.Contains(P2PCommandProcessor.P2PCommandHeader))
                        {
                            if (streamBuffer.Length > 20)
                            {
                                streamBuffer.Clear();
                            }
                            continue;
                        }

                        if (currentText.StartsWith(" ") || !currentText.StartsWith(P2PCommandProcessor.P2PCommandHeader))
                        {
                            int headerIdx = currentText.IndexOf(P2PCommandProcessor.P2PCommandHeader);
                            streamBuffer.Remove(0, headerIdx);
                            currentText = streamBuffer.ToString();
                        }

                        if (currentText.EndsWith(P2PCommandProcessor.P2PCommandEnd))
                        {
                            int startIdx = P2PCommandProcessor.P2PCommandHeader.Length;
                            int length = currentText.Length - P2PCommandProcessor.P2PCommandHeader.Length - P2PCommandProcessor.P2PCommandEnd.Length;

                            P2PCommandProcessor commandProcessor = new P2PCommandProcessor();

                            P2PCommandProcessor.P2PCommand inCmd = commandProcessor.ProcessRawP2PCommand(currentText.Substring(startIdx, length));
                            MessageBox.Show("Recieved cmd: " + inCmd.commandType.ToString() + " raw: " + currentText.Substring(startIdx, length));

                            switch (inCmd.commandType)
                            {
                                case P2PCommandProcessor.P2PCommands.P2PConnectedReturn:
                                    IdentifiableNetworkStream identifiableNetworkStream = new IdentifiableNetworkStream();

                                    identifiableNetworkStream.networkStream = stream;
                                    identifiableNetworkStream.associatedUser = inCmd.parameters[1];
                                    discoveredPeerUsername = inCmd.parameters[1];

                                    //
                                    // Todo: Add when multiple devices can use the login system
                                    //
                                    //if (!verifyUserIsAuthorised(discoveredPeerName))
                                    //{
                                    //    foreach (IdentifiableNetworkStream IDstream in streams)
                                    //    {
                                    //        if (IDstream.networkStream == stream)
                                    //        {
                                    //            streams.Remove(IDstream);
                                    //            try { IDstream.networkStream.Close(); } catch { }
                                    //        }
                                    //    }
                                    //
                                    //    foreach (TcpClient client in inNodes)
                                    //    {
                                    //        if (node == client)
                                    //        {
                                    //            inNodes.Remove(client);
                                    //            try { node.Close(); } catch { }
                                    //        }
                                    //    }
                                    //
                                    //    return;
                                    //}
                                    //

                                    streams.Add(identifiableNetworkStream);
                                    break;

                                case P2PCommandProcessor.P2PCommands.P2PGlobalMessage:
                                    // Todo: Add Global Message sending
                                    break;
                            }

                            if (commandProcessor.doesCommandRequireResponse(inCmd))
                            {
                                P2PCommandProcessor.P2PCommands p2pCommandType = commandProcessor.getAppropriateResponseP2PCommand(inCmd);
                                P2PCommandProcessor.P2PCommand outCmd = new P2PCommandProcessor.P2PCommand();

                                switch (p2pCommandType)
                                {
                                    case P2PCommandProcessor.P2PCommands.P2PConnected:
                                    case P2PCommandProcessor.P2PCommands.P2PSyncRequest:
                                    case P2PCommandProcessor.P2PCommands.P2PSyncRequestAccept:
                                    case P2PCommandProcessor.P2PCommands.P2PSyncStart:
                                    case P2PCommandProcessor.P2PCommands.P2PSyncEnd:
                                        outCmd.commandType = p2pCommandType;
                                        break;

                                    case P2PCommandProcessor.P2PCommands.P2PConnectedReturn:
                                        outCmd.commandType = p2pCommandType;
                                        outCmd.parameters.Add(_username.Length.ToString());
                                        outCmd.parameters.Add(_username);
                                        break;

                                    case P2PCommandProcessor.P2PCommands.P2PGlobalMessage:
                                        outCmd.commandType = p2pCommandType;
                                        //outCmd.parameters.Add(messageToSend.Length.ToString());
                                        //outCmd.parameters.Add(messageToSend);
                                        break;
                                }

                                sendCommandToNode(node, outCmd);
                                MessageBox.Show("sent cmd: " + outCmd.commandType.ToString());
                            }

                            currentText = string.Empty;
                            streamBuffer.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            EndOfStreamException eos = (EndOfStreamException)ex;
                            MessageBox.Show("Peer " + discoveredPeerUsername + " Disconnected");

                            foreach (IdentifiableNetworkStream IDstream in streams)
                            {
                                if (IDstream.networkStream == stream)
                                {
                                    streams.Remove(IDstream);
                                    try { IDstream.networkStream.Close(); } catch { }
                                }
                            }

                            foreach (TcpClient client in inNodes)
                            {
                                if (node == client)
                                {
                                    inNodes.Remove(client);
                                    try { node.Close(); } catch { }
                                }
                            }

                            break;
                        }
                        catch (Exception ex2)
                        {

                        }

                        MessageBox.Show("Error with p2p session. Source: StartP2PSession(). msg: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
        }

        // Communication Methods
        
        public void sendCommandToNode(TcpClient node, P2PCommandProcessor.P2PCommand cmd)
        {
            string commandStr = P2PCommandProcessor.P2PCommandHeader + " TYPE=";

            switch (cmd.commandType)
            {
                case P2PCommandProcessor.P2PCommands.P2PConnected:
                    commandStr += "NDE-CONNECT";
                    break;

                case P2PCommandProcessor.P2PCommands.P2PConnectedReturn:
                    commandStr += "NDE-CONNECT-RETURN USERNAME-LEN=" + cmd.parameters[0] + " USERNAME=\"" + cmd.parameters[1] + "\"";
                    break;

                case P2PCommandProcessor.P2PCommands.P2PSyncRequest:
                    commandStr += "SYNC-REQ";
                    break;

                case P2PCommandProcessor.P2PCommands.P2PSyncRequestAccept:
                    commandStr += "SYNC-REQ-ACCEPT";
                    break;

                case P2PCommandProcessor.P2PCommands.P2PSyncStart:
                    commandStr += "SYNC-START";
                    break;

                case P2PCommandProcessor.P2PCommands.P2PSyncEnd:
                    commandStr += "SYNC-END";
                    break;

                case P2PCommandProcessor.P2PCommands.P2PGlobalMessage:
                    commandStr += "MESSAGE-GLOBAL MESSAGE-LEN=" + cmd.parameters[0] + " MESSAGE=\"" + cmd.parameters[1] + "\"";
                    break;
            }

            commandStr += " END-CMD";

            using (BinaryWriter writer = new BinaryWriter(node.GetStream(), Encoding.UTF8, true))
            {
                writer.Write(commandStr + " ");
                writer.Flush();
            }

            commandStr = string.Empty;
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
