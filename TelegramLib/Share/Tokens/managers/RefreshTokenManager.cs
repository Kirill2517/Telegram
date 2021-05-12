using TelegramLib.Share.Models;
using TelegramLib.Share.Tokens.models;
using TelegramLib.Share.Utils.Extensions;
using TelegramLib.Static;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TelegramLib.Share.Tokens.managers
{
    internal class RefreshTokenManager : DataBaseController
    {
        public RefreshTokenManager(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        protected override string sqlPathFolder => base.sqlPathFolder + "/refreshSessions";
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

        internal async Task<bool> DriverIsSignedIn(string deviceId, int id)
        {
            RefreshToken refreshtoken = await GetSession(deviceId, id);
            return refreshtoken != null;
        }

        public async Task<RefreshToken> GetSession(string deviceId, int id)
        {
            string sql = $"{sqlPathFolder}/SelectRefreshSessionById.sql".ReadStringFromatFromFile(deviceId, id);
            RefreshToken refreshtoken = await QueryCommandSingleOrDefaultAsync<RefreshToken>(sql);
            return refreshtoken;
        }

        public async Task<RefreshToken> GetSession(RefreshToken refreshToken)
        {
            string sql = $"{sqlPathFolder}/SelectRefreshSessionByToken.sql".ReadStringFromatFromFile(refreshToken.deviceId, refreshToken.refreshToken);
            RefreshToken refreshtoken = await QueryCommandSingleOrDefaultAsync<RefreshToken>(sql);
            return refreshtoken;
        }

        public async Task<RefreshToken> GetSession(RefreshToken refreshToken, int id)
        {
            string sql = $"{sqlPathFolder}/SelectRefreshSessionByToken_Id.sql".ReadStringFromatFromFile(refreshToken.deviceId, refreshToken.refreshToken, id);
            RefreshToken refreshtoken = await QueryCommandSingleOrDefaultAsync<RefreshToken>(sql);
            return refreshtoken;
        }

        /// <summary>
        /// этот телефон существует
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        internal async Task<bool> DriverIsSignedIn(string deviceId)
        {
            return await FieldExists("fingerprint", deviceId, "refreshSessions");
        }


        /// <summary>
        /// Создает и записывает в бд токен и параметры
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        internal async Task<RefreshToken> GenerateNewSeesion(int id, string deviceId)
        {
            RefreshToken refreshtoken = RefreshToken.GenerateRefrashToken();
            refreshtoken.deviceId = deviceId;
            refreshtoken.idDataUser = id;
            await WriteToDataBase(refreshtoken);
            return refreshtoken;
        }

        internal async Task DeleteSession(int id, string deviceId)
        {
            string sql = $"{sqlPathFolder}/DeleteSessionById.sql".ReadStringFromatFromFile(deviceId, id);
            await ActionCommand(sql, deviceId);
        }

        internal async Task DeleteSession(RefreshToken refreshToken)
        {
            string sql = $"{sqlPathFolder}/DeleteSessionByToken.sql".ReadStringFromatFromFile(refreshToken.deviceId, refreshToken.refreshToken);
            await ActionCommand(sql, refreshToken.deviceId);
        }

        private async Task<string> WriteToDataBase(models.RefreshToken refreshtoken)
        {
            string sql = $"{sqlPathFolder}/InsertRefreshSession.sql".ReadStringFromatFromFile(refreshtoken.idDataUser, refreshtoken.deviceId,
                refreshtoken.refreshToken, refreshtoken.expiresIn.DateTimeFormatSql(), refreshtoken.createdAt.DateTimeFormatSql());
            await ActionCommand(sql, refreshtoken);
            return refreshtoken.refreshToken;
        }
    }
}
