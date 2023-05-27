using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Attributes
{
    public class ManaPoolAttribute : SeconadaryAttribute
    {
        public ManaPoolAttribute(int startingValue = 100, float baseMultiplier = 0, AttributeType type = AttributeType.Mana)
            : base(startingValue, baseMultiplier, type)
        {
        }

        public override int CalculateValue()
        {
            _FinalValue = BaseValue;
            int wisdom = _OtherAttributes.FirstOrDefault(a => a.AttributeType == AttributeType.Wisdom).FinalValue;
            int intelligence = _OtherAttributes.FirstOrDefault(a => a.AttributeType == AttributeType.Intelligence).FinalValue;

            _FinalValue += (50 * (intelligence + wisdom));
            ApplyBonuses();

            return _FinalValue;
        }
    }
}
