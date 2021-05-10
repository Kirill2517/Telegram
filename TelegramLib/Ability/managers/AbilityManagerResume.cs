using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramLib.Ability.managers
{
    public class AbilityManagerResume : AbilityManagerBase
    {
        public AbilityManagerResume(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        protected override string sqlPathFolder => base.sqlPathFolder + "/Skills";
        public void InsertSkills(Resume.model.Resume resume)
        {
            this.InsertCollection(resume.skills, async (ability) =>
            {
                await InsertAbility(resume.Id, ability, new SqlFileNameAbility()
                {
                    GetAbilityByDescription = "SelectSkillsBydescription",
                    InsertToAbilityGuid = "InsertSkillToSkillGuid",
                    InsertToOwnerConnect = "InsertSkillToSkillResume",
                    rootFolder = sqlPathFolder
                });
            });
        }
    }
}
