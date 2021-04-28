using Dapper;
using TelegramLib.DataBaseImage;
using TelegramLib.Static;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramLib.Share.Models
{
    public abstract class DataBaseController : IDisposable
    {
        private readonly string connectionstring = Settings.connectionString;
        private readonly MySqlConnection connection;
        protected virtual string sqlPathFolder { get; } = Settings.SqlFolder;
        public DataBaseController()
        {
            connection = new MySqlConnection(connectionstring);
            connection.OpenAsync();
        }
        protected async Task<IEnumerable<T>> QueryCommandIEnumerable<T>(string sql)
        {
            return await connection.QueryAsync<T>(sql);
        }

        protected void InsertCollection<T>(IEnumerable<T> collection, Action<T> action)
        {
            if (collection != null)
                foreach (var item in collection)
                {
                    if (item != null)
                        action(item);
                }
        }

        protected async Task<T> QueryCommandSingleAsync<T>(string sql)
        {
            return await connection.QuerySingleAsync<T>(sql);
        }

        protected async Task<T> QueryCommandSingleOrDefaultAsync<T>(string sql, object key)
        {
            return await connection.QuerySingleOrDefaultAsync<T>(sql, key);
        }

        protected async Task<T> QueryCommandSingleOrDefaultAsync<T>(string sql)
        {
            return await connection.QuerySingleOrDefaultAsync<T>(sql);
        }

        protected async Task<int> ActionCommand(string sql, object obj = null)
        {
            return await connection.ExecuteAsync(sql, obj);
        }

        protected async Task<int> GetUserId(string email)
        {
            return await QueryCommandSingleAsync<int>($"SELECT id FROM DataUser where email = '{email}'");
        }

        protected async Task<string> GetEmailById(int id)
        {
            return await QueryCommandSingleAsync<string>($"SELECT email FROM DataUser where id = {id}");
        }

        protected async Task<int> GetLastInsertedId()
        {
            return await this.QueryCommandSingleAsync<int>("select last_insert_id();");
        }
        protected async Task<AccountType> GetAccountType(string email)
        {
            ApplicantImage image = new ApplicantImage();
            bool applicantExists = await FieldExists(image.IdFieldName, await GetUserId(email), image.Title);
            return applicantExists ? AccountType.applicant : AccountType.employer;
        }
        [Obsolete]
        private protected virtual BDImageBase GetImageByType(Models.Object @object)
        {
            return null;
        }
        [Obsolete]
        /// <summary>
        /// значение поля существует в бд
        /// </summary>
        protected async Task<bool> FieldExists(string column, object key, string bdTitle)
        {
            return await QueryCommandSingleOrDefaultAsync<bool>($"SELECT EXISTS(SELECT * FROM {bdTitle} WHERE {column} = @key)", new { key });
        }

        [Obsolete]
        public async Task<bool> IndexesExist(Models.Object model)
        {
            BDImageBase targetImage = GetImageByType(model);
            foreach (KeyValuePair<DataBaseImage.Models.DbIndex, object> item in targetImage.GetIndexes(model))
            {
                if (!await FieldExists(item.Key.TitleColumn, item.Value, item.Key.TitleTable))
                {
                    return false;
                }
            }
            return true;
        }

        [Obsolete]
        public async Task<bool> FieldsUniqAsync(Models.Object model)
        {
            BDImageBase targetImage = GetImageByType(model);
            foreach (KeyValuePair<string, object> item in targetImage.UniqFields(model))
            {
                if (await FieldExists(item.Key, item.Value, targetImage.Title))
                {
                    return false;
                }
            }
            return true;
        }

        public virtual void Dispose()
        {
            connection.CloseAsync();
            GC.SuppressFinalize(this);
        }
    }
}
