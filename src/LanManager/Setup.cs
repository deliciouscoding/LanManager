using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanManager
{
    public partial class Setup : Form
    {

        public String Nickname;
        public String ServerUrl;
        public Boolean RefreshData = false;
        public String GameServerPath;
        public String GameServerUser;
        public String GameServerPW;
        public Boolean Debug = true;


        public Setup()
        {
            InitializeComponent();
        }

        public Setup (String Nickname, String Url)
        {
            InitializeComponent();
            this.Nickname = Nickname;
            this.ServerUrl = Url;
        }
       

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            Nickname = txtChatNickname.Text;
            ServerUrl = txtServerUrl.Text;
            GameServerPath = txtGameServerPath.Text;
            GameServerUser = txtGameServerUser.Text;
            GameServerPW = txtGameServerPW.Text;
            Debug = cbDebug.Checked;
            RefreshData = true;
            this.Close();
        }

        private void Setup_Load(object sender, EventArgs e)
        {

        }

    }
}
