using HeroesOfDice;
using HeroesOfDice.Abilities;
using HeroesOfDice.Sides;

public class Cleric : BDice
{
    public Cleric(string name, int maxHealth, ETargetType targetType)
        : base(name, "Cleric", maxHealth, targetType)
    {
        Abilities[0] = new Regular(new Prayer());
        Abilities[1] = new Armored(new Shieldslam(), 3);
        Abilities[2] = new Regular(new Heal());
        Abilities[3] = new Evade(new Dodge(), 0.25f);
        Abilities[4] = new Armored(new Bare("Chest", "Bare Chest"), 3);
        Abilities[5] = new Vulnerable(new Bare("Back", "Your bare back"));
    }
}
