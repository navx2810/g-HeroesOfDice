using System.Collections.Generic;
using HeroesOfDice.Managers;
using UnityEngine;

namespace HeroesOfDice
{
    public abstract class BAi : MonoBehaviour
    {
        public List<BDice> ThreatSheet { get; set; }
        public List<BDice> HelpSheet { get; set; }
        //public List<BDice> Party { get; set; }

        protected BAi()
        {
            ThreatSheet = new List<BDice>(CombatManager.Instance.PlayersParty);
            HelpSheet = new List<BDice>(CombatManager.Instance.EnemyParty);
            //Party = new List<BDice>(CombatManager.Instance.EnemyParty);                 // todo: this is redundant
        }

        public abstract void DoAction();
        public abstract void PopulateSheets();
    }
}

