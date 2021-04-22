using HhLib.Share.Models;
using Newtonsoft.Json;

namespace HhLib.Applicant.model
{
    public class Applicant : User
    {
        public int? idSex { get; set; }
        public int? idEducation { get; set; }
        [JsonProperty(PropertyName = "idTypeEmployment")]
        public int? idTypeOfDesiredEmployment { get; set; }
        [JsonProperty(PropertyName = "desiredArea")]
        public string desiredWorkLocationArea { get; set; }

        public override bool IsValid()
        {
            return DataUserIsValid;
        }
    }
}
