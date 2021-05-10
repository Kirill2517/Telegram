using TelegramLib.DataUser.controllers;
using TelegramLib.Share.Models;
using TelegramLib.Share.Tokens.managers;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TelegramLib.Share.Controllers.Base
{
    public abstract class AuthControllerBase : AuthDataController
    {
        protected AuthControllerBase(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

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
            {
                return new { error = "Model is not valid." };
            }

            if (await AuthAsync(user))
            {
                user.accountType = await GetAccountType(user.email);
                return await new TokensManager(this.connection).GetTokens(user);
            }
            else
            {
                return new { error = "Invalid username or password." };
            }
        }
        /// <summary>
        /// проверка логина, пароля и существования пользователя
        /// </summary>
        /// <returns></returns>
        protected abstract Task<bool> AuthAsync(SignInModel model);
    }
}
