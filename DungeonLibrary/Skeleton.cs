using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Skeleton : Monster
    {
        public Skeleton()
        {
            MaxLife = 8;
            MaxDamage = 5;
            Name = "Skeleton";
            HitChance = 20;
            Block = 15;
            MinDamage = 1;
            Life = 8;
            Description = "The bones of fallen heros before you re-animate and seek vengence...";
        }

    }//end class
}//end namespace
