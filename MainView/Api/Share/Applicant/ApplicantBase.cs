using TelegramLib.Share.Models;
using Telegram.Api.Share.Models;
using MySql.Data.MySqlClient;

namespace Telegram.Api.Share.Applicant
{
    public abstract class ApplicantBase : Layer
    {
        protected ApplicantBase(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        protected sealed override string Role => AccountType.applicant.ToString();
    }
}
