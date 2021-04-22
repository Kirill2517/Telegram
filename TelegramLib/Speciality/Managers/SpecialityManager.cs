using HhLib.DataBaseImage;
using HhLib.Share.Models;
using HhLib.Static;
using System.Threading.Tasks;

namespace HhLib.Speciality.Managers
{
    public class SpecialityManager : DataBaseController
    {
        protected const string sqlPathMain = Settings.SqlFolder + "/Speciality";

        public async Task<int> GetIdSpeciality(string name)
        {
            Model.Speciality speciality = new Speciality.Model.Speciality() { name = name };
            if (await FieldsUniqAsync(speciality))
            {
                await InsertSpecialityAsync(speciality);
            }

            BDImageBase image = GetImageByType(speciality);
            return await QueryCommandSingleAsync<int>($"select {image.IdFieldName} from {image.Title} where name = '{name}'");
        }

        private async Task<bool> InsertSpecialityAsync(Speciality.Model.Speciality speciality)
        {
            BDImageBase targetImage = GetImageByType(speciality);
            string command = $"{targetImage.InsertCommand} VALUES ({targetImage.FieldsName});";
            return await ActionCommand(command, speciality) > 0;
        }

        private protected override BDImageBase GetImageByType(HhLib.Share.Models.Object @object)
        {
            if (@object.GetType() == typeof(Speciality.Model.Speciality))
            {
                return new SpecialityImage();
            }

            return null;
        }
    }
}
