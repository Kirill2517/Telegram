using System.Collections.Generic;
using TelegramLib.Share.Models;

namespace TelegramLib.Resume.model
{
    internal interface IContainerUniqueData
    {
        public void DeleteDuplicatesDatas();
    }
}