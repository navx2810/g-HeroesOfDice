using UnityEngine;
using System.Collections;
using HeroesOfDice;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    public BDice model;
    public Button button;
    public Text abilityName;

    public void Flush()
    {
        model = null;
    }

    public void SetModel(BDice model)
    {
        this.model = model;
        abilityName.text = model.UpSide.Ability.Name;
    }
}
