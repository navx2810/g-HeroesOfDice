using UnityEngine;
using System.Collections;
using DG.Tweening;
using HeroesOfDice;
using HeroesOfDice.GameObjects;
using HeroesOfDice.Managers;
using HeroesOfDice.Util;
using UnityEngine.UI;

public class BattleTweenScreen : BMenuState
{
    public GameObject TweenCatcher;
    public Transform AttackerPosition, DefenderPosition, SinglePosition, Attacker, Defender, AttackersRest, DefendersRest;
    public Rigidbody AttackersRB, DefendersRB;
    public BoxCollider AttackersBC, DefendersBC;

    public EntityShelf HeroShelf, EnemyShelf;

    private Vector3 attackerTempPos;

    public override void OnEnter()
    {
        HeroShelf.Hide();
        EnemyShelf.Hide();

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

        if (Attacker.Equals(Defender))
            Attacker.DOMove(SinglePosition.position, .5f).OnComplete(HandleSelfHeal);
        else if (CombatManager.Instance.Attacker.UpSide.Ability.TargetType == ETargetType.Enemy)
        {
            Attacker.DOMove(AttackerPosition.position, .5f);
            Defender.DOMove(DefenderPosition.position, .5f).OnComplete(StartAttack);
        }
        else
        {
            Attacker.DOMove(AttackerPosition.position, .5f);
            Defender.DOMove(DefenderPosition.position, .5f).OnComplete(StartHeal); 
        }
    }

    private void StartAttack()
    {
        attackerTempPos = Attacker.position;
        Attacker.DOMove(Defender.position, .1f).SetEase(Ease.InOutBounce).OnComplete(HandleAttack);
    }

    private void StartHeal()
    {
        attackerTempPos = Attacker.position;
        Attacker.DOMove(Attacker.position + AttackerPosition.up*1.5f, .2f).SetEase(Ease.InExpo).OnComplete(HandleHeal);
    
    }

    private void HandleAttack()
    {
        // TODO: Eventually, handle damaging the player here, but dont let the turn end until the animation is complete
        //CombatManager.Instance.Attacker.UseAbility();         
        Defender.DOShakeRotation(1f, 50).OnComplete(MoveBack);
        Attacker.DOMove(attackerTempPos, .2f).SetEase(Ease.InOutBack);

    }

    private void HandleSelfHeal()
    {
        Attacker.DOPunchRotation(AttackerPosition.up * 25f, .5f).OnComplete(MoveSingleBack);
    }

    private void HandleHeal()
    {
        Attacker.DOMove(attackerTempPos, .5f).SetEase(Ease.OutExpo);
        Defender.DOPunchRotation(DefenderPosition.up * 25f, .5f).OnComplete(MoveBack);
    }

    private void MoveSingleBack()
    {
        Attacker.DOMove(AttackersRest.position, .5f).OnComplete(MenuManager.Instance.CallGameScreen);
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

        HeroShelf.Show();
        EnemyShelf.Show();

        // TODO: Alert the TurnManager to check for end of turn instead of doing it in the combat manager? That way the tween will work effectively
    }
}
