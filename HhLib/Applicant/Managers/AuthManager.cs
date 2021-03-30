using HhLib.Applicant.model;
using HhLib.DataBaseImage;
using HhLib.Shared.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Applicant.Managers
{
    public class ApplicantManager : DataBaseController
    {
        public string Email { get; }
        public ApplicantManager(string email)
        {
            Email = email;
        }

        public async Task<DataUser.model.DataUser> GetDataAsync()
        {
            return await this.QueryCommandSingleAsync<DataUser.model.DataUser>($"SELECT DataUser.* FROM Applicant inner join DataUser on Applicant.idApplicant = DataUser.id where Applicant.idApplicant = '{await this.GetUserId(Email)}'; ");
        }

        private protected override BDImageBase GetImageByType<T>(T @object)
        {
            throw new NotImplementedException();
        }
    }
}
