using UnityEngine;
using System.Collections;
using HeroesOfDice;
using HeroesOfDice.Managers;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    public BDice model;
    public Button button;
    public Text abilityName;

    public void Start()
    {
        button.onClick.AddListener(Click);
    }

    public void Flush()
    {
        model = null;
        button.interactable = false;
        abilityName.text = "";

    }

    public void SetModel(BDice m)
    {
        model = m;
        button.interactable = true;
        abilityName.text = m.UpSide.Ability.Name;
    }

    public void Click()
    {
        CombatManager.Instance.Attacker = model;
        MenuManager.Instance.CallHightlightSelection();
    }
}
