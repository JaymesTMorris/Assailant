using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    [Flags]
    public enum SkillType
    {
        None = 0,
        Spell = 1 << 0,
        SpecialAttack = 1 << 2,
        BasicAttack = 1 <<3,
        Buff = 1 <<4
    }
}
