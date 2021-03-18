using System;
using System.Collections.Generic;
using System.Text;

namespace HhLib.Share.Models
{
    public abstract class User : HhObject
    {
        public DataUser.model.DataUser DataUser { get; set; }

        public override bool IsValid()
        {
            return DataUser.IsValid();
        }
    }
}
