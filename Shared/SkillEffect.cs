using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class SkillEffect
    {
        public bool Evadable { get; set; } = false;
        public bool Parriable { get; set; } = false;
        public bool Blockable { get; set; } = false;
        public bool Resistable { get; set; } = false;
        public int MinDamage { get; set; } = 100;
        public int MaxDamage { get; set; } = 100;
        public double? Duration { get; set; }
        public double?  Freqency { get; set; }
        public double? LastTrigger { get; set; }
        public DamageTypes DamageType { get; set; } = DamageTypes.Physical;
        public virtual void Action(Combatant caster, Combatant opponent)
        {
            int damage = new Random().Next(MinDamage, MaxDamage);
            opponent.ApplyDamage(caster.CalcDmgToDeal(damage, DamageType), DamageType, 100);
        }

        public virtual void DropOffAction()
        {

        }
    }
}
