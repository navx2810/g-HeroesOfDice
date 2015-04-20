using HeroesOfDice;
using HeroesOfDice.Managers;
using UnityEngine;

public class EmulateScenarioManager : MonoBehaviour {
    public void Awake()
    {

        BDice[] party = new BDice[3];
        party[0] = new Warrior("Max", 10, ETargetType.Ally);
        party[1] = new Cleric("Jason", 10, ETargetType.Ally);
        party[2] = new Sorcerer("Mike", 6, ETargetType.Ally);

        BDice[] enemy = new BDice[3];
        enemy[0] = new Warrior("Clara", 10, ETargetType.Enemy);
        enemy[1] = new Cleric("Mich", 8, ETargetType.Enemy);
        enemy[2] = new Sorcerer("Veela", 7, ETargetType.Enemy);

        party[0].CurrentHealth = 5;

        for (int x = 0; x < party.Length; x++)
        {
            party[x].DiceObject = CombatManager.Instance.PartyDiceObjects[x];
            party[x].DiceObject.diceModel = party[x];
            party[x].OnDead += party[x].DiceObject.OnDeath;
            enemy[x].DiceObject = CombatManager.Instance.EnemyDiceObjects[x];
            enemy[x].DiceObject.diceModel = enemy[x];
            enemy[x].OnDead += enemy[x].DiceObject.OnDeath;
        }

        CombatManager.Instance.PlayersParty = party;
        CombatManager.Instance.EnemyParty = enemy;

        MenuManager.Instance.CurrentState = MenuManager.Instance.States[0];

        TurnManager.Instance.AI = MenuManager.Instance.gameObject.AddComponent<EasyAI>();

    }
}
