using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanManager
{
    public class Game
    {
        public String Networkpath; // \\ServerIP\Dir\Filename.rar
        public String Displayname; // Filename
        public String DownloadPath; // e.g. E:\LAN\MyGames
        public String InstallPath;  // e.g. E:\LAN\MyGames\Filename\
        public bool DownloadComplete = false;
        public bool UnrarComplete = false;
      
        public InstallerCFG installer;

        public Game()
        {

        }

      
        // Networkpath
        // DisplayName
        // ArchiveName
        // Unrar
        // Installer  --> Start Setup.exe if necessary
        // InstallPath ~ --> can be set by User ... 

        // install Cfg in rar

        // Pfad vom Rar ->  Unpack -> Parse Cfg ->Install? or Unpack?
        //
        // 
        
        // we should save the install path into an cfg File... Just 
        // 


    }
}
