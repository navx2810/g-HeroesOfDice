using System.Collections.Generic;
using HeroesOfDice.Managers;

namespace HeroesOfDice
{
    public abstract class BAi
    {
        public SortedDictionary<BDice, int> ThreatSheet { get; set; }
        public SortedDictionary<BDice, int> HelpSheet { get; set; }
        public BDice[] Party { get; set; }

        protected BAi()
        {
            ThreatSheet = new SortedDictionary<BDice, int>();
            HelpSheet = new SortedDictionary<BDice, int>();
            Party = CombatManager.Instance.EnemyParty;
        }

        public abstract void DoAction();

    }
}

