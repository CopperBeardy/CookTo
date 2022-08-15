using Bogus;
using CookTo.Server.Modules.Recipes.Core;

namespace CookTo.Tests.Fakes;

public class UtensilPartDocumentFaker : Faker<UtensilPartDocument>
{
    public UtensilPartDocumentFaker()
    {
        RuleFor(o => o.RequiredAmount, f => f.Random.Number(0, 10));
        RuleFor(o => o.Utensil, new UtensilDocumentFaker().Generate());
    }
}
