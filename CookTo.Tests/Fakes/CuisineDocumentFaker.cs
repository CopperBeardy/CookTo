using Bogus;
using CookTo.Server.Modules.Cuisines.Core;

namespace CookTo.Tests.Fakes;

public class CuisineDocumentFaker : Faker<CuisineDocument>
{
    public CuisineDocumentFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Text, f => f.Random.Word());
    }
}
