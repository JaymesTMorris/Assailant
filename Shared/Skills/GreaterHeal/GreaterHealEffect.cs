using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shared.Skills.GreaterHeal
{
    public class GreaterHealEffect:SkillEffect
    {
        public override void Action(Combatant caster, Combatant opponent)
        {
            MinDamage = 115;
            MaxDamage = 135;
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
