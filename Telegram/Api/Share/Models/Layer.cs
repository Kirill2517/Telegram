using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Utils.Controller;

namespace Telegram.Api.Share.Models
{
    public abstract class Layer : ControllerBase
    {
        protected abstract string Role { get; }
<<<<<<< HEAD
        protected virtual bool CheckRole() 
        {
            if (this.UserIsAuthorized())
            {
                var role = this.GetRole();
                return role.Equals(this.Role);
            }
=======
        protected virtual bool CheckRole(string role) 
        {
            if (this.UserIsAuthorized())
                return role.Equals(this.Role);
>>>>>>> 72218f33386eaf737715efd4fc25e8af79597616
            return false;
        }
    }
}
