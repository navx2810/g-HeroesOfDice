using UnityEngine;

namespace HeroesOfDice.Sides
{
    public class Evade : BSide
    {
        public float EvadeChance { get; set; }
        public Evade(BAbility ability, float evadeChance)
            : base(ability)
        {
            EvadeChance = evadeChance;
        }

        public override void OnHit(int amount)
        {
            if (Random.Range(0f, 1f) > EvadeChance)
                base.OnHit(amount);

        }
    }
}
