using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Skills
{
    public  class HealEffect:SkillEffect
    {
        public HealEffect()
            :this(100,125)
        {
        }

        public HealEffect(int min, int max)
        {
            MinDamage = min;
            MaxDamage = max;
            Resistable = false;
            Evadable= false;
            Blockable= false;
            Parriable= false;
        }
        public override void Action(Combatant caster, Combatant opponent)
        {
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
