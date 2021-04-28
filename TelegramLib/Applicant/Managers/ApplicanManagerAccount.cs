using TelegramLib.Share.Utils.Extensions;
using System.Threading.Tasks;

namespace TelegramLib.Applicant.managers
{
    public class ApplicanManagerAccount : ApplicantManagerBase
    {
        protected override string sqlPathFolder => base.sqlPathFolder + "/Account";
        public async Task<DataUser.model.DataUser> GetDataUserAsync(string email)
        {
            return await QueryCommandSingleAsync<DataUser.model.DataUser>($"{sqlPathFolder}/GetDataUserByEmail.sql".ReadStringFromatFromFile(await GetUserId(email)));
        }

        public async Task<Applicant.model.ApplicantView> GetApplicantDataAsync(string email)
        {
            return await QueryCommandSingleAsync<Applicant.model.ApplicantView>($"{sqlPathFolder}/GetApplicantData.sql".ReadStringFromatFromFile(await GetUserId(email)));
        }

        public async Task<Applicant.model.ApplicantView> GetFullDataAsync(string email)
        {
            model.ApplicantView applicant = await GetApplicantDataAsync(email);
            applicant.DataUser = await GetDataUserAsync(email);
            return applicant;
        }
    }
}
