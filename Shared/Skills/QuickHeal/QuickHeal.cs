using Shared.Skills.QuickHeal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Skills.BowBasicAttack
{
    public class QuickHeal : Skill
    {
        public QuickHeal()
        {
            Type = SkillType.Spell;
            RecoveryTime = .5;
            CastTime = .5;
            Cooldown = 10;
            Cost = 100;
            Name = "Quick Heal";
            Effect = new QuickHealEffect();
        }
    }
}
