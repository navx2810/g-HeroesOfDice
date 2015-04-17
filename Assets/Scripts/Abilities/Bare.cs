namespace HeroesOfDice.Abilities
{
    public class Bare : BAbility
    {
        public Bare(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
        {
        }

        /// <summary>
        /// Constructor used for naming a bare side
        /// </summary>
        /// <param name="name">the name of the side</param>
        /// <param name="description">the flavor text of the side</param>
        public Bare(string name, string description) : base(name, description, 0, 0f, 0f, ETargetType.None)
        {
        }

        public Bare() : base("Bare", "an unequiped area", 0, 0f, 0f, ETargetType.None)
        {
        }

        public override void Use()
        {
        }
    }
}
