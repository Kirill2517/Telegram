using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace HhLib.Static
{
    public class Settings
    {
        private static JObject Getjson()
        {
            string configuration;
#if RELEASE
            configuration = "releaseSetting";
#else
            configuration = "devSetting";
#endif
            return (JObject)JObject.Parse(File.ReadAllText("settings.json"))[configuration];
        }

        public static string ISSUER => (string)Getjson()["issuer"]; // издатель токена
        public static string AUDIENCE = (string)Getjson()["audience"]; // потребитель токена
        static readonly string KEY = (string)Getjson()["key"];   // ключ для шифрации
        public static int LIFETIME => (int)Getjson()["lifetime"]; // время жизни токена - 1 минута
        public static TimeSpan LIFETIMETS => TimeSpan.FromMinutes(LIFETIME);
        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        public static string connectionString => (string)Getjson()["dbConnection"];
    }
}