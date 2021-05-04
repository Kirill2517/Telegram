using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramLib.Share.Models;
using TelegramLib.Share.Utils.Extensions;

namespace TelegramLib.Ability.managers
{
    struct SqlFileNameAbility
    {
        public string GetAbilityByDescription { get; set; }
        public string InsertToAbilityGuid { get; set; }
        public string InsertToOwnerConnect { get; set; }
        public string rootFolder { get; set; }
    }
    public class AbilityManager : DataBaseController
    {
        protected override string sqlPathFolder => base.sqlPathFolder + "/Ability";
        public void InsertSkills(Resume.model.Resume resume)
        {
            this.InsertCollection(resume.skills, async (ability) =>
            {
                await InsertAbility(resume, ability, new SqlFileNameAbility()
                {
                    GetAbilityByDescription = "SelectSkillsBydescription",
                    InsertToAbilityGuid = "InsertSkillToSkillGuid",
                    InsertToOwnerConnect = "InsertSkillToSkillResume",
                    rootFolder = "Skills/"
                });
            });
        }

        public void InsertPositives(Resume.model.Resume resume)
        {
            this.InsertCollection(resume.positives, async (ability) =>
            {
                await InsertAbility(resume, ability, new SqlFileNameAbility()
                {
                    GetAbilityByDescription = "SelectSkillsBydescription",
                    InsertToAbilityGuid = "InsertSkillToSkillGuid",
                    InsertToOwnerConnect = "InsertSkillToSkillResume",
                    rootFolder = "Positives/"
                });
            });
        }

        public void InsertNegatives(Resume.model.Resume resume)
        {
            this.InsertCollection(resume.negatives, async (ability) =>
            {
                await InsertAbility(resume, ability, new SqlFileNameAbility()
                {
                    GetAbilityByDescription = "SelectSkillsBydescription",
                    InsertToAbilityGuid = "InsertSkillToSkillGuid",
                    InsertToOwnerConnect = "InsertSkillToSkillResume",
                    rootFolder = "Negatives/"
                });
            });
        }

        private async Task InsertAbility(Resume.model.Resume resume, Ability.model.Ability ability, SqlFileNameAbility sqlFile)
        {
            var fileroot = $"{sqlPathFolder}/{sqlFile.rootFolder}";
            var sqlSelect = $"{fileroot}{sqlFile.GetAbilityByDescription}.sql".ReadStringFromatFromFile(ability.description);
            var id = await this.QueryCommandSingleOrDefaultAsync<int?>(sqlSelect);
            if (!id.HasValue)
            {
                var sqlInsert = $"{fileroot}{sqlFile.InsertToAbilityGuid}.sql".ReadStringFromatFromFile(ability.description);
                await this.ActionCommand(sqlInsert, ability.description);
                id = await this.GetLastInsertedId();
            }

            var sqlInsertSkillResume = $"{fileroot}{sqlFile.InsertToOwnerConnect}.sql".ReadStringFromatFromFile(resume.Id, id.Value);
            await this.ActionCommand(sqlInsertSkillResume, null);
        }
    }
}
