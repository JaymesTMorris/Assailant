using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Skills
{
    public class BasicAttackEffect : SkillEffect
    {
        public override void Action(Combatant caster, Combatant opponent)
        {
            Damage = new Random().Next(caster.EquipedItems.Weapon.MinDamage, caster.EquipedItems.Weapon.MaxDamage);
            DamageType = caster.EquipedItems.Weapon.DamageType;
            opponent.ApplyDamage(caster.CalcDmgToDeal(Damage, DamageType), DamageType);
        }
    }
}
