﻿using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HhLib.DataUser.model
{
    public class DataUser : HhObject
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public DateTime birthday { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }

        public override bool IsValid()
        {
            if (new List<object> { email, firstName, middleName, surname, phone }.Contains(null))
                return false;
            if (!new EmailAddressAttribute().IsValid(email))
                return false;
            if (!new PhoneAttribute().IsValid(phone))
                return false;
            return true;
        }
    }
}
