using TelegramLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramLib.Applicant.guider
{
    public class GuidApplicantAccountManager : GuidManagerBase
    {
        protected override string sqlPathFolder => base.sqlPathFolder + "/Applicant";
    }
}
