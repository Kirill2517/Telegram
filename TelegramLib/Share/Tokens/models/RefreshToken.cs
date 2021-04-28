using TelegramLib.Static;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramLib.Share.Tokens.models
{
    public class RefreshToken : Models.Object
    {
        private static readonly Random Random = new();
        public static RefreshToken GenerateRefrashToken()
        {
            List<string> list = new List<string>();
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

        private static string SummaTokens(IEnumerable<string> guids)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 36; i++)
            {
                foreach (string guid in guids)
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
            {
                return false;
            }

            return true;
        }
    }
}
