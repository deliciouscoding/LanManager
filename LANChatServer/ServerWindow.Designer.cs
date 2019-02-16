namespace LANChatServer
{
    partial class ServerWindow
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
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.txtServerStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(2, 9);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(100, 20);
            this.txtServerIP.TabIndex = 1;
            this.txtServerIP.Text = "127.0.0.1";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(108, 9);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(100, 20);
            this.txtServerPort.TabIndex = 2;
            this.txtServerPort.Text = "44044";
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(214, 6);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(75, 23);
            this.btnStartServer.TabIndex = 3;
            this.btnStartServer.Text = "Start";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(295, 6);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(75, 23);
            this.btnStopServer.TabIndex = 4;
            this.btnStopServer.Text = "Stop";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // txtServerStatus
            // 
            this.txtServerStatus.AcceptsReturn = true;
            this.txtServerStatus.Location = new System.Drawing.Point(13, 50);
            this.txtServerStatus.Multiline = true;
            this.txtServerStatus.Name = "txtServerStatus";
            this.txtServerStatus.ReadOnly = true;
            this.txtServerStatus.Size = new System.Drawing.Size(394, 419);
            this.txtServerStatus.TabIndex = 5;
            // 
            // ServerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 481);
            this.Controls.Add(this.txtServerStatus);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.txtServerPort);
            this.Controls.Add(this.txtServerIP);
            this.Name = "ServerWindow";
            this.Text = "LANManager Server";
            this.Load += new System.EventHandler(this.ServerWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.TextBox txtServerStatus;
    }
}

