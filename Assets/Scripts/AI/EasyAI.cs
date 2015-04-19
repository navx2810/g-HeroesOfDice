using UnityEngine;
using System.Collections;
using System.Linq;
using HeroesOfDice;
using HeroesOfDice.Managers;

public class EasyAI : BAi
{
    public override void DoAction()
    {
        BDice dice = CombatManager.Instance.EnemyAbilities.First().Key;

        CombatManager.Instance.Attacker = dice;

        if (dice.TargetType == ETargetType.Enemy)
            CombatManager.Instance.Defender = ThreatSheet.Last().Key;
        else if (dice.TargetType == ETargetType.Ally)
            CombatManager.Instance.Defender = HelpSheet.Last().Key;
    }
}
