using NUnrar.Archive;
using NUnrar.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using static NetShare;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using SharpCompress.Archives;
using SharpCompress.Common;
using System.Threading;
using System.Diagnostics;

namespace LanManager
{
    public partial class Games : Form
    {
        public Games()
        {
            InitializeComponent();
        }

        public string networkPath = @"\\192.168.178.25\LANGames_Installer";
        NetworkCredential credentials = null;
        public string myNetworkPath = string.Empty;
        public Game choosenGame;
        Dictionary<String, Game> GameList = new Dictionary<string, Game>();
        public Setup settings = null;
        public String Output = "";
        

        private void Games_Load(object sender, EventArgs e)
        {
            try
            {
                networkPath = @settings.GameServerPath;
                credentials = new NetworkCredential(settings.GameServerUser, settings.GameServerPW);

                string[] filelist = GetFileList("");
                foreach (string f in filelist)
                {
                    Game g = new Game();
                    g.installer = new InstallerCFG();
                    g.Displayname = f.Replace(networkPath + "\\", "").Replace(".rar", "");
                    g.Networkpath = f;
                    cboGameList.Items.Add(g.Displayname);
                    GameList.Add(g.Displayname, g);
                }
                txtInstallState.Text = String.Format("Connected to: [{0}:{1}@{2}]", settings.GameServerUser, settings.GameServerPW, settings.GameServerPath);
            }
            catch (Exception ex)
            {
                txtInstallState.Text = String.Format("No Connection to Server: [{0}:{1}@{2}]", settings.GameServerPath, settings.GameServerUser, settings.GameServerPW);
            }
        }

        private void ResetGamesWindow()
        {
            txtInstallState.Text = "";
            lblProgress.Text = "0%";
            choosenGame.DownloadPath = "";
        }

