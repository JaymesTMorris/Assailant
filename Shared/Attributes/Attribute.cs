using Shared.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Attributes
{
    public class Attribute : BaseAttribute
    {
        List<BaseAttribute> Bonuses= new List<BaseAttribute>();
        protected int _FinalValue;
        public int FinalValue { get { return CalculateValue(); }}

        public Attribute(int startingValue=100) 
            : base(startingValue)
        {
            _FinalValue= BaseValue;
        }

        public void AddBonus(BaseAttribute bonus)
        {
            Bonuses.Add(bonus);
        }

        public void RemoveBonus(BaseAttribute bonus)
        {
            Bonuses.Remove(bonus);
        }

        public virtual int CalculateValue()
        {
            _FinalValue = BaseValue;

            ApplyBonuses();

            return _FinalValue;
        }

        protected void ApplyBonuses()
        {
            int bonusValue = 0;
            double bonusMultiplier = 0;

            foreach (var bonus in Bonuses)
            {
                bonusValue += bonus.BaseValue;
                bonusMultiplier += bonus.BaseMultiplier;
            }

            _FinalValue += bonusValue;
            _FinalValue = (int)Math.Floor(_FinalValue * (1 + bonusMultiplier));
        }
    }
}
