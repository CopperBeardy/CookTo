using Bogus;
using CookTo.Shared.Models.ManageRecipes;

namespace CookTo.Tests.Fakes;

public class UtensilPartFaker : Faker<UtensilPart>
{
    public UtensilPartFaker()
    {
        RuleFor(o => o.RequiredAmount, f => f.Random.Number(0, 10));
        RuleFor(o => o.Utensil, new UtensilFaker().Generate());
    }
}
