namespace HeroesOfDice.Abilities
{
   public class DragonsBreath : BaDamaging
    {
       public DragonsBreath(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
       {
       }

       public DragonsBreath() : base("Dragon's Breath", "You are breathing fire!", 3, 1f, 1.25f, ETargetType.Enemy)
       {
       }
    }
}
