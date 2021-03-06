using HeroesOfDice;
using UnityEngine;

public class MenuScreen : BMenuState
{

    public GameObject catcher;

    public void Quit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public override void OnEnter()
    {
        catcher.SetActive(true);
    }

    public override void OnLeave()
    {
        catcher.SetActive(false);
    }
}
