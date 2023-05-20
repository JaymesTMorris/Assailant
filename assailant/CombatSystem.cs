using System.Collections.Generic;
using System.Diagnostics;
using Shared;

public class CombatSystem
{
	List<Combatant> Combatants = new List<Combatant>();

    CombatSystem(List<Combatant> combatants)
	{
		Combatants = combatants;
	}
	public void Update(double delta)
	{

        foreach(var combatant in Combatants)
        {

            combatant.Update(delta);
        }
    }


    static Stopwatch _Stopwatch = Stopwatch.StartNew();

    public double hires_time_in_seconds()
    {
        return _Stopwatch.ElapsedMilliseconds/1000;

    }
}
