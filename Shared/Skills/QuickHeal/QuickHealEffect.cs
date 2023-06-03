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
            MinDamage = 90;
            MaxDamage = 110;
            int damage = new Random().Next(MinDamage, MaxDamage);
            var multiplier = caster.Stats.SpellPower.FinalValue / (double)250;
            opponent.Stats.RemainingHP += (int)(damage * multiplier);
            if (opponent.Stats.RemainingHP > opponent.Stats.MaxHP.FinalValue)
            {
                opponent.Stats.RemainingHP = opponent.Stats.MaxHP.FinalValue;
            }
        }
    }
}
