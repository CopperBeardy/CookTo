using Bogus;
using CookTo.DataAccess.Documents.UtensilDocumentAccess;

namespace CookTo.Tests.Fakes;

public class UtensilDocumentFaker : Faker<UtensilDocument>
{
    public UtensilDocumentFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Name, f => f.Random.Word());
    }
}
