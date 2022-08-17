using Bogus;
using CookTo.DataAccess.Documents.RecipeDocumentAccess;

namespace CookTo.Tests.Fakes;

public class StepIngredientDocumentFaker : Faker<StepIngredientDocument>
{
    public StepIngredientDocumentFaker()
    {
        RuleFor(o => o.Quantity, f => f.Random.Number().ToString());
        RuleFor(o => o.Measure, f => f.PickRandom(SharedGenerators.Measures));
        RuleFor(o => o.Ingredient, f => f.Random.Word());
    }
}