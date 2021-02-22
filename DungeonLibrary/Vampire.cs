using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Vampire : Monster
    {
        public DateTime HourChangeBack { get; set; }

        public Vampire(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base (name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            HourChangeBack = DateTime.Now;

            if (HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18)
            {
                HitChance += 10;
                Block += 10;
                MinDamage += 1;
                MaxDamage += 2;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}{1}",
                base.ToString(),
                HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18 ?
                "It looks a little strong and angry...\n" :
                "In the daylight, it's looking a bit weak.\n");
        }//end ToString

    }//end class
}//end namespace
