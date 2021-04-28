using System;

namespace TelegramLib.Share.Tokens.models
{
    public class Tokens : Models.Object
    {
        public string access_token { get; set; }
        public string email { get; set; }
        public string refresh_token { get; set; }
        public DateTime expires { get; set; }
    }
}
