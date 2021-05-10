using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramLib.Ability.model;

namespace TelegramLib.Ability.managers
{
    public class AbilityManagerApplicant : AbilityManagerBase
    {
        public AbilityManagerApplicant(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        protected override string sqlPathFolder => base.sqlPathFolder + "/Applicant";

        public void InsertPositives(int idApplicant, List<Ability.model.Ability> positives)
        {
            this.InsertCollection(positives, async (ability) =>
            {
                await InsertAbility(idApplicant, ability, new SqlFileNameAbility()
                {
                    GetAbilityByDescription = "SelectPositiveBydescription",
                    InsertToAbilityGuid = "InsertPositiveToPositivesGuid",
                    InsertToOwnerConnect = "InsertPositiveToPositivesApplicant",
                    rootFolder = $"{sqlPathFolder}/Positives"
                });
            });
        }

        public void InsertNegatives(int idApplicant, List<Ability.model.Ability> negatives)
        {
            this.InsertCollection(negatives, async (ability) =>
            {
                await InsertAbility(idApplicant, ability, new SqlFileNameAbility()
                {
                    GetAbilityByDescription = "SelectNegativeBydescription",
                    InsertToAbilityGuid = "InsertNegativeToNegativesGuid",
                    InsertToOwnerConnect = "InsertNegativeToNegativesApplicant",
                    rootFolder = $"{sqlPathFolder}/Negatives"
                });
            });
        }
    }
}
