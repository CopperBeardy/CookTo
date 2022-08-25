using Bogus;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Tests.Fakes;

public class StepIngredientFaker : Faker<StepIngredient>
{
    public StepIngredientFaker()
    {
        RuleFor(o => o.Quantity, f => f.Random.Number().ToString());
        RuleFor(o => o.Measure, f => f.PickRandom(SharedGenerators.Measures));
        RuleFor(o => o.Ingredient, f => f.Random.Word());
    }
}