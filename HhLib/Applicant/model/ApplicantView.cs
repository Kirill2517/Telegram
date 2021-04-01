using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
