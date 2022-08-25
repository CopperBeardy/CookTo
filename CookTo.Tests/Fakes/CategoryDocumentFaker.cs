using Bogus;
using CookTo.DataAccess.Documents.CategoryDocumentAccess;

namespace CookTo.Tests.Fakes;

public class CategoryDocumentFaker : Faker<CategoryDocument>
{
    public CategoryDocumentFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Name, f => f.Random.Word());
    }
}
