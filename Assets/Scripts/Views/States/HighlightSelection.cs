using System.Collections.Generic;
using HeroesOfDice;
using HeroesOfDice.Managers;
using UnityEngine;
using UnityEngine.UI;

public class HighlightSelection : BMenuState
{

    public GameObject catcher;

    public override void OnEnter()
    {
        catcher.SetActive(true);
        List<EntityPanel> panels = new List<EntityPanel>();

        panels.AddRange(MenuManager.Instance.PartyPanel);
        panels.AddRange(MenuManager.Instance.EnemyPanel);
        ETargetType abiltiesTargetType = CombatManager.Instance.Attacker.UpSide.Ability.TargetType;

        foreach (var panel in panels)
            if (panel.model.TargetType == abiltiesTargetType && !panel.model.IsDead)
            {
                panel.button.onClick.RemoveAllListeners();
                var panel1 = panel;
                panel.button.onClick.AddListener(() => MenuManager.Instance.MakeSelection(panel1.model));
                // If model is not a target type of ally, disable them
                // If they are, change the onClick of the panel to link to the CombatManager and set the model as the defender
            }
            else
            {
                panel.GetComponent<Image>().color = new Color(.2f, .2f, .2f);
                panel.button.interactable = false;
            }

    }


    public override void OnLeave()
    {
        catcher.SetActive(false);
        // Reset the panel
        List<EntityPanel> panels = new List<EntityPanel>();
        panels.AddRange(MenuManager.Instance.PartyPanel);
        panels.AddRange(MenuManager.Instance.EnemyPanel);

        foreach (var panel in panels)
        {
            panel.button.onClick.RemoveAllListeners();
            panel.button.onClick.AddListener(panel.Click);
            panel.button.interactable = true;
            panel.GetComponent<Image>().color = Color.white;
            // If model is not a target type of ally, disable them
            // If they are, change the onClick of the panel to link to the CombatManager and set the model as the defender
        }
    }
}
