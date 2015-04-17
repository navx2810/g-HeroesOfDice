using UnityEngine;

namespace HeroesOfDice
{
    public class BDice
    {
        public BSide UpSide { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public BSide[] Abilities { get; set; }
        public ETargetType TargetType { get; set; }

        /// <summary>
        /// Base Dice class
        /// </summary>
        /// <param name="name">the name of the dice</param>
        /// <param name="job">the job "class" of the dice</param>
        /// <param name="maxHealth">the maximum health for the dice</param>
        /// <param name="targetType">the target type of the dice</param>
        public BDice(string name, string job, int maxHealth, ETargetType targetType)
        {
            Name = name;
            Job = job;
            MaxHealth = maxHealth;
            TargetType = targetType;
            Abilities = new BSide[6];
            CurrentHealth = maxHealth;
        }

        /// <summary>
        /// the method for using the UpSides ability. This stands for both an attack or a usability ability like 'Heal'
        /// </summary>
        public void UseAbility() { UpSide.OnUse(); }
        public void BeAttacked(int amount) { UpSide.OnHit(amount); }

        /// <summary>
        /// the method for modifying the dice's current health.
        /// </summary>
        /// <param name="amount">the amount the current health will be modified by. The value can be negative denoting this was an attack.</param>
        public void ModHealth(int amount)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
            IsDead();
        }

        public bool IsDead()
        {
            return (CurrentHealth == 0) ? true : false;
        }
    }
}
