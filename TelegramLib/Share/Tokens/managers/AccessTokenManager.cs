using HhLib.Share.Models;
using HhLib.Share.Tokens.models;

namespace HhLib.Share.Tokens.managers
{
    internal class AccessTokenManager : DataBaseController
    {
        public AccessToken GetAccessToken(SignInModel model)
        {
            return AccessToken.GenerateAccessToken(model);
        }
    }
}
