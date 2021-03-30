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
        protected virtual bool CheckRole()
        {
            if (this.UserIsAuthorized())
            {
                var role = this.GetRole();
                return role.Equals(this.Role);
            }
            return false;
        }

        /// <summary>
        /// функция доступна каждому методу в каждом слое, где нужна проверка ролей, вызывать именно эту функцию 
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected async virtual Task<IActionResult> BaseFunction(Func<Task<IActionResult>> func)
        {
            if (CheckRole())
                return await func();
            return BadRequest(new { error = "Неверный тип авторизации" });
        }
    }
}
