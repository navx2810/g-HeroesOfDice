using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using HeroesOfDice;
using HeroesOfDice.Managers;
using Random = UnityEngine.Random;

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

        if (!IsPerforming) StartCoroutine(DoActions());
    }

    public override void PopulateSheets()
    {
        var players = CombatManager.Instance.ActivePlayerModels;
        var enemies = CombatManager.Instance.ActiveEnemyModels;
        HelpSheet.Clear();
        ThreatSheet.Clear();

        foreach(var dice in players)
            if( !dice.IsDead )
                ThreatSheet.Add(dice);
        foreach(var dice in enemies)
            if( !dice.IsDead )
                HelpSheet.Add(dice);

        ThreatSheet.Sort(new CompareDiceThreat());
        HelpSheet.Sort(new CompareDiceHelp());
    }

   public IEnumerator DoActions()
    {
        IsPerforming = true;
        yield return new WaitForSeconds(1f);
        //while (CombatManager.Instance.EnemyAbilities.Count > 0)
        for (var x = 0; x < 3; x++)
        {
            while(MenuManager.Instance.IsTweening)
                yield return new WaitForSeconds(1f);

            if (CombatManager.Instance.EnemyAbilities.Count == 0)
                break;

            BDice dice = CombatManager.Instance.EnemyAbilities.Keys.First();

            if (dice.UpSide.Ability.TargetType == ETargetType.None)
            {
                CombatManager.Instance.EnemyAbilities.Remove(dice);
                break;
            }

            CombatManager.Instance.EnemyAbilities.Remove(dice);
            PopulateSheets();
            CombatManager.Instance.Attacker = dice;

            if (dice.UpSide.Ability.TargetType == ETargetType.Enemy)
                CombatManager.Instance.Defender = GetOpponent();
            else if (dice.UpSide.Ability.TargetType == ETargetType.Ally)
                CombatManager.Instance.Defender = GetFriendly();

            MenuManager.Instance.DisplayMessage(String.Format("{0} uses {1} against {2}", dice.Name, dice.UpSide.Ability.Name, CombatManager.Instance.Defender.Name), 1.5f);
           
            MenuManager.Instance.MoveToState(4);
            //CombatManager.Instance.Attacker.UseAbility();

            yield return new WaitForSeconds(2f + Random.Range(0f, 1f));

            //if (CombatManager.Instance.EnemyAbilities.Count == 0)
            //    break;
        }

        TurnManager.Instance.EndTurn();
        IsPerforming = false;

    }

    private BDice GetFriendly()
    {
        int count = Random.Range(0, 729) % HelpSheet.Count;
        return HelpSheet[count];
    }

    private BDice GetOpponent()
    {
        int count = Random.Range(0, 729) % ThreatSheet.Count;
        return ThreatSheet[count];
    }
}
