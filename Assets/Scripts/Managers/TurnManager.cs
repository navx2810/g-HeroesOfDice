using System;
using UnityEngine;
using System.Collections;

namespace HeroesOfDice.Managers
{
    public class TurnManager : MonoBehaviour
    {
        private static TurnManager _instance;
        public static TurnManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<TurnManager>();
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

            IsPlayersTurn = true;
        }

        public bool IsPlayersTurn { get; set; }

        public BAi AI { get; set; }

        public void EndTurn()
        {
            if (CombatManager.Instance.IsGameOver)
                return;

            if (!IsPlayersTurn)
            {
                if (CombatManager.Instance.EnemyAbilities.Keys.Count > 0)
                {
                    foreach (var d in CombatManager.Instance.EnemyAbilities.Keys)
                        Debug.LogErrorFormat("{0} still has ability: {1}, target type of {2}", d.Name,
                            d.UpSide.Ability.Name, d.UpSide.Ability.TargetType);
                    //throw new Exception("You done fucked up, There shouldn't be abilities left");
                    AI.StopAllCoroutines();
                    AI.IsPerforming = false;
                    AI.DoAction();
                }
                else
                {
                    AI.StopAllCoroutines();
                    Roll();
                    if (TurnEnding != null) TurnEnding();
                    MenuManager.Instance.DisplayMessage("Enemies turn ending", 2f);
                    CombatManager.Instance.PlayerAbilities.Clear();
                    CombatManager.Instance.EnemyAbilities.Clear();
                    IsPlayersTurn = true;
                }
            }
            else
            {

                MenuManager.Instance.DisplayMessage("Player's turn ending", 2f);
                IsPlayersTurn = false;
                AI.DoAction();
            }
        }

        private void Roll()
        {
            foreach(var dice in CombatManager.Instance.ActivePlayerModels)
                dice.DiceObject.Roll();

            foreach(var dice in CombatManager.Instance.ActiveEnemyModels)
                dice.DiceObject.Roll();
        }

        public delegate void Notify();
        public event Notify TurnEnding;
    } 
}
