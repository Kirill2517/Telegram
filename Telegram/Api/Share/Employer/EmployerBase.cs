using HhLib.Share.Models;
using Telegram.Api.Share.Models;

namespace Telegram.Api.Share.Employer
{
    public abstract class EmployerBase : Layer
    {
        protected sealed override string Role => AccountType.employer.ToString();
    }
}
