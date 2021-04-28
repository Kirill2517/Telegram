using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Utils.Guider.baseinterfaces;
using TelegramLib.Resume.model;

namespace Telegram.Utils.Guider.Resume
{
    public interface IResumeGuider : IGuider<TelegramLib.Resume.model.Resume>
    {
    }
}
