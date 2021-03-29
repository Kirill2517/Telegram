using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Api.Share.Models;
<<<<<<< HEAD
using Telegram.Utils.Controller;
=======
>>>>>>> 72218f33386eaf737715efd4fc25e8af79597616

namespace Telegram.Api.Share.Employer
{
    public abstract class EmployerBase : Layer
    {
        protected sealed override string Role => AccountType.employer.ToString();
    }
}
