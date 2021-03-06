﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Telegram.Utils.Controller
{
    public static class Extensions
    {
        public static string GetUserIdentity(this ControllerBase controller)
        {
            return controller.User.Identity.Name;
        }

        public static string GetRole(this ControllerBase controller)
        {
            return controller.User.Claims.SingleOrDefault(r => r.Type == ClaimTypes.Role).Value;
        }

        public static bool UserIsAuthorized(this ControllerBase controller)
        {
            return controller.HttpContext.User.Identity.Name != null;
        }
    }
}
