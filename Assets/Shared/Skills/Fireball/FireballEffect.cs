using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityScripts;

namespace Shared.Skills.Fireball
{
    public class FireballEffect : SkillEffect
    {
        public FireballEffect() 
        {
            MinDamage= 275;
            MaxDamage= 325;
            DamageType = DamageTypes.Magic;
        }

        public override void Action(ICombatant caster, ICombatant opponent)
        {
            //int damage = new Random().Next(MinDamage,MaxDamage);
            //opponent.ApplyDamage(caster.CalcDmgToDeal(damage, DamageType), DamageType);
            //opponent.ApplyEffect(new BurningEffect());
            //FireBallObject.target
            GameObject gameObject = ((UnityScripts.Player)caster).gameObject;
            GameObject instance = MonoBehaviour.Instantiate(Resources.Load("Meteor", typeof(GameObject)), gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        }
    }
}
