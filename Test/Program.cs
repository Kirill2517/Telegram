using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        for (int i = 0; i < 100; i++)
        {
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            string guid3 = Guid.NewGuid().ToString();
            //Console.WriteLine(guid1);
            //Console.WriteLine(guid2);
            //Console.WriteLine(guid3);
            var result = NewMethod(guid1, guid2, guid3);
            Console.WriteLine(result);
        }
    }

}