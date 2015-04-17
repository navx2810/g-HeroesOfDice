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
               ArmorCount--;
           else
               base.OnHit(amount);
       }
    }
}
