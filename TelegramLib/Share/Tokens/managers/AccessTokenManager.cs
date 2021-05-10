using MySql.Data.MySqlClient;
using TelegramLib.Share.Models;
using TelegramLib.Share.Tokens.models;

namespace TelegramLib.Share.Tokens.managers
{
    internal class AccessTokenManager : DataBaseController
    {
        public AccessTokenManager(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        public AccessToken GetAccessToken(SignInModel model)
        {
            return AccessToken.GenerateAccessToken(model);
        }
    }
}
