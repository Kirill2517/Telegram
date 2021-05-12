using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using Telegram.Utils.Controller;
using TelegramLib.DataUser.controllers;

namespace Telegram.Api.Share.Models
{
    public abstract class Layer : ControllerBaseModel
    {
        public Layer(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }
        protected abstract string Role { get; }
        protected virtual bool CheckRole()
        {
            if (this.UserIsAuthorized())
            {
                string role = this.GetRole();
                return role.Equals(Role);
            }
            return false;
        }

        /// <summary>
        /// функция доступна каждому методу в каждом слое, где нужна проверка ролей, вызывать именно эту функцию 
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected virtual async Task<IActionResult> BaseFunction(Func<Task<IActionResult>> func)
        {
            if (!new TelegramLib.DataUser.controllers.AuthController(Connection).CheckEmail(this.GetUserIdentity()).Result)
                return BadRequest(new { error = "Задан несуществующий аккаунт." });
            if (CheckRole())
                return await func();
            return BadRequest(new { error = "Неверный тип авторизации" });
        }
    }
}
