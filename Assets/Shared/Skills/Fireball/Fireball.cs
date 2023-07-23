using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Skills.Fireball
{
    public class Fireball : Skill
    {
        public Fireball()
        {
            Type = SkillType.Spell;
            WeaponsUsability = WeaponTypes.Staff|WeaponTypes.Wand;
            RecoveryTime = .5;
            CastTime = 3;
            Cooldown = 20;
            Cost = 200;
            Name = "Fireball";
            Effect = new FireballEffect();
            //ParticleEffect = 
            Animation = "Attack02Maintain";
        }
    }
}
