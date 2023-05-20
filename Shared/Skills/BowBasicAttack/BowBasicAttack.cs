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
            RecoveryTime = 1;
            CastTime = 1.5;
            Cooldown = 1;
            Name = "Basic Bow Attack";
        }
    }
}
