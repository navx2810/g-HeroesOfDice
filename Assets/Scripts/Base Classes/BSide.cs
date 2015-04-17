using HeroesOfDice.Managers;

namespace HeroesOfDice
{
   public abstract class BSide
    {
       public BAbility Ability { get; set; }

       protected BSide(BAbility ability)
       {
           Ability = ability;
       }

       public virtual void OnHit(int amount)
       {
           CombatManager.Instance.Defender.ModHealth(amount * -1);
       }

       public virtual void OnUse()
       {
           Ability.Use();
       }
    }
}
