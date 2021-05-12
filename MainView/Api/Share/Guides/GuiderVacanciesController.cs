using TelegramLib.Resume.guider;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Utils.Guider.Vacancy;
using TelegramLib.Resume.enums;
using TelegramLib.Vacancy.guider;
using Telegram.Utils.Guider.baseinterfaces;
using TelegramLib.Vacancy.models;
using MySql.Data.MySqlClient;

namespace Telegram.Api.Share.Guides
{
    [ApiController]
    [Route("api/guider")]
    public class GuiderVacancyController : GuiderControllerbase, IVacancyGuider //реализция через интерфейсы
    {
        public GuiderVacancyController(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        [HttpGet]
        [Route("vacancy/getvacancy/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseFunction(async () =>
            {
                GuiderVacancyManager guider = new(Connection);
                Vacancy value = await guider.GetVacancyById(id); return base.Ok(value);
            });
        }
    }
}
