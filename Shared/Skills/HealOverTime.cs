using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Skills
{
    public class HealOverTime : HealEffect
    {
        public HealOverTime()
            : this(17, 22)
        {

        }

        public HealOverTime(int min, int max)
        {
            MinDamage = min;
            MaxDamage = max;
            DamageType = DamageTypes.Magic;
            Freqency = 1;
            Duration = 10;
            LastTrigger = 0;
        }
    }
}
