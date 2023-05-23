// See https://aka.ms/new-console-template for more information
using assailant;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Debugging;
using Shared;
using Shared.Skills.BowBasicAttack;
using System.Data;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var loggerFactory = new LoggerFactory()
    .AddSerilog(Log.Logger);

Microsoft.Extensions.Logging.ILogger logger = loggerFactory.CreateLogger("Logger"); 


bool playing = true;
int desiredGameTicksPerSecond = 20;

Combatant one = new Combatant()
{
    Name= "A",
    Skills = new SkillLoadout() { SlotThree = new BowBasicAttack(),  SlotTwo = new SwordBasicAttack(), SlotOne = new StaffBasicAttack()},
    EquipedItems = new EquipmentSet() {Weapon = new Weapon() { DamageType = DamageType.Magic, MinDamage = 50, MaxDamage =450} },
    Stats = new Shared.Attributes.Attributes()
};
Combatant two = new Combatant()
{
    Name = "B",
    Skills = new SkillLoadout() { SlotOne = new BowBasicAttack(), SlotTwo = new SwordBasicAttack(), SlotThree = new StaffBasicAttack() },
    EquipedItems = new EquipmentSet() { Weapon = new Weapon() { DamageType = DamageType.Magic, MinDamage = 200, MaxDamage = 300 } },
    Stats = new Shared.Attributes.Attributes()
};
var combatSystem = new CombatSystem(one, two, loggerFactory.CreateLogger<CombatSystem>());


double totalCombatTime = 0;
double deltaTime = 1 / (double)desiredGameTicksPerSecond; //fixed update time
double currentTime = TimeKeeper.hires_time_in_seconds();
double accumulator = 0.0;


while (playing)
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

