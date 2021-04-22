using HhLib.Share.Models;

namespace HhLib.Applicant.model
{
    public class ApplicantView : User
    {
        public string desiredWorkLocationArea { get; set; }
        public string typeEmployment { get; set; }
        public string education { get; set; }
        public string gender { get; set; }
    }
}
