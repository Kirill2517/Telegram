using HhLib.Applicant.Managers;
using HhLib.Applicant.model;
using HhLib.DataUser.model;
using HhLib.Share.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Utils.Controller;
using ApplicantModel = HhLib.Applicant.model.Applicant;
namespace Telegram.Api.Share.Applicant
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantAccount : ApplicantBase
    {
        [HttpPost]
        [Route("getdata")]
        public async Task<IActionResult> GetAccountData()
        {
            if (CheckRole())
            {
                ApplicantManager applicantManager = new(this.GetUserIdentity());
                return Ok(await applicantManager.GetDataAsync());
            }
            return BadRequest(new { error = "Неверный тип авторизации" });
        }
    }
}
