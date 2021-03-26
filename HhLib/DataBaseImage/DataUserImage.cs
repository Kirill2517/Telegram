using HhLib.DataBaseImage.Models;
using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.DataBaseImage
{
    internal class DataUserImage : BDImageBase
    {
        public override string Title => "DataUser";
        public override string IdFieldName => "id";
        public override string InsertCommand => $"INSERT INTO {Title} (email, firstName, middleName, birthday, surname, phone, password) ";

        public override string FieldsName => "@email, @firstName, @middleName, @birthday, @surname, @phone";
        public override Dictionary<string, object> UniqFields(HhObject hhObject)
        {
            var dataUser = hhObject as DataUser.model.DataUser;
            return new Dictionary<string, object>()
            {
                {
                "phone", dataUser.phone
                },
                {
                "email", dataUser.email
                }
            };
        }
    }
}
