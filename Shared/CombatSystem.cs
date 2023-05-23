using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using Shared;

namespace Shared
{
    public class CombatSystem
    {
        ILogger<CombatSystem> Logger;
        Combatant CombatantOne { get; set; }
        Combatant CombatantTwo { get; set; }

        public CombatSystem(Combatant one, Combatant two, ILogger<CombatSystem> logger)
        {
            Logger = logger;

            CombatantOne = one;
            CombatantOne.Opponent = two;
            one.Logger = logger;

            CombatantTwo = two;
            CombatantTwo.Opponent = one;
            two.Logger = logger;

        }
        public bool Update(double delta)
        {

            CombatantOne.Update(delta);
            CombatantTwo.Update(delta);

            var stillFighting= CombatantOne.Stats.HP.FinalValue > 0 && CombatantTwo.Stats.HP.FinalValue > 0;
            if(!stillFighting)
            {
                Logger.LogInformation("It is finished!!!");
            }
            return stillFighting;
        }

    }
}
