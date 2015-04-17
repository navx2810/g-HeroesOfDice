using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using HeroesOfDice;
using HeroesOfDice.Managers;

public class AbilityPanel : MonoBehaviour
{

    public Button[] abilityButtons;

		// Use this for initialization
		void Start ()
		{
				abilityButtons = GetComponentInChildren<RectTransform> ().GetComponentsInChildren<Button> ();
		}
}
