using UnityEngine;
using System.Collections;

public class DiceSide : MonoBehaviour
{
		[SerializeField]
		private string
				sideName;
		private Dice parentDice;

		// Use this for initialization
		void Start ()
		{
				parentDice = GetComponentInParent<Dice> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

//		void OnTriggerEnter (Collider collider)
//		{
//				if (!(collider is DiceSide))
//				if (collider.CompareTag ("Floor"))
//						parentDice.touchingSide = this;
//		}
//
//		void OnCollisionExit ()
//		{
//				parentDice.touchingSide = null;
//		}

}
