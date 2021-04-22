using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object = HhLib.Share.Models.Object;

namespace HhLib.Resume.model
{
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
