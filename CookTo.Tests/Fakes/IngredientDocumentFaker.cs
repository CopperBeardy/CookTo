using Bogus;
using CookTo.Server.Modules.Ingredients.Core;

namespace CookTo.Tests.Fakes;

public class IngredientDocumentFaker : Faker<IngredientDocument>
{
    public IngredientDocumentFaker() { RuleFor(o => o.Text, f => f.Random.Word()); }
}