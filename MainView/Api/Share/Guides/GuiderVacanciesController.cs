using TelegramLib.Resume.guider;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Utils.Guider.Vacancy;
using TelegramLib.Resume.enums;
using TelegramLib.Vacancy.guider;
using Telegram.Utils.Guider.baseinterfaces;
using TelegramLib.Vacancy.models;

namespace Telegram.Api.Share.Guides
{
    [ApiController]
    [Route("api/guider")]
    public class GuiderVacancyController : ControllerBase, IVacancyGuider //реализция через интерфейсы
    {
        [HttpGet]
        [Route("vacancy/getvacancy/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            GuiderVacancyManager guider = new();
            TelegramLib.Vacancy.models.Vacancy value = await guider.GetVacancyById(id);
            return base.Ok(value);
        }
    }
}
