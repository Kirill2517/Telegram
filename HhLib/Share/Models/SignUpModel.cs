using HhLib.Share.Utils.Validator;
using HhLib.Static;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Models
{
    public class SignUpModel<T> : HhObject, IPasswordHolder
        where T : User
    {
        public T User { get; set; }
        public string password { get; set; }
        [JsonIgnore]
        public List<string> Errors { get; set; } = new List<string>();

        public override bool IsValid()
        {
            if (new List<object> { password, User }.Contains(null))
                return false;
            if (!User.IsValid())
                return false;
            return true;
        }

        public async Task<bool> ValidPassword()
        {
            IdentityResult identityResult = await Settings.PasswordValidator.ValidateAsync(password);
            if (!identityResult.Succeeded)
                Errors = new List<string>(identityResult.Errors);
            return identityResult.Succeeded;
        }
    }
}
