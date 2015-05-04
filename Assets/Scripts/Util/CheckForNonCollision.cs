using DG.Tweening;
using HeroesOfDice.GameObjects;
using HeroesOfDice.Managers;
using UnityEngine;

namespace HeroesOfDice.Util
{
    [RequireComponent(typeof(Rigidbody))]
    public class CheckForNonCollision : MonoBehaviour
    {
        public Transform _tf, RestPosition;
        public Vector3 oldPosition, newPosition, oldRotation, newRotation;
        public Dice dice;

        public void Awake()
        {
            dice = GetComponent<Dice>();
            _tf = transform;
        }

        public void FixedUpdate()
        {
            oldPosition = _tf.position;
            oldRotation = _tf.rotation.eulerAngles;
        }



        public void Update()
        {
            newPosition = _tf.position;
            newRotation = _tf.rotation.eulerAngles;

            if (oldPosition.Equals(newPosition) && oldRotation.Equals(newRotation))
                CheckSides();
        }

        void CheckSides()
        {
            //foreach (DiceSide side in dice.sides)
            //    if (Vector3.Dot(side.transform.forward, dice.floor.up) > .95f)
            //    {
            //        dice.upSide = side;
            //        MoveToRestPosition();
            //        break;
            //    }

            for (var x = 0; x < dice.sides.Length; x++)
                if (Vector3.Dot(dice.sides[x].transform.forward, dice.floor.up) > .95f)
                {
                    dice.upSide = dice.sides[x];                            // Dice sides are not really needed
                    dice.diceModel.UpSide = dice.diceModel.Abilities[x];
                    MoveToRestPosition();
                    break;
                }

            if (dice.upSide == null)
                dice.ShootUp();
            //else
            //{
            //    dice.diceModel.UpSide = dice.diceModel.Abilities[dice.upSide.Index];
            //    CombatManager.Instance.RegisterAbility(dice.diceModel);
            //    enabled = false;
            //}
        }

        private void MoveToRestPosition()
        {
            GetComponent<BoxCollider>().isTrigger = true;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.DOMove(RestPosition.position, 1f).OnComplete(OnRestPosition);
            enabled = false;
        }

        private void OnRestPosition()
        {
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().isKinematic = false;      // Turn this off before tweening so it won't fall during movement

            // Register that dice has ability with combat manager
            CombatManager.Instance.RegisterAbility(dice.diceModel);
        }
    }

}
