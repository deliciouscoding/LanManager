namespace LanManager
{
    partial class LanManagerWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LanManagerWindow));
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.einstellungenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SetupToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtClientList = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnRefreshGameList = new System.Windows.Forms.Button();
            this.txtGameList = new System.Windows.Forms.TextBox();
            this.lblGameList = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMessage.Location = new System.Drawing.Point(510, 558);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 0;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendChatMessage_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.AcceptsReturn = true;
            this.txtMessage.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtMessage.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtMessage.Location = new System.Drawing.Point(1, 558);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(495, 23);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.Text = "a";
            this.txtMessage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMessage_MouseClick);
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.einstellungenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(146, 26);
            // 
            // einstellungenToolStripMenuItem1
            // 
            this.einstellungenToolStripMenuItem1.Name = "einstellungenToolStripMenuItem1";
            this.einstellungenToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.einstellungenToolStripMenuItem1.Text = "Einstellungen";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetupToolStripMenuItem2,
            this.hilfeToolStripMenuItem,
            this.gamesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(678, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SetupToolStripMenuItem2
            // 
            this.SetupToolStripMenuItem2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetupToolStripMenuItem2.Name = "SetupToolStripMenuItem2";
            this.SetupToolStripMenuItem2.Size = new System.Drawing.Size(54, 20);
            this.SetupToolStripMenuItem2.Text = "Setup";
            this.SetupToolStripMenuItem2.Click += new System.EventHandler(this.SetupToolStripMenuItem2_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // gamesToolStripMenuItem
            // 
            this.gamesToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamesToolStripMenuItem.Name = "gamesToolStripMenuItem";
            this.gamesToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.gamesToolStripMenuItem.Text = "Games";
            this.gamesToolStripMenuItem.Click += new System.EventHandler(this.gamesToolStripMenuItem_Click);
            // 
            // txtChat
            // 
            this.txtChat.AcceptsReturn = true;
            this.txtChat.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtChat.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtChat.Location = new System.Drawing.Point(1, 27);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(414, 524);
            this.txtChat.TabIndex = 5;
            this.txtChat.Text = "This is a Test";
            // 
            // txtClientList
            // 
            this.txtClientList.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientList.Location = new System.Drawing.Point(421, 28);
            this.txtClientList.Multiline = true;
            this.txtClientList.Name = "txtClientList";
            this.txtClientList.Size = new System.Drawing.Size(155, 267);
            this.txtClientList.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(591, 558);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.txtConnect_Click);
            // 
            // btnRefreshGameList
            // 
            this.btnRefreshGameList.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshGameList.Location = new System.Drawing.Point(566, 320);
            this.btnRefreshGameList.Name = "btnRefreshGameList";
            this.btnRefreshGameList.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshGameList.TabIndex = 8;
            this.btnRefreshGameList.Text = "Refresh";
            this.btnRefreshGameList.UseVisualStyleBackColor = true;
            this.btnRefreshGameList.Click += new System.EventHandler(this.btnRefreshGameList_Click);
            // 
            // txtGameList
            // 
            this.txtGameList.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGameList.Location = new System.Drawing.Point(420, 344);
            this.txtGameList.Multiline = true;
            this.txtGameList.Name = "txtGameList";
            this.txtGameList.Size = new System.Drawing.Size(220, 207);
            this.txtGameList.TabIndex = 9;
            // 
            // lblGameList
            // 
            this.lblGameList.AutoSize = true;
            this.lblGameList.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameList.Location = new System.Drawing.Point(420, 325);
            this.lblGameList.Name = "lblGameList";
            this.lblGameList.Size = new System.Drawing.Size(61, 13);
            this.lblGameList.TabIndex = 10;
            this.lblGameList.Text = "GameList:";
            // 
            // LanManagerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(678, 587);
            this.Controls.Add(this.lblGameList);
            this.Controls.Add(this.txtGameList);
            this.Controls.Add(this.btnRefreshGameList);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtClientList);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSendMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LanManagerWindow";
            this.Text = "LANManager";
            this.Load += new System.EventHandler(this.LanManagerWindow_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SetupToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtClientList;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRefreshGameList;
        private System.Windows.Forms.TextBox txtGameList;
        private System.Windows.Forms.Label lblGameList;
        private System.Windows.Forms.ToolStripMenuItem gamesToolStripMenuItem;
    }
}

