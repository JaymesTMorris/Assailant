using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Skills.BowBasicAttack
{
    public class BowBasicAttack : Skill
    {
        public BowBasicAttack()
        {
            Type = SkillType.BasicAttack;
            WeaponsUsability = WeaponType.Bow;
            RecoveryTime = 1;
            CastTime = 2;
            Cooldown = 20;
            Cost = 100;
            Name = "Basic Bow Attack";
            Effect = new BasicAttackEffect();
        }
    }
}
