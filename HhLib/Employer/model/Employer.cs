using HhLib.Share.Models;
using System.Collections.Generic;

namespace HhLib.Employer.model
{
    public class Employer : User
    {
        public string name { get; set; }
        public string address { get; set; }
        public string website { get; set; }

        public override bool IsValid()
        {
            if (new List<object> { name }.Contains(null))
            {
                return false;
            }

            return DataUserIsValid;
        }
    }
}
