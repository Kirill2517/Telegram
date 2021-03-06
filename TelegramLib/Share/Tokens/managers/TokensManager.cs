﻿using TelegramLib.Share.Models;
using TelegramLib.Share.Tokens.models;
using System;
using System.Threading.Tasks;
using Object = TelegramLib.Share.Models.Object;
using MySql.Data.MySqlClient;

namespace TelegramLib.Share.Tokens.managers
{
    public class TokensManager : DataBaseController
    {
        public TokensManager(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        public async Task<Object> GetTokens(SignInModel signInModel)
        {
            RefreshTokenManager refreshTokenManager = new(this.connection);
            int id = await GetUserId(signInModel.email);
            if (await refreshTokenManager.DriverIsSignedIn(signInModel.deviceId, id))
            {
                return new ErrorModel()
                {
                    Code = 404,
                    Description = "Driver alredy exists."
                };
            }

            AccessToken accesstoken = AccessToken.GenerateAccessToken(signInModel);
            RefreshToken refreshToken = await refreshTokenManager.GenerateNewSeesion(id, signInModel.deviceId);

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
            RefreshTokenManager refreshTokenManager = new(this.connection);
            int id = await GetUserId(email);
            if (!await refreshTokenManager.DriverIsSignedIn(refreshToken, id))
            {
                return new ErrorModel()
                {
                    Code = 404,
                    Description = "Session does not exist."
                };
            }

            await refreshTokenManager.DeleteSession(id, refreshToken.deviceId);
            return new ErrorModel()
            {
                Code = 200,
                Description = "You logged out."
            };
        }

        public async Task<Object> UpdateToken(RefreshToken refreshToken)
        {
            RefreshTokenManager refreshManager = new RefreshTokenManager(this.connection);
            refreshToken = await refreshManager.GetSession(refreshToken);
            if (refreshToken is null)
            {
                return new ErrorModel()
                {
                    Code = 404,
                    Description = "Session does not exist."
                };
            }

            if (refreshToken.expiresIn < DateTime.UtcNow)
            {
                await refreshManager.DeleteSession(refreshToken);
                return new ErrorModel()
                {
                    Code = 404,
                    Description = $"Token was expired {(DateTime.UtcNow - refreshToken.expiresIn).Days} ago. Sign in again."
                };
            }

            await refreshManager.DeleteSession(refreshToken.idDataUser, refreshToken.deviceId);
            string email = await GetEmailById(refreshToken.idDataUser);
            return await GetTokens(new SignInModel() { accountType = await GetAccountType(email), email = email, deviceId = refreshToken.deviceId });
        }
    }
}
