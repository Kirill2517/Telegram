using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Utils.Controller;
using TelegramLib.Employer.Managers;
using TelegramLib.Share.Models;

namespace Telegram.Api.Share.Employer
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployerVacancy : EmployerBase
    {
        public EmployerVacancy(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        [HttpGet]
        [Route("getallvacancies")]
        public async Task<IActionResult> GetAllResumeOfMine(int start, int count)
        {
            return await BaseFunction(async delegate ()
            {
                Range range = Range.FactorRange(start, count);
                EmployerManagerVacancy applicantManager = new(Connection);
                return Ok(await applicantManager.GetAllVacanciesAsyncByApplicantEmail(this.GetUserIdentity(), range));
            });
        }
    }
}
