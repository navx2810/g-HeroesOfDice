namespace HeroesOfDice.Abilities
{
    public class Kick : BaDamaging
    {
        public Kick(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
        {
        }

        public Kick() : base("Kick", "A movement of the legs!", 5, 1f, 1.25f, ETargetType.Enemy)
        {
        }
    }
}
