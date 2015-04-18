using HeroesOfDice;
using HeroesOfDice.Abilities;
using HeroesOfDice.Sides;

public class Warrior : BDice
{
    public Warrior(string name, int maxHealth, ETargetType targetType)
        : base(name, "Warrior", maxHealth, targetType)
    {
        Abilities[0] = new Regular(new Headbutt());
        Abilities[1] = new Armored(new Shieldslam(), 3);
        Abilities[2] = new Regular(new Slash());
        Abilities[3] = new Regular(new Kick());
        Abilities[4] = new Regular(new Tackle());
        Abilities[5] = new Vulnerable(new Bare("Back", "Your bare back"));

    }


}
