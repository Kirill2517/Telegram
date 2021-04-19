using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.DataBaseImage
{
    internal class SpecialityImage : BDImageBase
    {
        public override string Title => "Speciality";
        public override string IdFieldName => "idSpeciality";
        public override string InsertCommand => $"INSERT INTO {Title} ({IdFieldName}, name)";
        public override string FieldsName => "@name";

        public override Dictionary<string, object> UniqFields(HhObject hhObject)
        {
            var speciality = hhObject as Speciality.Model.Speciality;
            return new Dictionary<string, object>()
            {
                {
                "name", speciality.name
                }
            };
        }
    }
}
