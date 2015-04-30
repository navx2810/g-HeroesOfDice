namespace HeroesOfDice.Abilities
{
    public class Spring : BAbility
    {
        public Spring(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
        {
        }

        public Spring() : base("Spring", "Jump away from your opponent!", 0, 0f, 0f, ETargetType.None)
        {
        }

        public override void Use()
        {
            // TODO: Throw the dice into the air
        }
    }
}
