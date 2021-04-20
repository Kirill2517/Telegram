using HhLib.Share.models;
using HhLib.Share.RefreshToken.models;
using HhLib.Share.Utils.Extensions;
using HhLib.Static;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.RefreshToken.managers
{
    public class RefreshTokenManager : DataBaseController
    {
        protected const string sqlPathMain = Settings.SqlFolder + "/refreshSessions";
        public async Task<object> CreateNewSession(string email, string finger)
        {
            var id = await this.GetUserId(email);
            return await CreateNewSession(id, finger);
        }

        public async Task<object> CreateNewSession(int id, string finger)
        {
            var refreshtoken = RefreshToken.models.RefreshToken.GenerateNewRefrashToken();
            refreshtoken.fingerprint = finger;
            refreshtoken.idDataUser = id;
            if (!await FieldExists("fingerprint", finger, "refreshSessions"))
            {
                return await GenerateToken(refreshtoken);
            }
            return new { error = "You are already signed in from this device." };
        }

        private async Task<object> GenerateToken(models.RefreshToken refreshtoken)
        {
            var sql = $"{sqlPathMain}/InsertRefreshSession.sql".ReadStringFromatFromFile(refreshtoken.idDataUser, refreshtoken.fingerprint,
                refreshtoken.refreshToken, refreshtoken.expiresIn.DateTimeFormatSql(), refreshtoken.createdAt.DateTimeFormatSql());
            await this.ActionCommand(sql, refreshtoken);
            return refreshtoken.refreshToken;
        }

        public async Task<object> UpdateRefreshToken(string fingerprint, string refreshtoken)
        {
            if (!await FieldExists("fingerprint", fingerprint, "refreshSessions"))
                return new { error = "Invalid refresh session" };
            var sql = $"{sqlPathMain}/SelectRefreshSession.sql".ReadStringFromatFromFile(fingerprint);
            var token = await this.QueryCommandSingleAsync<RefreshToken.models.RefreshToken>(sql);
            if (token.refreshToken != refreshtoken)
                return new { error = "Invalid refresh session" };
            if (token.expiresIn < DateTime.UtcNow)
                return new { error = $"Token was expired {(DateTime.UtcNow - token.expiresIn).Days} ago." };

            sql = $"{sqlPathMain}/DeleteSessionByFingerprint.sql".ReadStringFromatFromFile(fingerprint);
            await this.ActionCommand(sql, fingerprint);


            var newToken = RefreshToken.models.RefreshToken.GenerateNewRefrashToken();
            newToken.idDataUser = token.idDataUser;
            newToken.fingerprint = fingerprint;
            return await GenerateToken(newToken);
        }
    }
}
