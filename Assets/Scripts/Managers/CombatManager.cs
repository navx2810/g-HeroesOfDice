using System;
using System.Collections;
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

            ActivePlayerModels = new List<BDice>();
            ActiveEnemyModels = new List<BDice>();

        }

        public BDice Attacker { get; set; }
        public BDice Defender { get; set; }
        public BDice[] PlayersModels { get; set; }
        public BDice[] EnemysModels { get; set; }

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

        public bool IsGameOver { get; set; }

        public List<BDice> ActivePlayerModels { get; set; }
        public List<BDice> ActiveEnemyModels { get; set; } 
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
            //if (dice.UpSide.Ability.TargetType != ETargetType.None)
                if (dice.TargetType == ETargetType.Ally)
                {
                    if (PlayerAbilities.ContainsKey(dice)) UnregisterAbility(dice);
                    PlayerAbilities.Add(dice, dice.UpSide.Ability);
                }
                else
                {
                    if(EnemyAbilities.ContainsKey(dice)) UnregisterAbility(dice);
                    EnemyAbilities.Add(dice, dice.UpSide.Ability);
                }

            if (OnAbilityRegister != null) OnAbilityRegister(dice);

            // TODO: add check to see if all abilities do not have the target type of None, otherwise the turn would end
            if (TurnManager.Instance.IsPlayersTurn)
            {
                if (PlayerAbilities.Count == ActivePlayerModels.Count)
                {
                    var count = 0;

                    foreach (var d in ActivePlayerModels)
                        if (d.UpSide != null && d.UpSide.Ability.TargetType == ETargetType.None)
                            count ++;

                    if (count == ActivePlayerModels.Count)
                        TurnManager.Instance.EndTurn();
                    
                }

                //bool isAllEmpty = true;
                //bool isMissingAny = false;

                //foreach (var d in PlayersModels)
                //    if (!isAllEmpty || isMissingAny)
                //        break;
                //    else if (d.UpSide != null && d.UpSide.Ability.TargetType != ETargetType.None)
                //        isAllEmpty = false;
                //    else if (d.UpSide == null)
                //        isMissingAny = true;

                //if(isAllEmpty & !isMissingAny) TurnManager.Instance.EndTurn();
            }
        }

        public void UnregisterAbility(BDice dice)
        {
            if (IsGameOver)
                return;

            PlayerAbilities.Remove(dice);
            if (OnAbilityUnregister != null) OnAbilityUnregister(dice);

            Debug.Log("[--- What is left over ---]");
            foreach (var key in PlayerAbilities)
                Debug.Log(String.Format("{0} : {1}", key.Key.Name, key.Value.Name));

            if (TurnManager.Instance.IsPlayersTurn)
            {
                var count = 0;
                foreach (var x in PlayerAbilities)
                {
                    if (x.Value.TargetType == ETargetType.None)
                        count ++;
                }

                if (count == PlayerAbilities.Count)
                    TurnManager.Instance.EndTurn();
            }

            //if ( TurnManager.Instance.IsPlayersTurn & PlayerAbilities.Count == 0)
            //    TurnManager.Instance.EndTurn();
        }

        public delegate void NotifyChange(BDice dice);
        
        public event NotifyChange OnAbilityRegister;
        public event NotifyChange OnAbilityUnregister;

        public void HandleDeath(BDice dice)
        {
            UnregisterAbility(dice);
            if (dice.TargetType == ETargetType.Ally)
            {
                ActivePlayerModels.Remove(dice);
                PlayerAbilities.Remove(dice);
            }
            else if (dice.TargetType == ETargetType.Enemy)
            {
                ActiveEnemyModels.Remove(dice);
                EnemyAbilities.Remove(dice);
            }

            if (ActivePlayerModels.Count == 0)
            {
                IsGameOver = true;
                MenuManager.Instance.DisplayEndGameMessage("You Lost");
            }
            else if (ActiveEnemyModels.Count == 0)
            {
                IsGameOver = true;
                MenuManager.Instance.DisplayEndGameMessage("You Won!");
            }
        }
         
    }
}
