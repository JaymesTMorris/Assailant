using System.Collections.Generic;

namespace Shared
{
    public class EquipmentSet
    {
        public Equipment Head { get; set; }
        public Equipment Body { get; set;}
        public Equipment Legs { get; set;}
        public List<Equipment> Rings { get;}
        public Equipment Neck { get; }
        public Equipment Belt { get; set; }
        public Weapon Weapon { get; set; }
        public Weapon Shield { get; set; }

    }
}