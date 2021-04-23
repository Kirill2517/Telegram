using HhLib.Share.Models;
using HhLib.Static;

namespace HhLib.Applicant.managers
{
    public abstract class ApplicantManagerBase : DataBaseController
    {
        protected override string sqlPathFolder => base.sqlPathFolder + "/Applicant";
    }
}
