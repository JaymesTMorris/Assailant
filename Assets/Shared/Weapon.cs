using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Weapon:Equipment
    {
        public WeaponTypes WeaponType { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public DamageTypes DamageType { get; set; }
    }
}
