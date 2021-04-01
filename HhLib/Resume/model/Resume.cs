using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Resume.model
{
    public class Resume : HhObject
    {
        public string Owner { get; set; }
        public string Speciality { get; set; }
    }
}
