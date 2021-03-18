using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.Share.Models
{
    public class SignUpModel<T> : HhObject
        where T : User
    {
        public T User { get; set; }
        public string password { get; set; }

        public override bool IsValid()
        {
            if (!User.IsValid())
                return false;
            if (new List<object> { password }.Contains(null))
                return false;
            return true;
        }
    }
}
