using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator.entity
{
    public class Applicant : User
    {
        public int idSex { get; set; }
        public int idEducation { get; set; }
        public int idTypeEmployment { get; set; }
        public string desiredArea { get; set; }
    }
}
