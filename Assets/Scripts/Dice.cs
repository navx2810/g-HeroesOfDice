using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour
{
		[SerializeField]
		private DiceSide[]
				sides;
		[SerializeField]
		public DiceSide
				touchingSide, upSide;

		private Vector3 startingPosition;
		public Transform floor; 
	
		// Use this for initialization
		void Start ()
		{
				sides = GetComponentsInChildren<DiceSide> ();
				startingPosition = transform.position;
				upSide = null;
				Roll ();
		
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.A)) {
						StopAllCoroutines ();
						Roll ();
				}
						
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

		IEnumerator CheckSidesForCollision (float seconds)
		{
				yield return new WaitForSeconds (seconds);
				if (rigidbody.velocity.magnitude == 0) {
						if (touchingSide != null && Vector3.Dot (touchingSide.transform.forward, floor.transform.up) <= -.99f)
								foreach (DiceSide side in sides) {
										if (Vector3.Dot (side.transform.forward, floor.transform.up) >= .99f)
												upSide = side;
								}
						else {
								//Debug.Log (Vector3.Dot (touchingSide.transform.forward, floor.transform.up));
								ShootUp ();
								touchingSide = null;
								StopCoroutine (CheckSidesForCollision (7f));
								StartCoroutine (CheckSidesForCollision (7f));
						}
				}
		}

		void Roll ()
		{
				transform.position = startingPosition;
				touchingSide = null;
				StopCoroutine (CheckSidesForCollision (7f));
				StartCoroutine (CheckSidesForCollision (7f));
		}

		public void ShootUp ()
		{
				rigidbody.AddForce (Vector3.up * 500f);
				rigidbody.AddTorque (Vector3.right * 200f);
		}


}
