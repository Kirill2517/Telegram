using TelegramLib.Resume.guider;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Utils.Guider.Resume;
using TelegramLib.Resume.enums;
using Telegram.Utils.Guider.baseinterfaces;
using TelegramLib.Resume.model;

namespace Telegram.Api.Share.Guides
{
    [ApiController]
    [Route("api/guider")]
    public class GuiderResumeController : GuiderControllerbase, IResumeGuider //реализация через интерфейсы
    {
        [HttpGet]
        [Route("resume/getresume/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            GuidResumeManager resumeManager = new();
            return Ok(await resumeManager.GetResumeById(id));
        }
    }
}
