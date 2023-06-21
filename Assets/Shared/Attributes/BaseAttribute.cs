using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Attributes
{
    public class BaseAttribute
    {
        public int BaseValue { get; set; }
        public float BaseMultiplier { get; set; }
        public AttributeType AttributeType { get; set; }
        public BaseAttribute(int baseValue=10, float baseMultiplier=0, AttributeType type = AttributeType.None)
        {
            BaseValue = baseValue;
            BaseMultiplier = baseMultiplier;
            AttributeType = type;
        }
    }
}
