using Bogus;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Tests.Fakes;

public class PartIngredientFaker : Faker<RecipePartIngredient>
{
    public PartIngredientFaker()
    {
        RuleFor(o => o.Quantity, f => f.Random.Number().ToString());
        RuleFor(o => o.Measure, f => f.PickRandom(SharedGenerators.Measures));
        RuleFor(o => o.Ingredient, new IngredientFaker().Generate());
        RuleFor(o => o.AdditionalInformation, f => f.Random.Words());
    }
}
