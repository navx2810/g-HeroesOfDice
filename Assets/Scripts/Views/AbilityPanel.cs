using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AbilityPanel : MonoBehaviour
{

		public Button[] abilityButtons;

		// Use this for initialization
		void Start ()
		{
				abilityButtons = GetComponentInChildren<RectTransform> ().GetComponentsInChildren<Button> ();
		}
	
		public void hitAbility (Button button)
		{

		}
}
