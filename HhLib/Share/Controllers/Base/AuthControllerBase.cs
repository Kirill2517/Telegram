using HhLib.DataUser.controllers;
using HhLib.Share.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Controllers.Base
{
    public abstract class AuthControllerBase
    {
        protected AuthDataController bdcontroller = new AuthDataController();
        /// <summary>
        /// регистрация
        /// </summary>
        /// <returns></returns>
        public abstract Task<string> SignUpUnauthorizedAsync<T>(SignUpModel<T> signUpModel) where T : User;
        /// <summary>
        /// возврат токена при удачной аунтефикации
        /// </summary>
        /// <returns></returns>
        public virtual async Task<string> AuthorizeAsync(SignInModel user)
        {
            if (!user.IsValid())
                return JsonConvert.SerializeObject(new { error = "Model is not valid." });
            if (await AuthAsync(user))
            {
                user.accountType = await bdcontroller.GetAccountType(user.email);
                return TokenGenerator.GetToken(user);
            }
            else return JsonConvert.SerializeObject(new { error = "Invalid username or password." });
        }
        /// <summary>
        /// проверка логина, пароля и существования пользователя
        /// </summary>
        /// <returns></returns>
        protected abstract Task<bool> AuthAsync(SignInModel model);
    }
}
