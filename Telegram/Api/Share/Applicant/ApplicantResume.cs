using HhLib.Applicant.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Utils.Controller;

namespace Telegram.Api.Share.Applicant
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantResume : ApplicantBase
    {
        [HttpPost]
        [Route("getallresume")]
        public async Task<IActionResult> GetAllResumeOfMine()
        {
            return await BaseFunction(async delegate ()
            {
                ApplicantManagerResume applicantManager = new();
                return Ok(await applicantManager.GetAllResumesAsyncByApplicantEmail(this.GetUserIdentity()));
            });
        }

        [HttpPost]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetResumeById(int id)
        {
            ApplicantManagerResume applicantManager = new();
            return Ok(await applicantManager.GetResumeById(id));
        }
    }
}
