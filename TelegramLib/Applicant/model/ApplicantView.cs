using TelegramLib.Ability.model;
using TelegramLib.Share.Models;

namespace TelegramLib.Applicant.model
{
    public class ApplicantView : User
    {
        public string desiredWorkLocationArea { get; set; }
        public string typeEmployment { get; set; }
        public string education { get; set; }
        public string gender { get; set; }
        public Abilities Abilities { get; set; }
    }
}
