using Microsoft.AspNet.Identity;
using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var d = new DateTime(2021, 4, 17, 17, 23, 51);
        Console.WriteLine(d.ToLocalTime());
    }
}