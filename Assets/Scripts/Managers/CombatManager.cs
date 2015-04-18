using System.Collections.Generic;
using HeroesOfDice.GameObjects;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

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

        public void HightlightSelection()
        {
            ETargetType type = Attacker.UpSide.Ability.TargetType;
            // Cycle through all dice and highlight those who match this target type
        }
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
        }

        public delegate void NotifyChange(BDice dice);

        public event NotifyChange OnAbilityRegister;
        public event NotifyChange OnAbilityUnregister;
    }
}
