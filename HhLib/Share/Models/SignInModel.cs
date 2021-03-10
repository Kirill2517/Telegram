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
            return true;
        }
    }
}
