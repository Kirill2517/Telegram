using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Models
{
    public class Range : Object
    {
        public int start { get; set; }
        public int count { get; set; }

        public override bool IsValid()
        {
            if (start >= 0 && count >= 0)
                return true;
            return false;
        }

        public static Range FactorRange(int start, int count) => start == 0 && count == 0 ? null : new Range() { start = start, count = count };
    }
}
