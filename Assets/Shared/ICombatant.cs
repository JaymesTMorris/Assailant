using System.Collections.Generic;

namespace Shared
{
    public interface ICombatant :ICharacter
    {
        List<SkillEffect> Activeffects { get; }
        double CastTimeRemaining { get; set; }
        ICombatant Opponent { get; set; }
        double RecoveryTimeRemaining { get; set; }
        Skill SkillBeingCasted { get; set; }
        CombatState State { get; set; }

        void ApplyDamage(int damage, DamageTypes damageType, double attackerAccuracy = 100);
        void ApplyEffect(SkillEffect effect);
        int CalcDmgToDeal(int damage, DamageTypes damageType);
        void Update(double delta);
    }
}