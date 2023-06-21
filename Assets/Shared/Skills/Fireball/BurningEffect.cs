using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Skills.Fireball
{
    public class BurningEffect:SkillEffect
    {
        public BurningEffect()
        {
            MinDamage = 17;
            MaxDamage = 22;
            DamageType = DamageTypes.Magic;
            Freqency = 1;
            Duration = 10;
            LastTrigger = 0;
        }
    }
}
