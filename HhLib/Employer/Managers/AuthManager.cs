using HhLib.Share.Models;
using System.Threading.Tasks;

namespace HhLib.Employer.Managers
{
    public class AuthManager : DataBaseController
    {
        public string Email { get; }
        public AuthManager(string email)
        {
            Email = email;
        }

        public async Task<DataUser.model.DataUser> GetGuidAsync()
        {
            return await QueryCommandSingleAsync<DataUser.model.DataUser>($"SELECT DataUser.* FROM Applicant inner join DataUser on Applicant.idApplicant = DataUser.id where Applicant.idApplicant = {await GetUserId(Email)}; ");
        }
    }
}
