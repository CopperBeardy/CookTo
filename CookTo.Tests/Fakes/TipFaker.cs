using Bogus;
using CookTo.Shared.Models.ManageTips;

namespace CookTo.Tests.Fakes;

public class TipFaker : Faker<Tip>
{
    public TipFaker()
    {
        RuleSet("New", set =>
        {
            set.RuleFor(o => o.Description, f => f.Random.Word());
        });
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Description, f => f.Lorem.Sentence());
    }
}
