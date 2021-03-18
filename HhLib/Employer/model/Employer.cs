using HhLib.DataUser.model;
using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
                return false;
            return DataUser is null || DataUser.IsValid();
        }
    }
}