        private void cmbGameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GameList.ContainsKey(cboGameList.Text))
            {
                choosenGame = GameList[cboGameList.Text];
                ResetGamesWindow();
            }
        }

        public string[] GetFileList(string path)
        {
            string[] fileList = null;
            using (new ConnectToSharedFolder(networkPath, credentials))
            {
                fileList = Directory.GetFiles(networkPath + path);
            }
            return fileList;
        }


        static void DataOutputEventHandler(object sender, DataAddedEventArgs e)
        {
            String newRecord = ((PSDataCollection<String>)sender)[e.Index];
        }


        public String MountImage(String imagePath)
        {
            String isopath = "";
            // mount image snippet
            if (imagePath == "")
            {
                isopath = @"E:\Projekte\C#\LAN-Manger\LanManager\LanManager\bin\Debug\Rocket_League.iso";
            } else
            {
                isopath = imagePath;
            }
            PowerShell ps_mount = PowerShell.Create();
            PowerShell ps_mounted_info = PowerShell.Create();
            txtInstallState.Text = string.Format("Mount Image: {0}", isopath);
            ps_mount.AddCommand("Mount-DiskImage").AddParameter("ImagePath", isopath).Invoke();
            ps_mount.Dispose();

            ps_mounted_info.AddCommand("Get-DiskImage").AddParameter("ImagePath", isopath);
            ps_mounted_info.AddCommand("Get-Volume");
            
            // invoke execution on the pipeline (collecting output)
            Collection<PSObject> PSOutput = ps_mounted_info.Invoke();

            // loop through each output object item
            foreach (PSObject outputItem in PSOutput)
            {
                // if null object was dumped to the pipeline during the script then a null
                // object may be present here. check for null to prevent potential NRE.
                if (outputItem != null)
                {
                    // get the mounted disk letter
                    return outputItem.Members["DriveLetter"].Value.ToString();
                }
            }
            return "";
        }

        public void UnMountImage(String imagePath)
        {
            PowerShell ps = PowerShell.Create();
            // AFTER SETUP FINISHED: UNMOUNT
            txtInstallState.Text = string.Format("DisMount Image: {0}", imagePath);
            ps.AddCommand("Dismount-DiskImage").AddParameter("ImagePath", imagePath).Invoke();
            ps.Dispose();
        }

        
        private void InstallFromImage(Game g)
        {
            // prepend the mounted device letter
            string img_path = g.DownloadPath + "\\" + g.installer.ImagePath;
            g.installer.SetupPath = MountImage(img_path) + ":\\" + g.installer.SetupPath;
            txtInstallState.Text = string.Format("Install from Image: {0}", g.installer.SetupPath);
            if (File.Exists(g.installer.SetupPath)) {
                // do the Setup
                InstallFromDir(g);
            }
            // unmount
            UnMountImage(img_path);
        }

        private void InstallFromDir(Game g)
        {
            /*
            SetupPath: ""  "8bitARMS\setup_8bit_armies_2.23.0.27.exe"-- relative to the unpack/ download path
            SetupParams: "/"-- / DIR = "G:\GamesDownload\8-BitARMS" / LANG = german / SUPPRESSMSGBOXES / VERYSILENT / SP -
            http://unattended.sourceforge.net/InnoSetup_Switches_ExitCodes.html
            */
            string setup_exec = g.installer.SetupPath;
            string dest_path = g.DownloadPath + "\\" + g.installer.GameName + "\\";
         
            txtInstallState.Text = string.Format("Install Setup: {0} \n to: {1} ", setup_exec, dest_path);
            g.installer.SetupParams = g.installer.SetupParams.Replace("INSTALL-DIR", dest_path);
            //ps_exec.AddCommand(setup_exec).AddParameter(g.installer.SetupParams).BeginInvoke();

            // we need no powershell here..
            var p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = setup_exec,
                    Arguments = g.installer.SetupParams
                }
            };
            p.Start();
            p.WaitForExit();
        }

        private void DoInstallGame()
        {
            // Parse installer.cfg
            if (File.Exists(choosenGame.DownloadPath + "\\install.cfg"))
            {
                using (StreamReader json = File.OpenText(choosenGame.DownloadPath + "\\install.cfg"))
                {
                    txtInstallState.Text = json.ToString();
                    JsonSerializer serializer = new JsonSerializer();
                    choosenGame.installer = (InstallerCFG)serializer.Deserialize(json, typeof(InstallerCFG));
                }
                if (choosenGame.installer != null)
                {
                    // Now we have to launch installer handling
                    if (choosenGame.installer.HasISO)
                    {
                        InstallFromImage(choosenGame);
                    }
                    else
                    {
                        // no iso to mount, we can start setup directly
                        choosenGame.installer.SetupPath = choosenGame.DownloadPath + "\\" + choosenGame.installer.SetupPath;
                        InstallFromDir(choosenGame);
                    }
                }
            } // else nothing to do.. nothing else needed than unpacking

            txtInstallState.Text = "";            
            lblProgressFilename.Text = "Install Complete!";
        }


        private void btnInstallGame_Click(object sender, EventArgs e)
        {
            if (choosenGame != null
                && choosenGame.DownloadPath != ""
                && choosenGame.Networkpath != ""
                && credentials != null) {
                _inputParameter.gamedata = choosenGame;
                _inputParameter.netcred = credentials;
        
                // 1. DOWNLOAD from FILESERVER AND UNRAR afterwards
                backgroundDownload.RunWorkerAsync(_inputParameter);
                // Download and UnRAR Succeeded!
            }
        }

        private void btnLocalDestinationPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != ""
                && choosenGame != null)
            {
                choosenGame.DownloadPath = folderBrowserDialog1.SelectedPath;
                lblGameInfo.Text = choosenGame.DownloadPath;
            }
        }


        // DOWNLOAD
        struct DownloadSettings
        {
            public Game gamedata { get; set; }
            public NetworkCredential netcred { get; set; }
        }
        DownloadSettings _inputParameter;

        private void backgroundDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            Game gamedownload = ((DownloadSettings)e.Argument).gamedata;
            NetworkCredential cred = ((DownloadSettings)e.Argument).netcred;
            // using (new ConnectToSharedFolder(gamedownload.Networkpath, cred))
            string fn = gamedownload.DownloadPath + "\\" + Path.GetFileName(gamedownload.Networkpath);
            bool fe = File.Exists(fn);
            if (!fe)
            {
                myNetworkPath = gamedownload.Networkpath;

                try
                {
                    byte[] buffer = new byte[1024];
                    FileStream fs = File.OpenRead(myNetworkPath);
                    FileStream write = File.OpenWrite(gamedownload.DownloadPath + "\\" + Path.GetFileName(myNetworkPath));
                    double total = (double)fs.Length;
                    int byteRead = 0;
                    double read = 0;
                    do
                    {
                        if (!backgroundDownload.CancellationPending)
                        {
                            byteRead = fs.Read(buffer, 0, 1024);
                            read += (double)byteRead;
                            double percentage = read / total * 100;
                            backgroundDownload.ReportProgress((int)percentage);
                            write.Write(buffer, 0, 1024);
                        }
                    } while (byteRead != 0);

                    write.Close();
                    fs.Close();

                }
                catch (Exception ex)
                {
                    string Message = ex.Message.ToString();
                }
            }
        }

        private void backgroundDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgress.Text = $"{e.ProgressPercentage}%";
            if ( e.ProgressPercentage % 10 == 0) { 
                txtInstallState.Text = String.Format("Downloading {0} - {1}%", Path.GetFileName(choosenGame.Networkpath), e.ProgressPercentage.ToString());
            }
            progressBar.Value = e.ProgressPercentage;
            progressBar.Update();
        }

        private void backgroundDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProgressFilename.Text = "Download Completed!";
            txtInstallState.Text = String.Format("Download Completed!");
            backgroundUnrar.RunWorkerAsync(choosenGame.DownloadPath + "\\" + Path.GetFileName(choosenGame.Networkpath));
        }

        // UNRAR 
        private void backgroundUnrar_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!backgroundUnrar.CancellationPending)
                {
                    String rarfilepath = ((String)e.Argument);
                    String dst_path = rarfilepath.Replace(Path.GetFileName(rarfilepath), "");
                    var archive = ArchiveFactory.Open(rarfilepath);
                    long totalfiles = archive.Entries.Where(f => !f.IsDirectory).Sum(f => f.Size);
                    double byteswritten = 0;
                   
                    foreach (var entry in archive.Entries.Where(f => !f.IsDirectory))
                    {
                        // Filename : e.g mySetup.exe
                        string fileName = Path.GetFileName(entry.Key);
                        // destination filepath: e.g.   D:\GameDownload\MyGame\Setup\mySetup.exe
                        string dst_filepath = dst_path + entry.Key;
                        // directory path in local filesystem: e.g.  D:\GameDownload\MyGame\Setup\
                        string path = dst_filepath.Replace(fileName, "");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        if (!File.Exists(dst_path + "\\" + entry.Key))
                        {
                            FileStream write = File.OpenWrite(dst_path + "\\" + entry.Key);

                            using (var entryStream = entry.OpenEntryStream())
                            {
                                const int bufSize = 1024 * 16;//16k
                                byte[] buf = new byte[bufSize];
                                int bytesRead = 0;

                                while ((bytesRead = entryStream.Read(buf, 0, bufSize)) > 0)
                                {
                                    byteswritten += bytesRead;
                                    write.Write(buf, 0, bytesRead);
                                    double percentage = (byteswritten / totalfiles) * 100;
                                    backgroundUnrar.ReportProgress((int)percentage);
                                }
                            }
                            write.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblGameInfo.Text = String.Format("Error at unpacking: {0}", ex);
            }
        }

        private void backgroundUnrar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgress.Text = $"uncompressing: {e.ProgressPercentage}%";
            if (e.ProgressPercentage % 10 == 0)
            {
                txtInstallState.Text = String.Format("Uncompressing {0} - {1}%", Path.GetFileName(choosenGame.Networkpath), e.ProgressPercentage.ToString());
            }
            progressBar.Value = e.ProgressPercentage;
            progressBar.Update();
        }

        private void backgroundUnrar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProgressFilename.Text = "Unrar Completed!";
            txtInstallState.Text += string.Format("Install: {0} to {1}", choosenGame.Displayname, choosenGame.DownloadPath);
            if (e.Cancelled == false && e.Error == null)
            {
                // when everything is fine -->Install
                DoInstallGame();
            }
        }
    }
}
