using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AbilityInfo : MonoBehaviour
{

    public Image icon;
    public Text[] texts;

    public string AbilityName
    {
        get { return texts[0].text; }
        set { texts[0].text = value; }
    }

    public string AbilityDescription
    {
        get { return texts[1].text; }
        set { texts[1].text = value; }
    }
}
