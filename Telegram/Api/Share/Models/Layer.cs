﻿using Microsoft.AspNetCore.Mvc;
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
        protected virtual bool CheckRole() 
        {
            if (this.UserIsAuthorized())
            {
                var role = this.GetRole();
                return role.Equals(this.Role);
            }
            return false;
        }
    }
}