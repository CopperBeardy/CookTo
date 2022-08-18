using Bogus;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Tests.Fakes;

public class IngredientFaker : Faker<Ingredient>
{
    public IngredientFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Name, f => f.Random.Word());
    }
}