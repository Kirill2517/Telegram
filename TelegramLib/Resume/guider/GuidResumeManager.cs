using TelegramLib.Resume.model;
using TelegramLib.Share.Models;
using TelegramLib.Share.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramLib.Resume.guider
{
    public class GuidResumeManager : GuidManagerBase
    {

        protected override string sqlPathFolder => base.sqlPathFolder + "/Resume";
        public async Task<Resume.model.Resume> GetResumeById(int id)
        {
            model.Resume resume = await QueryCommandSingleOrDefaultAsync<Resume.model.Resume>($"{sqlPathFolder}/GetResumeById.sql".ReadStringFromatFromFile(id));
            if (resume != null)
                resume.skills = (await GetSkillsOfResume(resume.Id)).ToList();
            return resume;
        }

        public async Task<IEnumerable<Ability.model.Ability>> GetSkillsOfResume(int idResume)
        {
            var sql = $"{sqlPathFolder}/GetAllSkillsByIdResume.sql".ReadStringFromatFromFile(idResume);
            return await this.QueryCommandIEnumerable<Ability.model.Ability>(sql);
        }
    }
}
