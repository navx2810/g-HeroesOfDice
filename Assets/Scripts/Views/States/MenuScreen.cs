using HeroesOfDice;
using UnityEngine;

public class MenuScreen : BMenuState
{

    public GameObject catcher;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Quit()
    {
        Application.Quit();
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
