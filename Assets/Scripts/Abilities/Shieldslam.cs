namespace HeroesOfDice.Abilities
{
   public class Shieldslam : BaDamaging
    {
       public Shieldslam(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
       {
       }

       public Shieldslam() : base("Shield Slam", "Thrust your shield at your enemy!", 3, 1f, 1.25f, ETargetType.Enemy)
       {
       }
    }
}
