using HeroesOfDice;
using HeroesOfDice.Abilities;
using HeroesOfDice.Sides;

public class Sorcerer : BDice
{
    public Sorcerer(string name, int maxHealth, ETargetType targetType)
        : base(name, "Sorcerer", maxHealth, targetType)
    {
        Abilities[0] = new Regular(new DragonsBreath());
        Abilities[1] = new Regular(new IceBeam());
        Abilities[2] = new Regular(new LightningBolt());
        Abilities[3] = new Evade(new Spring(), 0.25f);
        Abilities[4] = new Vulnerable(new Bare("Chest", "Your bare chest"));
        Abilities[5] = new Vulnerable(new Bare("Back", "Your bare back"));
    }
}
