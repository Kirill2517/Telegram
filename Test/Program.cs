<<<<<<< HEAD
﻿//local master
//hfghgdhfghgf
=======
﻿using System;

namespace ConsoleApplication4
{
    class Program
    {
        class Per
        { 
            public string key { get; set; }
        }
        static void Main(string[] args)
        {
            var a = new { key = "str" };
            var t = a.GetType();

        }

        private static void TestMethod(Object x)
        {
            // This is a dummy value, just to get 'a' to be of the right type
            var a = new { Id = 0, Name = "" };
            a = Cast(a, x);
            Console.Out.WriteLine(a.Id + ": " + a.Name);
        }

        private static T Cast<T>(T typeHolder, Object x)
        {
            // typeHolder above is just for compiler magic
            // to infer the type to cast x to
            return (T)x;
        }
    }

    public static class Ext {
        public static T CastTo<T>(this Object value, T targetType)
        {
            // targetType above is just for compiler magic
            // to infer the type to cast value to
            return typeof(T)value;
        }
    }
}
>>>>>>> 17d7f08c2fc09cd2e12c87c4728d075feb1fcdc5
