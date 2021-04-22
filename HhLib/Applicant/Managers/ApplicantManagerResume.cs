using HhLib.DataBaseImage;
using HhLib.Share.Models;
using HhLib.Share.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Applicant.managers
{
    public class ApplicantManagerResume : ApplicantManagerBase
    {
        protected override string sqlPathFolder => base.sqlPathFolder + "/Resume";

        //range == null     all
        //range is not valid        error
        //range is ok       range
        public async Task<object> GetAllResumesAsyncByApplicantEmail(string email, Share.Models.Range range = null)
        {
            if (range != null && !range.IsValid())
                return new { error = "Range is not valid." };

            string sql = range is null
                ? $"{sqlPathFolder}/GetAllResumeByApplicantEmail.sql".ReadStringFromatFromFile(email)
                : $"{sqlPathFolder}/SelectRangeOfMyResumeByEmail.sql".ReadStringFromatFromFile(email, range.start, range.count);

            IEnumerable<Resume.model.Resume> resumes = await this.QueryCommandIEnumerable<Resume.model.Resume>(sql);
            return new { count = resumes.Count(), resumes };
        }

        public async Task<object> GetAllResumesAsyncByApplicantId(int id)
        {
            string sql = $"{sqlPathFolder}/GetAllResumeByApplicantId.sql".ReadStringFromatFromFile(id);
            IEnumerable<Resume.model.Resume> resumes = await this.QueryCommandIEnumerable<Resume.model.Resume>(sql);
            return new { count = resumes.Count(), resumes };
        }

        public async Task<object> CreateResume(Resume.model.Resume resume, string identity)
        {
            if (!resume.IsValid())
                return new { error = "Model is not valid." };

            resume.Owner = identity;
            var image = GetImageByType(resume);
            int idSpeciality = await new Speciality.Managers.SpecialityManager().GetIdSpeciality(resume.Speciality);
            int idApplicant = await GetUserId(identity);
            var sql = $"{image.InsertCommand} values ({idApplicant}, {idSpeciality}, curtime(), {image.FieldsName});";
            await this.ActionCommand(sql, resume);
            return new { result = "success" };
        }

        private protected override BDImageBase GetImageByType(HhLib.Share.Models.Object @object)
        {
            if (@object.GetType() == typeof(Resume.model.Resume))
                return new ResumeImage();
            return null;
        }
    }
}
