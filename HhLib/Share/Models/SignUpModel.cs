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
            if (new List<object> { password, User }.Contains(null))
                return false;
            if (!User.IsValid())
                return false;
            return true;
        }
    }
}
