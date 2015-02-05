using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour
{
		[SerializeField]
		private DiceSide[]
				sides;
		[SerializeField]
		public DiceSide
				touchingSide;

		private Vector3 startingPosition;
	
		// Use this for initialization
		void Start ()
		{
				sides = GetComponentsInChildren<DiceSide> ();
				startingPosition = transform.position;				// Until I can control this better
				Roll ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.A))
						Roll ();
		}

		IEnumerator CheckSidesForCollision (float seconds)
		{
				yield return new WaitForSeconds (seconds);
				Debug.Log ("Checking for dice sides");
				if (rigidbody.velocity.magnitude == 0) {
						if (touchingSide == null) {
								StopAllCoroutines ();
								StartCoroutine (CheckSidesForCollision (7f));
						}
				} else {
						rigidbody.AddForce (Vector3.up * 500f);
						rigidbody.AddTorque (Vector3.right * 200f);
						StopAllCoroutines ();
						StartCoroutine (CheckSidesForCollision (5f));
				}	
		}

		void Roll ()
		{
				transform.position = startingPosition;
				touchingSide = null;
				StopCoroutine (CheckSidesForCollision (7f));
				StartCoroutine (CheckSidesForCollision (7f));
		}

}
