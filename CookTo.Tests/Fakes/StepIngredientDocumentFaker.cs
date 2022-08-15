using Bogus;
using CookTo.Server.Modules.Recipes.Core;

namespace CookTo.Tests.Fakes;

public class StepIngredientDocumentFaker : Faker<StepIngredientDocument>
{
    public string[] Measures = { "g", "l", "tsp", "pinch" };

    public StepIngredientDocumentFaker()
    {
        RuleFor(o => o.Quantity, f => f.Random.Number().ToString());
        RuleFor(o => o.Measure, f => f.PickRandom(Measures));
        RuleFor(o => o.Ingredient, f => f.Random.Word());
    }
}