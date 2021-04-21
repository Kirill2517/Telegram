using HhLib.DataBaseImage.Models;
using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.DataBaseImage
{
    internal class ResumeImage : BDImageBase
    {
        public override string Title => "Resume";
        public override string IdFieldName => "idResume";
        public override string InsertCommand => $"INSERT INTO {Title} (idApplicant, idSpeciality, created, title, workExperience, desiredSalary, description)";
        public override string FieldsName => "@title, @workExperience, @desiredSalary, @description";

        public override Dictionary<string, object> UniqFields(Share.Models.Object hhObject)
        {
            return new Dictionary<string, object>();
        }
    }
}
