namespace HeroesOfDice.Abilities
{
   public class Slash : BaDamaging
    {
       public Slash(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
       {
       }

       public Slash() : base("Slash", "A quick downward strike!", 4, 1f, 1.5f, ETargetType.Enemy)
       {
       }
    }
}
