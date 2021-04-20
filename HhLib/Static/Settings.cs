using HhLib.Share.Utils.Validator;
using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using PasswordValidatorHH = HhLib.Share.Utils.Validator.PasswordValidator;
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

        public static PasswordValidatorHH PasswordValidator => Getjson()["PasswordValidator"].ToObject<PasswordValidatorHH>();

        public static IPasswordHasher Hasher => new HhLib.Share.Utils.Hashes.Hasher();
        public const string SqlFolder = "sqls";
        public static string ISSUER => (string)Getjson()["issuer"]; // издатель токена
        public static string AUDIENCE = (string)Getjson()["audience"]; // потребитель токена
        static readonly string KEY = (string)Getjson()["key"];   // ключ для шифрации
        private static int LIFETIME => (int)Getjson()["lifetime"];
        private static int LIFETIMERT => (int)Getjson()["lifetimeRT"];
        public static TimeSpan LIFETIMETS => TimeSpan.FromMinutes(LIFETIME);
        public static TimeSpan LIFETIMETSRT => TimeSpan.FromDays(LIFETIMERT);
        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        public static string connectionString => (string)Getjson()["dbConnection"];
    }
}