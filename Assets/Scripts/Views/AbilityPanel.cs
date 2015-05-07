using HeroesOfDice;
using HeroesOfDice.Managers;
using UnityEngine;

public class AbilityPanel : MonoBehaviour
{

    public AbilityButton[] buttons;
    public ETargetType panelType;


    // Use this for initialization
    public void Start()
    {
        //abilityButtons = GetComponentInChildren<RectTransform> ().GetComponentsInChildren<Button> ();
        //buttons = GetComponentInChildren<RectTransform>().GetComponentsInChildren<AbilityButton>();

        for (var x = 0; x < 3; x++)
        {
            if (panelType == ETargetType.Ally) // If this panel type is the player
                buttons[x].model = CombatManager.Instance.PlayersModels[x];
            else
                buttons[x].model = CombatManager.Instance.EnemysModels[x];
        }

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
        if (dice.TargetType == panelType)
            foreach (var b in buttons)
                if (b.model == dice)
                    b.SetModel(dice);

        //if (dice.TargetType == panelType)
        //    for (int x = 0; x < buttons.Length; x++)
        //        if (buttons[x].model == null || buttons[x].model == dice)
        //        {
        //            buttons[x].SetModel(dice);

        //            break;
        //        }
    }

    public void RemoveFromView(BDice dice)
    {
        if (dice.TargetType == panelType)
            foreach (var b in buttons)
                if (b.model == dice)
                    b.Flush();

        //for (int x = 0; x < buttons.Length; x++)
        //    if (buttons[x].model == dice)
        //    {
        //        buttons[x].Flush();
        //        break;
        //    }
    }


}
