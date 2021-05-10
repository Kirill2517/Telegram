using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramLib.Share.Models;

namespace TelegramLib.Share.Debug.Managers
{
    public class DebugManager : DataBaseController
    {
        public DebugManager(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }
       
        public async Task DeleteRecords()
        {
            await this.ActionCommand("call delete_all_data();");
        }
    }
}
