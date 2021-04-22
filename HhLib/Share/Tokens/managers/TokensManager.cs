using HhLib.Share.Models;
using HhLib.Share.Models;
using HhLib.Share.Tokens.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object = HhLib.Share.Models.Object;

namespace HhLib.Share.Tokens.managers
{
    public class TokensManager : DataBaseController
    {
        public async Task<Object> GetTokens(SignInModel signInModel)
        {
            RefreshTokenManager refreshTokenManager = new();
            int id = await this.GetUserId(signInModel.email);
            if (await refreshTokenManager.DriverIsSignedIn(signInModel.fingerprint, id))
                return new ErrorModel()
                {
                    Code = 404,
                    Description = "Driver alredy exists."
                };
            var accesstoken = AccessToken.GenerateAccessToken(signInModel);
            RefreshToken refreshToken = await refreshTokenManager.GenerateNewSeesion(id, signInModel.fingerprint);

            return new models.Tokens()
            {
                access_token = accesstoken.access_token,
                expires = accesstoken.expires,
                refresh_token = refreshToken.refreshToken,
                email = accesstoken.email
            };
        }

        public async Task<ErrorModel> LogOut(RefreshToken refreshToken, string email)
        {
            RefreshTokenManager refreshTokenManager = new();
            int id = await this.GetUserId(email);
            if (!await refreshTokenManager.DriverIsSignedIn(refreshToken, id))
                return new ErrorModel()
                {
                    Code = 404,
                    Description = "Session does not exist."
                };

            await refreshTokenManager.DeleteSession(id, refreshToken.fingerprint);
            return new ErrorModel()
            {
                Code = 200,
                Description = "You logged out."
            };
        }

        public async Task<Object> UpdateToken(RefreshToken refreshToken)
        {
            var refreshManager = new RefreshTokenManager();
            refreshToken = await refreshManager.GetSession(refreshToken);
            if (refreshToken is null)
                return new ErrorModel()
                {
                    Code = 404,
                    Description = "Session does not exist."
                };
            if (refreshToken.expiresIn < DateTime.UtcNow)
            {
                await refreshManager.DeleteSession(refreshToken);
                return new ErrorModel()
                {
                    Code = 404,
                    Description = $"Token was expired {(DateTime.UtcNow - refreshToken.expiresIn).Days} ago. Sign in again."
                };
            }

            await refreshManager.DeleteSession(refreshToken.idDataUser, refreshToken.fingerprint);
            var email = await GetEmailById(refreshToken.idDataUser);
            return await GetTokens(new SignInModel() { accountType = await GetAccountType(email), email = email, fingerprint = refreshToken.fingerprint });
        }
    }
}
