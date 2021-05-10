using MySql.Data.MySqlClient;

namespace TelegramLib.Share.Models
{
    public abstract class GuidManagerBase : DataBaseController
    {
        protected GuidManagerBase(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        protected override string sqlPathFolder => base.sqlPathFolder + "/Guid";
    }
}
