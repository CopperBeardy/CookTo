using Bogus;
using CookTo.Server.Modules.Recipes.Core;

namespace CookTo.Tests.Fakes;

public class CookingStepDocumentFaker : Faker<CookingStepDocument>
{
    public CookingStepDocumentFaker()
    {
        RuleFor(o => o.OrderNumber, f => f.Random.Number(1, 10));
        RuleFor(o => o.StepDescription, f => f.Random.Words());
        RuleFor(o => o.StepIngredients, new Faker<StepIngredientDocument>().GenerateBetween(0, 10));
    }
}
