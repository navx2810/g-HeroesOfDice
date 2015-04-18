using HeroesOfDice.GameObjects;
using HeroesOfDice.Managers;
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

        public Dice DiceObject { get; set; }

        public BDice(string name, string job, int maxHealth, ETargetType targetType)
        {
            Name = name;
            Job = job;
            MaxHealth = maxHealth;
            TargetType = targetType;
            Abilities = new BSide[6];
            CurrentHealth = maxHealth;
        }

        public void UseAbility() { UpSide.OnUse(); CombatManager.Instance.UnregisterAbility(this); }
        public void BeAttacked(int amount) { UpSide.OnHit(amount); }
        public void ModHealth(int amount)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
            if (OnHealthChange != null) OnHealthChange(this);
            IsDead();
        }

        public delegate void NotifyChange(BDice dice);
        public event NotifyChange OnHealthChange;
        public event NotifyChange OnDead;

        public bool IsDead()
        {
            if (CurrentHealth > 0)
                return false;
            if (OnDead != null) OnDead(this);
            return true;
        }
    }
}
