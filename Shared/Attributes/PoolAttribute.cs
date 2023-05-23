using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Attributes
{
    public class PoolAttribute : SeconadaryAttribute
    {
        public PoolAttribute(int startingValue=1200) : base(startingValue)
        {
        }

        public override int CalculateValue()
        {
            _FinalValue = BaseValue;
            int constitution = _OtherAttributes[0].CalculateValue();

            _FinalValue += constitution * 100;
            ApplyBonuses();

            return _FinalValue;
        }
    }
}
