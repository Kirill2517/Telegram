using TelegramLib.Share.Models;
using TelegramLib.Share.Tokens.models;

namespace TelegramLib.Share.Tokens.managers
{
    internal class AccessTokenManager : DataBaseController
    {
        public AccessToken GetAccessToken(SignInModel model)
        {
            return AccessToken.GenerateAccessToken(model);
        }
    }
}
