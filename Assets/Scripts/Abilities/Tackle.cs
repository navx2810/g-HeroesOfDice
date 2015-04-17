namespace HeroesOfDice.Abilities
{
    public class Tackle :BaDamaging
    {
        public Tackle(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
        {
        }

        public Tackle() : base("Tackle", "Player used Tackle!", 3, 1f, 1.25f, ETargetType.Enemy)
        {
        }
    }
}
