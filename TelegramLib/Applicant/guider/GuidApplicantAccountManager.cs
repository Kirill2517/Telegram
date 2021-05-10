using TelegramLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TelegramLib.Applicant.guider
{
    public class GuidApplicantAccountManager : GuidManagerBase
    {
        public GuidApplicantAccountManager(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        protected override string sqlPathFolder => base.sqlPathFolder + "/Applicant";
    }
}
