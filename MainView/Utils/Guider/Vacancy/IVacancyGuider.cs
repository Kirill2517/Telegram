using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Utils.Guider.baseinterfaces;
using TelegramLib.Vacancy.models;

namespace Telegram.Utils.Guider.Vacancy
{
    public interface IVacancyGuider : IGuider<TelegramLib.Vacancy.models.Vacancy>
    {
    }
}
