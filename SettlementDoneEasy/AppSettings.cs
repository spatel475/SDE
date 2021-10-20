using Newtonsoft.Json;
using System;
using System.IO;

namespace SDE_Server
{
    public class AppSettings
    {
        public string SDE_ServerHost;
        public string SDE_ServerPort;
        public string[] CorsAllowedAccess;
        public string DBConnectionString;
        public JWTSettings JwtSettings;

        public static AppSettings GetSettings()
        {
            return JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(Environment.CurrentDirectory + "\\appsettings.json"));
        }
    }

    public class JWTSettings
    {
        public string securityKey;
        public string validIssuer;
        public string validAudience;
        public string expiryInMinutes;
    }
}
