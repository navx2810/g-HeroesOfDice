using HeroesOfDice;
using HeroesOfDice.Managers;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPanel : MonoBehaviour
{

    public AbilityButton[] buttons;
    

    // Use this for initialization
    void Start()
    {
        //abilityButtons = GetComponentInChildren<RectTransform> ().GetComponentsInChildren<Button> ();
        buttons = GetComponentInChildren<RectTransform>().GetComponentsInChildren<AbilityButton>();
    }

    public void OnEnable()
    {
        CombatManager.Instance.OnAbilityRegister += AddToView;
        CombatManager.Instance.OnAbilityUnregister += RemoveFromView;
    }

    public void OnDisable()
    {
        CombatManager.Instance.OnAbilityRegister -= AddToView;
        CombatManager.Instance.OnAbilityUnregister -= RemoveFromView;
    }

    public void AddToView(BDice dice)
    {
        for(int x = 0; x < buttons.Length; x++)
            if (buttons[x].model == null)
            {
                buttons[x].SetModel(dice);
                break;
            }
    }

    public void RemoveFromView(BDice dice)
    {
        for(int x = 0; x < buttons.Length; x++)
            if (buttons[x].model == dice)
            {
                buttons[x].Flush();
                break;
            }
    }


}
