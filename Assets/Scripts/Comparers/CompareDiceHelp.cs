using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HeroesOfDice;

public class CompareDiceHelp : IComparer<BDice> {
    public int Compare(BDice x, BDice y)
    {
        return x.CurrentHealth - y.CurrentHealth;
    }
}
