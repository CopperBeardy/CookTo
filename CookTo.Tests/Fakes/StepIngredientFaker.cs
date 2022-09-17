using Bogus;
using CookTo.Shared.Models.ManageRecipes;

namespace CookTo.Tests.Fakes;

public class StepIngredientFaker : Faker<CookingStepIngredient>
{
    public StepIngredientFaker()
    {
        RuleFor(o => o.Quantity, f => f.Random.Number().ToString());
        RuleFor(o => o.Measure, f => f.PickRandom(SharedGenerators.Measures));
        RuleFor(o => o.Ingredient, new IngredientFaker().Generate());
    }
}