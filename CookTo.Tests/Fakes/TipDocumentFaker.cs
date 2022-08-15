using Bogus;
using CookTo.Server.Modules.Tips.Core;

namespace CookTo.Tests.Fakes;

public class TipDocumentFaker : Faker<TipDocument>
{
    public TipDocumentFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Description, f => f.Lorem.Sentence());
    }
}
