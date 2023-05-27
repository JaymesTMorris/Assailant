using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Attributes
{
    public class MPRegenAttribute : SeconadaryAttribute
    {
        public MPRegenAttribute(int startingValue = 1, float baseMultiplier = 0, AttributeType type = AttributeType.ManaRegen)
            : base(startingValue, baseMultiplier, type)
        {
        }

        public override int CalculateValue()
        {
            _FinalValue = BaseValue;
            int constitution = _OtherAttributes.FirstOrDefault(a => a.AttributeType == AttributeType.Constitution).FinalValue;
            int wisdom = _OtherAttributes.FirstOrDefault(a => a.AttributeType == AttributeType.Wisdom).FinalValue;

            _FinalValue += constitution / 20;
            _FinalValue += wisdom / 10;
            ApplyBonuses();

            return _FinalValue;
        }
    }
}
