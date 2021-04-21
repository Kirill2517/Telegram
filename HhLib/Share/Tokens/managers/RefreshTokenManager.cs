using HhLib.Share.models;
using HhLib.Share.Models;
using HhLib.Share.Tokens.models;
using HhLib.Share.Utils.Extensions;
using HhLib.Static;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Tokens.managers
{
    class RefreshTokenManager : DataBaseController
    {
        protected const string sqlPathMain = Settings.SqlFolder + "/refreshSessions";
        /// <summary>
        /// определенный аккаунт существует на этом телефоне
        /// </summary>
        /// <param name="fingerprint"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        internal async Task<bool> DriverIsSignedIn(RefreshToken refreshToken, int id)
        {
            RefreshToken refreshtoken = await GetSession(refreshToken, id);
            return refreshtoken != null;
        }

        internal async Task<bool> DriverIsSignedIn(string fingerprint, int id)
        {
            RefreshToken refreshtoken = await GetSession(fingerprint, id);
            return refreshtoken != null;
        }

        public async Task<RefreshToken> GetSession(string fingerprint, int id)
        {
            var sql = $"{sqlPathMain}/SelectRefreshSessionById.sql".ReadStringFromatFromFile(fingerprint, id);
            var refreshtoken = await this.QueryCommandSingleOrDefaultAsync<RefreshToken>(sql);
            return refreshtoken;
        }

        public async Task<RefreshToken> GetSession(RefreshToken refreshToken)
        {
            var sql = $"{sqlPathMain}/SelectRefreshSessionByToken.sql".ReadStringFromatFromFile(refreshToken.fingerprint, refreshToken.refreshToken);
            var refreshtoken = await this.QueryCommandSingleOrDefaultAsync<RefreshToken>(sql);
            return refreshtoken;
        }

        public async Task<RefreshToken> GetSession(RefreshToken refreshToken, int id)
        {
            var sql = $"{sqlPathMain}/SelectRefreshSessionByToken_Id.sql".ReadStringFromatFromFile(refreshToken.fingerprint, refreshToken.refreshToken, id);
            var refreshtoken = await this.QueryCommandSingleOrDefaultAsync<RefreshToken>(sql);
            return refreshtoken;
        }

        /// <summary>
        /// этот телефон существует
        /// </summary>
        /// <param name="fingerprint"></param>
        /// <returns></returns>
        internal async Task<bool> DriverIsSignedIn(string fingerprint) => await FieldExists("fingerprint", fingerprint, "refreshSessions");


        /// <summary>
        /// Создает и записывает в бд токен и параметры
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fingerprint"></param>
        /// <returns></returns>
        internal async Task<RefreshToken> GenerateNewSeesion(int id, string fingerprint)
        {
            var refreshtoken = RefreshToken.GenerateRefrashToken();
            refreshtoken.fingerprint = fingerprint;
            refreshtoken.idDataUser = id;
            await WriteToDataBase(refreshtoken);
            return refreshtoken;
        }

        internal async Task DeleteSession(int id, string fingerprint)
        {
            var sql = $"{sqlPathMain}/DeleteSessionById.sql".ReadStringFromatFromFile(fingerprint, id);
            await this.ActionCommand(sql, fingerprint);
        }

        internal async Task DeleteSession(RefreshToken refreshToken)
        {
            var sql = $"{sqlPathMain}/DeleteSessionByToken.sql".ReadStringFromatFromFile(refreshToken.fingerprint, refreshToken.refreshToken);
            await this.ActionCommand(sql, refreshToken.fingerprint);
        }

        private async Task<string> WriteToDataBase(models.RefreshToken refreshtoken)
        {
            var sql = $"{sqlPathMain}/InsertRefreshSession.sql".ReadStringFromatFromFile(refreshtoken.idDataUser, refreshtoken.fingerprint,
                refreshtoken.refreshToken, refreshtoken.expiresIn.DateTimeFormatSql(), refreshtoken.createdAt.DateTimeFormatSql());
            await this.ActionCommand(sql, refreshtoken);
            return refreshtoken.refreshToken;
        }
        #region oldcode
        //public async Task<object> CreateNewSession(string email, string finger)
        //{
        //    var id = await this.GetUserId(email);
        //    return await CreateNewSession(id, finger);
        //}

        //public async Task<object> CreateNewSession(int id, string finger)
        //{
        //    var refreshtoken = Tokens.models.RefreshToken.GenerateRefrashToken();
        //    refreshtoken.fingerprint = finger;
        //    refreshtoken.idDataUser = id;
        //    if (!await FieldExists("fingerprint", finger, "refreshSessions"))
        //    {
        //        return await GenerateToken(refreshtoken);
        //    }
        //    return new { error = "You are already signed in from this device." };
        //}



        //public async Task<object> UpdateRefreshToken(string fingerprint, string refreshtoken)
        //{
        //    if (!await FieldExists("fingerprint", fingerprint, "refreshSessions"))
        //        return new { error = "Invalid refresh session" };
        //    var sql = $"{sqlPathMain}/SelectRefreshSession.sql".ReadStringFromatFromFile(fingerprint);
        //    var token = await this.QueryCommandSingleAsync<Tokens.models.RefreshToken>(sql);
        //    if (token.refreshToken != refreshtoken)
        //        return new { error = "Invalid refresh session" };
        //    if (token.expiresIn < DateTime.UtcNow)
        //        return new { error = $"Token was expired {(DateTime.UtcNow - token.expiresIn).Days} ago." };

        //    sql = $"{sqlPathMain}/DeleteSessionByFingerprint.sql".ReadStringFromatFromFile(fingerprint);
        //    await this.ActionCommand(sql, fingerprint);


        //    var newToken = Tokens.models.RefreshToken.GenerateRefrashToken();
        //    newToken.idDataUser = token.idDataUser;
        //    newToken.fingerprint = fingerprint;
        //    return await GenerateToken(newToken);
        //}
        #endregion


    }
}
