﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Skill
    {
        public string? Name { get; set; }
        public SkillType Type { get; set; }
        public string? Description { get; set; }
        public int EffectId { get; set; }
        public double Cooldown { get; set; }
        public double RecoveryTime { get; set; }
        public double CastTime { get; set; }
        public WeaponType MyProperty { get; set; }
        public double RemainingCooldown { get; set; }

    }
}