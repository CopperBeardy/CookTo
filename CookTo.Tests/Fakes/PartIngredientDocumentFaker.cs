using Bogus;
using CookTo.DataAccess.Documents.RecipeDocumentAccess;

namespace CookTo.Tests.Fakes;

public class PartIngredientDocumentFaker : Faker<PartIngredientDocument>
{
    public PartIngredientDocumentFaker()
    {
        RuleFor(o => o.Quantity, f => f.Random.Number().ToString());
        RuleFor(o => o.Measure, f => f.PickRandom(SharedGenerators.Measures));
        RuleFor(o => o.Ingredient, new IngredientDocumentFaker().Generate());
        RuleFor(o => o.AdditionalInformation, f => f.Random.Words());
        ;
    }
}
