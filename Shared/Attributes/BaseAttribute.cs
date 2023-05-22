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
        public BaseAttribute(int baseValue, float baseMultiplier=0)
        {
            BaseValue = baseValue;
            BaseMultiplier = baseMultiplier;
        }
    }
}
