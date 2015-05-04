using HeroesOfDice.GameObjects;
using HeroesOfDice.Managers;
using UnityEngine;

namespace HeroesOfDice.Util
{
    [RequireComponent(typeof(Rigidbody))]
    public class CheckForNonCollision : MonoBehaviour
    {
        public Transform _tf;
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
            foreach (DiceSide side in dice.sides)
                if (Vector3.Dot(side.transform.forward, dice.floor.up) > .9f)
                {
                    dice.upSide = side;
                    break;
                }

            if (dice.upSide == null)
                dice.ShootUp();
            else
            {
                dice.diceModel.UpSide = dice.diceModel.Abilities[dice.upSide.Index];
                CombatManager.Instance.RegisterAbility(dice.diceModel);
                enabled = false;
            }
        }
    }
}
