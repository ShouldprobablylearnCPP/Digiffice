using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup.Localizer;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficePeercompute.P2PNode
{
    public class P2PCommandProcessor
    {
        //
        // DP-CMD-P2P TYPE=NDE-CONNECT END-CMD
        // DP-CMD-P2P TYPE=NDE-CONNECT-RETURN USERNAME-LEN=[Username Len In Bytes] USERNAME="[USERNAME]" END-CMD
        // DP-CMD-P2P TYPE=SYNC-REQ END-CMD
        // DP-CMD-P2P TYPE=SYNC-REQ-ACCEPT END-CMD
        // DP-CMD-P2P TYPE=SYNC-START END-CMD
        // DP-CMD-P2P TYPE=SYNC-END END-CMD
        // DP-CMD-P2P TYPE=MESSAGE-GLOBAL MESSAGE-LEN=[message len in bytes] MESSAGE="[MESSAGE]" END-CMD
        // DP-CMD-P2P TYPE=SYNC-BLOCK BLOCK-LEN=[block len in bytes] BLOCK="[BLOCK]" END-CMD
        // DP-CMD-P2P TYPE=SYNC-BLOCK-ACCEPT END-CMD
        // DP-CMD-P2P TYPE-SYNC-BLOCK-RESOLVE END-CMD
        // DP-CMD-P2P TYPE=SYNC-CONTINUE END-CMD
        //

        public const string P2PCommandHeader = "DP-CMD-P2P";
        public const string P2PCommandEnd = "END-CMD";
        public enum P2PCommands
        {
            P2PConnected = 0,                               // NDE-CONNECT
            P2PConnectedReturn = 1,                         // NDE-CONNECT-RETURN
            P2PSyncRequest = 2,                             // SYNC-REQ
            P2PSyncRequestAccept = 3,                       // SYNC-REQ-ACCEPT
            P2PSyncStart = 4,                               // SYNC-START
            P2PSyncEnd = 5,                                 // SYNC-END
            P2PGlobalMessage = 6,                           // MESSAGE-GLOBAL
            P2PSyncBlock = 7,                               // SYNC-BLOCK
            P2PSyncBlockAccept = 8,                         // SYNC-BLOCK-ACCEPT
            P2PSyncBlockResolve = 9,                        // SYNC-BLOCK-RESOLVE
            P2PSyncContinue = 10,                           // SYNC-CONTINUE
        }

        public struct P2PCommand
        {
            public P2PCommands commandType = new P2PCommands();
            public List<string> parameters = new List<string>();

            public P2PCommand()
            {

            }
        }

        public P2PCommand ProcessRawP2PCommand(string rawCmd)
        {
            P2PCommand command = new P2PCommand();
            string block = string.Empty;

            for (int i = 0; i < rawCmd.Length; i++)
            {
                if (rawCmd[i] == ' ')
                {
                    int len = 0; // Only use for byte-length blocks

                    switch (block)
                    {
                        case P2PCommandHeader:
                        case P2PCommandEnd:
                            break;

                        case "TYPE=NDE-CONNECT":
                            command.commandType = P2PCommands.P2PConnected;
                            break;

                        case "TYPE=NDE-CONNECT-RETURN":
                            command.commandType = P2PCommands.P2PConnectedReturn;
                            break;

                        case "TYPE=SYNC-REQ":
                            command.commandType = P2PCommands.P2PSyncRequest;
                            break;

                        case "TYPE=SYNC-REQ-ACCEPT":
                            command.commandType = P2PCommands.P2PSyncRequestAccept;
                            break;

                        case "TYPE=SYNC-START":
                            command.commandType = P2PCommands.P2PSyncStart;
                            break;

                        case "TYPE=SYNC-END":
                            command.commandType = P2PCommands.P2PSyncEnd;
                            break;

                        case "TYPE=MESSAGE-GLOBAL":
                            command.commandType = P2PCommands.P2PGlobalMessage;
                            break;
                    }

                    if (block.StartsWith("USERNAME-LEN="))
                    {
                        len = int.Parse(block.Substring(13));
                        command.parameters.Add(block.Substring(13));
                    }

                    if (block.StartsWith("USERNAME=\""))
                    {
                        command.parameters.Add(block.Substring(10, len));
                    }

                    if (block.StartsWith("MESSAGE-LEN="))
                    {
                        len = int.Parse(block.Substring(12));
                        command.parameters.Add(block.Substring(12));
                    }

                    if (block.StartsWith("MESSAGE=\""))
                    {
                        command.parameters.Add(block.Substring(9, len));
                    }

                    block = string.Empty;
                }
                else
                {
                    block += rawCmd[i];
                }
            }

            return command;
        }

        public string constructP2PCommand(P2PCommand cmd)
        {
            string commandRaw = P2PCommandHeader + " TYPE=";

            switch (cmd.commandType)
            {
                case P2PCommands.P2PConnected:
                    commandRaw += "NDE-CONNECT";
                    break;

                case P2PCommands.P2PConnectedReturn:
                    commandRaw += "NDE-CONNECT-RETURN USERNAME-LEN=" + cmd.parameters[0] + " USERNAME=\"" + cmd.parameters[1] + "\"";
                    break;

                case P2PCommands.P2PSyncRequest:
                    commandRaw += "SYNC-REQ";
                    break;

                case P2PCommands.P2PSyncRequestAccept:
                    commandRaw += "SYNC-REQ-ACCEPT";
                    break;

                case P2PCommands.P2PSyncStart:
                    commandRaw += "SYNC-START";
                    break;

                case P2PCommands.P2PSyncEnd:
                    commandRaw += "SYNC-END";
                    break;

                case P2PCommands.P2PGlobalMessage:
                    commandRaw += "MESSAGE-GLOBAL MESSAGE-LEN=" + cmd.parameters[0] + " MESSAGE=\"" + cmd.parameters[1] + "\"";
                    break;

                case P2PCommands.P2PSyncBlock:
                    commandRaw += "SYNC-BLOCK BLOCK-LEN=" + cmd.parameters[0] + " BLOCK=\"" + cmd.parameters[1] + "\"";
                    break;

                case P2PCommands.P2PSyncBlockAccept:
                    commandRaw += "SYNC-BLOCK-ACCEPT";
                    break;

                case P2PCommands.P2PSyncBlockResolve:
                    commandRaw += "SYNC-BLOCK-RESOLVE";
                    break;

                case P2PCommands.P2PSyncContinue:
                    commandRaw += "SYNC-BLOCK-CONTINUE";
                    break;
            }

            commandRaw += " END-CMD";

            return commandRaw;
        }

        public bool doesCommandRequireResponse(P2PCommand command)
        {
            switch (command.commandType)
            {
                case P2PCommands.P2PConnected:
                case P2PCommands.P2PConnectedReturn:
                case P2PCommands.P2PSyncRequest:
                case P2PCommands.P2PSyncRequestAccept:
                case P2PCommands.P2PSyncStart:
                case P2PCommands.P2PSyncBlockAccept:
                case P2PCommands.P2PSyncContinue:
                    return true;

                case P2PCommands.P2PSyncEnd:
                case P2PCommands.P2PGlobalMessage:
                case P2PCommands.P2PSyncBlock:
                case P2PCommands.P2PSyncBlockResolve:
                    return false;
            }

            return false;
        }

        public P2PCommands getAppropriateResponseP2PCommand(P2PCommand command)
        {
            switch (command.commandType)
            {
                case P2PCommands.P2PConnected:
                    return P2PCommands.P2PConnectedReturn;

                case P2PCommands.P2PConnectedReturn:
                    return P2PCommands.P2PSyncRequest;

                case P2PCommands.P2PSyncRequest:
                    return P2PCommands.P2PSyncRequestAccept;

                case P2PCommands.P2PSyncRequestAccept:
                    return P2PCommands.P2PSyncStart;

                case P2PCommands.P2PSyncStart:
                    return P2PCommands.P2PSyncEnd; // Todo: Implement syncing

                case P2PCommands.P2PSyncBlockAccept:
                    return P2PCommands.P2PSyncBlock;

                case P2PCommands.P2PSyncContinue:
                    return P2PCommands.P2PSyncBlock;
            }

            return P2PCommands.P2PGlobalMessage; // Any command requiring no response is ok
        }
    }
}
