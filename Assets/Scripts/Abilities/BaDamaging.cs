using HeroesOfDice.Managers;

namespace HeroesOfDice.Abilities
{
    public abstract class BaDamaging : BAbility
    {
        protected BaDamaging(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
        {
        }

        public override void Use()
        {
            CombatManager.Instance.Defender.BeAttacked(CalculatePower());
        }
    }
}
