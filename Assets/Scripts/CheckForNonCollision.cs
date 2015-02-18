using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CheckForNonCollision : MonoBehaviour
{
		public Rigidbody _rigidbody;
		public Dice dice;

		void Awake ()
		{
				_rigidbody = GetComponent<Rigidbody> ();
				dice = GetComponent<Dice> ();
		}
	
		void Update ()
		{
				if (_rigidbody.velocity.magnitude <= 0) {
						CheckSides ();		
						this.enabled = false;
				}
		}

		void CheckSides ()
		{
				foreach (DiceSide side in dice.sides)
						if (Vector3.Dot (side.transform.forward, dice.floor.up) <= -.99f)
								dice.touchingSide = side;
						else if (Vector3.Dot (side.transform.forward, dice.floor.up) >= .99f)
								dice.upSide = side;
						
				if (dice.upSide == null)
						dice.ShootUp ();
		}
}
