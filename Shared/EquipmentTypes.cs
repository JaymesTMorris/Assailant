using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public enum EquipmentTypes
    {
        None = 0,
        Armor = 1 << 0,
        Weapon = 1 << 1
    }
}
