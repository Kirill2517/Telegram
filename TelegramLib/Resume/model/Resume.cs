using System;
using System.Collections.Generic;
using System.Linq;
using TelegramLib.Ability.model;

namespace TelegramLib.Resume.model
{
    public class Resume : Share.Models.Object, IContainerUniqueData
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Speciality { get; set; }
        public string workExperience { get; set; }
        public string desiredSalary { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public DateTime created { get; set; }
        public List<Ability.model.Ability> skills { get; set; } = new List<Ability.model.Ability>();
        public Abilities Abilities { get; set; } = new Abilities();

        public void DeleteDuplicatesDatas()
        {
            skills = skills.GroupBy(a => a.description).Select(g => g.First()).ToList();
            Abilities.DeleteDuplicatesDatas();
        }

        public override bool IsValid()
        {
            if (new List<object> { Speciality, title, workExperience }.Contains(null))
            {
                return false;
            }
            return true;
        }
    }
}
