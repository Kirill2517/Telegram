using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telegram.Utils.Controller
{
    public static class Extensions
    {
        public static string GetUserIdentity(this ControllerBase controller)
        {
            return controller.User.Identity.Name;
        }
    }
}
