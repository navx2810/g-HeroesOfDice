using HeroesOfDice;
using HeroesOfDice.Managers;
using UnityEngine;

public class DicePanel : MonoBehaviour
{

    public EntityPanel[] entityPanel;
    public bool isPlayer;

    // Use this for initialization
    public void Awake()
    {
        entityPanel = GetComponentsInChildren<EntityPanel>();
    }

    public void Start()
    {
        BDice[] party;
        party = isPlayer ? CombatManager.Instance.PlayersParty : CombatManager.Instance.EnemyParty;
        for (int x = 0; x < party.Length; x++)
        {
            entityPanel[x].model = party[x];
            entityPanel[x].Init();
        }
    }

}
