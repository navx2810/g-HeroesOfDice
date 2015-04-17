using HeroesOfDice.Managers;

namespace HeroesOfDice.Abilities
{
    public class Heal : BAbility
    {
        public Heal(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType)
            : base(name, description, power, baseModifier, critModifier, targetType)
        {
        }

        public Heal() : base("Heal", "Restore the health of an ally!", 4, 1f, 1.25f, ETargetType.Ally)
        {
        }

        public override void Use()
        {
            CombatManager.Instance.Defender.ModHealth(CalculatePower());
        }


    }
}
