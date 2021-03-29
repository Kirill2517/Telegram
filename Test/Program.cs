using System;

<<<<<<< .merge_file_a01512
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
=======
[Flags]
enum MyEnum
{
    appl,
    empl,
    guest
}

class Account
{

    public MyEnum MyEnum = MyEnum.appl | MyEnum.empl;
}

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine(Enum.Parse(typeof(MyEnum), "appl"));
>>>>>>> .merge_file_a18668
    }
}