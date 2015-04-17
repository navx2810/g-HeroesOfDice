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

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                if (this != _instance)
                    Destroy(gameObject);
            }
        }

        public BDice Attacker { get; set; }
        public BDice Defender { get; set; }
        public BDice[] PlayersParty { get; set; }
        public BDice[] EnemyParty { get; set; }

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
    }
}
