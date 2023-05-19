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
        TwoHander = 1 << 1,
        Bow = 1 << 2,
        Wand = 1 << 3,
        Staff = 1 << 4,
        Shield= 1 << 5,
        All = ~(~0<<6)
    }
}
