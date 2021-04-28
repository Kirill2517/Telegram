using TelegramLib.Share.Models;
using TelegramLib.Static;

namespace TelegramLib.Applicant.managers
{
    public abstract class ApplicantManagerBase : DataBaseController
    {
        protected override string sqlPathFolder => base.sqlPathFolder + "/Applicant";
    }
}
