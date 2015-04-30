using System;
using HeroesOfDice.Managers;

namespace HeroesOfDice.Sides
{
   public class Armored : BSide
    {
       public int ArmorCount { get; set; }

       public Armored(BAbility ability, int armorCount) : base(ability)
       {
           ArmorCount = armorCount;
       }

       public override void OnHit(int amount)
       {
           if (ArmorCount > 0)
           {
               ArmorCount--;
               MenuManager.Instance.DisplayMessage(String.Format("{0}'s armor blocked the attack", CombatManager.Instance.Defender.Name));
           }
           else
               base.OnHit(amount);
       }
    }
}
