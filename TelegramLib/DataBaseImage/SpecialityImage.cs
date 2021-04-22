using System.Collections.Generic;

namespace HhLib.DataBaseImage
{
    internal class SpecialityImage : BDImageBase
    {
        public override string Title => "Speciality";
        public override string IdFieldName => "idSpeciality";
        public override string InsertCommand => $"INSERT INTO {Title} (name)";
        public override string FieldsName => "@name";

        public override Dictionary<string, object> UniqFields(Share.Models.Object hhObject)
        {
            Speciality.Model.Speciality speciality = hhObject as Speciality.Model.Speciality;
            return new Dictionary<string, object>()
            {
                {
                "name", speciality.name
                }
            };
        }
    }
}
