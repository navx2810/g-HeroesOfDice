using HeroesOfDice;
using HeroesOfDice.Abilities;
using HeroesOfDice.Sides;

public class AllNoneGuy : BDice {
    public AllNoneGuy(string name, string job, int maxHealth, ETargetType targetType) : base(name, job, maxHealth, targetType)
    {
       for(int x = 0; x < 6; x++)
           Abilities[x] = new Regular(new Bare());
    }
}
