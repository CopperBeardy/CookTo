using Bogus;
using CookTo.Server.Modules.Recipes.Core;

namespace CookTo.Tests.Fakes;

public class ShoppingItemDocumentFaker : Faker<ShoppingItemDocument>
{
    public string[] Measures = { "g", "l", "tsp", "pinch" };

    public ShoppingItemDocumentFaker()
    {
        RuleFor(o => o.Quantity, f => f.Random.Number().ToString());
        RuleFor(o => o.Measure, f => f.PickRandom(Measures));
        RuleFor(o => o.Ingredient, new IngredientDocumentFaker().Generate());
        RuleFor(o => o.AdditionalInformation, f => f.Random.Words());
        ;
    }
}
