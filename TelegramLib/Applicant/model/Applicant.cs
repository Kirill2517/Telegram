using TelegramLib.Share.Models;
using System.Text.Json.Serialization;

namespace TelegramLib.Applicant.model
{
    public class Applicant : User
    {
        public int? idSex { get; set; }
        public int? idEducation { get; set; }
        [JsonPropertyName("idTypeEmployment")]
        public int? idTypeOfDesiredEmployment { get; set; }
        [JsonPropertyName("desiredArea")]
        public string desiredWorkLocationArea { get; set; }

        public override bool IsValid()
        {
            return DataUserIsValid;
        }
    }
}
