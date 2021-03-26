using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Api.Share.Models;

namespace Telegram.Api.Share.Applicant
{
    public abstract class ApplicantBase : Layer
    {
        protected sealed override string Role => AccountType.applicant.ToString();
    }
}
