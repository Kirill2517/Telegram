using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using HhLib.Static;
using Dapper;
using System.Threading.Tasks;
using HhLib.DataBaseImage;
using HhLib.Share.Models;

namespace HhLib.Shared.models
{
    public abstract class DataBaseController : IDisposable
    {
        private string connectionstring = Settings.connectionString;
        protected readonly MySqlConnection connection;
        public DataBaseController()
        {
            connection = new MySqlConnection(connectionstring);
            connection.OpenAsync();
        }
        protected async Task<IEnumerable<T>> QueryCommandIEnumerable<T>(string sql) => await connection.QueryAsync<T>(sql);
        protected async Task<T> QueryCommandSingleAsync<T>(string sql) => await connection.QuerySingleAsync<T>(sql);
        protected async Task<T> QueryCommandSingleOrDefaultAsync<T>(string sql, object key) => await connection.QuerySingleOrDefaultAsync<T>(sql, key);
        protected async Task<int> InsertCommand<T>(string sql, T obj) => await connection.ExecuteAsync(sql, obj);
        protected async Task<int> GetUserId(string email) => await this.QueryCommandSingleAsync<int>($"SELECT id FROM DataUser where email = '{email}'");
        protected private abstract BDImageBase GetImageByType<T>(T @object) where T : HhObject;
        /// <summary>
        /// значение поля существует в бд
        /// </summary>
        protected async Task<bool> FieldExists(string column, object key, string bdTitle)
        {
            return await this.QueryCommandSingleOrDefaultAsync<bool>($"SELECT EXISTS(SELECT * FROM {bdTitle} WHERE {column} = @key)", new { key });
        }

        public async Task<bool> IndexesExist<T>(T model) where T : HhObject
        {
            var targetImage = GetImageByType(model);
            foreach (var item in targetImage.GetIndexes(model))
            {
                if (!await FieldExists(item.Key.TitleColumn, item.Value, item.Key.TitleTable))
                    return false;
            }
            return true;
        }

        public virtual void Dispose()
        {
            connection.CloseAsync();
        }
    }
}
