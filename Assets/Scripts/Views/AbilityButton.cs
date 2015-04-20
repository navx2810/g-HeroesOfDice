using HeroesOfDice;
using HeroesOfDice.Managers;
using JetBrains.Annotations;
using UnityEngine;
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
        button.interactable = (m.UpSide.Ability.TargetType != ETargetType.None && m.TargetType != ETargetType.Enemy);
        abilityName.text = m.UpSide.Ability.Name;
    }

    public void Click()
    {
        CombatManager.Instance.Attacker = model;
        MenuManager.Instance.CallHightlightSelection();
    }

    public void OnDisable()
    {
        TurnManager.Instance.TurnEnding -= Flush;
    }

    public void OnEnable()
    {
        TurnManager.Instance.TurnEnding += Flush;
    }


}
