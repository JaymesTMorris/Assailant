using System.Collections.Generic;
using System.Diagnostics;
using assailant;
using Shared;

public class CombatSystem
{
    Combatant CombatantOne { get; set; }
    Combatant CombatantTwo { get; set; }

    public CombatSystem(Combatant one, Combatant two)
	{
        CombatantOne = one;
        CombatantOne.Opponent = two;
        CombatantTwo = two;
        CombatantTwo.Opponent = one;
	}
	public bool Update(double delta)
	{

        CombatantOne.Update(delta);
        CombatantTwo.Update(delta);

        return CombatantOne.CurrentStats.HP > 0 && CombatantTwo.CurrentStats.HP > 0;

    }



}
