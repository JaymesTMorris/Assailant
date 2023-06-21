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
            MinDamage = caster.EquipedItems.Weapon.MinDamage;
            MaxDamage = caster.EquipedItems.Weapon.MaxDamage;
            int damage = new Random().Next(MinDamage, MaxDamage);
            DamageType = caster.EquipedItems.Weapon.DamageType;
            opponent.ApplyDamage(caster.CalcDmgToDeal(damage, DamageType), DamageType);
        }
    }
}
