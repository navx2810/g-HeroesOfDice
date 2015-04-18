using UnityEngine;

namespace HeroesOfDice.Sides
{
    public class Vulnerable : BSide
    {
        public Vulnerable(BAbility ability)
            : base(ability)
        {
        }

        public override void OnHit(int amount)
        {
            base.OnHit(Mathf.CeilToInt(amount * 1.5f));
        }
    }
}
