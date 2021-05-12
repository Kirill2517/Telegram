using TelegramLib.Applicant.managers;
using TelegramLib.Resume.model;
using TelegramLib.Share.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Utils.Controller;
using MySql.Data.MySqlClient;

namespace Telegram.Api.Share.Applicant
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantResume : ApplicantBase
    {
        public ApplicantResume(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }
        //Варианты использования метода
        //без параметров - выдаст все свои резюме
        //с параметрами start и count - в определенном диапазоне
        //с параметром count - резюме от 0 до count
        [HttpGet]
        [Route("getallresume")]
        public async Task<IActionResult> GetAllResumeOfMine(int start, int count)
        {
            return await BaseFunction(async delegate ()
            {
                Range range = Range.FactorRange(start, count);
                ApplicantManagerResume applicantManager = new(Connection);
                return Ok(await applicantManager.GetAllResumesAsyncByApplicantEmail(this.GetUserIdentity(), range));
            });
        }

        [HttpPost]
        [Route("createresume")]
        public async Task<IActionResult> CreateResume(Resume resume)
        {
            return await BaseFunction(async delegate ()
            {
                ApplicantManagerResume applicantManager = new(Connection);
                //TODO: возврат positives, negatives
                return Ok(await applicantManager.CreateResume(resume, this.GetUserIdentity()));
            });
        }
    }
}
