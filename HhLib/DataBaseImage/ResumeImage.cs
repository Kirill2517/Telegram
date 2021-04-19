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
        public override string Title => "Title";
        public override string IdFieldName => "idResume";
        public override string InsertCommand => $"INSERT INTO {Title} ({IdFieldName}, idApplicant, idSpeciality, title, created, workExperience, desiredSalary, description)";
        public override string FieldsName => "@idApplicant, @idSpeciality, @title, @created, @workExperience, @desiredSalary, @description";

        public override Dictionary<string, object> UniqFields(HhObject hhObject)
        {
            return new Dictionary<string, object>();
        }
    }
}
