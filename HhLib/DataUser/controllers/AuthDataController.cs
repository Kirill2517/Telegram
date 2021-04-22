using HhLib.DataBaseImage;
using HhLib.Share.Models;
using System.Threading.Tasks;

namespace HhLib.DataUser.controllers
{
    public class AuthDataController : DataBaseController
    {
        public async Task<bool> EmailExistsAsync<T>(T user, string identity) where T : User
        {
            if (await FieldExists("email", identity, new DataUserImage().Title))
            {
                int id = await GetUserId(identity);
                BDImageBase targetImage = GetImageByType(user);
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
            string command = dataUserImage.InsertCommand + $"VALUES ({dataUserImage.FieldsName}, '{password}');";
            return await ActionCommand(command, dataUser) > 0;
        }

        public async Task<bool> InsertUserAsync<T>(T user, string identity) where T : User
        {
            BDImageBase targetImage = GetImageByType(user);
            string command = $"{targetImage.InsertCommand} VALUES ('{await GetUserId(identity)}', {targetImage.FieldsName});";
            return await ActionCommand(command, user) > 0;
        }

        public async Task<bool> CheckCorrectDataUserAsync(SignInModel user)
        {
            return await QueryCommandSingleAsync<bool>($"SELECT EXISTS(SELECT * FROM {new DataUserImage().Title} WHERE email = '{user.email}' and password = '{user.password}')");
        }

        private protected override BDImageBase GetImageByType(HhLib.Share.Models.Object @object)
        {
            if (@object.GetType() == typeof(Applicant.model.Applicant))
            {
                return new ApplicantImage();
            }

            if (@object.GetType() == typeof(Employer.model.Employer))
            {
                return new EmployerImage();
            }

            if (@object.GetType() == typeof(DataUser.model.DataUser))
            {
                return new DataUserImage();
            }

            return null;
        }
    }
}
