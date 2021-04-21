using HhLib.Share.models;
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
    public class AuthDataController : DataBaseController
    {
        public async Task<bool> EmailExistsAsync<T>(T user, string identity) where T : User
        {
            if (await FieldExists("email", identity, new DataUserImage().Title))
            {
                int id = await GetUserId(identity);
                var targetImage = GetImageByType(user);
                return await FieldExists(targetImage.IdFieldName, id, targetImage.Title);
            }
            return false;
            //var command = $"SELECT idApplicant FROM Applicant inner join DataUser on DataUser.id = Applicant.idApplicant where DataUser.email = '{email}'";
            //var res = await this.QueryCommandSingleOrDefaultAsync<Applicant.model.Applicant>(command) != null;
            //return res;
        }

        public async Task<bool> InsertDataUserAsync(model.DataUser dataUser, string password)
        {
            DataUserImage dataUserImage = new DataUserImage();
            var command = dataUserImage.InsertCommand + $"VALUES ({dataUserImage.FieldsName}, '{password}');";
            return await this.ActionCommand(command, dataUser) > 0;
        }

        public async Task<bool> InsertUserAsync<T>(T user, string identity) where T : User
        {
            BDImageBase targetImage = GetImageByType(user);
            var command = $"{targetImage.InsertCommand} VALUES ('{await GetUserId(identity)}', {targetImage.FieldsName});";
            return await this.ActionCommand(command, user) > 0;
        }

        public async Task<bool> CheckCorrectDataUserAsync(SignInModel user)
        {
            return await QueryCommandSingleAsync<bool>($"SELECT EXISTS(SELECT * FROM {new DataUserImage().Title} WHERE email = '{user.email}' and password = '{user.password}')");
        }

        private protected override BDImageBase GetImageByType<T>(T @object)
        {
            if (@object.GetType() == typeof(Applicant.model.Applicant))
                return new ApplicantImage();
            if (@object.GetType() == typeof(Employer.model.Employer))
                return new EmployerImage();
            if (@object.GetType() == typeof(DataUser.model.DataUser))
                return new DataUserImage();
            return null;
        }
    }
}
