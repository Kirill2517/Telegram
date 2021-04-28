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

        public void InsertAbilities(Resume.model.Resume resume)
        {
            this.InsertCollection(resume.skills, async (ability) =>
            {
                var sqlSelect = $"{sqlPathFolder}/SelectSkillsBydescription.sql".ReadStringFromatFromFile(ability.description);
                var id = await this.QueryCommandSingleOrDefaultAsync<int?>(sqlSelect);
                if (!id.HasValue)
                {
                    var sqlInsert = $"{sqlPathFolder}/InsertSkillToSkillGuid.sql".ReadStringFromatFromFile(ability.description);
                    await this.ActionCommand(sqlInsert, ability.description);
                    id = await this.GetLastInsertedId();
                }

                var sqlInsertSkillResume = $"{sqlPathFolder}/InsertSkillToSkillResume.sql".ReadStringFromatFromFile(resume.Id, id.Value);
                await this.ActionCommand(sqlInsertSkillResume, null);
            });
        }

        public async Task<IEnumerable<Ability.model.Ability>> GetSkillsOfResume(int idResume)
        {
            var sql = $"{sqlPathFolder}/GetAllSkillsByIdResume.sql".ReadStringFromatFromFile(idResume);
            return await this.QueryCommandIEnumerable<Ability.model.Ability>(sql);
        }
    }
}
