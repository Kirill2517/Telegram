using System;

class Program
{
    private static Random random = new Random();
    public static bool Check()
    {
        return 5 == random.Next(0, 6);
    }

    public static string BaseFun(Func<string> func)
    {
        if (Check())
        {
            return func();
        }
        return "успех";
    }


    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(BaseFun(delegate () { return "не успех"; }));
        }
    }
}
