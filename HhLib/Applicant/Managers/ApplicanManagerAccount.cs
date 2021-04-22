using HhLib.DataBaseImage;
using HhLib.Share.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Applicant.managers
{
    public class ApplicanManagerAccount : ApplicantManagerBase
    {
        protected override string sqlPathFolder => base.sqlPathFolder + "/Account";
        public async Task<DataUser.model.DataUser> GetDataUserAsync(string email)
        {
            return await this.QueryCommandSingleAsync<DataUser.model.DataUser>($"{sqlPathFolder}/GetDataUserByEmail.sql".ReadStringFromatFromFile(await this.GetUserId(email)));
        }

        public async Task<Applicant.model.ApplicantView> GetApplicantDataAsync(string email)
        {
            return await this.QueryCommandSingleAsync<Applicant.model.ApplicantView>($"{sqlPathFolder}/GetApplicantData.sql".ReadStringFromatFromFile(await this.GetUserId(email)));
        }

        public async Task<Applicant.model.ApplicantView> GetFullDataAsync(string email)
        {
            var applicant = await GetApplicantDataAsync(email);
            applicant.DataUser = await GetDataUserAsync(email);
            return applicant;
        }
    }
}
