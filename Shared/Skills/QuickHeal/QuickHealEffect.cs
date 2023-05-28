using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Skills.QuickHeal
{
    public class QuickHealEffect : SkillEffect
    {
        public override void Action(Combatant caster, Combatant opponent)
        {
            Damage = 100;
            var multiplier = caster.Stats.SpellPower.FinalValue / (double)250;
            opponent.Stats.RemainingHP += (int)(Damage * multiplier);
            if (opponent.Stats.RemainingHP > opponent.Stats.MaxHP.FinalValue)
            {
                opponent.Stats.RemainingHP = opponent.Stats.MaxHP.FinalValue;
            }
        }
    }
}
