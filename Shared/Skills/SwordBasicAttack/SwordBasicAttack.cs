using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Skills.BowBasicAttack
{
    public class SwordBasicAttack : Skill
    {
        public SwordBasicAttack()
        {
            Type = SkillType.BasicAttack;
            WeaponsUsability = WeaponType.OneHander;
            RecoveryTime = 1;
            CastTime = .5;
            Cooldown = 5;
            Cost = 5;
            Name = "Basic Sword Attack";
            Effect = new BasicAttackEffect();
        }
    }
}
