using HeroesOfDice.Managers;

namespace HeroesOfDice.Abilities
{
    public class Prayer : BAbility
    {
        public Prayer(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType) : base(name, description, power, baseModifier, critModifier, targetType)
        {
        }

        public Prayer() : base("Prayer", "Heals! Heals for everyone!", 2, 1f, 1.15f, ETargetType.Ally) { }

        public override void Use()
        {
            BDice[] allies = CombatManager.Instance.PlayersParty;

            foreach (BDice dice in allies)
                dice.ModHealth(CalculatePower());
        }
    }
}
