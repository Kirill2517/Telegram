using TelegramLib.Applicant.managers;
using TelegramLib.Applicant.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Utils.Controller;
using System.Collections.Generic;
using TelegramLib.Ability.model;
using MySql.Data.MySqlClient;

namespace Telegram.Api.Share.Applicant
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantAccount : ApplicantBase
    {
        public ApplicantAccount(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        [HttpGet]
        [Route("getdata")]
        public async Task<IActionResult> GetAccountData()
        {
            return await AuthRoleCheck(async delegate ()
            {
                ApplicanManagerAccount applicantManager = new(Connection);
                return Ok(await applicantManager.GetDataUserAsync(this.GetUserIdentity()));
            });
        }

        [HttpGet]
        [Route("getshortdata")]
        public async Task<IActionResult> GetApplicantData()
        {
            return await base.AuthRoleCheck(async delegate ()
            {
                ApplicanManagerAccount applicantManager = new(Connection);
                ApplicantView applicant = await applicantManager.GetApplicantDataAsync(this.GetUserIdentity());
                return base.Ok(new { applicant.education, applicant.desiredWorkLocationArea, applicant.gender, applicant.typeEmployment });
            });
        }

        [HttpGet]
        [Route("getfulldata")]
        public async Task<IActionResult> GetFullAccountData()
        {
            return await base.AuthRoleCheck(async delegate ()
            {
                ApplicanManagerAccount applicantManager = new(Connection);
                return Ok(await applicantManager.GetFullDataAsync(this.GetUserIdentity()));
            });
        }

        [HttpPost]
        [Route("addabilities")]
        public async Task<IActionResult> AddAbilities(Abilities abilities)
        {
            if (abilities is null)
                return BadRequest();
            return await base.AuthRoleCheck(async delegate ()
            {
                ApplicanManagerAccount applicantManager = new(Connection);
                return Ok(await applicantManager.AddAbilities(this.GetUserIdentity(), abilities));
            });
        }
    }
}
