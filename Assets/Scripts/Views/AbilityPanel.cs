using UnityEngine;
using UnityEngine.UI;

public class AbilityPanel : MonoBehaviour
{

    public Button[] abilityButtons;

		// Use this for initialization
		void Start ()
		{
				abilityButtons = GetComponentInChildren<RectTransform> ().GetComponentsInChildren<Button> ();
		}
}
