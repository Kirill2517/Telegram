using HhLib.Share.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HhLib.Share.Utils.Validator
{
    internal interface IPasswordHolder
    {
        public string password { get; set; }
        public List<ErrorModel> Errors { get; set; }
        public Task<bool> ValidPassword();
    }
}
