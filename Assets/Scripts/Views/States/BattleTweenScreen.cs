using UnityEngine;
using System.Collections;
using DG.Tweening;
using HeroesOfDice;
using HeroesOfDice.GameObjects;
using HeroesOfDice.Managers;
using HeroesOfDice.Util;

public class BattleTweenScreen : BMenuState
{
    public GameObject TweenCatcher;
    public Transform AttackerPosition, DefenderPosition, Attacker, Defender, AttackersRest, DefendersRest;
    public Rigidbody AttackersRB, DefendersRB;
    public BoxCollider AttackersBC, DefendersBC;

    private Vector3 attackerTempPos;

    public override void OnEnter()
    {
        TweenCatcher.SetActive(true);
        Attacker = CombatManager.Instance.Attacker.DiceObject.transform;
        Defender = CombatManager.Instance.Defender.DiceObject.transform;

        AttackersRB = Attacker.GetComponent<Rigidbody>();
        DefendersRB = Defender.GetComponent<Rigidbody>();

        AttackersBC = Attacker.GetComponent<BoxCollider>();
        DefendersBC = Defender.GetComponent<BoxCollider>();

        AttackersRB.isKinematic = true;
        DefendersRB.isKinematic = true;

        AttackersBC.isTrigger = true;
        DefendersBC.isTrigger = true;

        AttackersRest = Attacker.GetComponent<CheckForNonCollision>().RestPosition;
        DefendersRest = Defender.GetComponent<CheckForNonCollision>().RestPosition;

        Attacker.DOMove(AttackerPosition.position, .5f);
        Defender.DOMove(DefenderPosition.position, .5f).OnComplete(StartAttack);
    }

    private void StartAttack()
    {
        attackerTempPos = Attacker.position;
        Attacker.DOMove(Defender.position, .1f).OnComplete(HandleAttack);
    }

    private void HandleAttack()
    {
        // TODO: Eventually, handle damaging the player here, but dont let the turn end until the animation is complete
        //CombatManager.Instance.Attacker.UseAbility();         
        Defender.DOShakeRotation(1f, 50).OnComplete(MoveBack);
        Attacker.DOMove(attackerTempPos, .2f);

    }

    private void MoveBack()
    {
        Attacker.DOMove(AttackersRest.position, .5f);
        Defender.DOMove(DefendersRest.position, .5f).OnComplete(MenuManager.Instance.CallGameScreen);
    }

    public override void OnLeave()
    {
        CombatManager.Instance.Attacker.UseAbility();

        AttackersBC.isTrigger = false;
        DefendersBC.isTrigger = false;

        AttackersRB.isKinematic = false;
        DefendersRB.isKinematic = false;

        TweenCatcher.SetActive(false);

        // TODO: Alert the TurnManager to check for end of turn instead of doing it in the combat manager? That way the tween will work effectively
    }
}
