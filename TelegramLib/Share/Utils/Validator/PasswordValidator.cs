using TelegramLib.Share.Models;
using System.Threading.Tasks;

namespace TelegramLib.Share.Utils.Validator
{
    public class PasswordValidator : IIdentityValidator<string>
    {
        public bool RequireUppercase { get; set; }
        public bool RequireNonLetterOrDigit { get; set; }
        public bool RequireLowercase { get; set; }
        public uint RequiredLength { get; set; }
        public bool RequireDigit { get; set; }
        public async Task<IdentityResult> ValidateAsync(string item)
        {
            IdentityResult ir = new IdentityResult() { Successed = true };
            return ir;
        }
    }
}
