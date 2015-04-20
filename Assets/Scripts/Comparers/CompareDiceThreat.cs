using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HeroesOfDice;

public class CompareDiceThreat : IComparer<BDice>
{
    // Use Y before X to make this list go from highest -> lowest
    public int Compare(BDice x, BDice y)
    {
       return y.UpSide.Ability.CalculatePower() - x.UpSide.Ability.CalculatePower();
    }
}
