using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramLib.Share.Models;
using TelegramLib.Share.Utils.Extensions;

namespace TelegramLib.Ability.managers
{
    internal struct SqlFileNameAbility
    {
        public string GetAbilityByDescription { get; set; }
        public string InsertToAbilityGuid { get; set; }
        public string InsertToOwnerConnect { get; set; }
        public string rootFolder { get; set; }
    }
    public class AbilityManagerBase : DataBaseController
    {
        protected override string sqlPathFolder => base.sqlPathFolder + "/Ability";
        protected private async Task InsertAbility(int idModel, Ability.model.Ability ability, SqlFileNameAbility sqlFile)
        {
            var fileroot = sqlFile.rootFolder;
            var sqlSelect = $"{fileroot}/{sqlFile.GetAbilityByDescription}.sql".ReadStringFromatFromFile(ability.description);
            var id = await this.QueryCommandSingleOrDefaultAsync<int?>(sqlSelect);
            if (!id.HasValue)
            {
                var sqlInsert = $"{fileroot}/{sqlFile.InsertToAbilityGuid}.sql".ReadStringFromatFromFile(ability.description);
                await this.ActionCommand(sqlInsert, ability.description);
                id = await this.GetLastInsertedId();
            }

            var sqlInsertSkillResume = $"{fileroot}/{sqlFile.InsertToOwnerConnect}.sql".ReadStringFromatFromFile(idModel, id.Value);
            try
            {
                await this.ActionCommand(sqlInsertSkillResume, null);
            }
            catch { };
        }
    }
}
