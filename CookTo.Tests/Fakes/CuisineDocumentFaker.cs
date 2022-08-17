using Bogus;
using CookTo.DataAccess.Documents.CuisineDocumentAccess;

namespace CookTo.Tests.Fakes;

public class CuisineDocumentFaker : Faker<CuisineDocument>
{
    public CuisineDocumentFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Name, f => f.Random.Word());
    }
}
