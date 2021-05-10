using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator
{
    public static class Extensions
    {
        private static Random gen = new Random();
        public static DateTime RandomDay(this DateTime dateTime)
        {
            DateTime start = new DateTime(1976, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
