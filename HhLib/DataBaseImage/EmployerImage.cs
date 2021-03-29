using HhLib.DataBaseImage.Models;
using HhLib.Employer.model;
using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.DataBaseImage
{
    internal class EmployerImage : BDImageBase
    {
        public override string Title => "Employer";
        public override string IdFieldName => "idEmployer";
        public override string InsertCommand => $"INSERT INTO {Title} ({IdFieldName}, name, address, website)";
        public override string FieldsName => "@name, @address, @website";
        public override Dictionary<string, object> UniqFields(HhObject hhObject)
        {
            var employer = hhObject as Employer.model.Employer;
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
