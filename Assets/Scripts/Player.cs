using Shared;
using Shared.Attributes;
using Shared.Skills.BowBasicAttack;
using Shared.Skills.Fireball;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICombatant
{
    public Player player1;
    public Player player2;
    public Player oppsingPlayer;
    public ManaBar manaBar;
    public HealthBar healthBar;

    public ICombatant Opponent
    {
        get
        {
            return oppsingPlayer;
        }
        set
        {
            if (value is Player)
            {
                oppsingPlayer = (Player)value;
            }
        }
    }
    public double RecoveryTimeRemaining { get; set; } = 0;
    public double CastTimeRemaining { get; set; } = 0;
    public CombatState State { get; set; }
    public Skill? SkillBeingCasted { get; set; }

    public List<SkillEffect> Activeffects { get; private set; } = new List<SkillEffect>();
    public Attributes Stats { get; set; }
    public SkillLoadout Skills { get; set; }
    public EquipmentSet EquipedItems { get; set; }
    public int Score { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
    public int Rank { get; set; }
    public string Name { get; set; }

    void Start()
    {
        Name = "A";
        Skills = new SkillLoadout() { SlotThree = new Fireball(), SlotTwo = new StaffBasicAttack(), SlotOne = new QuickHeal() };
        EquipedItems = new EquipmentSet() { Weapon = new Weapon() { DamageType = DamageTypes.Magic, MinDamage = 240, MaxDamage = 260 } };
        Stats = new Attributes(hp: 100, con: 100, mp: 1000, wis: 0, intel: 0);
        manaBar.SetMaxMana(Stats.MaxMP.FinalValue);
        healthBar.SetMaxHealth(Stats.MaxHP.FinalValue);
    }

    void FixedUpdate()
    {

        update(Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(50);
        }
        healthBar.SetHealth(Stats.RemainingHP);
        manaBar.SetMana(Stats.RemainingMP);
    }

    void TakeDamage(int damage)
    {
        Stats.RemainingHP -= damage;


        Stats.RemainingMP -= damage;


    }

    public void update(double delta)
    {
        ReduceCooldowns(delta);
        UpdateCombatState(delta);
        ProcessActiveEffects(delta);
       // Regen(delta)
    }

    private void ProcessActiveEffects(double delta)
    {
        foreach (var effect in Activeffects)
        {
            effect.LastTrigger += (int)delta;
            effect.Duration -= (int)delta;
            if (effect.Duration < 0)
            {
                effect?.DropOffAction();
                Activeffects.Remove(effect);
            }

            if (effect.LastTrigger >= effect.Freqency)
            {
                effect.Action(this, Opponent);
                effect.LastTrigger = 0;
            }
        }
    }

    private void Regen(double delta)
    {
        Stats.RemainingHP += Stats.HPRegen.FinalValue;
        if (Stats.RemainingHP > Stats.MaxHP.FinalValue)
        {
            Stats.RemainingHP = Stats.MaxHP.FinalValue;
        }

        Stats.RemainingMP += Stats.MPRegen.FinalValue;
        if (Stats.RemainingMP > Stats.MaxMP.FinalValue)
        {
            Stats.RemainingMP = Stats.MaxMP.FinalValue;
        }
    }

    private void UpdateCombatState(double delta)
    {
        if (State == CombatState.Recovering)
        {
            RecoveryTimeRemaining -= delta;
            if (RecoveryTimeRemaining < 0)
            {
                RecoveryTimeRemaining = 0;
                State = CombatState.None;
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
        State = CombatState.Casting;
        Stats.RemainingMP -= skill.Cost;
        CastTimeRemaining = skill.CastTime;
        SkillBeingCasted = skill;
    }

    private void ReduceCooldowns(double delta)
    {
        foreach (var skill in Skills.SkillList)
        {
            skill.RemainingCooldown -= delta;
            if (skill.RemainingCooldown < 0)
            {
                skill.RemainingCooldown = 0;
            }
        }
    }

    private void ExecuteSkill(Skill skill)
    {
        skill.Effect.Action(this, Opponent);
        //create instance of effect prefab 
        if (skill.ParticleEffect != null){
            GameObject instance = Instantiate(Resources.Load(skill.ParticleEffect, typeof(GameObject)), gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            instance.GetComponent<ParticleSystem>().GetPlaybackState().;
        }
        SkillBeingCasted = null;
        State = CombatState.Recovering;
        RecoveryTimeRemaining = skill.RecoveryTime;
        skill.RemainingCooldown = skill.Cooldown;
    }

    public int CalcDmgToDeal(int damage, DamageTypes damageType)
    {
        double multiplier = 1;
        if (DamageTypes.Magic == damageType)
        {
            multiplier = Stats.SpellPower.FinalValue / (double)250;
        }
        else if (damageType == DamageTypes.Physical)
        {
            multiplier = Stats.AttackPower.FinalValue / (double)250;
        }
        return (int)(damage * multiplier);
    }

    public void ApplyEffect(SkillEffect effect)
    {
        Activeffects.Add(effect);
    }

    public void ApplyDamage(int damage, DamageTypes damageType, double attackerAccuracy = 100)
    {
        double evasion = 0; //Do we even want evasion? If so need to add an attribute to track and calculate evasion with
        double chanceToEvade = 1 - (attackerAccuracy * 1.25) / (attackerAccuracy + Math.Pow(evasion * .20, .9));

        if (damageType == DamageTypes.Physical)
        {
            damage = (int)((10 * damage * damage) / (double)Stats.PhysicalArmor.FinalValue + 10 * damage);
        }
        else if (DamageTypes.Magic == damageType)
        {
            damage = (int)((10 * damage * damage) / (double)Stats.MagicArmor.FinalValue + 10 * damage);
        }

        Stats.RemainingHP -= damage;
        if (Stats.RemainingHP < 0)
        {
            Stats.RemainingHP = 0;
        }
    }

}
