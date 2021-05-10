using generator.entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator.logic
{
    public static class GeneratorDataUser
    {
        public static Datauser GetDatauser()
        {
            return new Datauser
            {
                birthday = new DateTime().RandomDay(),
                email = Email,
                firstName = Name,
                surname = Surname,
                middleName = Surname,
                phone = $"+{random.Next(100000000, 999999999)}"
            };
        }

        private static string Name => GetString(@"./data/names.txt");
        private static string Email => GetString(@"./data/emails.txt");
        private static string Surname => GetString(@"./data/surname.txt");

        static readonly Random random = new Random((int)DateTime.Now.Millisecond);

        private static string GetString(string path)
        {
            var lines = File.ReadAllLines(path);
            return lines[random.Next(0, lines.Length)];
        }
    }
}
