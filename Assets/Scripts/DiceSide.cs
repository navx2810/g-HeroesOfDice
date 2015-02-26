using UnityEngine;
using System.Collections;

public class DiceSide : MonoBehaviour
{
		[SerializeField]
		private string
				sideName;

		// Use this for initialization
		void Start ()
		{
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
