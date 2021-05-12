using TelegramLib.Share.Controllers.Base;
using TelegramLib.Share.Models;
using TelegramLib.Share.Tokens.managers;
using TelegramLib.Share.Tokens.models;
using TelegramLib.Static;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TelegramLib.DataUser.controllers
{
    public class AuthController : AuthControllerBase
    {
        public AuthController(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        public async Task<bool> CheckEmail(string email)
        {
            return await FieldExists("email", email, "DataUser");
        }

        public override async Task<object> SignUpUnauthorizedAsync<T>(SignUpModel<T> model)
        {
            if (!await model.ValidPassword())
            {
                return new { errors = model.Errors };
            }
            if (!model.IsValid())
            {
                return new { error = "Model is not valid." };
            }
            if (await EmailExistsAsync(model.User, model.User.DataUser.email))
            {
                return new { error = "Email already exists." };
            }
            if (!(await FieldsUniqAsync(model.User.DataUser)))
            {
                return new { error = "Uniq dataUser field already exists." };
            }
            if (!(await FieldsUniqAsync(model.User)))
            {
                return new { error = "Uniq account field already exists." };
            }
            if (!(await IndexesExist(model.User)))
            {
                return new { error = "Some values don't exist." };
            }
            if (!(await IndexesExist(model.User.DataUser)))
            {
                return new { error = "Some values don't exist." };
            }

            await InsertDataUserAsync(model.User.DataUser, Settings.Hasher.HashPassword(model.password));
            await InsertUserAsync(model.User, model.User.DataUser.email);
            AccountType type = await GetAccountType(model.User.DataUser.email);
            Share.Models.Object token = await new TokensManager(this.connection).GetTokens(new SignInModel() { email = model.User.DataUser.email, accountType = type, deviceId = model.deviceId });
            return token;
        }

        protected override async Task<bool> AuthAsync(SignInModel model)
        {
            model.password = Settings.Hasher.HashPassword(model.password);
            return await CheckCorrectDataUserAsync(model);
        }

        public async Task<ErrorModel> Logout(RefreshToken refreshToken, string email)
        {
            TokensManager tokensManager = new TokensManager(this.connection);
            return await tokensManager.LogOut(refreshToken, email);
        }

        public async Task<object> UpdateTokens(RefreshToken refreshToken)
        {
            return await new TokensManager(this.connection).UpdateToken(refreshToken);
        }

        public async Task<bool> SignUpSecondAccount<T>(string identity, T model) where T : User
        {
            if (!model.IsValid())
            {
                return false;
            }

            if (await EmailExistsAsync(model, identity))
            {
                return false;
            }

            if (!(await FieldsUniqAsync(model)))
            {
                return false;
            }

            return await InsertUserAsync(model, identity);
        }
    }
}
