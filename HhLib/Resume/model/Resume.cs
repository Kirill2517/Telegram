using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Resume.model
{
    public class Resume : Share.Models.Object
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Speciality { get; set; }
        public string workExperience { get; set; }
        public string desiredSalary { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public DateTime created { get; set; }

        public override bool IsValid()
        {
            if (new List<object> { Speciality, title, workExperience }.Contains(null))
                return false;
            return true;
        }
    }
}
