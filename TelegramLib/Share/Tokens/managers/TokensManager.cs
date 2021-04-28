﻿using TelegramLib.Share.Models;
using TelegramLib.Share.Tokens.models;
using System;
using System.Threading.Tasks;
using Object = TelegramLib.Share.Models.Object;

namespace TelegramLib.Share.Tokens.managers
{
    public class TokensManager : DataBaseController
    {
        public async Task<Object> GetTokens(SignInModel signInModel)
        {
            RefreshTokenManager refreshTokenManager = new();
            int id = await GetUserId(signInModel.email);
            if (await refreshTokenManager.DriverIsSignedIn(signInModel.fingerprint, id))
            {
                return new ErrorModel()
                {
                    Code = 404,
                    Description = "Driver alredy exists."
                };
            }

            AccessToken accesstoken = AccessToken.GenerateAccessToken(signInModel);
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
            int id = await GetUserId(email);
            if (!await refreshTokenManager.DriverIsSignedIn(refreshToken, id))
            {
                return new ErrorModel()
                {
                    Code = 404,
                    Description = "Session does not exist."
                };
            }

            await refreshTokenManager.DeleteSession(id, refreshToken.fingerprint);
            return new ErrorModel()
            {
                Code = 200,
                Description = "You logged out."
            };
        }

        public async Task<Object> UpdateToken(RefreshToken refreshToken)
        {
            RefreshTokenManager refreshManager = new RefreshTokenManager();
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

            await refreshManager.DeleteSession(refreshToken.idDataUser, refreshToken.fingerprint);
            string email = await GetEmailById(refreshToken.idDataUser);
            return await GetTokens(new SignInModel() { accountType = await GetAccountType(email), email = email, fingerprint = refreshToken.fingerprint });
        }
    }
}