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
        public PoolAttribute MP { get; set; }
        public Attribute Strength { get; set; }
        public Attribute Agility { get; set; }
        public Attribute Constitution { get; set; }
        public Attribute Intelligence { get; set; }
        public Attribute Wisdom { get; set; }
        public SeconadaryAttribute AttackPower { get; set; }
        public SeconadaryAttribute SpellPower { get; set; }
        public SeconadaryAttribute MagicArmor { get; set; }
        public SeconadaryAttribute PhysicalArmor { get; set; }

        public Attributes(int hp, int mp,
            int str, int agl,int con, int intel,int wis,
            int atkPwr, int spPwr, int mgArmor, int physArmor)
        {
            Strength = new Attribute(str);
            Agility = new Attribute(agl);
            Constitution = new Attribute(con);
            Intelligence = new Attribute(intel);
            Wisdom = new Attribute(wis);

            HP = new PoolAttribute(hp);
            HP.AddAttribute(Constitution);

            MP = new PoolAttribute(mp);
            MP.AddAttribute(Intelligence);
            MP.AddAttribute(Wisdom);

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
