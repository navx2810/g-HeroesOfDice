using UnityEngine;

namespace HeroesOfDice.Managers
{
    public class MenuManager : MonoBehaviour
    {
        private static MenuManager _instance;
        public static MenuManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<MenuManager>();
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
            {
                if (this != _instance)
                    Destroy(gameObject);
            }
        }

        public BMenuState CurrentState { get; set; }
        public BDice SelectedModel { get; set; }

        [SerializeField]
        private BMenuState[] _states;
        public BMenuState[] States
        {
            get { return _states; }
            set { _states = value; }
        }

        [SerializeField]
        private EntityPanel[] _partyPanel, _enemyPanel;

        [SerializeField]
        private Color _newColor;

        public void MoveToState(BMenuState state)
        {
            CurrentState.OnLeave();
            CurrentState.gameObject.SetActive(false);
            CurrentState = state;
            CurrentState.gameObject.SetActive(true);
            CurrentState.OnEnter();
        }
        public void MoveToState(int stateIndex)
        {
            MoveToState(_states[stateIndex]);
        }

        // TODO: turn these into events and delegates so buttons can bind to them
        public void CallMenuOpen()
        {
            MoveToState(_states[1]);
        }

        public void CallDiceViewOpen()
        {
            MoveToState(_states[2]);
        }

        public void CallHightlightSelection()
        {
            if (CombatManager.Instance.Attacker.UpSide.Ability.TargetType == ETargetType.Ally)
            {
                foreach (var panel in _partyPanel)
                    if (panel.model.TargetType == ETargetType.Ally)
                    {
                        // If model is not a target type of ally, disable them
                        // If they are, change the onClick of the panel to link to the CombatManager and set the model as the defender
                    }
            }
            else
            {
                foreach (var panel in _enemyPanel)
                {
                    // If model is not a target type of ally, disable them
                    // If they are, change the onClick of the panel to link to the CombatManager and set the model as the defender
                }
            }

        }

        public void CallGameScreen()
        {
            MoveToState(_states[0]);
        }
    }
}
