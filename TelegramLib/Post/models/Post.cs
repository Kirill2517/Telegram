using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramLib.Share.Models;
using Object = TelegramLib.Share.Models.Object;

namespace TelegramLib.Post.models
{
    public class Post : Object
    {
        public string name { get; set; }
        public override bool IsValid()
        {
            if (new List<object> { name }.Contains(null))
            {
                return false;
            }
            return true;
        }
    }
}
