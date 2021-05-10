using MySql.Data.MySqlClient;
using TelegramLib.Share.Models;
using TelegramLib.Static;

namespace TelegramLib.Applicant.managers
{
    public abstract class ApplicantManagerBase : DataBaseController
    {
        protected ApplicantManagerBase(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        protected override string sqlPathFolder => base.sqlPathFolder + "/Applicant";
    }
}
