using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class SkillEffect
    {
        public int Damage { get; set; } = 100;
        public DamageType DamageType { get; set; } = DamageType.Physical;
        public virtual void Action(Combatant caster, Combatant opponent)
        {
            opponent.ApplyDamage(caster.CalcDmgToDeal(Damage, DamageType), DamageType);
        }
    }
}
