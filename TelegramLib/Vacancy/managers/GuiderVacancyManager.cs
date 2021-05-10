using TelegramLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramLib.Vacancy.models;
using TelegramLib.Share.Utils.Extensions;
using MySql.Data.MySqlClient;

namespace TelegramLib.Vacancy.guider
{
    public class GuiderVacancyManager : GuidManagerBase
    {
        public GuiderVacancyManager(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        protected override string sqlPathFolder => base.sqlPathFolder + "/Vacancy";

        public async Task<Vacancy.models.Vacancy> GetVacancyById(int id)
        {
            Vacancy.models.Vacancy vacancy = await QueryCommandSingleOrDefaultAsync<Vacancy.models.Vacancy>($"{sqlPathFolder}/GetVacancyById.sql".ReadStringFromatFromFile(id));
            if (vacancy != null)
                vacancy.skills = (await GetSkillsOfVacancy(vacancy.Id)).ToList();
            return vacancy;
        }


        public async Task<IEnumerable<Ability.model.Ability>> GetSkillsOfVacancy(int idVacancy)
        {
            var sql = $"{sqlPathFolder}/GetAllSkillsByIdVacancy.sql".ReadStringFromatFromFile(idVacancy);
            return await this.QueryCommandIEnumerable<Ability.model.Ability>(sql);
        }
    }
}
