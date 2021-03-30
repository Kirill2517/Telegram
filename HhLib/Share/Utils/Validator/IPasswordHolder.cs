using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Utils.Validator
{
    interface IPasswordHolder
    {
        public string password { get; set; }
        public List<string> Errors { get; set; }
        public Task<bool> ValidPassword();
    }
}
