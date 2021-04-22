using HhLib.DataBaseImage;
using HhLib.Share.Interfaces;
using HhLib.Share.Models;
using HhLib.Share.Models;
using HhLib.Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HhLib.Applicant.managers
{
    public abstract class ApplicantManagerBase : DataBaseController
    {
        protected override string sqlPathFolder => Settings.SqlFolder + "/Applicant";
    }
}
