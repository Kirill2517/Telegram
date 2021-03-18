using HhLib.Shared.models;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using HhLib.Share.Models;
using HhLib.DataBaseImage;
using System.Threading.Tasks;
using HhLib.Applicant.model;

namespace HhLib.DataUser.controllers
{
    public class AuthDataBaseController : DataBaseController
    {
        DataUserImage DataUserImage = new DataUserImage();
        ApplicantImage ApplicantImage = new ApplicantImage();
        EmployerImage EmployerImage = new EmployerImage();
        /// <summary>
        /// значение поля существует в бд
        /// </summary>
        private async Task<bool> FieldExists<T>(string column, object key, T bd) where T : BDImageBase
        {
            return await this.QueryCommandSingleAsync<bool>($"SELECT EXISTS(SELECT * FROM {bd.Title} WHERE {column} = '{key}')");
        }

        public async Task<bool> EmailExistsAsync<T>(T user, string identity) where T : User
        {
            if (await FieldExists("email", identity, DataUserImage))
            {
                int id = await GetUserId(identity);
                var targetImage = GetImageByType(user);
                return await FieldExists(targetImage.IdFieldName, id, targetImage);
            }
            return false;
            //var command = $"SELECT idApplicant FROM Applicant inner join DataUser on DataUser.id = Applicant.idApplicant where DataUser.email = '{email}'";
            //var res = await this.QueryCommandSingleOrDefaultAsync<Applicant.model.Applicant>(command) != null;
            //return res;
        }

        public async Task<bool> FieldsUniqAsync<T>(T model) where T : HhObject
        {
            var targetImage = GetImageByType(model);
            foreach (var item in targetImage.UniqFields(model))
            {
                if (await FieldExists(item.Key, item.Value, targetImage))
                    return false;
            }
            return true;
        }

        public async Task<bool> InsertDataUserAsync(model.DataUser dataUser, string password)
        {
            var command = DataUserImage.InsertCommand + $"VALUES ({DataUserImage.FieldsName}, '{password}');";
            return await this.InsertCommand(command, dataUser) > 0;
        }

        public async Task<bool> InsertUserAsync<T>(T user, string identity) where T : User
        {
            BDImageBase targetImage = GetImageByType(user);
            var command = $"{targetImage.InsertCommand} VALUES ('{await GetUserId(identity)}', {targetImage.FieldsName});";
            return await this.InsertCommand(command, user) > 0;
        }

        private BDImageBase GetImageByType<T>(T @object) where T : HhObject
        {
            if (@object.GetType() == typeof(Applicant.model.Applicant))
                return ApplicantImage;
            if (@object.GetType() == typeof(Employer.model.Employer))
                return EmployerImage;
            if (@object.GetType() == typeof(DataUser.model.DataUser))
                return DataUserImage;
            return null;
        }

        public async Task<bool> CheckCorrectDataUserAsync(SignInModel user)
        {
            return await QueryCommandSingleAsync<bool>($"SELECT EXISTS(SELECT * FROM {DataUserImage.Title} WHERE email = '{user.email}' and password = '{user.password}')");
        }
    }
}
