using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shared.Skills.GreaterHeal
{
    public class GreaterHeal:Skill
    {
        public GreaterHeal()
        {
            Type = SkillType.Spell;
            RecoveryTime = .5;
            CastTime = 1.5;
            Cooldown = 15;
            Cost = 200;
            Name = "Greater Heal";
            Effect = new GreaterHealEffect();
        }
    }
}
