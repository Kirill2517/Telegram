using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Api.Share.Models;
using TelegramLib.Share.Debug.Managers;

namespace Telegram.Api.Share.Guides
{
    public class GuiderControllerbase : ControllerBaseModel
    {
        public GuiderControllerbase(MySqlConnection connection) : base(connection)
        {
        }
    }
}
