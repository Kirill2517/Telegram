using TelegramLib.DataBaseImage;
using TelegramLib.Share.Models;
using TelegramLib.Static;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TelegramLib.Speciality.Managers
{
    public class SpecialityManager : DataBaseController
    {
        public SpecialityManager(MySqlConnection mySqlConnection) : base(mySqlConnection)
        {
        }

        protected override string sqlPathFolder => base.sqlPathFolder + "/Speciality";

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

        private protected override BDImageBase GetImageByType(TelegramLib.Share.Models.Object @object)
        {
            if (@object.GetType() == typeof(Speciality.Model.Speciality))
            {
                return new SpecialityImage();
            }

            return null;
        }
    }
}
