namespace LanManager
{
    partial class Setup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup));
            this.txtServerUrl = new System.Windows.Forms.TextBox();
            this.labelServerUrl = new System.Windows.Forms.Label();
            this.buttonSetupAccept = new System.Windows.Forms.Button();
            this.txtChatNickname = new System.Windows.Forms.TextBox();
            this.labelNickName = new System.Windows.Forms.Label();
            this.txtGameServerPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGameServerUser = new System.Windows.Forms.TextBox();
            this.txtGameServerPW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGameServerPW = new System.Windows.Forms.Label();
            this.cbDebug = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtServerUrl
            // 
            this.txtServerUrl.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerUrl.Location = new System.Drawing.Point(84, 15);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.Size = new System.Drawing.Size(173, 20);
            this.txtServerUrl.TabIndex = 0;
            this.txtServerUrl.Text = "192.168.178.5:44044";
            // 
            // labelServerUrl
            // 
            this.labelServerUrl.AutoSize = true;
            this.labelServerUrl.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerUrl.Location = new System.Drawing.Point(17, 18);
            this.labelServerUrl.Name = "labelServerUrl";
            this.labelServerUrl.Size = new System.Drawing.Size(61, 13);
            this.labelServerUrl.TabIndex = 1;
            this.labelServerUrl.Text = "ServerUrl";
            // 
            // buttonSetupAccept
            // 
            this.buttonSetupAccept.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetupAccept.Location = new System.Drawing.Point(436, 437);
            this.buttonSetupAccept.Name = "buttonSetupAccept";
            this.buttonSetupAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonSetupAccept.TabIndex = 2;
            this.buttonSetupAccept.Text = "Annehmen";
            this.buttonSetupAccept.UseVisualStyleBackColor = true;
            this.buttonSetupAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // txtChatNickname
            // 
            this.txtChatNickname.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChatNickname.Location = new System.Drawing.Point(84, 51);
            this.txtChatNickname.MaxLength = 16;
            this.txtChatNickname.Name = "txtChatNickname";
            this.txtChatNickname.Size = new System.Drawing.Size(173, 20);
            this.txtChatNickname.TabIndex = 3;
            this.txtChatNickname.Text = "Unknown";
            // 
            // labelNickName
            // 
            this.labelNickName.AutoSize = true;
            this.labelNickName.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNickName.Location = new System.Drawing.Point(23, 54);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(55, 13);
            this.labelNickName.TabIndex = 4;
            this.labelNickName.Text = "Nickname";
            // 
            // txtGameServerPath
            // 
            this.txtGameServerPath.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGameServerPath.Location = new System.Drawing.Point(84, 88);
            this.txtGameServerPath.Name = "txtGameServerPath";
            this.txtGameServerPath.Size = new System.Drawing.Size(173, 20);
            this.txtGameServerPath.TabIndex = 5;
            this.txtGameServerPath.Text = "\\\\192.168.178.5\\LANGames_Installer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "GameServer";
            // 
            // txtGameServerUser
            // 
            this.txtGameServerUser.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGameServerUser.Location = new System.Drawing.Point(299, 88);
            this.txtGameServerUser.Name = "txtGameServerUser";
            this.txtGameServerUser.Size = new System.Drawing.Size(82, 20);
            this.txtGameServerUser.TabIndex = 7;
            this.txtGameServerUser.Text = "lanparty";
            // 
            // txtGameServerPW
            // 
            this.txtGameServerPW.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGameServerPW.Location = new System.Drawing.Point(412, 88);
            this.txtGameServerPW.Name = "txtGameServerPW";
            this.txtGameServerPW.Size = new System.Drawing.Size(93, 20);
            this.txtGameServerPW.TabIndex = 8;
            this.txtGameServerPW.Text = "freegames";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(263, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "User";
            // 
            // lblGameServerPW
            // 
            this.lblGameServerPW.AutoSize = true;
            this.lblGameServerPW.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameServerPW.Location = new System.Drawing.Point(387, 91);
            this.lblGameServerPW.Name = "lblGameServerPW";
            this.lblGameServerPW.Size = new System.Drawing.Size(19, 13);
            this.lblGameServerPW.TabIndex = 10;
            this.lblGameServerPW.Text = "PW";
            // 
            // cbDebug
            // 
            this.cbDebug.AutoSize = true;
            this.cbDebug.Checked = true;
            this.cbDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDebug.Enabled = false;
            this.cbDebug.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDebug.Location = new System.Drawing.Point(277, 17);
            this.cbDebug.Name = "cbDebug";
            this.cbDebug.Size = new System.Drawing.Size(104, 17);
            this.cbDebug.TabIndex = 11;
            this.cbDebug.Text = "Log Debugdata";
            this.cbDebug.UseVisualStyleBackColor = true;
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(523, 472);
            this.Controls.Add(this.cbDebug);
            this.Controls.Add(this.lblGameServerPW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGameServerPW);
            this.Controls.Add(this.txtGameServerUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGameServerPath);
            this.Controls.Add(this.labelNickName);
            this.Controls.Add(this.txtChatNickname);
            this.Controls.Add(this.buttonSetupAccept);
            this.Controls.Add(this.labelServerUrl);
            this.Controls.Add(this.txtServerUrl);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setup";
            this.Text = "Setup";
            this.Load += new System.EventHandler(this.Setup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServerUrl;
        private System.Windows.Forms.Label labelServerUrl;
        private System.Windows.Forms.Button buttonSetupAccept;
        private System.Windows.Forms.TextBox txtChatNickname;
        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.TextBox txtGameServerPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGameServerUser;
        private System.Windows.Forms.TextBox txtGameServerPW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGameServerPW;
        private System.Windows.Forms.CheckBox cbDebug;
    }
}