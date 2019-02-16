using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanManager
{
    public class InstallerCFG
    {
        public String GameName { get; set; }
        public String InstallDir { get; set; }
        public String PaylerNameFile { get; set; }
        public Boolean HasISO = false;
        public String SetupPath { get; set; }   //  -- relative to the unpack/download directory e.g. \GameName\setup.exe
        public String SetupParams { get; set; } //  -- /DIR="E:\LAN\MyGames\Filename" /LANG=german /SUPPRESSMSGBOXES /VERYSILENT /SP-
        public String ImagePath { get; set; }   //  -- path to iso-File   eg.  E:\LAN\MyGames\GameName\ImageName.iso 
      
        /*String Language = null;
        Dictionary<String, String> DLCs = null;
        Dictionary<String, String> CrackDir = null;
        String cfg = null;
        */

        /*
       Movie m = JsonConvert.DeserializeObject<Movie>(json);
       string json = @"{
                 'Name': 'Bad Boys',
                 'ReleaseDate': '1995-4-7T00:00:00',
                 'Genres': [
                   'Action',
                   'Comedy'
                 ]
               }";
       Product product = new Product();
       product.Name = "Apple";
       product.Expiry = new DateTime(2008, 12, 28);
               product.Sizes = new string[] { "Small" };

           string json = JsonConvert.SerializeObject(product);
           // {
           //   "Name": "Apple",
           //   "Expiry": "2008-12-28T00:00:00",
           //   "Sizes": [
           //     "Small"
           //   ]
           // }
           */
    }
}
