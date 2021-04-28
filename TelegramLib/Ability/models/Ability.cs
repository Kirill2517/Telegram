using TelegramLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object = TelegramLib.Share.Models.Object;

namespace TelegramLib.Ability.model
{
    /// <summary>
    /// Positive, Negative, Skill
    /// </summary>
    public class Ability : Object
    {
        public string description { get; set; }
        public override bool IsValid()
        {
            if (new List<object> { description }.Contains(null))
            {
                return false;
            }
            return true;
        }
    }
}
