using HeroesOfDice.Managers;

namespace HeroesOfDice.Abilities
{
    public class Punch : BAbility
    {
        public Punch(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
        {
        }

        public Punch() : base("Punch", "A powerful jab!", 3, 1f, 1.5f, ETargetType.Enemy)
        {
        }

        public override void Use()
        {
            CombatManager.Instance.Defender.BeAttacked(CalculatePower());
        }
    }
}
