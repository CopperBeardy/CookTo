using Bogus;
using CookTo.DataAccess.Documents.IngredientDocumentAccess;

namespace CookTo.Tests.Fakes;

public class IngredientDocumentFaker : Faker<IngredientDocument>
{
    public IngredientDocumentFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Name, f => f.Random.Word());
    }
}