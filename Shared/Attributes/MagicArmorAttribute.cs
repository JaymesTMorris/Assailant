using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Attributes
{
    public class MagicArmorAttribute : SeconadaryAttribute
    {
        public MagicArmorAttribute(int startingValue = 100, float baseMultiplier = 0, AttributeType type = AttributeType.MagicArmor)
            : base(startingValue, baseMultiplier, type)
        {
        }

        public override int CalculateValue()
        {
            _FinalValue = BaseValue;
            int wisdom = _OtherAttributes.FirstOrDefault(a => a.AttributeType == AttributeType.Wisdom).FinalValue;
            int agility = _OtherAttributes.FirstOrDefault(a => a.AttributeType == AttributeType.Agility).FinalValue;
            int con = _OtherAttributes.FirstOrDefault(a => a.AttributeType == AttributeType.Constitution).FinalValue;

            _FinalValue += (wisdom / 3) + (agility / 20) + (con / 10);
            ApplyBonuses();

            return _FinalValue;
        }
    }
}
