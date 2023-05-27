using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public enum DamageTypes
    {
        None = 0,
        Magic = 1 << 0,
        Physical = 1 << 1,
        True = 1 << 2,
    }
}
