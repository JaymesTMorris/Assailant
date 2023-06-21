using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Skills.Fireball
{
    public class FireballEffect : SkillEffect
    {
        public FireballEffect() 
        {
            MinDamage= 275;
            MaxDamage= 325;
            DamageType = DamageTypes.Magic;
        }

        public override void Action(Combatant caster, Combatant opponent)
        {
            int damage = new Random().Next(MinDamage,MaxDamage);
            opponent.ApplyDamage(caster.CalcDmgToDeal(damage, DamageType), DamageType);
            opponent.ApplyEffect(new BurningEffect());
        }
    }
}
