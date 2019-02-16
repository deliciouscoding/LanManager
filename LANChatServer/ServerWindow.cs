using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using SimpleTCP;
using System.Windows.Forms;

namespace LANChatServer
{
    public partial class ServerWindow : Form
    {
        public ServerWindow()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;
        ChatMessage msg;
        Voting vote;

        private void ServerWindow_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13; // enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;
            server.ClientConnected += Server_NewClientConnected;
        }

        private void Server_NewClientConnected(object sender, System.Net.Sockets.TcpClient e)
        {
            ChatMessage info = new ChatMessage("info", "", "server", String.Format("New Client: connected") + Environment.NewLine);
            txtServerStatus.Invoke((MethodInvoker)delegate ()
            {
                txtServerStatus.Text += info.PrintChatMessage();
                // Now we have to send this message to all Clients...
                server.BroadcastLine(info.EncodeMessage());
            });
        }


        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            msg.DecodeMessage(e.MessageString);
            String serverTxt_buf = "";
            if (msg.Type == "chat")
            {
                // Now we have to send this message to all Clients...
                serverTxt_buf += msg.PrintChatMessage() + Environment.NewLine;
                server.BroadcastLine(e.MessageString);
            }

            if (msg.Type == "chat-hello")
            {
                server.BroadcastLine(msg.EncodeMessage());
            }

            if (msg.Type == "chat-bye")
            {
                server.BroadcastLine(msg.EncodeMessage());
            }

            if (msg.Type == "vote")
            {  // Here we have to do the voting stuff... 
               /**
                 * 1. Create a voting instance (only one at once)
                 * 2. Contact all clients about voting 
                 * 3. Listen for votings and send them to the voting instance
                 * 3a. Make sure everyone has only one "ticket" -> take the newest one
                 * 4. wait till 120seconds // we may set the timer by user (for a range 1 to 10min?)
                 * 4a. !result results in bc of current state of votings.. may be not..
                 * 5. Send Broadcast with Result
                 * 
                 */
                if (msg.Payload.StartsWith("!games?"))
                {
                    vote = new Voting();
                    string[] OptionList = msg.Payload.Replace("!games?", "").TrimEnd(':').Split(':');
                    if (!vote.is_running && OptionList.Length >= 1)
                    {
                        // instatiate
                        vote.Start();
                        System.Timers.Timer runonce = new System.Timers.Timer(120000);
                        runonce.Elapsed += (s, evt) => { vote.Stop(); SendVotingResults(); };
                        runonce.AutoReset = false;
                        runonce.Start();

                        serverTxt_buf += "Voting has started: " + Environment.NewLine;
                        foreach (string item in OptionList)
                        {
                            vote.Options.Add(item, 0);
                            serverTxt_buf += item + Environment.NewLine;
                        }
                        // send Voting to all Clients
                        server.BroadcastLine(e.MessageString.Replace(":", "\n").Replace("?", "?\n"));
                    }
                }
                else
                {
                    String key = msg.Payload.Replace("!", "");
                    if (vote.Options.ContainsKey(key))
                    {
                        // is a valid key to vote for
                        if (vote.Voter.ContainsKey(msg.Source))
                        {
                            // already voted:
                            String old_key = vote.Voter[msg.Source];
                            if (vote.Options.ContainsKey(old_key))
                            {
                                // only if it was a valid key...
                                vote.Options[old_key]--;
                            }
                            vote.Voter[msg.Source] = key;
                        } else
                        {
                            vote.Voter.Add(msg.Source, key);
                        }
                        vote.Options[key]++;

                        serverTxt_buf += msg.Source + ":" + key + ": " + Convert.ToString(vote.Options[key]) + Environment.NewLine;
                    }
                }
            }
            txtServerStatus.Invoke((MethodInvoker)delegate ()
            {
                // here we set the StatusText whithin the Thread which is responsible for this windows form
                txtServerStatus.Text += serverTxt_buf;
            });
        }


        private void SendVotingResults()
        {
            String result = vote.GetVotingResult();
            ChatMessage resultMsg = new ChatMessage("vote", "", "server", "Voting Finished: Winner!: "+ result);
            server.BroadcastLine(resultMsg.EncodeMessage());
            // todo we have no Access to ServerStatus.Text becaus it is in a different thread..
            txtServerStatus.Invoke((MethodInvoker)delegate ()
            {
                txtServerStatus.Text += resultMsg.PrintChatMessage() + Environment.NewLine;
            });
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (!server.IsStarted)
            {
                System.Net.IPAddress ip;
                msg = new ChatMessage();
                ip = System.Net.IPAddress.Parse(txtServerIP.Text);
                txtServerStatus.Text = "Server is started.." + Environment.NewLine;
                server.Start(ip, Convert.ToInt32(txtServerPort.Text));
            }
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
            {
                txtServerStatus.Text = "Server is stopped!" + Environment.NewLine;
                server.Stop();
            }
        }
        
    }
}
