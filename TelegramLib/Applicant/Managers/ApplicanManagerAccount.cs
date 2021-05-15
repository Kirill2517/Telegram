using TelegramLib.Share.Utils.Extensions;
using System.Threading.Tasks;
using System.Collections.Generic;
using TelegramLib.Ability.model;
using TelegramLib.Ability.managers;
using System.Linq;
using MySql.Data.MySqlClient;
using Dapper;
using System.Diagnostics;

namespace TelegramLib.Applicant.managers
{
    public class ApplicanManagerAccount : ApplicantManagerBase
    {
        public ApplicanManagerAccount(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        protected override string sqlPathFolder => base.sqlPathFolder + "/Account";
        public async Task<DataUser.model.DataUser> GetDataUserAsync(string email)
        {
            return await QueryCommandSingleAsync<DataUser.model.DataUser>($"{sqlPathFolder}/GetDataUserByEmail.sql".ReadStringFromatFromFile(await GetUserId(email)));
        }

        public async Task<Applicant.model.ApplicantView> GetApplicantDataAsync(string email)
        {
            return await QueryCommandSingleAsync<Applicant.model.ApplicantView>($"{sqlPathFolder}/GetApplicantData.sql".ReadStringFromatFromFile(await GetUserId(email)));
        }

        public async Task<Abilities> GetAbilitiesByApplicantId(string email)
        {
            return new Abilities()
            {
                negatives = (await this.QueryCommandIEnumerable<Ability.model.Ability>($"{sqlPathFolder}/GetNegativesByApplicantId.sql".ReadStringFromatFromFile(await GetUserId(email)))).ToList(),
                positives = (await this.QueryCommandIEnumerable<Ability.model.Ability>($"{sqlPathFolder}/GetPositivesByApplicantId.sql".ReadStringFromatFromFile(await GetUserId(email)))).ToList()
            };
        }

        public async Task<object> AddAbilities(string email, Abilities abilities)
        {
            if (!abilities.IsValid())
                return new { error = "model is not valid." };
            AbilityManagerApplicant abilityManager = new(this.connection);
            abilityManager.InsertPositives(await this.GetUserId(email), abilities.positives);
            abilityManager.InsertNegatives(await this.GetUserId(email), abilities.negatives);
            return new { success = "abilities has been added" };
        }

        public async Task<Applicant.model.ApplicantView> GetFullDataAsync(string email)
        {
            model.ApplicantView applicant = await GetApplicantDataAsync(email);
            applicant.DataUser = await GetDataUserAsync(email);
            applicant.Abilities = await GetAbilitiesByApplicantId(email);
            return applicant;
        }
    }
}
