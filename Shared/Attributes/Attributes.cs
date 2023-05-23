using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Attributes
{
    public class Attributes
    {
        public PoolAttribute HP { get; set; }
        public int RemainingHP { get; set; }
        public SeconadaryAttribute HPRegen { get; set; }
        public PoolAttribute MP { get; set; }
        public int RemainingMP { get; set; }
        public SeconadaryAttribute MPRegen { get; set; }
        public Attribute Strength { get; set; }
        public Attribute Agility { get; set; }
        public Attribute Constitution { get; set; }
        public Attribute Intelligence { get; set; }
        public Attribute Wisdom { get; set; }
        public SeconadaryAttribute AttackPower { get; set; }
        public SeconadaryAttribute SpellPower { get; set; }
        public SeconadaryAttribute MagicArmor { get; set; }
        public SeconadaryAttribute PhysicalArmor { get; set; }

        public Attributes(int hp=1200, int hpRegen=0, int mp = 1200, int mpRegen=0,
            int str=100, int agl = 100, int con = 100, int intel = 100, int wis = 100,
            int atkPwr = 100, int spPwr = 100, int mgArmor = 100, int physArmor = 100)
        {
            Strength = new Attribute(str);
            Agility = new Attribute(agl);
            Constitution = new Attribute(con);
            Intelligence = new Attribute(intel);
            Wisdom = new Attribute(wis);

            HP = new PoolAttribute(hp);
            HP.AddAttribute(Constitution);
            RemainingHP = HP.FinalValue;

            HPRegen = new SeconadaryAttribute(hpRegen);
            HPRegen.AddAttribute(HP);

            MP = new PoolAttribute(mp);
            MP.AddAttribute(Intelligence);
            MP.AddAttribute(Wisdom);
            RemainingMP= MP.FinalValue;

            MPRegen = new SeconadaryAttribute(mpRegen);
            MPRegen.AddAttribute(MP);

            AttackPower = new SeconadaryAttribute(atkPwr);
            AttackPower.AddAttribute(Strength);
            AttackPower.AddAttribute(Agility);

            SpellPower = new SeconadaryAttribute(spPwr);
            SpellPower.AddAttribute(Intelligence);
            SpellPower.AddAttribute(Wisdom);

            MagicArmor = new SeconadaryAttribute(mgArmor);
            MagicArmor.AddAttribute(Wisdom);

            PhysicalArmor = new SeconadaryAttribute(physArmor);
            PhysicalArmor.AddAttribute(Agility);

        }
    }
}
