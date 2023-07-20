using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Shared
{
    public class Skill
    {
        public string? Name { get; set; }
        public SkillType Type { get; set; }
        public string? Description { get; set; }
        public SkillEffect Effect { get; set; }
        public double Cooldown { get; set; }
        public double RecoveryTime { get; set; }
        public double CastTime { get; set; }
        public WeaponTypes WeaponsUsability { get; set; }
        public double RemainingCooldown { get; set; }
        public int Cost { get; set; }
        public string ParticleEffect { get; set; }
        public float ParticleExpirationTime { get; set; }
        public string Animation { get; set; }
    }
}
