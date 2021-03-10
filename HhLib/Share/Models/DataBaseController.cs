using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using HhLib.Static;
using Dapper;
using System.Threading.Tasks;

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
        protected async Task<T> QueryCommandSingleOrDefaultAsync<T>(string sql) => await connection.QuerySingleOrDefaultAsync<T>(sql);
        protected async Task<int> InsertCommand<T>(string sql, T obj) => await connection.ExecuteAsync(sql, obj);
        protected async Task<int> GetUserId(string email) => await this.QueryCommandSingleAsync<int>($"SELECT id FROM DataUser where email = '{email}'");
        public virtual void Dispose()
        {
            connection.CloseAsync();
        }
    }
}
