namespace HeroesOfDice.Abilities
{
    public class Headbutt : BaDamaging
    {
        public Headbutt(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
        {
        }

        public Headbutt() : base("Headbutt", "A swift bash with the noggin.", 1, 1f, 1.5f, ETargetType.Enemy)
        {
        }
    }
}
