using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Attributes
{
    public class HPRegenAttribute : SeconadaryAttribute
    {
        public HPRegenAttribute(int startingValue = 1, float baseMultiplier = 0, AttributeType type = AttributeType.HealthRegen)
            : base(startingValue, baseMultiplier, type)
        {
        }

        public override int CalculateValue()
        {
            _FinalValue = BaseValue;
            int constituation = _OtherAttributes.FirstOrDefault(a => a.AttributeType == AttributeType.Constitution).FinalValue;
            int strength = _OtherAttributes.FirstOrDefault(a => a.AttributeType == AttributeType.Strength).FinalValue;

            _FinalValue += constituation / 20;
            _FinalValue += strength / 10;
            ApplyBonuses();

            return _FinalValue;
        }
    }
}
