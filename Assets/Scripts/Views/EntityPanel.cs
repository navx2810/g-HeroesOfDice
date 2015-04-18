using HeroesOfDice;
using HeroesOfDice.Managers;
using UnityEngine;
using UnityEngine.UI;

public class EntityPanel : MonoBehaviour
{
    public BDice model;
    public Text nameLabel;
    public Slider healthBar;
    public Button button;

    public void OnHealthChange()
    {
        healthBar.value = model.CurrentHealth;
    }

    public void Init()
    {
        button.onClick.AddListener(Click);
        nameLabel.text = model.Name;
        healthBar.maxValue = model.MaxHealth;
        healthBar.minValue = 0;
        healthBar.value = model.CurrentHealth;
    }

    public void Click()
    {
        MenuManager.Instance.SelectedModel = model;
        MenuManager.Instance.CallDiceViewOpen();
    }

}
