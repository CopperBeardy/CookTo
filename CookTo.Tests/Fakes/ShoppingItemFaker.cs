using Bogus;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Tests.Fakes;

public class ShoppingItemFaker : Faker<ShoppingItem>
{
    public string[] Measures = { "g", "l", "tsp", "pinch" };

    public ShoppingItemFaker()
    {
        RuleFor(o => o.Quantity, f => f.Random.Number().ToString());
        RuleFor(o => o.Measure, f => f.PickRandom(Measures));
        RuleFor(o => o.Ingredient, new IngredientFaker().Generate());
        RuleFor(o => o.AdditionalInformation, f => f.Random.Words());
        ;
    }
}
