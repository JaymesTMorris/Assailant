using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Attributes
{
    public class HealthPoolAttribute : SeconadaryAttribute
    {
        public HealthPoolAttribute(int startingValue = 100, float baseMultiplier = 0, AttributeType type = AttributeType.Health)
            : base(startingValue, baseMultiplier, type)
        {
        }

        public override int CalculateValue()
        {
            _FinalValue = BaseValue;
            int constitution = _OtherAttributes.FirstOrDefault(a => a.AttributeType == AttributeType.Constitution).FinalValue;

            _FinalValue += constitution * 100;
            ApplyBonuses();

            return _FinalValue;
        }
    }
}
