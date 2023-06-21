using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Attributes
{
    public class Attributes
    {
        public HealthPoolAttribute MaxHP { get; set; }
        public int RemainingHP { get; set; }
        public HPRegenAttribute HPRegen { get; set; }
        public ManaPoolAttribute MaxMP { get; set; }
        public int RemainingMP { get; set; }
        public MPRegenAttribute MPRegen { get; set; }
        public Attribute Strength { get; set; }
        public Attribute Agility { get; set; }
        public Attribute Constitution { get; set; }
        public Attribute Intelligence { get; set; }
        public Attribute Wisdom { get; set; }
        public AttackPowerAttribute AttackPower { get; set; }
        public SpellPowerAttribute SpellPower { get; set; }
        public MagicArmorAttribute MagicArmor { get; set; }
        public PhysicalArmorAttribute PhysicalArmor { get; set; }

        public Attributes(int hp=1200, int hpRegen=0, int mp = 1200, int mpRegen=0,
            int str=100, int agl = 100, int con = 100, int intel = 100, int wis = 100,
            int atkPwr = 100, int spPwr = 100, int mgArmor = 100, int physArmor = 100)
        {
            Strength = new Attribute(str, 0, AttributeType.Strength);
            Agility = new Attribute(agl, 0, AttributeType.Agility);
            Constitution = new Attribute(con,0, AttributeType.Constitution);
            Intelligence = new Attribute(intel,0,AttributeType.Intelligence);
            Wisdom = new Attribute(wis,0,AttributeType.Wisdom);

            MaxHP = new HealthPoolAttribute(hp);
            MaxHP.AddAttribute(Constitution);
            RemainingHP = MaxHP.FinalValue;

            HPRegen = new HPRegenAttribute(hpRegen, 0 , AttributeType.HealthRegen);
            HPRegen.AddAttribute(Strength);
            HPRegen.AddAttribute(Constitution);


            MaxMP = new ManaPoolAttribute(mp);
            MaxMP.AddAttribute(Intelligence);
            MaxMP.AddAttribute(Wisdom);
            RemainingMP= MaxMP.FinalValue;

            MPRegen = new MPRegenAttribute(mpRegen,0, AttributeType.ManaRegen);
            MPRegen.AddAttribute(Wisdom);
            MPRegen.AddAttribute(Constitution);


            AttackPower = new AttackPowerAttribute(atkPwr);
            AttackPower.AddAttribute(Strength);
            AttackPower.AddAttribute(Agility);

            SpellPower = new SpellPowerAttribute(spPwr);
            SpellPower.AddAttribute(Intelligence);
            SpellPower.AddAttribute(Wisdom);

            MagicArmor = new MagicArmorAttribute(mgArmor);
            MagicArmor.AddAttribute(Wisdom);
            MagicArmor.AddAttribute(Agility);
            MagicArmor.AddAttribute(Constitution);


            PhysicalArmor = new PhysicalArmorAttribute(physArmor);
            PhysicalArmor.AddAttribute(Wisdom);
            PhysicalArmor.AddAttribute(Agility);
            PhysicalArmor.AddAttribute(Constitution);
        }
    }
}
