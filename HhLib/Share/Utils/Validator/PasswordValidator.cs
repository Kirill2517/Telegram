using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Utils.Validator
{
    public class PasswordValidator : Microsoft.AspNet.Identity.PasswordValidator
    {
        public override Task<IdentityResult> ValidateAsync(string item)
        {
            return base.ValidateAsync(item);
        }
    }
}
