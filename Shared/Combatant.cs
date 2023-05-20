using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Combatant:Character
    {
        public double RecoveryTimeRemaining { get; set; } = 0;
        public double CastTimeRemaining { get; set; } = 0;
        public CombatState State { get; set; }
        public Skill? SkillBeingCasted { get; set; }
        public void Update(double delta)
        {
            ReduceCooldowns(delta);
            if (State == CombatState.Recovering)
            {
                RecoveryTimeRemaining -= delta;
                if (RecoveryTimeRemaining < 0)
                {
                    RecoveryTimeRemaining = 0;
                }
            }
            else if (State == CombatState.Casting)
            {
                CastTimeRemaining -= delta;
                if (CastTimeRemaining < 0)
                {
                    ExecuteSkill(SkillBeingCasted);
                }
            }
            else
            {
                foreach (var skill in Skills.SkillList)
                {
                    if (skill.RemainingCooldown == 0)
                    {
                        Cast(skill);
                        break;
                    }
                }
                if(State != CombatState.Casting)
                {
                    Cast(EquipedItems.Weapon.BasicAttack);
                }
            }
        }

        private void Cast(Skill skill)
        {
            State = CombatState.Casting;
            CastTimeRemaining = skill.CastTime;

        }

        private void ReduceCooldowns(double delta)
        {
            foreach(var skill in Skills.SkillList)
            {
                skill.RemainingCooldown -= delta;
                if (skill.RemainingCooldown<0)
                {
                    skill.RemainingCooldown= 0;
                }
            }
        }

        private void ExecuteSkill(Skill skill)
        {
            RecoveryTimeRemaining = skill.RecoveryTime;
            State = CombatState.Recovering;
            //Do Skill
        }
    }
}
