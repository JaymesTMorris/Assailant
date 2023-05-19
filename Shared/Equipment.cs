using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Equipment
    {
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        public EquipmentSlot Slot { get; set; }
        public string Description { get; set; }
    }
}
