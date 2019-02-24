using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SimpleTCP;
using System.Windows.Forms;
using System.Net;
using System.IO;
using static NetShare;

namespace LanManager
{
    public partial class LanManagerWindow : Form
    {
        public Setup mySetup = new Setup("Unknown", "127.0.0.1:44044");
        Games GamesWindow = new Games();
        SimpleTcpClient client = null;
        List<String> clientlist = new List<String>();
        ChatMessage msg;

        public String server_ip = "127.0.0.1";
        public int server_port = 44044;

        public LanManagerWindow()
        {
            InitializeComponent();
        }

        private string GetServerIP()
        {
            return this.server_ip;
        }

        public void SetServerData()
        {
            this.server_ip = mySetup.ServerUrl.Split(':')[0];
            this.server_port = Convert.ToInt32(mySetup.ServerUrl.Split(':')[1]);
            msg.Source = mySetup.Nickname;
        }

        private void SetupToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            mySetup.ShowDialog();
            if (mySetup.RefreshData)
            {
                SetServerData();
            }
        }

        private void ClientReconnect()
        {
            try
            {
                // Reconnect the TCP connection
                if (client != null)
                {
                    client.Disconnect();
                }
                client = new SimpleTcpClient();
                client.Connect(server_ip, server_port);
                client.StringEncoder = Encoding.UTF8;
                client.DataReceived += Client_DataReceived;

                // reconnect the chat messenger session -"Hello Msg"
                ChatMessage m = new ChatMessage("chat-hello", "server", "", mySetup.Nickname);
                SendMessage(m);

            }
            catch (Exception ex)
            {
                txtChat.Text = "Couldnt connect to server!";
            }
        }

        private void btnSendChatMessage_Click(object sender, EventArgs e)
        {
            SendChatMessage(txtMessage.Text);
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            ChatMessage response = new ChatMessage();
            response.DecodeMessage(e.MessageString);
                       
            if (response.Source != "any")
            { // only user and specific server messages are printed
                txtMessage.Invoke((MethodInvoker)delegate ()
                {
                    if (response.Type == "vote")
                    {
                        // here we have to do a special Handling for our VotingSystem
                        txtChat.Text += response.PrintChatMessage() + Environment.NewLine;
                    }
                    else if (response.Type == "chat")
                    {
                        /* common message
                         * message was received correctly from Server so we can show the message to
                         * our own text field
                         */                    
                        byte[] bytes = Encoding.Default.GetBytes(response.PrintChatMessage() + Environment.NewLine);
                        txtChat.Text += Encoding.UTF8.GetString(bytes);

                    }
                    else if (response.Type == "chat-hello") // hello/bye messages only have the username of the "new" member in payload
                    { // NEW Chat User
                        if (!clientlist.Contains(response.Payload))
                        {
                            txtChat.Text += String.Format("{0} has connected!{1}", response.Payload, Environment.NewLine);
                            clientlist.Add(response.Payload);
                        }
                        txtClientList.Clear();
                        foreach (string client in clientlist)
                        {
                            txtClientList.Text += client + Environment.NewLine;
                        }
                    }
                    else if (response.Type == "chat-bye")
                    {
                        // Chat User disconnected
                        if (!clientlist.Contains(response.Payload))
                        {
                            txtChat.Text += String.Format("{0} has disconnected!{0}", response.Payload, Environment.NewLine);
                            clientlist.Remove(response.Payload);
                        }
                        txtClientList.Clear();
                        foreach (string client in clientlist)
                        {
                            txtClientList.Text += client;
                        }
                    }

                });
            }
        }

        private void LanManagerWindow_Load(object sender, EventArgs e)
        {
            //client = new SimpleTcpClient();
            msg = new ChatMessage();
        }

        private void txtConnect_Click(object sender, EventArgs e)
        {
            SetServerData();
            ClientReconnect();
        }

        private void gamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GamesWindow.settings = mySetup;
            GamesWindow.ShowDialog();
        }

        private void btnRefreshGameList_Click(object sender, EventArgs e)
        {

        }

        private void txtMessage_MouseClick(object sender, MouseEventArgs e)
        {
            txtMessage.Text = "";
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                SendChatMessage(txtMessage.Text);
            }
        }


        public void SendMessage(ChatMessage m)
        {
            try
            {
                client.WriteLine(m.EncodeMessage());
            }
            catch (Exception ex)
            {
                txtChat.Text = "Could not Send Message! Check your Settings!";
            }
        }

        public void SendChatMessage(String txt)
        {
            ChatMessage m = new ChatMessage();
            try
            {
                if (txt == "") return;
                m.Source = mySetup.Nickname;
                m.Type = "chat";

                if (txt.StartsWith("!games?"))
                {
                    // here we have a voting request -> Check for args
                    msg.Type = "vote";
                }

                if (txt.StartsWith("!"))
                {
                    m.Type = "vote";
                }
                m.Payload = txt;
                client.WriteLine(m.EncodeMessage());
                txtMessage.Clear(); // reset txtMessage field
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                txtChat.Text = "Could not Send Message! Check your Settings!";
            }
        }


    }
}


