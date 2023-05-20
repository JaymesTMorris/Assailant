using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class SkillEffect
    {
        public virtual void Action(Combatant caster, Combatant opponent)
        {
            throw new NotImplementedException();
        }
    }
}
