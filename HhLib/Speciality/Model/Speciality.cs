using System.Collections.Generic;

namespace HhLib.Speciality.Model
{
    public class Speciality : Share.Models.Object
    {
        public int IdSpeciality { get; set; }
        public string name { get; set; }

        public override bool IsValid()
        {
            if (new List<object> { name }.Contains(null))
            {
                return false;
            }

            return true;
        }
    }
}
