using UnityEngine;
using System.Collections;
using System.Linq;
using HeroesOfDice;
using HeroesOfDice.Managers;
using JetBrains.Annotations;

public class EasyAI : BAi
{
    public override void DoAction()
    {
        //BDice dice = CombatManager.Instance.EnemyAbilities.First().Key;

        //CombatManager.Instance.Attacker = dice;

        //if (dice.TargetType == ETargetType.Enemy)
        //    CombatManager.Instance.Defender = ThreatSheet.Last().Key;
        //else if (dice.TargetType == ETargetType.Ally)
        //    CombatManager.Instance.Defender = HelpSheet.Last().Key;
        StartCoroutine(DoActions());
    }

    public override void PopulateSheets()
    {
        var players = CombatManager.Instance.PlayersParty;
        var enemies = CombatManager.Instance.EnemyParty;
        HelpSheet.Clear();
        ThreatSheet.Clear();

        foreach(var dice in players)
            if( !dice.IsDead )
                ThreatSheet.Add(dice);
        foreach(var dice in enemies)
            if( !dice.IsDead )
                HelpSheet.Add(dice);
    }

    IEnumerator DoActions()
    {
        for (var x = 0; x < 3; x++)
        {
            BDice dice = CombatManager.Instance.EnemyAbilities.Keys.First();
            PopulateSheets();
            CombatManager.Instance.Attacker = dice;

            if (dice.TargetType == ETargetType.Enemy)
                CombatManager.Instance.Defender = GetOpponent();
            else if (dice.TargetType == ETargetType.Ally)
                CombatManager.Instance.Defender = GetFriendly();

            CombatManager.Instance.Attacker.UseAbility();

            yield return new WaitForSeconds(1f + Random.Range(0f, 1f));

            if (CombatManager.Instance.EnemyAbilities.Count == 0)
                break;
        }

        TurnManager.Instance.EndTurn();

    }

    private BDice GetFriendly()
    {
        int count = Random.Range(0, 729) % ThreatSheet.Count;
        return HelpSheet[count];
    }

    private BDice GetOpponent()
    {
        int count = Random.Range(0, 729) % ThreatSheet.Count;
        return ThreatSheet[count];
    }
}
