using Shared.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Skills.Rejuvenation
{
    public class Rejuvenation : Skill
    {
        public Rejuvenation()
        {
            Type = SkillType.Spell;
            RecoveryTime = .5;
            CastTime = .5;
            Cooldown = 10;
            Cost = 100;
            Name = "Rejuvenation";
            Effect = new RejuvenationEffect();
            //ParticleEffect = ;
        }
    }
}
