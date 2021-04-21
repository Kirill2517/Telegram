using HhLib.Applicant.model;
using HhLib.DataBaseImage.Models;
using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.DataBaseImage
{
    internal class ApplicantImage : BDImageBase
    {
        public override string Title => "Applicant";
        public override string IdFieldName => "idApplicant";
        public override string InsertCommand => $"INSERT INTO {Title} ({IdFieldName}, idSex, idEducation, idTypeOfDesiredEmployment, desiredWorkLocationArea)";

        public override string FieldsName => "@idSex, @idEducation, @idTypeOfDesiredEmployment, @desiredWorkLocationArea";

        protected override DbIndex[] Indexes => new DbIndex[]
        {
            new DbIndex("Sex_Guide", "idSex"),
            new DbIndex("Education", "idEducation"),
            new DbIndex("Type_Of_Employment", "idType_Of_Employment")
        };

        internal override Dictionary<DbIndex, object> GetIndexes(Share.Models.Object hhObject)
        {
            var applicant = hhObject as Applicant.model.Applicant;
            return new Dictionary<DbIndex, object>()
            {
                { Indexes[0], applicant.idSex },
                { Indexes[1], applicant.idEducation },
                { Indexes[2], applicant.idTypeOfDesiredEmployment }
            };
        }

        public override Dictionary<string, object> UniqFields(Share.Models.Object hhObject)
        {
            return new Dictionary<string, object>();
        }
    }
}
