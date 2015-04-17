using UnityEngine;
using UnityEngine.UI;

public class AbilityPanel : MonoBehaviour
{

    public AbilityButton[] buttons;

		// Use this for initialization
		void Start ()
		{
                //abilityButtons = GetComponentInChildren<RectTransform> ().GetComponentsInChildren<Button> ();
		    buttons = GetComponentInChildren<RectTransform>().GetComponentsInChildren<AbilityButton>();
		}

    public void UpdateView()
    {
    }
}
