using Bogus;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Tests.Fakes;

public class CookingStepFaker : Faker<CookingStep>
{
    public CookingStepFaker()
    {
        RuleFor(o => o.OrderNumber, f => f.Random.Number(1, 10));
        RuleFor(o => o.StepDescription, f => f.Random.Words());
        RuleFor(o => o.StepIngredients, new Faker<StepIngredient>().GenerateBetween(0, 10));
    }
}
