using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramLib.Applicant.managers;
using TelegramLib.Share.Utils.Extensions;
using TelegramLib.Vacancy.guider;
using TelegramLib.Vacancy.models;

namespace TelegramLib.Employer.Managers
{
    public class EmployerManagerVacancy : EmployerManagerBase
    {
        public EmployerManagerVacancy(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        protected override string sqlPathFolder => base.sqlPathFolder + "/Vacancy";

        public async Task<object> GetAllVacanciesAsyncByApplicantEmail(string email, Share.Models.Range range = null)
        {
            if (range != null && !range.IsValid())
            {
                return new { error = "Range is not valid." };
            }

            string sql = range is null
                ? $"{sqlPathFolder}/GetAllVacanciesByEmployerEmail.sql".ReadStringFromatFromFile(email)
                : $"{sqlPathFolder}/SelectRangeOfMyVacanciesByEmail.sql".ReadStringFromatFromFile(email, range.start, range.count);

            var vacancies = new List<Vacancy.models.Vacancy>();
            foreach (var id in await QueryCommandIEnumerable<int>(sql))
            {
                vacancies.Add(await new GuiderVacancyManager(this.connection).GetVacancyById(id));
            }
            return new { count = vacancies.Count, vacancies };
        }
    }
}
