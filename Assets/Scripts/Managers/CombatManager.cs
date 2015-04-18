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

            HasAbility = new List<BDice>(6);
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

        public List<BDice> HasAbility { get; set; }

        public void ConfirmSelection()
        {
            // Link this function to the GUI
            // When the player selects a target a Checkmark or X will appear next to that to confirm
            // When the Checkmark is pressed, link to this function
            Attacker.UseAbility();
        }

        public void RegisterAbility(BDice dice)
        {
            HasAbility.Add(dice);
            OnAbilityRegister(dice);

            // TODO: add check to see if all abilities do not have the target type of None, otherwise the turn would end
            if (HasAbility.Count == PlayersParty.Length)
            {
                bool allNone = true;
                foreach (var d in HasAbility)
                    if (d.UpSide.Ability.TargetType != ETargetType.None)
                        allNone = false;
                if (allNone) { }
                    //End turn
            }
        }

        public void UnregisterAbility(BDice dice)
        {
            HasAbility.Remove(dice);
            OnAbilityUnregister(dice);
        }

        public delegate void NotifyChange(BDice dice);

        public event NotifyChange OnAbilityRegister;
        public event NotifyChange OnAbilityUnregister;
    }
}
