using HhLib.DataBaseImage;
using HhLib.Share.models;
using System;
using System.Collections.Generic;
using System.Text;
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
            return await this.QueryCommandSingleAsync<DataUser.model.DataUser>($"SELECT DataUser.* FROM Applicant inner join DataUser on Applicant.idApplicant = DataUser.id where Applicant.idApplicant = {await this.GetUserId(Email)}; ");
        }
    }
}
