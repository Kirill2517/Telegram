using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.DataBaseImage
{
    public class ApplicantImage : BDImageBase
    {
        public override string Title => "Applicant";
        public override string IdFieldName => "idApplicant";
        public override string InsertCommand => $"INSERT INTO {Title} ({IdFieldName}, idSex, idEducation, idTypeOfDesiredEmployment, desiredWorkLocationArea)";

        public override string FieldsName => "@idSex, @idEducation, @idTypeOfDesiredEmployment, @desiredWorkLocationArea";

        public override Dictionary<string, object> UniqFields(HhObject hhObject)
        {
            return new Dictionary<string, object>();
        }
    }
}
