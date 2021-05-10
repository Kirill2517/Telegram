using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator.entity
{
    public abstract class User
    {
        public Datauser dataUser { get; set; }
    }

    public class Employer : User
    {
        public string name { get; set; }
        public string address { get; set; }
        public string website { get; set; }
    }
}
