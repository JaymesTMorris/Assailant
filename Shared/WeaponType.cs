using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    [Flags]
    public enum WeaponType
    {
        NotSet = 0,
        OneHander = 1 << 0,
        TwoHander = 1 << 2,
        Bow = 1 << 3,
        Wand = 1 << 4,
        Staff = 1 << 5,
        Shield= 1 << 6,
        All = ~(~1<<4)
    }
}
