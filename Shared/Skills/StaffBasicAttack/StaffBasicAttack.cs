﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Skills.BowBasicAttack
{
    public class StaffBasicAttack : Skill
    {
        public StaffBasicAttack()
        {
            Type = SkillType.BasicAttack;
            WeaponsUsability = WeaponType.Bow;
            RecoveryTime = 1;
            CastTime = 1.5;
            Cooldown = 15;
            Cost = 5;
            Name = "Basic Staff Attack";
            Effect = new StaffBasicAttackEffect();
        }
    }
}
