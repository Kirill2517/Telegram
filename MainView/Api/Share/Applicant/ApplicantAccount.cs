using TelegramLib.Applicant.managers;
using TelegramLib.Applicant.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Utils.Controller;
using System.Collections.Generic;
using TelegramLib.Ability.model;

namespace Telegram.Api.Share.Applicant
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantAccount : ApplicantBase
    {
        [HttpGet]
        [Route("getdata")]
        public async Task<IActionResult> GetAccountData()
        {
            return await BaseFunction(async delegate ()
            {
                ApplicanManagerAccount applicantManager = new();
                return Ok(await applicantManager.GetDataUserAsync(this.GetUserIdentity()));
            });
        }

        [HttpGet]
        [Route("getshortdata")]
        public async Task<IActionResult> GetApplicantData()
        {
            return await base.BaseFunction(async delegate ()
            {
                ApplicanManagerAccount applicantManager = new();
                ApplicantView applicant = await applicantManager.GetApplicantDataAsync(this.GetUserIdentity());
                return base.Ok(new { applicant.education, applicant.desiredWorkLocationArea, applicant.gender, applicant.typeEmployment });
            });
        }

        [HttpGet]
        [Route("getfulldata")]
        public async Task<IActionResult> GetFullAccountData()
        {
            return await base.BaseFunction(async delegate ()
            {
                ApplicanManagerAccount applicantManager = new();
                return Ok(await applicantManager.GetFullDataAsync(this.GetUserIdentity()));
            });
        }

        [HttpPost]
        [Route("addabilities")]
        public async Task<IActionResult> AddAbilities(Abilities abilities)
        {
            if (abilities is null)
                return BadRequest();
            return await base.BaseFunction(async delegate ()
            {
                ApplicanManagerAccount applicantManager = new();
                return Ok(await applicantManager.AddAbilities(this.GetUserIdentity(), abilities));
            });
        }
    }
}
