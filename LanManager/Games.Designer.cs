namespace LanManager
{
    partial class Games
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Games));
            this.cboGameList = new System.Windows.Forms.ComboBox();
            this.btnInstallGame = new System.Windows.Forms.Button();
            this.lblGameInfo = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnLocalDestinationPath = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgressFilename = new System.Windows.Forms.Label();
            this.backgroundDownload = new System.ComponentModel.BackgroundWorker();
            this.lblProgress = new System.Windows.Forms.Label();
            this.backgroundUnrar = new System.ComponentModel.BackgroundWorker();
            this.txtInstallState = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboGameList
            // 
            this.cboGameList.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGameList.FormattingEnabled = true;
            this.cboGameList.Location = new System.Drawing.Point(12, 12);
            this.cboGameList.Name = "cboGameList";
            this.cboGameList.Size = new System.Drawing.Size(246, 21);
            this.cboGameList.Sorted = true;
            this.cboGameList.TabIndex = 0;
            this.cboGameList.Text = "Gamelist";
            this.cboGameList.SelectedIndexChanged += new System.EventHandler(this.cmbGameList_SelectedIndexChanged);
            // 
            // btnInstallGame
            // 
            this.btnInstallGame.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallGame.Location = new System.Drawing.Point(280, 49);
            this.btnInstallGame.Name = "btnInstallGame";
            this.btnInstallGame.Size = new System.Drawing.Size(75, 23);
            this.btnInstallGame.TabIndex = 1;
            this.btnInstallGame.Text = "Install";
            this.btnInstallGame.UseVisualStyleBackColor = true;
            this.btnInstallGame.Click += new System.EventHandler(this.btnInstallGame_Click);
            // 
            // lblGameInfo
            // 
            this.lblGameInfo.AutoSize = true;
            this.lblGameInfo.Location = new System.Drawing.Point(295, 15);
            this.lblGameInfo.Name = "lblGameInfo";
            this.lblGameInfo.Size = new System.Drawing.Size(0, 13);
            this.lblGameInfo.TabIndex = 2;
            // 
            // btnLocalDestinationPath
            // 
            this.btnLocalDestinationPath.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalDestinationPath.Location = new System.Drawing.Point(280, 10);
            this.btnLocalDestinationPath.Name = "btnLocalDestinationPath";
            this.btnLocalDestinationPath.Size = new System.Drawing.Size(75, 23);
            this.btnLocalDestinationPath.TabIndex = 3;
            this.btnLocalDestinationPath.Text = "Zielpfad";
            this.btnLocalDestinationPath.UseVisualStyleBackColor = true;
            this.btnLocalDestinationPath.Click += new System.EventHandler(this.btnLocalDestinationPath_Click);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.progressBar.Location = new System.Drawing.Point(12, 49);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(248, 23);
            this.progressBar.TabIndex = 4;
            // 
            // lblProgressFilename
            // 
            this.lblProgressFilename.AutoSize = true;
            this.lblProgressFilename.Location = new System.Drawing.Point(12, 276);
            this.lblProgressFilename.Name = "lblProgressFilename";
            this.lblProgressFilename.Size = new System.Drawing.Size(16, 13);
            this.lblProgressFilename.TabIndex = 5;
            this.lblProgressFilename.Text = " - ";
            // 
            // backgroundDownload
            // 
            this.backgroundDownload.WorkerReportsProgress = true;
            this.backgroundDownload.WorkerSupportsCancellation = true;
            this.backgroundDownload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundDownload_DoWork);
            this.backgroundDownload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundDownload_ProgressChanged);
            this.backgroundDownload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundDownload_RunWorkerCompleted);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblProgress.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(130, 54);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(25, 13);
            this.lblProgress.TabIndex = 6;
            this.lblProgress.Text = "0 %";
            // 
            // backgroundUnrar
            // 
            this.backgroundUnrar.WorkerReportsProgress = true;
            this.backgroundUnrar.WorkerSupportsCancellation = true;
            this.backgroundUnrar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundUnrar_DoWork);
            this.backgroundUnrar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundUnrar_ProgressChanged);
            this.backgroundUnrar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundUnrar_RunWorkerCompleted);
            // 
            // txtInstallState
            // 
            this.txtInstallState.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtInstallState.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstallState.Location = new System.Drawing.Point(12, 87);
            this.txtInstallState.Multiline = true;
            this.txtInstallState.Name = "txtInstallState";
            this.txtInstallState.Size = new System.Drawing.Size(343, 186);
            this.txtInstallState.TabIndex = 7;
            // 
            // Games
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(501, 330);
            this.Controls.Add(this.txtInstallState);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblProgressFilename);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnLocalDestinationPath);
            this.Controls.Add(this.lblGameInfo);
            this.Controls.Add(this.btnInstallGame);
            this.Controls.Add(this.cboGameList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Games";
            this.Text = "Games";
            this.Load += new System.EventHandler(this.Games_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboGameList;
        private System.Windows.Forms.Button btnInstallGame;
        private System.Windows.Forms.Label lblGameInfo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnLocalDestinationPath;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgressFilename;
        private System.ComponentModel.BackgroundWorker backgroundDownload;
        private System.Windows.Forms.Label lblProgress;
        private System.ComponentModel.BackgroundWorker backgroundUnrar;
        private System.Windows.Forms.TextBox txtInstallState;
    }
}