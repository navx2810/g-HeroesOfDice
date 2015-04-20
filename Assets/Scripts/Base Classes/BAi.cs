using System.Collections.Generic;
using HeroesOfDice.Managers;
using UnityEngine;

namespace HeroesOfDice
{
    public abstract class BAi : MonoBehaviour
    {
        public BDice[] ThreatSheet { get; set; }
        public BDice[] HelpSheet { get; set; }
        public BDice[] Party { get; set; }

        protected BAi()
        {
            ThreatSheet = CombatManager.Instance.PlayersParty;
            HelpSheet = CombatManager.Instance.EnemyParty;
            Party = CombatManager.Instance.EnemyParty;
        }

        public abstract void DoAction();

    }
}

