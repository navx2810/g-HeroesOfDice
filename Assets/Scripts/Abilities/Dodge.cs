namespace HeroesOfDice.Abilities
{
    public class Dodge : BAbility
    {
        public Dodge(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
        {
        }

        public Dodge() : base("Dodge", "Avoid the enemy's attacks!", 0, 0f, 0f, ETargetType.None)
        {
        }

        public override void Use()
        {
            
        }
    }
}
