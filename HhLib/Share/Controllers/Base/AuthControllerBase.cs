using HhLib.DataUser.controllers;
using HhLib.Share.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Controllers.Base
{
    public abstract class AuthControllerBase : AuthDataController
    {
        /// <summary>
        /// регистрация
        /// </summary>
        /// <returns></returns>
        public abstract Task<object> SignUpUnauthorizedAsync<T>(SignUpModel<T> signUpModel) where T : User;
        /// <summary>
        /// возврат токена при удачной аунтефикации
        /// </summary>
        /// <returns></returns>
        public virtual async Task<object> AuthorizeAsync(SignInModel user)
        {
            if (!user.IsValid())
                return new { error = "Model is not valid." };
            if (await AuthAsync(user))
            {
                user.accountType = await this.GetAccountType(user.email);
                return await TokenGenerator.GetToken(user);
            }
            else return new { error = "Invalid username or password." };
        }
        /// <summary>
        /// проверка логина, пароля и существования пользователя
        /// </summary>
        /// <returns></returns>
        protected abstract Task<bool> AuthAsync(SignInModel model);
    }
}
