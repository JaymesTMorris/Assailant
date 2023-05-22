using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Attributes
{
    public class SeconadaryAttribute : Attribute
    {


        protected List<Attribute> _OtherAttributes = new List<Attribute>();
        public SeconadaryAttribute(int startingValue)
            : base(startingValue)
        {

        }

        public void AddAttribute(Attribute attribute)
        {
            _OtherAttributes.Add(attribute);
        }

        public void RemoveAttribute(Attribute attribute)
        {
            _OtherAttributes.Remove(attribute);
        }

        public override int CalculateValue()
        {
            _FinalValue = BaseValue;
            int primaryAttribute = _OtherAttributes[0].CalculateValue();

            _FinalValue += primaryAttribute / 10;
            ApplyBonuses();

            return _FinalValue;
        }
    }
}
