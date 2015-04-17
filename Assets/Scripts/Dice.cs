using HeroesOfDice.Util;
using UnityEngine;

namespace HeroesOfDice.GameObjects
{
    public class Dice : MonoBehaviour
    {

        public BDice diceModel;
        [SerializeField]
        public DiceSide[]
            sides;
        [SerializeField]
        public DiceSide
            touchingSide, upSide;
        private CheckForNonCollision collisionCheck;

        private Vector3 startingPosition;
        public Transform floor; 
	
        // Use this for initialization
        void Start ()
        {
            sides = GetComponentsInChildren<DiceSide> ();
            startingPosition = transform.position;
            collisionCheck = GetComponent<CheckForNonCollision> ();
            upSide = null;
            touchingSide = null;
            Roll ();
		
        }
	
        // Update is called once per frame
        void Update ()
        {
            if (Input.GetKeyUp (KeyCode.A)) {
                Roll ();
            } else if (Input.GetKeyUp (KeyCode.Space))
                ShootUp ();
						
        }

//		IEnumerator CheckSidesForCollision (float seconds)
//		{
//				yield return new WaitForSeconds (seconds);
//				Debug.Log ("Checking for dice sides");
//				if (rigidbody.velocity.magnitude == 0) {
//						if (touchingSide == null) {
//								StopAllCoroutines ();
//								StartCoroutine (CheckSidesForCollision (7f));
//						}
//				} else {
//						StopAllCoroutines ();
//						StartCoroutine (CheckSidesForCollision (5f));
//				}	
//		}

//		IEnumerator CheckSidesForCollision (float seconds)
//		{
//				yield return new WaitForSeconds (seconds);
//				if (rigidbody.velocity.magnitude == 0) {
//						if (touchingSide != null && Vector3.Dot (touchingSide.transform.forward, floor.up) <= -.99f)
//								foreach (DiceSide side in sides) {
//										if (Vector3.Dot (side.transform.forward, floor.up) >= .99f)
//												upSide = side;
//								}
//						else {
//								//Debug.Log (Vector3.Dot (touchingSide.transform.forward, floor.transform.up));
//								ShootUp ();
//								touchingSide = null;
//								StopCoroutine (CheckSidesForCollision (7f));
//								StartCoroutine (CheckSidesForCollision (7f));
//						}
//				}
//		}

        void Roll ()
        {
            transform.position = startingPosition;
            touchingSide = null;
            upSide = null;
            collisionCheck.enabled = true;
//				touchingSide = null;
//				upSide = null;
//				StopCoroutine (CheckSidesForCollision (7f));
//				StartCoroutine (CheckSidesForCollision (7f));
        }

        public void ShootUp ()
        {
            GetComponent<Rigidbody>().AddForce (Vector3.up * 500f);
            GetComponent<Rigidbody>().AddTorque (Vector3.right * 200f);
            touchingSide = null;
            upSide = null;
            collisionCheck.enabled = true;
        }


    }
}
