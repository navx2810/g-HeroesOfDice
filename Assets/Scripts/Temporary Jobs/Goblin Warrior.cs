using UnityEngine;
using System.Collections;
using HeroesOfDice;
using HeroesOfDice.Abilities;
using HeroesOfDice.Sides;

public class GoblinWarrior : BDice {

    public GoblinWarrior(string name, string job, int maxHealth, ETargetType targetType) : base(name, job, maxHealth, targetType)
    {
        Abilities[0] = new Regular(new Headbutt());
        Abilities[1] = new Regular(new Punch());
        Abilities[2] = new Regular(new Slash());
        Abilities[3] = new Regular(new Kick());
        Abilities[4] = new Regular(new Tackle());
        Abilities[5] = new Vulnerable(new Bare("Back", "Your bare back"));
    }
}
