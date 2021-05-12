using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Api.Share.Models;
using TelegramLib.Share.Debug.Managers;

namespace Telegram.Api.Share.DebugManagers
{
#if DEBUG
    [ApiController]
    [Route("api/debugguider")]
    public class DebugManagerController : ControllerBaseModel
    {
        public DebugManagerController(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        [HttpDelete]
        [Route("common/deleterecords")]
        public async Task<IActionResult> DeleteRecords()
        {
            DebugManager debugManager = new DebugManager(Connection);
            await debugManager.DeleteRecords();
            return Ok();
        }
    }
#endif
}
