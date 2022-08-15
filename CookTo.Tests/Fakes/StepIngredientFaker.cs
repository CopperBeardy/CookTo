using Bogus;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Tests.Fakes;

public class StepIngredientFaker : Faker<StepIngredient>
{
    public string[] Measures = { "g", "l", "tsp", "pinch" };

    public StepIngredientFaker()
    {
        RuleFor(o => o.Quantity, f => f.Random.Number().ToString());
        RuleFor(o => o.Measure, f => f.PickRandom(Measures));
        RuleFor(o => o.Ingredient, f => f.Random.Word());
    }
}