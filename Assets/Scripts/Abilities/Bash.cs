namespace HeroesOfDice.Abilities
{
   public class Bash : BaDamaging
    {
       public Bash(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
       {
       }

       public Bash() : base("Bash", "A crushing blow!", 5, 1f, 1.5f, ETargetType.Enemy)
       {
       }
    }
}
