using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.Share.Models
{
    public class SignInModel : HhObject
    {
        public string password { get; set; }
        public string email { get; set; }

        public override bool IsValid()
        {
            if (new List<object> { email, password }.Contains(null))
                return false;
            return true;
        }
    }
}
