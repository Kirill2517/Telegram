using System;

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
    }
}