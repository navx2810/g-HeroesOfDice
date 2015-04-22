using HeroesOfDice;
using HeroesOfDice.Managers;
using UnityEngine;

public class EmulateScenarioManager : MonoBehaviour
{
    public void Awake()
    {

        BDice[] party = new BDice[3];
        party[0] = new Warrior("Hiro", 10, ETargetType.Ally);
        party[1] = new Cleric("Jason", 10, ETargetType.Ally);
        party[2] = new Sorcerer("Harry", 6, ETargetType.Ally);

        BDice[] enemy = new BDice[3];
        enemy[0] = new GoblinWarrior("Snarlie", "Warrior", 8, ETargetType.Enemy);
        enemy[1] = new GoblinWarrior("Toothless", "Warrior", 8, ETargetType.Enemy);
        enemy[2] = new GoblinSorcerer("Wizzie", "Sorcerer", 5, ETargetType.Enemy);

        //for (int x = 0; x < 3; x++)
        //{
        //    party[x] = new AllNoneGuy("Nonnie Jim", "None guy", 10, ETargetType.Ally);
        //    enemy[x] = new AllNoneGuy("Nonnie Jane", "None guy", 10, ETargetType.Enemy);
        //}

        //party[0].CurrentHealth = 5;

        for (int x = 0; x < party.Length; x++)
        {
            party[x].DiceObject = CombatManager.Instance.PartyDiceObjects[x];
            party[x].DiceObject.diceModel = party[x];
            party[x].OnDead += party[x].DiceObject.OnDeath;
            party[x].OnDead += CombatManager.Instance.HandleDeath;
            enemy[x].DiceObject = CombatManager.Instance.EnemyDiceObjects[x];
            enemy[x].DiceObject.diceModel = enemy[x];
            enemy[x].OnDead += enemy[x].DiceObject.OnDeath;
            enemy[x].OnDead += CombatManager.Instance.HandleDeath;
        }

        CombatManager.Instance.PlayersModels = party;
        CombatManager.Instance.EnemysModels = enemy;
        CombatManager.Instance.ActivePlayerModels.AddRange(party);
        CombatManager.Instance.ActiveEnemyModels.AddRange(enemy);

        MenuManager.Instance.CurrentState = MenuManager.Instance.States[0];

        TurnManager.Instance.AI = MenuManager.Instance.gameObject.AddComponent<EasyAI>();

    }
}
