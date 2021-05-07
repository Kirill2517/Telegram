using TelegramLib.Resume.model;
using TelegramLib.Share.Models;
using TelegramLib.Share.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramLib.Ability.model;

namespace TelegramLib.Resume.guider
{
    public class GuidResumeManager : GuidManagerBase
    {

        protected override string sqlPathFolder => base.sqlPathFolder + "/Resume";
        public async Task<Resume.model.Resume> GetResumeById(int id)
        {
            model.Resume resume = await QueryCommandSingleOrDefaultAsync<Resume.model.Resume>($"{sqlPathFolder}/GetResumeById.sql".ReadStringFromatFromFile(id));
            if (resume != null)
            {
                resume.skills = (await GetSkillsOfResume(resume.Id)).ToList();
                resume.Abilities = await GetAbilitiesByResumeId(resume.Id);
            }
            return resume;
        }

        public async Task<IEnumerable<Ability.model.Ability>> GetSkillsOfResume(int idResume)
        {
            var sql = $"{sqlPathFolder}/GetAllSkillsByIdResume.sql".ReadStringFromatFromFile(idResume);
            return await this.QueryCommandIEnumerable<Ability.model.Ability>(sql);
        }

        public async Task<Abilities> GetAbilitiesByResumeId(int ResumeId)
        {
            return new Ability.model.Abilities()
            {
                negatives = (await GetNegativesOfResume(ResumeId)).ToList(),
                positives = (await GetPositivesOfResume(ResumeId)).ToList()
            };
        }

        private async Task<IEnumerable<Ability.model.Ability>> GetPositivesOfResume(int idResume)
        {
            var sql = $"{sqlPathFolder}/GetAllPositivesByIdResume.sql".ReadStringFromatFromFile(idResume);
            return await this.QueryCommandIEnumerable<Ability.model.Ability>(sql);
        }

        private async Task<IEnumerable<Ability.model.Ability>> GetNegativesOfResume(int idResume)
        {
            var sql = $"{sqlPathFolder}/GetAllNegativesByIdResume.sql".ReadStringFromatFromFile(idResume);
            return await this.QueryCommandIEnumerable<Ability.model.Ability>(sql);
        }
    }
}
