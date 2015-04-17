using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using HeroesOfDice;
using HeroesOfDice.Managers;

public class DiceViewPanel : BMenuState
{
    public GameObject catcher;
    public Text nameText, jobText, healthInfoText;
    public Slider healthSlider;
    public AbilityInfo[] abilityViews;

    public override void OnEnter()
    {
       var model = MenuManager.Instance.SelectedModel;

        catcher.SetActive(true);
        nameText.text = model.Name;
        jobText.text = model.Job;
        healthInfoText.text = String.Format("{0} / {1}", model.CurrentHealth, model.MaxHealth);
        healthSlider.maxValue = model.MaxHealth;
        healthSlider.value = model.CurrentHealth;
        for (int x = 0; x < model.Abilities.Length; x++)
        {
            abilityViews[x].AbilityName = model.Abilities[x].Ability.Name;
            abilityViews[x].AbilityDescription = model.Abilities[x].Ability.Description;
        }
    }

    public override void OnLeave()
    {
        catcher.SetActive(false);
    }
}
