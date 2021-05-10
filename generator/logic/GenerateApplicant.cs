using generator.entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator.logic
{
    public static class GenerateApplicant
    {
        static readonly Random random = new Random((int)DateTime.Now.Millisecond);
        private static string Place => GetString(@"./data/places.txt");
        public static Applicant GetApplicant()
        {
            var appl = new Applicant();
            appl.dataUser = GeneratorDataUser.GetDatauser();
            appl.idSex = random.Next(0, 2);
            appl.idEducation = random.Next(0, 4);
            appl.idTypeEmployment = random.Next(0, 4);
            appl.desiredArea = Place;
            return appl;
        }

        private static string GetString(string path)
        {
            var lines = File.ReadAllLines(path);
            return lines[random.Next(0, lines.Length)];
        }
    }
}
