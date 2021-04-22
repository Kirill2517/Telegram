using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Models
{
    public abstract class GuidManagerBase : DataBaseController
    {
        protected override string sqlPathFolder => base.sqlPathFolder + "/Guid";
    }
}
