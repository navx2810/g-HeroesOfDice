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
            if (!IsPlayersTurn)
            {
                Debug.Log("Enemies Turn over, Rerolling");
                Roll();
                if (TurnEnding != null) TurnEnding();
                MenuManager.Instance.DisplayMessage("Enemies turn ending", 2f);
                CombatManager.Instance.PlayerAbilities.Clear();
                CombatManager.Instance.EnemyAbilities.Clear();
                IsPlayersTurn = true;
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
            foreach(var dice in CombatManager.Instance.PlayersParty)
                dice.DiceObject.Roll();

            foreach(var dice in CombatManager.Instance.EnemyParty)
                dice.DiceObject.Roll();
        }

        public delegate void Notify();
        public event Notify TurnEnding;
    } 
}
