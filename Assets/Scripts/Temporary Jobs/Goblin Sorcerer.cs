using UnityEngine;
using System.Collections;
using HeroesOfDice;
using HeroesOfDice.Abilities;
using HeroesOfDice.Sides;

public class GoblinSorcerer : BDice {

    public GoblinSorcerer(string name, string job, int maxHealth, ETargetType targetType) : base(name, job, maxHealth, targetType)
    {
        Abilities[0] = new Vulnerable(new Bare("Head", "Your bare head"));
        Abilities[1] = new Regular(new IceBeam());
        Abilities[2] = new Regular(new LightningBolt());
        Abilities[3] = new Evade(new Spring(), 0.25f);
        Abilities[4] = new Vulnerable(new Bare("Chest", "Your bare chest"));
        Abilities[5] = new Vulnerable(new Bare("Back", "Your bare back"));
    }
}
