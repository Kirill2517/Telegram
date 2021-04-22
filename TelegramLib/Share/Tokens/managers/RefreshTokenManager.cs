using HhLib.Share.Models;
using HhLib.Share.Tokens.models;
using HhLib.Share.Utils.Extensions;
using HhLib.Static;
using System.Threading.Tasks;

namespace HhLib.Share.Tokens.managers
{
    internal class RefreshTokenManager : DataBaseController
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
            string sql = $"{sqlPathMain}/SelectRefreshSessionById.sql".ReadStringFromatFromFile(fingerprint, id);
            RefreshToken refreshtoken = await QueryCommandSingleOrDefaultAsync<RefreshToken>(sql);
            return refreshtoken;
        }

        public async Task<RefreshToken> GetSession(RefreshToken refreshToken)
        {
            string sql = $"{sqlPathMain}/SelectRefreshSessionByToken.sql".ReadStringFromatFromFile(refreshToken.fingerprint, refreshToken.refreshToken);
            RefreshToken refreshtoken = await QueryCommandSingleOrDefaultAsync<RefreshToken>(sql);
            return refreshtoken;
        }

        public async Task<RefreshToken> GetSession(RefreshToken refreshToken, int id)
        {
            string sql = $"{sqlPathMain}/SelectRefreshSessionByToken_Id.sql".ReadStringFromatFromFile(refreshToken.fingerprint, refreshToken.refreshToken, id);
            RefreshToken refreshtoken = await QueryCommandSingleOrDefaultAsync<RefreshToken>(sql);
            return refreshtoken;
        }

        /// <summary>
        /// этот телефон существует
        /// </summary>
        /// <param name="fingerprint"></param>
        /// <returns></returns>
        internal async Task<bool> DriverIsSignedIn(string fingerprint)
        {
            return await FieldExists("fingerprint", fingerprint, "refreshSessions");
        }


        /// <summary>
        /// Создает и записывает в бд токен и параметры
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fingerprint"></param>
        /// <returns></returns>
        internal async Task<RefreshToken> GenerateNewSeesion(int id, string fingerprint)
        {
            RefreshToken refreshtoken = RefreshToken.GenerateRefrashToken();
            refreshtoken.fingerprint = fingerprint;
            refreshtoken.idDataUser = id;
            await WriteToDataBase(refreshtoken);
            return refreshtoken;
        }

        internal async Task DeleteSession(int id, string fingerprint)
        {
            string sql = $"{sqlPathMain}/DeleteSessionById.sql".ReadStringFromatFromFile(fingerprint, id);
            await ActionCommand(sql, fingerprint);
        }

        internal async Task DeleteSession(RefreshToken refreshToken)
        {
            string sql = $"{sqlPathMain}/DeleteSessionByToken.sql".ReadStringFromatFromFile(refreshToken.fingerprint, refreshToken.refreshToken);
            await ActionCommand(sql, refreshToken.fingerprint);
        }

        private async Task<string> WriteToDataBase(models.RefreshToken refreshtoken)
        {
            string sql = $"{sqlPathMain}/InsertRefreshSession.sql".ReadStringFromatFromFile(refreshtoken.idDataUser, refreshtoken.fingerprint,
                refreshtoken.refreshToken, refreshtoken.expiresIn.DateTimeFormatSql(), refreshtoken.createdAt.DateTimeFormatSql());
            await ActionCommand(sql, refreshtoken);
            return refreshtoken.refreshToken;
        }
    }
}
