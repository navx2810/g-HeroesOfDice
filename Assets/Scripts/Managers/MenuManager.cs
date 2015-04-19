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
        private EntityPanel[] _partyPanel;

        public EntityPanel[] PartyPanel
        {
            get { return _partyPanel; }
            set { _partyPanel = value; }
        }

        [SerializeField]
        private EntityPanel[] _enemyPanel;
        public EntityPanel[] EnemyPanel
        {
            get { return _enemyPanel; }
            set { _enemyPanel = value; }
        }

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
            MoveToState(_states[3]);
        }

        public void CallGameScreen()
        {
            MoveToState(_states[0]);
        }

        public void MakeSelection(BDice model)
        {
            CallGameScreen();

            if (model.UpSide == null)
                return;

            CombatManager.Instance.Defender = model;
            CombatManager.Instance.Attacker.UseAbility();
        }
    }
}
