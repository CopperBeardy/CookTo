using Bogus;
using CookTo.Shared.Models.ManageRecipes;

namespace CookTo.Tests.Fakes;

public class CookingStepFaker : Faker<CookingStep>
{
    public CookingStepFaker()
    {
        RuleFor(o => o.OrderNumber, f => f.Random.Number(1, 10));
        RuleFor(o => o.StepDescription, f => f.Random.Words());
        RuleFor(o => o.CookingStepIngredients, new Faker<CookingStepIngredient>().GenerateBetween(0, 10));
    }
}
