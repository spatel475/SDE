using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SDE_Serve
{

    public class AppSettings
    {
        public string SDE_ServerHost;
        public string SDE_ServerPort;
        public string[] CorsAllowedAccess;
        public static AppSettings GetSettings()
        {
            return JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(Environment.CurrentDirectory + "\\appsettings.json"));
        }
    }
}
