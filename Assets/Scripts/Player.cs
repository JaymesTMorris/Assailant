using Shared;
using Shared.Attributes;
using Shared.Skills.BowBasicAttack;
using Shared.Skills.Fireball;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Player : MonoBehaviour, ICombatant
{
    private Combatant combatant;
    public Player oppsingPlayer { get { return (Player)combatant.Opponent; } set { combatant.Opponent = value; } }
    public ManaBar manaBar;
    public HealthBar healthBar;
 

    public List<SkillEffect> Activeffects => combatant.Activeffects;


    public double CastTimeRemaining { get => combatant.CastTimeRemaining; set => combatant.CastTimeRemaining = value; }
    public ICombatant Opponent { get => combatant.Opponent; set => combatant.Opponent = value; }
    public double RecoveryTimeRemaining { get => combatant.RecoveryTimeRemaining; set => combatant.RecoveryTimeRemaining = value;  }
    public Skill SkillBeingCasted { get => combatant.SkillBeingCasted; set => combatant.SkillBeingCasted = value; }
    public CombatState State { get => combatant.State; set => combatant.State = value; }
    public EquipmentSet EquipedItems { get => combatant.EquipedItems; set => combatant.EquipedItems = value; }
    public int Experience { get => combatant.Experience; set => combatant.Experience = value; }
    public int Level { get => combatant.Level; set => combatant.Level = value; }
    public string Name { get => combatant.Name; set => combatant.Name = value; }
    public int Rank { get => combatant.Rank; set => combatant.Rank = value; }
    public int Score { get => combatant.Score; set => combatant.Score = value; }
    public SkillLoadout Skills { get => combatant.Skills; set => combatant.Skills = value; }
    public Attributes Stats { get => combatant.Stats; set => combatant.Stats = value; }

    public Player()
    {

        
    }
    // Start is called before the first frame update
    void Start()
    {
        combatant = new Combatant()
        {
            Name = "A",
            Skills = new SkillLoadout() { SlotThree = new Fireball(), SlotTwo = new StaffBasicAttack(), SlotOne = new QuickHeal() },
            EquipedItems = new EquipmentSet() { Weapon = new Weapon() { DamageType = DamageTypes.Magic, MinDamage = 240, MaxDamage = 260 } },
            Stats = new Attributes(hp: 100, con: 9, mp: 1000, wis: 0, intel: 0),
            Opponent = oppsingPlayer
        };
        manaBar.SetMaxMana(combatant.Stats.MaxMP.FinalValue);
        healthBar.SetMaxHealth(combatant.Stats.MaxHP.FinalValue);

    }

    // Update is called once per frame
    void Update()
    {
        combatant.Update(Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(50);
		}
    }

	void TakeDamage(int damage)
	{
		combatant.Stats.RemainingHP -= damage;

        healthBar.SetHealth(combatant.Stats.RemainingHP);
        combatant.Stats.RemainingMP -= damage;

        manaBar.SetMana(combatant.Stats.RemainingMP);
    }

    public void ApplyDamage(int damage, DamageTypes damageType, double attackerAccuracy = 100)
    {
        combatant.ApplyDamage(damage, damageType, attackerAccuracy);
    }

    public void ApplyEffect(SkillEffect effect)
    {
        combatant.ApplyEffect(effect);
    }

    public int CalcDmgToDeal(int damage, DamageTypes damageType)
    {
        return combatant.CalcDmgToDeal(damage,damageType);
    }

    public void Update(double delta)
    {
        combatant.Update(delta);
    }
}
