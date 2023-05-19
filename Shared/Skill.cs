using System;
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
        public int Cooldown { get; set; }
        public int RecoveryTime { get; set; }
        public int CastTime { get; set; }
        public WeaponType MyProperty { get; set; }
    }
}
