using generator.entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator.logic
{
    public static class GenerateEmployer
    {
        static readonly Random random = new Random((int)DateTime.Now.Millisecond);
        private static string Place => GetString(@"./data/places.txt");

        public static Employer GetEmployer()
        {
            var empl = new Employer();
            empl.dataUser = GeneratorDataUser.GetDatauser();
            empl.address = Place;
            empl.name = Guid.NewGuid().ToString().Substring(0, 7);
            empl.website = $"{Guid.NewGuid().ToString().Substring(0, random.Next(3, 8))}.{Guid.NewGuid().ToString().Substring(0, 3)}";
            return empl;
        }

        private static string GetString(string path)
        {
            var lines = File.ReadAllLines(path);
            return lines[random.Next(0, lines.Length)];
        }
    }
}
