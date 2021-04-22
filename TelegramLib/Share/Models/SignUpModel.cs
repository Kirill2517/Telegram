using HhLib.Share.Utils.Validator;
using HhLib.Static;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HhLib.Share.Models
{
    public class SignUpModel<T> : Object, IPasswordHolder
        where T : User
    {
        public T User { get; set; }
        public string password { get; set; }
        public string fingerprint { get; set; }
        [JsonIgnore]
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();

        public override bool IsValid()
        {
            if (new List<object> { password, User, fingerprint }.Contains(null))
            {
                return false;
            }

            if (!User.IsValid())
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ValidPassword()
        {
            IdentityResult identityResult = await Settings.PasswordValidator.ValidateAsync(password);
            if (!identityResult.Successed)
            {
                Errors = new List<ErrorModel>(identityResult.Errors);
            }

            return identityResult.Successed;
        }
    }
}
