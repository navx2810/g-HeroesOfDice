using UnityEngine;
using UnityEngine.UI;

namespace HeroesOfDice
{
    public abstract class BAbility
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int Power { get; set; }
        public float BaseModifier { get; set; }
        public float CritModifier { get; set; }
        public ETargetType TargetType { get; set; }
        public Image Icon { get; set; }

        protected BAbility(string name, string description, int power, float baseModifier, float critModifier, ETargetType targetType)
        {
            Name = name;
            Description = description;
            Power = power;
            CritModifier = critModifier;
            BaseModifier = baseModifier;
            TargetType = targetType;
        }

        public int CalculatePower()
        {
            return Mathf.CeilToInt(Power * BaseModifier);
        }

        public abstract void Use();
    }
}
