using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.Share.Models
{
    public abstract class Object
    {
        public virtual bool IsValid()
        {
            return true;
        }
    }
}
