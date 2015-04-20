using System;
using System.Collections.Generic;
using HeroesOfDice.GameObjects;
using UnityEngine;

namespace HeroesOfDice.Managers
{
    public class CombatManager : MonoBehaviour
    {
        private static CombatManager _instance;
        public static CombatManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<CombatManager>();
                    DontDestroyOnLoad(_instance.gameObject);
                }

                return _instance;
            }
        }

        public void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }
            else
                if (this != _instance)
                    Destroy(gameObject);

            PlayerAbilities = new Dictionary<BDice, BAbility>(3);
            EnemyAbilities = new Dictionary<BDice, BAbility>(3);
        }

        public BDice Attacker { get; set; }
        public BDice Defender { get; set; }
        public BDice[] PlayersParty { get; set; }
        public BDice[] EnemyParty { get; set; }

        [SerializeField]
        private Dice[] _partyDice;
        public Dice[] PartyDiceObjects
        {
            get { return _partyDice; }
            set { _partyDice = value; }
        }

        [SerializeField]
        private Dice[] _enemyDice;
        public Dice[] EnemyDiceObjects
        {
            get { return _enemyDice; }
            set { _enemyDice = value; }
        }

        public Dictionary<BDice, BAbility> PlayerAbilities { get; set; }
        public Dictionary<BDice, BAbility> EnemyAbilities { get; set; }

        public void ConfirmSelection()
        {
            // Link this function to the GUI
            // When the player selects a target a Checkmark or X will appear next to that to confirm
            // When the Checkmark is pressed, link to this function
            Attacker.UseAbility();
        }

        public void RegisterAbility(BDice dice)
        {
            if (dice.UpSide.Ability.TargetType != ETargetType.None)
                if (dice.TargetType == ETargetType.Ally)
                    PlayerAbilities.Add(dice, dice.UpSide.Ability);
                else
                    EnemyAbilities.Add(dice, dice.UpSide.Ability);
            
            if (OnAbilityRegister != null) OnAbilityRegister(dice);

            // TODO: add check to see if all abilities do not have the target type of None, otherwise the turn would end
            if (PlayerAbilities.Count == PlayersParty.Length)
            {
                bool allNone = true;
                foreach (var d in PlayerAbilities)
                    if (d.Key.TargetType == ETargetType.Ally)
                        if (d.Value.TargetType != ETargetType.None)
                            allNone = false;
                if (allNone)
                    Debug.Log("No usable abilities, ending turn");
            }
        }

        public void UnregisterAbility(BDice dice)
        {
            PlayerAbilities.Remove(dice);
            if (OnAbilityUnregister != null) OnAbilityUnregister(dice);

            Debug.Log("[--- What is left over ---]");
            foreach (var key in PlayerAbilities)
                Debug.Log(String.Format("{0} : {1}", key.Key.Name, key.Value.Name));

            // Problem here is that dice does not look to see who is an ally or not

            if ( TurnManager.Instance.IsPlayersTurn & PlayerAbilities.Count == 0)
                TurnManager.Instance.EndTurn();
        }

        public delegate void NotifyChange(BDice dice);
        
        public event NotifyChange OnAbilityRegister;
        public event NotifyChange OnAbilityUnregister;

        public void HandleDeath(BDice dice)
        {
            UnregisterAbility(dice);
        }
    }
}
