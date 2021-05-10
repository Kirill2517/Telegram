using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramLib.Share.Models;

namespace TelegramLib.Employer.Managers
{
    public class EmployerManagerBase : DataBaseController
    {
        public EmployerManagerBase(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        protected override string sqlPathFolder => base.sqlPathFolder + "/Employer";
    }
}
