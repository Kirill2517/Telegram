using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramLib.Share.Models;
using Object = TelegramLib.Share.Models.Object;

namespace TelegramLib.Vacancy.models
{
    public class Vacancy : Object
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Post { get; set; }
        public string Speciality { get; set; }
        public string typeEmployment { get; set; }
        public string salary { get; set; }
        public string workingPeriod { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime created { get; set; }
        public List<Ability.model.Ability> skills { get; set; } = new List<Ability.model.Ability>();
        public override bool IsValid()
        {
            if (new List<object> { Speciality, title, Post, title, description }.Contains(null))
            {
                return false;
            }

            return true;
        }
    }
}
