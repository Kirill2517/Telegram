using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramLib.Share.Models;

namespace Telegram.Utils.Guider.baseinterfaces
{
    public interface IGuider<T>
        where T: TelegramLib.Share.Models.Object
    {
        public Task<IActionResult> GetById(int id);
    }
}
