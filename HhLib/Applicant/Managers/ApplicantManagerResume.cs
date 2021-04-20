using HhLib.DataBaseImage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Applicant.Managers
{
    public class ApplicantManagerResume : ApplicantManagerBase
    {
        private readonly string sqlPathMain = ApplicantManagerBase.sqlPathMain + "/Resume";

        public async Task<IEnumerable<Resume.model.Resume>> GetAllResumesAsyncByApplicantEmail(string email)
        {
            string sql = string.Format(File.ReadAllText($"{sqlPathMain}/GetAllResumeByApplicantEmail.sql"), email);
            return await this.QueryCommandIEnumerable<Resume.model.Resume>(sql);
        }

        public async Task<IEnumerable<Resume.model.Resume>> GetAllResumesAsyncByApplicantId(int id)
        {
            string sql = string.Format(File.ReadAllText($"{sqlPathMain}/GetAllResumeByApplicantId.sql"), id);
            return await this.QueryCommandIEnumerable<Resume.model.Resume>(sql);
        }

        public async Task<Resume.model.Resume> GetResumeById(int id)
        { 
            return await this.QueryCommandSingleOrDefaultAsync<Resume.model.Resume>(string.Format(File.ReadAllText($"{sqlPathMain}/GetResumeById.sql"), id));
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
            await this.InsertCommand(sql, resume);
            return new { result = "success" };
        }

        private protected override BDImageBase GetImageByType<T>(T @object)
        {
            if (@object.GetType() == typeof(Resume.model.Resume))
                return new ResumeImage();
            return null;
        }
    }
}
