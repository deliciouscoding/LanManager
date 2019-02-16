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
        SimpleTcpClient client;
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
                client.Disconnect();
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
            msg.Payload = txtMessage.Text;
            SendMessage(msg);
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
                        // common message
                        // message was received correctly from Server so we can show the message to
                        // our own text field
                        byte[] bytes = Encoding.Default.GetBytes(response.PrintChatMessage() + Environment.NewLine);
                        txtChat.Text += Encoding.UTF8.GetString(bytes);

                    }
                    else if (response.Type == "chat-hello")
                    {

                    }
                    else if (response.Type == "chat-bye")
                    {

                    }

                });
            }
        }

        private void LanManagerWindow_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
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
                msg.Payload = txtMessage.Text;
                SendMessage(this.msg);
            }
        }


        public void SendMessage(ChatMessage m)
        {
            try
            {   if (m.Payload == "") return;
                m.Source = mySetup.Nickname;
                m.Type = "chat";

                if (m.Payload.StartsWith("!games?"))
                {
                    // here we have a voting request -> Check for args
                    msg.Type = "vote";
                }

                if (m.Payload.StartsWith("!"))
                {
                    m.Type = "vote";
                }
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


