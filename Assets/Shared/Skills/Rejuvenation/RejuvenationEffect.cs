using Shared.Skills.Fireball;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Skills.Rejuvenation
{
    public class RejuvenationEffect : HealEffect
    {
        public override void Action(ICombatant caster, ICombatant opponent)
        {
            base.Action(caster, opponent);
            opponent.ApplyEffect(new HealEffect());
        }
    }
}
