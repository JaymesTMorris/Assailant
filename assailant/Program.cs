// See https://aka.ms/new-console-template for more information
using assailant;
using Shared;
using System.Data;

bool playing = true;
int desiredGameTicksPerSecond = 20;

Combatant one = new Combatant();
Combatant two = new Combatant();
var combatSystem = new CombatSystem(one, two);


double totalCombatTime = 0;
double deltaTime = 1 / desiredGameTicksPerSecond; //fixed update time
double currentTime = TimeKeeper.hires_time_in_seconds();
double accumulator = 0.0;


while (!playing)
{
    double newTime = TimeKeeper.hires_time_in_seconds();
    double frameTime = newTime - currentTime;
    currentTime = newTime;

    accumulator += frameTime;

    while (accumulator >= deltaTime)
    {
        playing = combatSystem.Update(deltaTime);
        accumulator -= deltaTime;
        totalCombatTime += deltaTime;
    }
}

