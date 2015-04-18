namespace HeroesOfDice.Abilities
{
    public class LightningBolt : BaDamaging
    {
        public LightningBolt(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
        {
        }

        public LightningBolt()
            : base("Lightning Bolt", "Zap", 5, 1f, 1.5f, ETargetType.Enemy)
        {
        }

    }
}
