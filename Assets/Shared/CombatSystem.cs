using System.Collections.Generic;
using System.Diagnostics;
using Shared;

namespace Shared
{
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

            var stillFighting= CombatantOne.Stats.RemainingHP > 0 && CombatantTwo.Stats.RemainingHP > 0;

            return stillFighting;
        }

    }
}
