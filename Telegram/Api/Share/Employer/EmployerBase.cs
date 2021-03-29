using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Api.Share.Models;
using Telegram.Utils.Controller;

namespace Telegram.Api.Share.Employer
{
    public abstract class EmployerBase : Layer
    {
        protected sealed override string Role => AccountType.employer.ToString();
    }
}
