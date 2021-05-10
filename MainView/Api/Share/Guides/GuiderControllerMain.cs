using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramLib.Share.Debug.Managers;

namespace Telegram.Api.Share.Guides
{
    [ApiController]
    [Route("api/debugguider")]
    public class GuiderControllerbase : ControllerBase
    {
        public MySqlConnection MySqlConnection { get; }
        public GuiderControllerbase(MySqlConnection mySqlConnection)
        {
            MySqlConnection = mySqlConnection;
        }

#if DEBUG
        [HttpDelete]
        [Route("common/deleterecords")]
        public async Task<IActionResult> DeleteRecords()
        {
            DebugManager debugManager = new DebugManager(MySqlConnection);
            await debugManager.DeleteRecords();
            return Ok();
        }
#endif
    }
}
