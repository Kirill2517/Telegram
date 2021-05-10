using TelegramLib.Share.Models;
using Telegram.Api.Share.Models;
using MySql.Data.MySqlClient;

namespace Telegram.Api.Share.Employer
{
    public abstract class EmployerBase : Layer
    {
        protected EmployerBase(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        protected sealed override string Role => AccountType.employer.ToString();
    }
}
