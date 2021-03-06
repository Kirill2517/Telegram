﻿using System;
using System.Collections.Generic;

namespace TelegramLib.Share.Models
{
    public class SignInModel : Object
    {
        public string deviceId { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        [NonSerialized]
        public AccountType accountType;
        public override bool IsValid()
        {
            if (new List<object> { email, password, deviceId }.Contains(null))
            {
                return false;
            }

            return true;
        }
    }
}
