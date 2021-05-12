using TelegramLib.Resume.guider;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Utils.Guider.Resume;
using TelegramLib.Resume.enums;
using Telegram.Utils.Guider.baseinterfaces;
using TelegramLib.Resume.model;
using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;
using TelegramLib.Static;

namespace Telegram.Api.Share.Guides
{
    [ApiController]
    [Route("api/guider")]
    public class GuiderResumeController : GuiderControllerbase, IResumeGuider //реализация через интерфейсы
    {
        public GuiderResumeController(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }


        [HttpGet]
        [Route("resume/getresume/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseFunction(async () =>
            {
                GuidResumeManager resumeManager = new(Connection);
                return Ok(await resumeManager.GetResumeById(id));
            });
        }
    }
}
