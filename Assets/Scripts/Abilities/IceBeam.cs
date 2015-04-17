namespace HeroesOfDice.Abilities
{
   public class IceBeam : BaDamaging
    {
       public IceBeam(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
       {
       }

       public IceBeam() : base("Ice Beam", "Chilling beam of ice", 5, 1f, 1.5f, ETargetType.Enemy)
       {
       }
    }
}
