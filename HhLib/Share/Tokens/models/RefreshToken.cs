using HhLib.Share.Models;
using HhLib.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Tokens.models
{
    public class RefreshToken : Models.Object
    {
        public static RefreshToken GenerateRefrashToken()
        {
            var list = new List<string>();
            for (int i = 0; i < Random.Next(3, 7); i++)
            {
                list.Add(Guid.NewGuid().ToString());
            }
            RefreshToken refreshToken = new()
            {
                refreshToken = SummaTokens(list).ToLower(),
                createdAt = DateTime.UtcNow
            };
            refreshToken.expiresIn = refreshToken.createdAt.Add(Settings.LIFETIMETSRT);

            return refreshToken;
        }

        private static readonly Random Random = new();
        private static string SummaTokens(IEnumerable<string> guids)
        {
            var result = new StringBuilder();
            for (int i = 0; i < 36; i++)
            {
                foreach (var guid in guids)
                {
                    result.Append(guid[Random.Next(0, 36)]);
                }
            }

            return Settings.Hasher.HashPassword(result.ToString().Replace("-", string.Empty));
        }

        public string fingerprint { get; set; }
        public string refreshToken { get; set; }
        public DateTime expiresIn { get; set; }
        public DateTime createdAt { get; set; }
        public int idDataUser { get; set; }

        public override bool IsValid()
        {
            if (new List<object> { fingerprint, refreshToken }.Contains(null))
                return false;
            return true;
        }
    }
}
