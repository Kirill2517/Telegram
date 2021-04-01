using HhLib.DataBaseImage;
using HhLib.Share.Interfaces;
using HhLib.Share.models;
using HhLib.Share.Models;
using HhLib.Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HhLib.Applicant.Managers
{
    public class ApplicantManager : DataBaseController
    {
        private const string sqlPathMain = Settings.SqlFolder + "/Applicant";

        public async Task<DataUser.model.DataUser> GetDataUserAsync(string email)
        {
            return await this.QueryCommandSingleAsync<DataUser.model.DataUser>(string.Format(File.ReadAllText($"{sqlPathMain}/GetDataUserByEmail.sql"), await this.GetUserId(email)));
        }
        
        public async Task<Applicant.model.ApplicantView> GetApplicantDataAsync(string email)
        {
            return await this.QueryCommandSingleAsync<Applicant.model.ApplicantView>(string.Format(File.ReadAllText($"{sqlPathMain}/GetApplicantData.sql"), await this.GetUserId(email)));
        }

        public async Task<Applicant.model.ApplicantView> GetFullDataAsync(string email)
        {
            var applicant = await GetApplicantDataAsync(email);
            applicant.DataUser = await GetDataUserAsync(email);
            return applicant;
        }

        private protected override BDImageBase GetImageByType<T>(T @object)
        {
            throw new NotImplementedException();
        }
    }
}
