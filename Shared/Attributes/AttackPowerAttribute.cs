using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Attributes
{
    public class AttackPowerAttribute : SeconadaryAttribute
    {
        public AttackPowerAttribute(int startingValue = 100, float baseMultiplier = 0, AttributeType type = AttributeType.AttackPower)
            : base(startingValue, baseMultiplier, type)
        {
        }

        public override int CalculateValue()
        {
            _FinalValue = BaseValue;
            int strength = _OtherAttributes.FirstOrDefault(a => a.AttributeType == AttributeType.Strength).FinalValue;
            int agility = _OtherAttributes.FirstOrDefault(a => a.AttributeType == AttributeType.Agility).FinalValue;

            _FinalValue += strength / 10;
            _FinalValue += agility / 10;
            ApplyBonuses();

            return _FinalValue;
        }
    }
}
