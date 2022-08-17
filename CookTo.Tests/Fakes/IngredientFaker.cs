using Bogus;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Tests.Fakes;

public class IngredientFaker : Faker<Ingredient>
{
    public IngredientFaker() { RuleFor(o => o.Name, f => f.Random.Word()); }
}