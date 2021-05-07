using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramLib.Resume.model;
using TelegramLib.Share.Models;

namespace TelegramLib.Ability.model
{
    public class Abilities : Share.Models.Object, IContainerUniqueData
    {
        public List<Ability> positives { get; set; } = new List<Ability>();
        public List<Ability> negatives { get; set; } = new List<Ability>();

        public void DeleteDuplicatesDatas()
        {
            positives = positives.GroupBy(a => a.description).Select(g => g.First()).ToList();
            negatives = negatives.GroupBy(a => a.description).Select(g => g.First()).ToList();
        }

        public override bool IsValid()
        {
            return positives != null && negatives != null;
        }
    }
}
