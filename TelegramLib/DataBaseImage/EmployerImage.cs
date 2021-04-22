using System.Collections.Generic;

namespace HhLib.DataBaseImage
{
    internal class EmployerImage : BDImageBase
    {
        public override string Title => "Employer";
        public override string IdFieldName => "idEmployer";
        public override string InsertCommand => $"INSERT INTO {Title} ({IdFieldName}, name, address, website)";
        public override string FieldsName => "@name, @address, @website";
        public override Dictionary<string, object> UniqFields(Share.Models.Object hhObject)
        {
            Employer.model.Employer employer = hhObject as Employer.model.Employer;
            return new Dictionary<string, object>()
            {
                {
                "name", employer.name
                },
                {
                "website", employer.website
                },
            };
        }
    }
}
