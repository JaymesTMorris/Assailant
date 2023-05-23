using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Combatant:Character
    {
        public ILogger<CombatSystem> Logger { get; set; }
        public Combatant Opponent { get; set; }
        public double RecoveryTimeRemaining { get; set; } = 0;
        public double CastTimeRemaining { get; set; } = 0;
        public CombatState State { get; set; }
        public Skill? SkillBeingCasted { get; set; }
        public void Update(double delta)
        {
            ReduceCooldowns(delta);
            UpdateCombatState(delta);
            Regen(delta);
        }

        private void Regen(double delta)
        {
            //Stats.RemainingHP += Stats.HPRegen.FinalValue;
            //Stats.RemainingMP += Stats.MPRegen.FinalValue;
        }

        private void UpdateCombatState(double delta)
        {
            if (State == CombatState.Recovering)
            {
                RecoveryTimeRemaining -= delta;
                if (RecoveryTimeRemaining < 0)
                {
                    RecoveryTimeRemaining = 0;
                    State= CombatState.None;
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
                    if (skill.RemainingCooldown == 0 && Stats.RemainingMP >= skill.Cost)
                    {
                        Cast(skill);
                        break;
                    }
                }
                if (State != CombatState.Casting)
                {
                    //Cast(EquipedItems.Weapon.BasicAttack);
                }
            }
        }

        private void Cast(Skill skill)
        {
            Logger.LogInformation("{Combatant} begins {skill}", Name, skill.Name);
            State = CombatState.Casting;
            Stats.RemainingMP-= skill.Cost;
            CastTimeRemaining = skill.CastTime;
            SkillBeingCasted = skill;
            Logger.LogInformation("{Combatant} has {mana} MP remaining", Name, Stats.RemainingMP);
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
            Logger.LogInformation("{Combatant} executes {skill}", Name, skill.Name);
            skill.Effect.Action(this, Opponent);
            SkillBeingCasted = null;
            State = CombatState.Recovering;
            RecoveryTimeRemaining = skill.RecoveryTime;
            skill.RemainingCooldown = skill.Cooldown;
        }

        public int CalcDmgToDeal(int damage, DamageType damageType)
        {
            return damage;
        }

        public void ApplyDamage(int damage, DamageType damageType)
        {
            Logger.LogInformation("{Combatant} takes {damage} of {damageType}", Name, damage, damageType);
            Stats.RemainingHP -= damage;
            Logger.LogInformation("{Combatant} has {health} HP remaining.", Name, Stats.RemainingHP);
        }

    }
}
