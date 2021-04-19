using HhLib.DataBaseImage;
using HhLib.Share.models;
using HhLib.Share.Models;
using HhLib.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Speciality.Managers
{
    public class SpecialityManager : DataBaseController
    {
        protected const string sqlPathMain = Settings.SqlFolder + "/Speciality";

        public async Task<int> GetIdSpeciality(string name)
        {
            var speciality = new Speciality.Model.Speciality() { name = name };
            if (await FieldsUniqAsync(speciality))
                await InsertSpecialityAsync(speciality);
            var image = GetImageByType(speciality);
            return await QueryCommandSingleAsync<int>($"select {image.IdFieldName} from {image.Title}");
        }

        private async Task<bool> InsertSpecialityAsync(Speciality.Model.Speciality speciality)
        {
            BDImageBase targetImage = GetImageByType(speciality);
            var command = $"{targetImage.InsertCommand} VALUES {targetImage.FieldsName});";
            return await this.InsertCommand(command, speciality) > 0;
        }

        private protected override BDImageBase GetImageByType<T>(T @object)
        {
            if (@object.GetType() == typeof(Speciality.Model.Speciality))
                return new SpecialityImage();
            return null;
        }
    }
}
