using Bogus;
using CookTo.Server.Modules.Utensils.Core;

namespace CookTo.Tests.Fakes;

public class UtensilDocumentFaker : Faker<UtensilDocument>
{
    public UtensilDocumentFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Text, f => f.Random.Word());
    }
}
