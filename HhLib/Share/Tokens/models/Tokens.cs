using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Tokens.models
{
    public class Tokens : HhObject
    {
        public string access_token { get; set; }
        public string email { get; set; }
        public string refresh_token { get; set; }
        public DateTime expires { get; set; }
    }
}
